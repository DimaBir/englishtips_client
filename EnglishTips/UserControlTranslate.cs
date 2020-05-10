﻿using System;
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
            comboBox1.SelectedItem = "Hebrew";
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

            var EnglishCulture = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures)
                                .FirstOrDefault(r => r.EnglishName == comboBox1.SelectedItem.ToString());
            string languageCode = EnglishCulture.TwoLetterISOLanguageName;

            // Special languageCode cases
            if (comboBox1.SelectedItem.ToString() == "Chinese (Simplified)")
            {
                languageCode = "zh-CN";
            }
            else if(comboBox1.SelectedItem.ToString() == "Chinese (Traditional)")
            {
                languageCode = "zh-TW";
            }

            // Creates custom json
            // JSON body:
            // "text": (string)"Text you wanna to send to server"
            // "language": (string)"he"
            string json = new JavaScriptSerializer().Serialize(new
            {
                text = selection.Text,
                language = languageCode
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
                    if (languageCode == "he" || languageCode == "ar")
                    {
                        ((RichTextBox)lbxControl).RightToLeft = RightToLeft.Yes;
                    }
                    else
                    {
                        ((RichTextBox)lbxControl).RightToLeft = RightToLeft.No;
                    }
                    
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
