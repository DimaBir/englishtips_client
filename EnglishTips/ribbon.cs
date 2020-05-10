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

        private void button4_Click(object sender, RibbonControlEventArgs e)
        {
            // Store all coloring actions in a single record
            Word.UndoRecord recordObj = Globals.ThisAddIn.Application.UndoRecord;
            recordObj.StartCustomRecord("");

            // Remove existing underline
            Remove_underline();

            var activeDocument = Globals.ThisAddIn.Application.ActiveDocument;
            string text_to_check = activeDocument.Range(activeDocument.Content.Start, activeDocument.Content.End).Text;

            // Creates custom json
            // JSON body:
            // "text": (string)"Text you wanna to check for verbs"
            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });
            string api = "https://englishtips.azurewebsites.net/api/verbs2";

            // Sends created json to the server:
            // returns: Dictionary - that contains verbs and their indexes in sended text:
            //      string = verb itself,
            //      List<int> - list of indexes of verb in the text
            List<VerbsResponse> response =
                GenericSender<List<VerbsResponse>>.Send(json, api: api, "POST");

            // Print out verbs.
            foreach (VerbsResponse verbObject in response)
            {
                //Console.Write($"Verb: '{verbObject.Verb}' - Length: {verbObject.VerbLength} - Index: ");
                foreach (int index in verbObject.Indexes)
                {
                    Word.Range rng = Globals.ThisAddIn.Application.ActiveDocument.Range(index, index + verbObject.VerbLength);
                    rng.Font.Underline = Word.WdUnderline.wdUnderlineThick;
                    rng.Font.UnderlineColor = Word.WdColor.wdColorRed;
                }
            }

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
            //Word.Range rng = Globals.ThisAddIn.Application.ActiveDocument.Words[1];
            //rng.Text = "New Text";
            //rng.Font.ColorIndex = Word.WdColorIndex.wdRed;
            //rng.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineSingle;

            //rng.Font.Underline = Microsoft.Office.Interop.Word.WdUnderline.wdUnderlineThick;
            //rng.Font.UnderlineColor = Microsoft.Office.Interop.Word.WdColor.wdColorRed;
            //Globals.ThisAddIn.Application.ActiveDocument.UndoClear();

            // End coloring record
            recordObj.EndCustomRecord();
        }

        void Remove_underline()
        {
            Word.Range range = Globals.ThisAddIn.Application.ActiveDocument.Content;
            Remove_underline(range, Word.WdColor.wdColorRed.GetHashCode());
            //Remove_underline(range, 32769);
            //Remove_underline(range, 16711681);
        }
        void Remove_underline(Word.Range range, int colorIndex)
        {
            range.Find.ClearFormatting();
            range.Find.Replacement.ClearFormatting();
            range.Find.Text = "";
            range.Find.Font.UnderlineColor = (Word.WdColor)colorIndex;
            range.Find.Font.Underline = Word.WdUnderline.wdUnderlineThick;
            range.Find.Replacement.Text = "";
            range.Find.Replacement.Font.Underline = Word.WdUnderline.wdUnderlineNone;
            range.Find.Execute(Format: true, Replace: Word.WdReplace.wdReplaceAll);

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
    }
}
