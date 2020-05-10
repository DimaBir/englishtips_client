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

namespace EnglishTips
{
    public partial class UserControlTranslate : UserControl
    {
        public UserControlTranslate()
        {
            InitializeComponent();
        }

        private void UserControlTranslate_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedText = "Hebrew";
            comboBox2.SelectedIndex = comboBox2.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get current selection
            Word.Range selection = Globals.ThisAddIn.Application.Selection.Range;

            // If selection is empty - Don't translate
            if (selection.Text == null)
            {
                return;
            }

            //SayAloud.Say(text: selection.Text);

            //string text_to_translate = "Hello, how are you? Enter here text and the language you want to translate into.";
            string text_to_translate = selection.Text;

            // Creates custom json
            // JSON body:
            // "text": (string)"Text you wanna to send to server"
            // "language": (string)"he"
            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_translate,
                language = "he"
            });

            string api = "https://englishtips.azurewebsites.net/api/translate";

            // Sends created json to server and returns:
            // returns: string
            string translation = GenericSender<string>.Send(json, api: api, "POST");


            // Technique to handle  with printing hebrew to console.
            // If you will look at the string itself on debug mode, you will see that it stored as legal hebrew,
            // only in printing its messed up, so here is the solution.
            // Maybe in the word addin you can print hebrew as is, cause this solution reverses chars and numbers too. 

            //Globals.ThisAddIn.TranslateCustomTaskPane
            //TextBox txt = (TextBox)this.Parent.FindControl("txtid");
            foreach (Control lbxControl in this.Controls)
            {
                if (lbxControl is RichTextBox)
                {
                    ((RichTextBox)lbxControl).Text = translation;
                    ((RichTextBox)lbxControl).RightToLeft = RightToLeft.Yes;
                }
            }

            return;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
