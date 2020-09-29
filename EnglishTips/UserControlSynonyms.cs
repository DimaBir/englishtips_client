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
using AcrAPI;
using HyponAPI;
using HyperAPI;

namespace MySupervisor
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

        string getSelection()
        {
            // Get current selection
            Word.Range selection = Globals.ThisAddIn.Application.Selection.Range;

            // If selection is empty - do nothing
            if (selection.Text == null)
            {
                printToRichTextBox("Please select text in the document");
                return null;
            }

            return selection.Text;
        }

        void sendSynonymsRequest(string json, string txt)
        {
            string api = "https://avrl.cs.technion.ac.il:80/api/syn";

            SynonymResponse response;
            try
            {
                response = GenericSender<SynonymResponse>.Send(json, api: api, "POST");
            }
            catch
            {
                printToRichTextBox(Constants.connection_error, true);
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
                synonyms += "Synonyms for \"" + txt.Trim() + "\":\n";
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

        void sendAcronymsRequest(string json, string txt)
        {
            string api = "https://avrl.cs.technion.ac.il:80/api/acr";

            AcronymResponse response;
            try
            {
                response = GenericSender<AcronymResponse>.Send(json, api: api, "POST");
            }
            catch
            {
                printToRichTextBox(Constants.connection_error, true);
                return;
            }

            String acronyms = "";

            // Check if error has occured.
            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                acronyms = response.ErrorMessage;
            }
            else
            {
                acronyms += "Acronym for \"" + txt.Trim() + "\":\n";
                acronyms += response.Acronym;
            }

            printToRichTextBox(acronyms);

            return;
        }

        void sendHyponymyRequest(string json, string txt)
        {
            string api = "https://avrl.cs.technion.ac.il:80/api/hypon";

            HyponymResponse response;
            try
            {
                response = GenericSender<HyponymResponse>.Send(json, api: api, "POST");
            }
            catch
            {
                printToRichTextBox(Constants.connection_error, true);
                return;
            }

            String hyponyms = "";

            // Check if error has occured.
            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                hyponyms = response.ErrorMessage;
            }
            else
            {
                hyponyms += "Hyponyms for \"" + txt.Trim() + "\":\n";
                // Print out hyponyms
                foreach (string hyponymy in response.Hyponyms)
                {
                    hyponyms += hyponymy;
                    hyponyms += '\n';
                }
            }

            printToRichTextBox(hyponyms);

            return;
        }

        void sendHypernymyRequest(string json, string txt)
        {
            string api = "https://avrl.cs.technion.ac.il:80/api/hyper";

            HypernymyResponse response;
            try
            {
                response = GenericSender<HypernymyResponse>.Send(json, api: api, "POST");
            }
            catch
            {
                printToRichTextBox(Constants.connection_error, true);
                return;
            }

            String hypernyms = "";

            // Check if error has occured.
            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                hypernyms = response.ErrorMessage;
            }
            else
            {
                hypernyms += "Hypernyms for \"" + txt.Trim() + "\":\n";
                // Print out hypernyms
                foreach (string hypernym in response.Hypernymies)
                {
                    hypernyms += hypernym;
                    hypernyms += '\n';
                }
            }

            printToRichTextBox(hypernyms);

            return;
        }

        private void SynonymsButton_Click(object sender, EventArgs e)
        {
            string selection = getSelection();

            if (selection != null)
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    word = selection
                });

                printToRichTextBox("Contacting server.\nPlease wait...");
                Task.Run(() => sendSynonymsRequest(json, selection));
            }
        }

        private void AcronymsButton_Click(object sender, EventArgs e)
        {
            string selection = getSelection();

            if (selection != null)
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    word = selection
                });

                printToRichTextBox("Contacting server.\nPlease wait...");
                Task.Run(() => sendAcronymsRequest(json, selection));
            }
        }

        private void HyponymyButton_Click(object sender, EventArgs e)
        {
            string selection = getSelection();

            if (selection != null)
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    word = selection
                });

                printToRichTextBox("Contacting server.\nPlease wait...");
                Task.Run(() => sendHyponymyRequest(json, selection));
            }
        }

        private void HypernymyButton_Click(object sender, EventArgs e)
        {
            string selection = getSelection();

            if (selection != null)
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    word = selection
                });

                printToRichTextBox("Contacting server.\nPlease wait...");
                Task.Run(() => sendHypernymyRequest(json, selection));
            }
        }
    }
}
