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
using System.Web.Script.Serialization;
using RESTApiExample;
using TextSummarizationAPI;

namespace MySupervisor
{
    public partial class UserControlSummary : UserControl
    {
        public UserControlSummary()
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
            string api = "https://avrl.cs.technion.ac.il:80/api/summ";
            TextSummarizationResponse response;
                
            try
            {
                response = GenericSender<TextSummarizationResponse>.Send(json, api: api, "POST");
            }
            catch
            {
                printToRichTextBox(textBox, Constants.connection_error);
                return;
            }

            printToRichTextBox(textBox, response.Summary);
        }

        private void SummaryButton_Click(object sender, EventArgs e)
        {
            // Get current selection
            Word.Range selection = Globals.ThisAddIn.Application.Selection.Range;

            // If selection is empty - select entire document
            if (selection.Text == null)
            {
                //selection = Globals.ThisAddIn.Application.ActiveDocument.Content;
                printToRichTextBox(SummaryRichTextBox, "Please select in the document text to translate");
                return;
            }

            string json = new JavaScriptSerializer().Serialize(new
            {
                text = selection.Text
            });

            printToRichTextBox(SummaryRichTextBox, "Contacting server. Please wait...");
            Task.Run(() => sendRequest(SummaryRichTextBox, json));
        }
    }
}
