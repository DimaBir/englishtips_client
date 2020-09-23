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
using TopWordsAPI;
using AvgSenLenAPI;

namespace EnglishTips
{
    public partial class UserControlAnalytics : UserControl
    {
        public UserControlAnalytics()
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

        bool getTopWords (string text_to_check, ref string analytics)
        {
            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });
            string api = "https://avrl.cs.technion.ac.il:80/api/topwords";

            // Send request
            TopWordsResponse response;
            try
            {
                response = GenericSender<TopWordsResponse>.Send(json, api: api, "POST");
            }
            catch
            {
                printToRichTextBox(AnalyticsRichTextBox, Constants.connection_error);
                return false;
            }

            analytics += "Top 10 words:\n";

            foreach (TopWordsResponse.TopWordsData match in response.Results)
            {
                analytics += match.Word + " (" + match.Indexes.Count.ToString() + ")\n";
            }

            analytics += "\n";

            return true;
        }

        bool getAvgSentenceLength(string text_to_check, ref string analytics)
        {
            string json = new JavaScriptSerializer().Serialize(new
            {
                text = text_to_check
            });
            string api = "https://avrl.cs.technion.ac.il:80/api/asl";

            // Send request
            ASLResponse response;
            try
            {
                response = GenericSender<ASLResponse>.Send(json, api: api, "POST");
            }
            catch
            {
                printToRichTextBox(AnalyticsRichTextBox, Constants.connection_error);
                return false;
            }

            analytics += "Average Sentence Length: " + response.Average + "\n";

            return true;
        }

        void sendRequest(string text_to_check)
        {
            string analytics = "";
            if (getTopWords(text_to_check, ref analytics) && getAvgSentenceLength(text_to_check, ref analytics))
            {
                printToRichTextBox(AnalyticsRichTextBox, analytics);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            // Get current selection
            string text_to_check = Globals.ThisAddIn.Application.ActiveDocument.Content.Text;

            printToRichTextBox(AnalyticsRichTextBox, "Contacting server. Please wait...");
            Task.Run(() => sendRequest(text_to_check));
        }
    }
}
