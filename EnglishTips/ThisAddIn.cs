using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace EnglishTips
{
    public partial class ThisAddIn
    {
        public class TaskPanes
        {
            public Microsoft.Office.Tools.CustomTaskPane MarkTaskPane;
            public Microsoft.Office.Tools.CustomTaskPane TranslateTaskPane;
            public Microsoft.Office.Tools.CustomTaskPane SynonymsTaskPane;
            public Microsoft.Office.Tools.CustomTaskPane TipsTaskPane;
        }

        public Dictionary<Microsoft.Office.Interop.Word.Window, TaskPanes> TaskPanesDictionary;

        // NOTE: We need a backing field to prevent the delegate being garbage collected
        private SafeNativeMethods.HookProc _mouseProc;
        private SafeNativeMethods.HookProc _keyboardProc;

        private IntPtr _hookIdMouse;
        private IntPtr _hookIdKeyboard;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            TaskPanesDictionary = new Dictionary<Microsoft.Office.Interop.Word.Window, TaskPanes>();

            //Application.DocumentBeforeClose += DestroyTaskPaneWrapper;
            Application.DocumentOpen += CreateTaskPaneWrapper;
            ((ApplicationEvents4_Event)Application).NewDocument += CreateTaskPaneWrapper;
            Application.WindowActivate += UpdateRibbon;

            try
            {
                Word.Document doc = this.Application.ActiveDocument;
                if (String.IsNullOrWhiteSpace(doc.Path))
                {
                    //logger.Debug(String.Format("Word initialized with new document: {0}.", doc.FullName));
                    CreateTaskPaneWrapper(doc);
                }
                else
                {
                    //logger.Debug(String.Format("Word initialized with existing document: {0}.", doc.FullName));
                    CreateTaskPaneWrapper(doc);
                }
            }
            catch (COMException)
            {
                //logger.Debug("No document loaded with word.");
            }

            _mouseProc = MouseHookCallback;
            _keyboardProc = KeyboardHookCallback;

            SetWindowsHooks();
        }

        void updateTips()
        {
            bool hasValue = TaskPanesDictionary.TryGetValue(getActiveWindow(), out TaskPanes tp);
            if (hasValue)
            {
                if (Globals.Ribbons.Coloring.Tips.Checked)
                {
                    ((UserControlTips)tp.TipsTaskPane.Control).updateTips();
                }
            }
            else
            {
                //CreateTaskPaneWrapper();
            }
        }

        void ThisDocument_SelectionChange(object sender, Microsoft.Office.Tools.Word.SelectionEventArgs e)
        {
            updateTips();
        }

        private void OnShutdown(object sender, EventArgs eventArgs)
        {
            UnhookWindowsHooks(); // TODO: check placement

            if (Globals.ThisAddIn.Application.Documents.Count == 0)
            {
                return;
            }

            bool hasValue = TaskPanesDictionary.TryGetValue(getActiveWindow(), out TaskPanes tp);
            if (hasValue)
            {
                //TaskPanesDictionary.Remove(getVSTODocument());
                RemoveOrphanedWindowsFromDictionary();
                RemoveOrphanedTaskPanes();
            }
        }

       private void RemoveOrphanedTaskPanes()
        {
            for (int i = Globals.ThisAddIn.CustomTaskPanes.Count; i > 0; i--)
            {
                Microsoft.Office.Tools.CustomTaskPane ctp = Globals.ThisAddIn.CustomTaskPanes[i - 1];
                if (ctp.Control.IsDisposed || ctp.Window == null)
                {
                    this.CustomTaskPanes.Remove(ctp);
                }
            }
        }

        private void RemoveOrphanedWindowsFromDictionary()
        {
            var OrphanedWindows = new List<Window>();
            foreach (KeyValuePair<Window, TaskPanes> entry in TaskPanesDictionary)
            {
                bool found = false;

                foreach (Window window in Application.Windows)
                {
                    if (window == entry.Key)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    OrphanedWindows.Add(entry.Key);
                }            
            }

            foreach (Window window in OrphanedWindows)
            {
                TaskPanesDictionary.Remove(window);
            }            
        }

        private void DestroyTaskPaneWrapper(Word.Document Doc, ref bool Cancel)
        {
            bool hasValue = TaskPanesDictionary.TryGetValue(getActiveWindow(), out TaskPanes tp);
            if (hasValue)
            {
                //TaskPanesDictionary.Remove(getVSTODocument());
            }
        }

        public Window getActiveWindow()
        {
            Window result;
            try
            {
                result = Globals.ThisAddIn.Application.ActiveDocument.ActiveWindow;
            }
            catch
            {
                result = null;
            }
            return result;
        }

        public void CreateTaskPaneWrapper(Word.Document Doc = null)
        {
            Window window = getActiveWindow();

            if (window == null || TaskPanesDictionary.ContainsKey(window))
            {
                return;
            }

            Microsoft.Office.Interop.Word.Document nativeDocument = Globals.ThisAddIn.Application.ActiveDocument;
            //Globals.Factory.GetVstoObject(nativeDocument).Shutdown += OnShutdown;
            Globals.Factory.GetVstoObject(nativeDocument).Disposed += OnShutdown;

            Microsoft.Office.Tools.Word.Document vstoDoc = Globals.Factory.GetVstoObject(this.Application.ActiveDocument);
            vstoDoc.SelectionChange += new Microsoft.Office.Tools.Word.SelectionEventHandler(ThisDocument_SelectionChange);

            UserControlMark userControlMark = new UserControlMark();
            Microsoft.Office.Tools.CustomTaskPane MarkTaskPane = this.CustomTaskPanes.Add(userControlMark, "Mark");
            MarkTaskPane.Visible = false;
            MarkTaskPane.VisibleChanged += new EventHandler(ColoringCustomTaskPane_VisibleChanged);
            MarkTaskPane.Width = 335;

            UserControlTranslate userControlTranslate = new UserControlTranslate();
            Microsoft.Office.Tools.CustomTaskPane TranslateTaskPane = this.CustomTaskPanes.Add(userControlTranslate, "Translate");
            TranslateTaskPane.Visible = false;
            TranslateTaskPane.VisibleChanged += new EventHandler(TranslateCustomTaskPane_VisibleChanged);
            TranslateTaskPane.Width = 335;

            UserControlSynonyms userControlSynonyms = new UserControlSynonyms();
            Microsoft.Office.Tools.CustomTaskPane SynonymsTaskPane = this.CustomTaskPanes.Add(userControlSynonyms, "Synonyms");
            SynonymsTaskPane.Visible = false;
            SynonymsTaskPane.VisibleChanged += new EventHandler(SynonymsCustomTaskPane_VisibleChanged);
            SynonymsTaskPane.Width = 335;

            UserControlTips userControlTips = new UserControlTips();
            Microsoft.Office.Tools.CustomTaskPane TipsTaskPane = this.CustomTaskPanes.Add(userControlTips, "Tips");
            TipsTaskPane.Visible = false;
            TipsTaskPane.VisibleChanged += new EventHandler(TipsCustomTaskPane_VisibleChanged);
            TipsTaskPane.Width = 335;

            TaskPanes tp = new TaskPanes();
            tp.MarkTaskPane = MarkTaskPane;
            tp.TranslateTaskPane = TranslateTaskPane;
            tp.SynonymsTaskPane = SynonymsTaskPane;
            tp.TipsTaskPane = TipsTaskPane;

            // Save userControlColoring with current window
            TaskPanesDictionary.Add(window, tp);

            UpdateRibbon();
        }

        private void UpdateRibbon(Word.Document Doc = null, Window Wn = null)
        {
            bool hasValue = TaskPanesDictionary.TryGetValue(getActiveWindow(), out TaskPanes tp);
            if (hasValue)
            {
                Globals.Ribbons.Coloring.Translate.Checked = tp.TranslateTaskPane.Visible;
                Globals.Ribbons.Coloring.Mark.Checked = tp.MarkTaskPane.Visible;
                Globals.Ribbons.Coloring.Synonyms.Checked = tp.SynonymsTaskPane.Visible;
                Globals.Ribbons.Coloring.Tips.Checked = tp.TipsTaskPane.Visible;
            }
            else
            {
                //CreateTaskPaneWrapper();
            }
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void visibleChanged()
        {
            Window window = getActiveWindow();
            if (window != null)
            {
                bool hasValue = TaskPanesDictionary.TryGetValue(window, out TaskPanes tp);
                if (hasValue)
                {
                    Globals.Ribbons.Coloring.Mark.Checked = tp.MarkTaskPane.Visible;
                    Globals.Ribbons.Coloring.Translate.Checked = tp.TranslateTaskPane.Visible;
                    Globals.Ribbons.Coloring.Synonyms.Checked = tp.SynonymsTaskPane.Visible;
                    Globals.Ribbons.Coloring.Tips.Checked = tp.TipsTaskPane.Visible;
                }
            }
        }

        private void TranslateCustomTaskPane_VisibleChanged(object sender, System.EventArgs e)
        {
            visibleChanged();
        }

        private void ColoringCustomTaskPane_VisibleChanged(object sender, System.EventArgs e)
        {
            visibleChanged();
        }

        private void SynonymsCustomTaskPane_VisibleChanged(object sender, System.EventArgs e)
        {
            visibleChanged();
        }

        private void TipsCustomTaskPane_VisibleChanged(object sender, System.EventArgs e)
        {
            visibleChanged();
        }

        private void SetWindowsHooks()
        {
            uint threadId = (uint)SafeNativeMethods.GetCurrentThreadId();

            _hookIdMouse =
                SafeNativeMethods.SetWindowsHookEx(
                    (int)SafeNativeMethods.HookType.WH_MOUSE,
                    _mouseProc,
                    IntPtr.Zero,
                    threadId);

            _hookIdKeyboard =
                SafeNativeMethods.SetWindowsHookEx(
                    (int)SafeNativeMethods.HookType.WH_KEYBOARD,
                    _keyboardProc,
                    IntPtr.Zero,
                    threadId);
        }

        private void UnhookWindowsHooks()
        {
            SafeNativeMethods.UnhookWindowsHookEx(_hookIdKeyboard);
            SafeNativeMethods.UnhookWindowsHookEx(_hookIdMouse);
        }

        private IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var mouseHookStruct =
                    (SafeNativeMethods.MouseHookStructEx)
                        Marshal.PtrToStructure(lParam, typeof(SafeNativeMethods.MouseHookStructEx));

                // handle mouse message here
                var message = (SafeNativeMethods.WindowMessages)wParam;
                Debug.WriteLine(
                    "{0} event detected at position {1} - {2}",
                    message,
                    mouseHookStruct.pt.X,
                    mouseHookStruct.pt.Y);
            }
            return SafeNativeMethods.CallNextHookEx(
                _hookIdKeyboard,
                nCode,
                wParam,
                lParam);
        }

        private IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            // Feel free to move the const to a private field.
            const int HC_ACTION = 0;
            if (nCode == HC_ACTION)
            {
                Keys key = (Keys)wParam;
                KeyEventArgs args = new KeyEventArgs(key);

                bool isKeyDown = ((ulong)lParam & 0x40000000) == 0;
                if (isKeyDown)
                {
                    //onKeyDown(args);
                }
                else
                {
                    bool isLastKeyUp = ((ulong)lParam & 0x80000000) == 0x80000000;
                    if (isLastKeyUp)
                    {
                        //onKeyUp(args);
                        StringBuilder charPressed = new StringBuilder(256);
                        ToUnicode((uint)key, 0, new byte[256], charPressed, charPressed.Capacity, 0);
                        string str = charPressed.ToString();

                        //if (str == " " || str == "." || str == "," || str == ";" || str == "?" || str == ")")
                        updateTips();
                    }
                }
            }

            return SafeNativeMethods.CallNextHookEx(
                _hookIdKeyboard,
                nCode,
                wParam,
                lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int ToUnicode(
            uint virtualKeyCode,
            uint scanCode,
            byte[] keyboardState,
            StringBuilder receivingBuffer,
            int bufferSize,
            uint flags
        );

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }

    internal static class SafeNativeMethods
    {
        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        public enum HookType
        {
            WH_KEYBOARD = 2,
            WH_MOUSE = 7
        }

        public enum WindowMessages : uint
        {
            WM_KEYDOWN = 0x0100,
            WM_KEYFIRST = 0x0100,
            WM_KEYLAST = 0x0108,
            WM_KEYUP = 0x0101,
            WM_LBUTTONDBLCLK = 0x0203,
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MBUTTONDBLCLK = 0x0209,
            WM_MBUTTONDOWN = 0x0207,
            WM_MBUTTONUP = 0x0208,
            WM_MOUSEACTIVATE = 0x0021,
            WM_MOUSEFIRST = 0x0200,
            WM_MOUSEHOVER = 0x02A1,
            WM_MOUSELAST = 0x020D,
            WM_MOUSELEAVE = 0x02A3,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_MOUSEHWHEEL = 0x020E,
            WM_RBUTTONDBLCLK = 0x0206,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            WM_SYSDEADCHAR = 0x0107,
            WM_SYSKEYDOWN = 0x0104,
            WM_SYSKEYUP = 0x0105
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(
            int idHook,
            HookProc lpfn,
            IntPtr hMod,
            uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(
            IntPtr hhk,
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetCurrentThreadId();

        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public static implicit operator System.Drawing.Point(Point p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator Point(System.Drawing.Point p)
            {
                return new Point(p.X, p.Y);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseHookStructEx
        {
            public Point pt;
            public IntPtr hwnd;
            public uint wHitTestCode;
            public IntPtr dwExtraInfo;
            public int MouseData;
        }
    }
}
