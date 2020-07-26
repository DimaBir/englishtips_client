using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;

namespace EnglishTips
{
    public partial class ThisAddIn
    {
        private UserControlTranslate userControlTranslate;
        private UserControlColoring userControlColoring;
        internal Microsoft.Office.Tools.CustomTaskPane TranslateCustomTaskPane;
        internal Microsoft.Office.Tools.CustomTaskPane ColoringCustomTaskPane;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            // Initialize TranslateCustomTaskPane
            userControlTranslate = new UserControlTranslate();
            //userControlTranslate.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            TranslateCustomTaskPane = this.CustomTaskPanes.Add(userControlTranslate, "Translate");
            TranslateCustomTaskPane.Visible = false;
            TranslateCustomTaskPane.VisibleChanged += new EventHandler(TranslateCustomTaskPane_VisibleChanged);
            TranslateCustomTaskPane.Width = 335;// userControlTranslate.Width;

            // Initialize ColoringCustomTaskPane
            userControlColoring = new UserControlColoring();
            //userControlTranslate.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ColoringCustomTaskPane = this.CustomTaskPanes.Add(userControlColoring, "Coloring");
            ColoringCustomTaskPane.Visible = false;
            ColoringCustomTaskPane.VisibleChanged += new EventHandler(TranslateCustomTaskPane_VisibleChanged);
            ColoringCustomTaskPane.Width = 335;// userControlTranslate.Width;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void TranslateCustomTaskPane_VisibleChanged(object sender, System.EventArgs e)
        {
            Globals.Ribbons.Coloring.toggleButton1.Checked = TranslateCustomTaskPane.Visible;
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
