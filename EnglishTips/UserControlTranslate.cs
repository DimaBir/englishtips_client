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
            comboBox1.SelectedItem = "Hebrew";
            comboBox1.DropDownWidth = DropDownWidth(comboBox1);
        }

        int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0, temp = 0;
            foreach (var obj in myCombo.Items)
            {
                temp = TextRenderer.MeasureText(obj.ToString(), myCombo.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            return maxWidth;
        }

        void invokedPrintToRichTextBox(string txt, string languageCode)
        {
            this.TranslateRichTextBox.Text = txt;
            if (languageCode == "he" || languageCode == "ar" || languageCode == "yi")
            {
                TranslateRichTextBox.RightToLeft = RightToLeft.Yes;
            }
            else
            {
                TranslateRichTextBox.RightToLeft = RightToLeft.No;
            }
        }

        void printToRichTextBox(string txt, string languageCode)
        {
            if (this.TranslateRichTextBox.InvokeRequired)
            {
                this.TranslateRichTextBox.Invoke(new MethodInvoker(delegate { invokedPrintToRichTextBox(txt, languageCode); }));
            }
            else
            {
                invokedPrintToRichTextBox(txt, languageCode);
            }
        }

        void sendRequest(string json, string languageCode)
        {
            string api = "https://englishtips.azurewebsites.net/api/translate";
            string translation;
            try
            {
                translation = GenericSender<string>.Send(json, api: api, "POST");
            }
            catch
            {
                string error = "Can't connect to the server. Possible problems:\n";
                error += "Your internet connection may have failed.\n";
                error += "The security suit (firewall) may block Word from accessing the internet.";
                printToRichTextBox(error, "en");
                return;
            }

            printToRichTextBox(translation, languageCode);
            return;
        }

        private void TranslateButton_Click(object sender, EventArgs e)
        {
            // Get current selection
            Word.Range selection = Globals.ThisAddIn.Application.Selection.Range;

            // If selection is empty - select entire document
            if (selection.Text == null)
            {
                selection = Globals.ThisAddIn.Application.ActiveDocument.Content; ;
            }

            var EnglishCulture = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures)
                                .FirstOrDefault(r => r.EnglishName == comboBox1.SelectedItem.ToString());
            string languageCode = EnglishCulture.TwoLetterISOLanguageName;

            // Special languageCode cases
            if (comboBox1.SelectedItem.ToString() == "Chinese (Simplified)")
            {
                languageCode = "zh-CN";
            }
            else if (comboBox1.SelectedItem.ToString() == "Chinese (Traditional)")
            {
                languageCode = "zh-TW";
            }

            string json = new JavaScriptSerializer().Serialize(new
            {
                text = selection.Text,
                language = languageCode
            });

            printToRichTextBox("Contacting server...", "en");
            Task.Run(() => sendRequest(json, languageCode));

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
