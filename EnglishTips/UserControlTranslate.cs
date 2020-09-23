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

        void invokedPrintToRichTextBox(RichTextBox textBox,string txt, string languageCode)
        {
            textBox.Text = txt;
            if (languageCode == "he" || languageCode == "ar" || languageCode == "yi")
            {
                textBox.RightToLeft = RightToLeft.Yes;
            }
            else
            {
                textBox.RightToLeft = RightToLeft.No;
            }
        }

        void printToRichTextBox(RichTextBox textBox, string txt, string languageCode)
        {
            // Print translation
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new MethodInvoker(delegate { invokedPrintToRichTextBox(textBox, txt, languageCode); }));
            }
            else
            {
                invokedPrintToRichTextBox(textBox, txt, languageCode);
            }
        }

        void sendRequest(RichTextBox textBox, string json, string languageCode)
        {
            string api = "https://avrl.cs.technion.ac.il:80/api/translate";
            string translation;
            try
            {
                translation = GenericSender<string>.Send(json, api: api, "POST");
            }
            catch
            {
                printToRichTextBox(textBox, Constants.connection_error, "en");
                return;
            }

            printToRichTextBox(textBox, translation, languageCode);

            // Update rightToLeft of BackInEnglishTextBox
            if (BackInEnglishRichTextBox.InvokeRequired)
            {
                BackInEnglishRichTextBox.Invoke(new MethodInvoker(delegate { invokedPrintToRichTextBox(BackInEnglishRichTextBox, BackInEnglishRichTextBox.Text, "en"); }));
            }
            else
            {
                invokedPrintToRichTextBox(BackInEnglishRichTextBox, BackInEnglishRichTextBox.Text, "en");
            }

            return;
        }

        private void TranslateButton_Click(object sender, EventArgs e)
        {
            // Get current selection
            Word.Range selection = Globals.ThisAddIn.Application.Selection.Range;

            // If selection is empty - select entire document
            if (selection.Text == null)
            {
                //selection = Globals.ThisAddIn.Application.ActiveDocument.Content;
                printToRichTextBox(TranslateRichTextBox, "Please select in the document text to translate", "en");
                return;
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

            printToRichTextBox(TranslateRichTextBox, "Contacting server. Please wait...", "en");
            Task.Run(() => sendRequest(TranslateRichTextBox, json, languageCode));

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

        private void BackToEnglish_Click(object sender, EventArgs e)
        {
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
                text = TranslateRichTextBox.Text,
                language = "en"
            });

            printToRichTextBox(BackInEnglishRichTextBox, "Contacting server. Please wait...", "en");
            Task.Run(() => sendRequest(BackInEnglishRichTextBox, json, languageCode));

            return;
        }
    }
}
