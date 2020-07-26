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

            string api = "https://englishtips.azurewebsites.net/api/syn";

            // Sends request json to the server:
            // Response: List<string> - list of synonyms 
            SynonymResponse response = GenericSender<SynonymResponse>.Send(json, api: api, "POST");

            // Print out synonyms
            String synonyms = "";
            foreach (string synonym in response.Synonyms)
            {
                synonyms += synonym;
                synonyms += '\n';
            }

            //Globals.ThisAddIn.TranslateCustomTaskPane
            //TextBox txt = (TextBox)this.Parent.FindControl("txtid");
            foreach (Control lbxControl in this.Controls)
            {
                if (lbxControl is RichTextBox)
                {
                    ((RichTextBox)lbxControl).Text = synonyms;
                }
            }

            return;
        }
    }
}
