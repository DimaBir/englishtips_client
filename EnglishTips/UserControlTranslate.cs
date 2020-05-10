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

            // Creates custom json
            // JSON body:
            // "text": (string)"Text you wanna to send to server"
            // "language": (string)"he"
            string json = new JavaScriptSerializer().Serialize(new
            {
                text = selection.Text,
                language = "he"
            });

            string api = "https://englishtips.azurewebsites.net/api/translate";

            // Sends created json to server and returns:
            // returns: string
            string translation = GenericSender<string>.Send(json, api: api, "POST");

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
