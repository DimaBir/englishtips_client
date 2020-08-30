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

namespace EnglishTips
{
    public partial class ThisAddIn
    {
        public class TaskPanes
        {
            public Microsoft.Office.Tools.CustomTaskPane MarkTaskPane;
            public Microsoft.Office.Tools.CustomTaskPane TranslateTaskPane;
            public Microsoft.Office.Tools.CustomTaskPane SynonymsTaskPane;
        }

        public Dictionary<Microsoft.Office.Interop.Word.Window, TaskPanes> TaskPanesDictionary;

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
        }

        private void OnShutdown(object sender, EventArgs eventArgs)
        {
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

            TaskPanes tp = new TaskPanes();
            tp.MarkTaskPane = MarkTaskPane;
            tp.TranslateTaskPane = TranslateTaskPane;
            tp.SynonymsTaskPane = SynonymsTaskPane;

            // Save userControlColoring with current window
            TaskPanesDictionary.Add(window, tp);
        }

        private void UpdateRibbon(Word.Document Doc, Window Wn)
        {
            bool hasValue = TaskPanesDictionary.TryGetValue(getActiveWindow(), out TaskPanes tp);
            if (hasValue)
            {
                Globals.Ribbons.Coloring.Translate.Checked = tp.TranslateTaskPane.Visible;
                Globals.Ribbons.Coloring.Mark.Checked = tp.MarkTaskPane.Visible;
                Globals.Ribbons.Coloring.Synonyms.Checked = tp.SynonymsTaskPane.Visible;
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
}
