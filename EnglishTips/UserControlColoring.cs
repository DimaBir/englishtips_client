using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using VerbsAPI;
using WordinessAPI;
using NounsAPI;
using UncountableNoun;
using RESTApiExample;
using System.Web.Script.Serialization;

namespace EnglishTips
{
    public partial class UserControlColoring : UserControl
    {
        public UserControlColoring()
        {
            InitializeComponent();
        }

        private void UserControlColoring_Load(object sender, EventArgs e)
        {

        }

        private void Wordiness_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Wordiness_checkBox.Checked)
            {
                Color_wordiness();
            }
            else
            {
                Remove_underline(SystemColorToWdColor(Wordiness_button.BackColor).GetHashCode());
            }
        }

        private void Verbs_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Verbs_checkBox.Checked)
            {
                Color_verbs();
            }
            else
            {
                Remove_underline(SystemColorToWdColor(Verbs_button.BackColor).GetHashCode());
            }
        }

        private void NounCompound_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (NounCompound_checkBox.Checked)
            {
                Color_noun_compound();
            }
            else
            {
                Remove_underline(SystemColorToWdColor(NounCompound_button.BackColor).GetHashCode());
            }
        }

        private void UncountableNouns_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UncountableNouns_checkBox.Checked)
            {
                Color_uncountable_nouns();
            }
            else
            {
                Remove_underline(SystemColorToWdColor(UncountableNouns_button.BackColor).GetHashCode());
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            // Store all coloring actions in a single record
            Word.UndoRecord recordObj = Globals.ThisAddIn.Application.UndoRecord;
            recordObj.StartCustomRecord("");

            // Remove existing underline
            //Remove_underlines();

            if (Wordiness_checkBox.Checked)
            {
                Remove_underline(SystemColorToWdColor(Wordiness_button.BackColor).GetHashCode());
                Color_wordiness();
            }
            if (Verbs_checkBox.Checked)
            {
                Remove_underline(SystemColorToWdColor(Verbs_button.BackColor).GetHashCode());
                Color_verbs();
            }
            if (NounCompound_checkBox.Checked)
            {
                Remove_underline(SystemColorToWdColor(NounCompound_button.BackColor).GetHashCode());
                Color_noun_compound();
            }
            if (UncountableNouns_checkBox.Checked)
            {
                Remove_underline(SystemColorToWdColor(UncountableNouns_button.BackColor).GetHashCode());
                Color_uncountable_nouns();
            }

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
                    rng.Font.UnderlineColor = SystemColorToWdColor(Wordiness_button.BackColor);
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
                    rng.Font.UnderlineColor = SystemColorToWdColor(Verbs_button.BackColor);
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
                rng.Font.UnderlineColor = SystemColorToWdColor(NounCompound_button.BackColor);
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
                    rng.Font.UnderlineColor = SystemColorToWdColor(UncountableNouns_button.BackColor);

                }
            }
        }

        Word.WdColor SystemColorToWdColor(Color c)
        {
            return (Microsoft.Office.Interop.Word.WdColor)(c.R + 0x100 * c.G + 0x10000 * c.B);
        }

        void Remove_underlines()
        {
            Remove_underline(SystemColorToWdColor(Wordiness_button.BackColor).GetHashCode());
            Remove_underline(SystemColorToWdColor(Verbs_button.BackColor).GetHashCode());
            Remove_underline(SystemColorToWdColor(NounCompound_button.BackColor).GetHashCode());
            Remove_underline(SystemColorToWdColor(UncountableNouns_button.BackColor).GetHashCode());
        }
        void Remove_underline(int colorIndex)
        {
            Word.Range range = Globals.ThisAddIn.Application.ActiveDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Replacement.ClearFormatting();
            range.Find.Text = "";
            range.Find.Font.UnderlineColor = (Word.WdColor)colorIndex;
            range.Find.Font.Underline = Word.WdUnderline.wdUnderlineThick;
            range.Find.Replacement.Text = "";
            range.Find.Replacement.Font.Underline = Word.WdUnderline.wdUnderlineNone;
            range.Find.Execute(Format: true, Replace: Word.WdReplace.wdReplaceAll);

        }

        private void Wordiness_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Remove_underlines();
        }

        private void Wordiness_button_Click(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                Wordiness_button.BackColor = ColorDialog.Color;
            }
        }

        private void Verbs_button_Click(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                Verbs_button.BackColor = ColorDialog.Color;
            }
        }

        private void NounCompound_button_Click(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                NounCompound_button.BackColor = ColorDialog.Color;
            }
        }

        private void UncountableNouns_button_Click(object sender, EventArgs e)
        {
            if (ColorDialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                UncountableNouns_button.BackColor = ColorDialog.Color;
            }
        }
    }
}
