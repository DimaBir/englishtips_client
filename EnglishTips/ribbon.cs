using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.Threading;
using System.Speech.Synthesis;
using static EnglishTips.ThisAddIn;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;

namespace EnglishTips
{
    public partial class ribbon
    {
        // Initialization of synthesizer.
        private SpeechSynthesizer synth = null;
        private Prompt prompt;

        private void Coloring_Load(object sender, RibbonUIEventArgs e)
        {
            Synonyms.Label = "Synonyms\nAcronyms\nHyponymy\nHypernymy";
        }

        private void checkBox3_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void checkBox4_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void checkBox2_Click(object sender, RibbonControlEventArgs e)
        {

        }

        void readAloud()
        {
            // Get current selection
            Word.Range selection = Globals.ThisAddIn.Application.Selection.Range;

            // If selection is empty - read entire document
            if (selection.Text == null)
            {
                selection = Globals.ThisAddIn.Application.ActiveDocument.Content;
            }

            prompt = synth.SpeakAsync(selection.Text);
        
        }

        private void StartReadingButton_Click(object sender, RibbonControlEventArgs e)
        {
            if (synth == null)
            {
                synth = new SpeechSynthesizer();

                // Configure the audio output.
                synth.SetOutputToDefaultAudioDevice();
            }

            if (synth.State == SynthesizerState.Ready)
            {
                readAloud();
            }
        }

        private void StopReadingButton_Click(object sender, RibbonControlEventArgs e)
        {
            if (synth != null && synth.State == SynthesizerState.Speaking)
            {
                synth.SpeakAsyncCancel(prompt);
            }
        }

        private void toggleButton2_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void Translate_Click(object sender, RibbonControlEventArgs e)
        {
            Window window = Globals.ThisAddIn.getActiveWindow();
            if (window != null)
            {
                ThisAddIn.TaskPanes tp;
                bool hasValue = Globals.ThisAddIn.TaskPanesDictionary.TryGetValue(Globals.ThisAddIn.getActiveWindow(), out tp);
                if (hasValue)
                {
                    tp.TranslateTaskPane.Visible ^= true;
                }
                else
                {
                    Globals.ThisAddIn.CreateTaskPaneWrapper();
                }
            }
        }

        private void Mark_Click(object sender, RibbonControlEventArgs e)
        {
            Window window = Globals.ThisAddIn.getActiveWindow();
            if (window != null)
            {
                ThisAddIn.TaskPanes tp;
                bool hasValue = Globals.ThisAddIn.TaskPanesDictionary.TryGetValue(Globals.ThisAddIn.getActiveWindow(), out tp);
                if (hasValue)
                {
                    tp.MarkTaskPane.Visible ^= true;
                }
                else
                {
                    Globals.ThisAddIn.CreateTaskPaneWrapper();
                }
            }
        }

        private void Synonyms_Click(object sender, RibbonControlEventArgs e)
        {
            Window window = Globals.ThisAddIn.getActiveWindow();
            if (window != null)
            {
                ThisAddIn.TaskPanes tp;
                bool hasValue = Globals.ThisAddIn.TaskPanesDictionary.TryGetValue(Globals.ThisAddIn.getActiveWindow(), out tp);
                if (hasValue)
                {
                    tp.SynonymsTaskPane.Visible ^= true;
                }
                else
                {
                    Globals.ThisAddIn.CreateTaskPaneWrapper();
                }
            }
        }

        private void Acronyms_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void Hyponymy_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void Hypernymy_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void Tips_Click(object sender, RibbonControlEventArgs e)
        {
            Window window = Globals.ThisAddIn.getActiveWindow();
            if (window != null)
            {
                ThisAddIn.TaskPanes tp;
                bool hasValue = Globals.ThisAddIn.TaskPanesDictionary.TryGetValue(Globals.ThisAddIn.getActiveWindow(), out tp);
                if (hasValue)
                {
                    tp.TipsTaskPane.Visible ^= true;
                }
                else
                {
                    Globals.ThisAddIn.CreateTaskPaneWrapper();
                }
            }
        }

        private void AnalyticsToggleButton_Click(object sender, RibbonControlEventArgs e)
        {
            Window window = Globals.ThisAddIn.getActiveWindow();
            if (window != null)
            {
                ThisAddIn.TaskPanes tp;
                bool hasValue = Globals.ThisAddIn.TaskPanesDictionary.TryGetValue(Globals.ThisAddIn.getActiveWindow(), out tp);
                if (hasValue)
                {
                    tp.AnalyticsTaskPane.Visible ^= true;
                }
                else
                {
                    Globals.ThisAddIn.CreateTaskPaneWrapper();
                }
            }
        }

        private void AboutButton_Click(object sender, RibbonControlEventArgs e)
        {
            string about = "";
            about += "Developed by Dima Birenbaum & Netanel Lev\n";
            about += "for the GIP laboratory in the CS department of the Technion,\n";
            about += "under the supervision and guidance of:\n";
            about += "  Mr. Yaron Honen\n";
            about += "  Mr. Gary Mataev\n";
            about += "  Dr. Tzipora Rakedzon\n";
            about += "\nFor more information please visit\n";
            about += "https://avrl.cs.technion.ac.il:80/";
            MessageBox.Show(about);
        }
    }
}
