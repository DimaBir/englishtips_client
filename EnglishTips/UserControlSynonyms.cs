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
using SynonymAPI;

namespace EnglishTips
{
    public partial class UserControlSynonyms : UserControl
    {
        public UserControlSynonyms()
        {
            InitializeComponent();
        }

        void printToRichTextBox(string txt, bool error = false)
        {
            if (this.SynonymsRichTextBox.InvokeRequired)
            {
                this.SynonymsRichTextBox.Invoke(new MethodInvoker(delegate {
                    this.SynonymsRichTextBox.Text = txt;
                    this.SynonymsRichTextBox.ForeColor = error ? Color.Red : Color.Black;
                }));
            }
            else
            {
                this.SynonymsRichTextBox.Text = txt;
                this.SynonymsRichTextBox.ForeColor = error ? Color.Red : Color.Black;
            }
        }

        void sendRequest(string json)
        {
            //string api = "https://englishtips.azurewebsites.net/api/syn";
            string api = "https://avrl.cs.technion.ac.il:80/api/syn";

            SynonymResponse response;
            try
            {
                response = GenericSender<SynonymResponse>.Send(json, api: api, "POST");
            }
            catch
            {
                string error = "Can't connect to the server. Possible problems:\n";
                error += "Your internet connection may have failed.\n";
                error += "The security suit (firewall) may block Word from accessing the internet.";
                printToRichTextBox(error, true);
                return;
            }
            
            String synonyms = "";

            // Check if error has occured.
            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                synonyms = response.ErrorMessage;
            }
            else
            {
                // Print out synonyms
                foreach (string synonym in response.Synonyms)
                {
                    synonyms += synonym;
                    synonyms += '\n';
                }
            }

            printToRichTextBox(synonyms);

            return;
        }

        private void SynonymsButton_Click(object sender, EventArgs e)
        {
            // Get current selection
            Word.Range selection = Globals.ThisAddIn.Application.Selection.Range;

            // If selection is empty - do nothing
            if (selection.Text == null)
            {
                return;
            }

            string json = new JavaScriptSerializer().Serialize(new
            {
                word = selection.Text
            });

            printToRichTextBox("Contacting server.\nPlease wait...");
            Task.Run(() => sendRequest(json));
        }
    }
}
