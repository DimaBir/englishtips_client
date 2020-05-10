using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;


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

        private void button4_Click(object sender, RibbonControlEventArgs e)
        {
            // Store all coloring actions in a single record
            Word.UndoRecord recordObj = Globals.ThisAddIn.Application.UndoRecord;
            recordObj.StartCustomRecord("");

            // Underline first word
            /*(Word.Document myDocument = Globals.ThisAddIn.Application.ActiveDocument;
            foreach (Word.Paragraph paragraph in myDocument.Paragraphs)
            {
                string pText = paragraph.Range.Text;
                System.Diagnostics.Debug.WriteLine(pText);

                Word.InlineShapes shapes = paragraph.Range.InlineShapes;
                System.Diagnostics.Debug.WriteLine("Shape Count: " + shapes.Count);
            }*/

            //Word.Range rng = Globals.ThisAddIn.Application.ActiveDocument.Range(0, 1);
            //rng.Text = "New Text";

            // Change first word
            Word.Range rng = Globals.ThisAddIn.Application.ActiveDocument.Words[1];
            //rng.Text = "New Text";
            //rng.Font.ColorIndex = Word.WdColorIndex.wdRed;
            //rng.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;

            rng.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineThick;
            rng.Font.UnderlineColor = Microsoft.Office.Interop.Word.WdColor.wdColorRed;
            //Globals.ThisAddIn.Application.ActiveDocument.UndoClear();

            // End coloring record
            recordObj.EndCustomRecord();
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
    }
}
