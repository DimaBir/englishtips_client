namespace EnglishTips
{
    partial class UserControlTips
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SentenceStructure = new System.Windows.Forms.CheckBox();
            this.ConfusedWords = new System.Windows.Forms.CheckBox();
            this.Examples = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // SentenceStructure
            // 
            this.SentenceStructure.AutoSize = true;
            this.SentenceStructure.Enabled = false;
            this.SentenceStructure.Location = new System.Drawing.Point(3, 3);
            this.SentenceStructure.Name = "SentenceStructure";
            this.SentenceStructure.Size = new System.Drawing.Size(150, 21);
            this.SentenceStructure.TabIndex = 0;
            this.SentenceStructure.Text = "Sentence structure";
            this.SentenceStructure.UseVisualStyleBackColor = true;
            // 
            // ConfusedWords
            // 
            this.ConfusedWords.AutoSize = true;
            this.ConfusedWords.Location = new System.Drawing.Point(3, 30);
            this.ConfusedWords.Name = "ConfusedWords";
            this.ConfusedWords.Size = new System.Drawing.Size(131, 21);
            this.ConfusedWords.TabIndex = 1;
            this.ConfusedWords.Text = "Confused words";
            this.ConfusedWords.UseVisualStyleBackColor = true;
            this.ConfusedWords.CheckedChanged += new System.EventHandler(this.ConfusedWords_CheckedChanged);
            // 
            // Examples
            // 
            this.Examples.AutoSize = true;
            this.Examples.Enabled = false;
            this.Examples.Location = new System.Drawing.Point(3, 57);
            this.Examples.Name = "Examples";
            this.Examples.Size = new System.Drawing.Size(272, 21);
            this.Examples.TabIndex = 2;
            this.Examples.Text = "Sentence examples with selected word";
            this.Examples.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 84);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(314, 553);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // UserControlTips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Examples);
            this.Controls.Add(this.ConfusedWords);
            this.Controls.Add(this.SentenceStructure);
            this.Name = "UserControlTips";
            this.Size = new System.Drawing.Size(320, 640);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox SentenceStructure;
        private System.Windows.Forms.CheckBox ConfusedWords;
        private System.Windows.Forms.CheckBox Examples;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
