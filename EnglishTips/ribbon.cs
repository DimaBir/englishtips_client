using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using System.Web.Script.Serialization;

using VerbsAPI;
using WordinessAPI;
using NounsAPI;
using UncountableNoun;
using RESTApiExample;

namespace EnglishTips
{
    public partial class ribbon
    {
        private void Coloring_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void checkBox3_Click(object sender, RibbonControlEventArgs e)
        {

        }


        private void checkBox4_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void checkBox2_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            // Get current selection
            Word.Range selection = Globals.ThisAddIn.Application.Selection.Range;

            // If selection is empty - read entire document
            if (selection.Text == null)
            {
                selection = Globals.ThisAddIn.Application.ActiveDocument.Content;
            }

            SayAloud.Say(text: selection.Text);
        }

        private void toggleButton1_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.TranslateCustomTaskPane.Visible ^= true;
        }

        private void toggleButton2_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void Coloring_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.ColoringCustomTaskPane.Visible ^= true;
        }
    }
}
