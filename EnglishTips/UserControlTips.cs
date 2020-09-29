using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using RESTApiExample;
using Microsoft.Office.Interop;
using ConfusedWordsAPI;
using SentenceStructureAPI;

namespace MySupervisor
{
    public partial class UserControlTips : UserControl
    {
        public UserControlTips()
        {
            InitializeComponent();
        }

        public void updateTips()
        {
            if (!this.ConfusedWords.Checked && !this.SentenceStructure.Checked)
            {
                return;
            }

            Microsoft.Office.Interop.Word.Selection selection = Globals.ThisAddIn.Application.Selection;

            // Save selection
            Microsoft.Office.Interop.Word.Range oldRange = selection.Range;

            if (oldRange.Text == null || oldRange.Text.Length == 0)
            {
                selection.MoveLeft(Microsoft.Office.Interop.Word.WdUnits.wdWord, 1, Microsoft.Office.Interop.Word.WdMovementType.wdExtend);
            }
            //_wordApp.Selection.TypeText("NewWords");

            string word_to_check = selection.Text;

            // Restore old selection
            oldRange.Select();

            if (word_to_check == "")
            {
                return;
            }

            Task.Run(() => sendRequest(word_to_check));
        }

        void sendRequest(string word_to_check)
        {
            string tips = "";
            if (updateConfusedWords(word_to_check, ref tips) && updateSentenceStructure(word_to_check, ref tips))
            {
                printToRichTextBox(tips);
            }
        }

        bool updateConfusedWords(string word_to_check, ref string tips)
        {
            if (!this.ConfusedWords.Checked)
            {
                return true;
            }

            // Creates request
            string json = new JavaScriptSerializer().Serialize(new
            {
                word = word_to_check
            });
            string api = "https://avrl.cs.technion.ac.il:80/api/confused_word";

            // Send request
            ConfusedWordsResponse response;
            try
            {
                printToRichTextBox("Contacting server.\nPlease wait...");
                response = GenericSender<ConfusedWordsResponse>.Send(json, api: api, "POST");
            }
            catch
            {
                printConnectionError();
                return false;
            }

            if (response.Note != null)
            {
                printToRichTextBox("");
                tips += "Confused words for \"" + word_to_check + "\":\n" + response.Note + "\n\n";
            }

            return true;
        }

        bool updateSentenceStructure(string word_to_check, ref string tips)
        {
            if (!this.SentenceStructure.Checked)
            {
                return true;
            }

            // Creates request
            string json = new JavaScriptSerializer().Serialize(new
            {
                word = word_to_check
            });

            string api = "https://avrl.cs.technion.ac.il:80/api/sentence_structure";

            // Send request
            SentenceStructureResponse response;
            try
            {
                printToRichTextBox("Contacting server.\nPlease wait...");
                response = GenericSender<SentenceStructureResponse>.Send(json, api: api, "POST");
            }
            catch
            {
                printConnectionError();
                return false;
            }

            if (response.Structure != null)
            {
                printToRichTextBox("");
                tips += word_to_check + ":\n" + response.Structure + "\n\n";
            }

            return true;
        }

        void printToRichTextBox(string txt, bool error = false)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                this.richTextBox1.Invoke(new MethodInvoker(delegate {
                    this.richTextBox1.Visible = true;
                    this.richTextBox1.Text = txt;
                    this.richTextBox1.ForeColor = error ? Color.Red : Color.Black;
                }));
            }
            else
            {
                this.richTextBox1.Visible = true;
                this.richTextBox1.Text = txt;
                this.richTextBox1.ForeColor = error ? Color.Red : Color.Black;
            }
        }

        void printConnectionError()
        {
            printToRichTextBox(Constants.connection_error, true);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConfusedWords_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
