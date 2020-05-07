using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;

namespace EnglishTips
{
    public partial class ribbon
    {
        private void Coloring_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void checkBox3_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void button4_Click(object sender, RibbonControlEventArgs e)
        {
            // Underline first word
            /*foreach (Word.Paragraph paragraph in myDocument.Paragraphs)
            {
                string pText = paragraph.Range.Text;
                System.Diagnostics.Debug.WriteLine(pText);

                Word.InlineShapes shapes = paragraph.Range.InlineShapes;
                System.Diagnostics.Debug.WriteLine("Shape Count: " + shapes.Count);
            }*/

            Word.Range rng = this.Application.ActiveDocument.Range(0, 0);
            rng.Text = "New Text";

        }

        private void checkBox4_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void checkBox2_Click(object sender, RibbonControlEventArgs e)
        {

        }
    }
}
