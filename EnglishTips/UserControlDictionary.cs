using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Web.Script.Serialization;
using RESTApiExample;
using DictionaryAPI;

namespace EnglishTips
{
    public partial class UserControlDictionary : UserControl
    {
        public UserControlDictionary()
        {
            InitializeComponent();
        }

        void invokedPrintToRichTextBox(RichTextBox textBox, string txt)
        {
            textBox.Text = txt;
        }

        void printToRichTextBox(RichTextBox textBox, string txt)
        {
            // Print translation
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new MethodInvoker(delegate { invokedPrintToRichTextBox(textBox, txt); }));
            }
            else
            {
                invokedPrintToRichTextBox(textBox, txt);
            }
        }

        void sendRequest(RichTextBox textBox, string json)
        {
            string api = "https://avrl.cs.technion.ac.il:80/api/dictionary";
            DictionaryResponse response;

            try
            {
                response = GenericSender<DictionaryResponse>.Send(json, api: api, "POST");
            }
            catch
            {
                printToRichTextBox(textBox, Constants.connection_error);
                return;
            }

            printToRichTextBox(textBox, response.Definition);
        }

        private void DictionaryButton_Click(object sender, EventArgs e)
        {
            // Get current selection
            Word.Range selection = Globals.ThisAddIn.Application.Selection.Range;

            // If selection is empty - select entire document
            if (selection.Text == null)
            {
                //selection = Globals.ThisAddIn.Application.ActiveDocument.Content;
                printToRichTextBox(DictionaryRichTextBox, "Please select in the document text to translate");
                return;
            }

            string json = new JavaScriptSerializer().Serialize(new
            {
                word = selection.Text
            });

            printToRichTextBox(DictionaryRichTextBox, "Contacting server. Please wait...");
            Task.Run(() => sendRequest(DictionaryRichTextBox, json));
        }
    }
}
