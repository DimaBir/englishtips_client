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
        public UserControlColoring userControlColoring;
        public UserControlSynonyms userControlSynonyms;

        internal Microsoft.Office.Tools.CustomTaskPane TranslateCustomTaskPane;
        internal Microsoft.Office.Tools.CustomTaskPane ColoringCustomTaskPane;
        internal Microsoft.Office.Tools.CustomTaskPane SynonymsCustomTaskPane;

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
            ColoringCustomTaskPane.VisibleChanged += new EventHandler(ColoringCustomTaskPane_VisibleChanged);
            ColoringCustomTaskPane.Width = 335;// userControlTranslate.Width;

            // Initialize SynonymsCustomTaskPane
            userControlSynonyms = new UserControlSynonyms();
            //userControlTranslate.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            SynonymsCustomTaskPane = this.CustomTaskPanes.Add(userControlSynonyms, "Synonyms");
            SynonymsCustomTaskPane.Visible = false;
            SynonymsCustomTaskPane.VisibleChanged += new EventHandler(SynonymsCustomTaskPane_VisibleChanged);
            SynonymsCustomTaskPane.Width = 335;// userControlTranslate.Width;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void TranslateCustomTaskPane_VisibleChanged(object sender, System.EventArgs e)
        {
            Globals.Ribbons.Coloring.Translate.Checked = TranslateCustomTaskPane.Visible;
        }

        private void ColoringCustomTaskPane_VisibleChanged(object sender, System.EventArgs e)
        {
            Globals.Ribbons.Coloring.Coloring.Checked = ColoringCustomTaskPane.Visible;
        }

        private void SynonymsCustomTaskPane_VisibleChanged(object sender, System.EventArgs e)
        {
            Globals.Ribbons.Coloring.Synonyms.Checked = SynonymsCustomTaskPane.Visible;
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
