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

        private void button4_Click(object sender, RibbonControlEventArgs e)
        {
            // Store all coloring actions in a single record
            Word.UndoRecord recordObj = Globals.ThisAddIn.Application.UndoRecord;
            recordObj.StartCustomRecord("");

            // Remove existing underline
            Remove_underline();

            Color_wordiness();
            Color_verbs();
            Color_noun_compound();
            Color_uncountable_nouns();

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

        void Color_wordiness()
        {
            var activeDocument = Globals.ThisAddIn.Application.ActiveDocument;
            string text_to_check = activeDocument.Range(activeDocument.Content.Start, activeDocument.Content.End).Text;

            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });
            string api = "https://englishtips.azurewebsites.net/api/wordiness";

            // Send request
            WordinessResponse response = GenericSender<WordinessResponse>.Send(json, api: api, "POST");

            foreach (WordinessResponse.WordinessData match in response.Results)
            {
                //Console.Write($"Wordiness: '{match.Wordiness}' Length: {match.Length} Indexes: ");
                foreach (int index in match.Indexes)
                {
                    Console.Write($"{index}, ");
                    Word.Range rng = Globals.ThisAddIn.Application.ActiveDocument.Range(index, index + match.Length);
                    rng.Font.Underline = Word.WdUnderline.wdUnderlineThick;
                    rng.Font.UnderlineColor = Word.WdColor.wdColorBlue;
                }
            }
        }

        void Color_verbs()
        {
            var activeDocument = Globals.ThisAddIn.Application.ActiveDocument;
            string text_to_check = activeDocument.Range(activeDocument.Content.Start, activeDocument.Content.End).Text;

            // Creates custom json
            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });
            string api = "https://englishtips.azurewebsites.net/api/verbs2";

            // Sends created json to the server:
            List<VerbsResponse> response = GenericSender<List<VerbsResponse>>.Send(json, api: api, "POST");

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
        }

        void Color_noun_compound()
        {
            var activeDocument = Globals.ThisAddIn.Application.ActiveDocument;
            string text_to_check = activeDocument.Range(activeDocument.Content.Start, activeDocument.Content.End).Text;

            // Creates custom json
            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });
            string api = "https://englishtips.azurewebsites.net/api/noun-compound";

            // Sends created json to the server:
            NounCompoundResponse response = GenericSender<NounCompoundResponse>.Send(json, api: api, "POST");

            // Print out verbs.
            foreach (List<int> compoundIndexes in response.Result)
            {
                int startIndex = compoundIndexes[0];
                int length = compoundIndexes[1];
                //String nounCompound = text_to_check.Substring(startIndex, length + 1); // PAY ATTEMTION ADDED 1 MANUALLY TO LENGTH IN ORDER TO PRINT WHOLE WORD

                Word.Range rng = Globals.ThisAddIn.Application.ActiveDocument.Range(startIndex, startIndex + length + 1);
                rng.Font.Underline = Word.WdUnderline.wdUnderlineThick;
                rng.Font.UnderlineColor = Word.WdColor.wdColorBrightGreen;
            }
        }
        

        void Color_uncountable_nouns()
        {
            var activeDocument = Globals.ThisAddIn.Application.ActiveDocument;
            string text_to_check = activeDocument.Range(activeDocument.Content.Start, activeDocument.Content.End).Text;

            // Creates custom json
            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });
            string api = "https://englishtips.azurewebsites.net/api/uncountable";

            // Sends created json to the server:
            List<UncountableNounResponse> response = GenericSender<List<UncountableNounResponse>>.Send(json, api: api, "POST");

            foreach (UncountableNounResponse uncountableNoun in response)
            {
                Console.Write($"Uncountable Noun: '{uncountableNoun.UncountableNoun}' - Length: {uncountableNoun.Length} - Index: ");
                foreach (int index in uncountableNoun.Indexes)
                {
                    Word.Range rng = Globals.ThisAddIn.Application.ActiveDocument.Range(index, index + uncountableNoun.Length);
                    rng.Font.Underline = Word.WdUnderline.wdUnderlineThick;
                    rng.Font.UnderlineColor = Word.WdColor.wdColorBrown;
                }
            }
        }

        void Remove_underline()
        {
            Word.Range range = Globals.ThisAddIn.Application.ActiveDocument.Content;
            Remove_underline(range, Word.WdColor.wdColorRed.GetHashCode());
            Remove_underline(range, Word.WdColor.wdColorBlue.GetHashCode());
            Remove_underline(range, Word.WdColor.wdColorBrightGreen.GetHashCode());
            Remove_underline(range, Word.WdColor.wdColorBrown.GetHashCode());
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

        private void Coloring_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.ColoringCustomTaskPane.Visible ^= true;
        }
    }
}
