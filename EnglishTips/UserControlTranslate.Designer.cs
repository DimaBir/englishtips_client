namespace EnglishTips
{
    partial class UserControlTranslate
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.TranslateButton = new System.Windows.Forms.Button();
            this.TranslateRichTextBox = new System.Windows.Forms.RichTextBox();
            this.To = new System.Windows.Forms.RichTextBox();
            this.BackToEnglishTextBox = new System.Windows.Forms.RichTextBox();
            this.BackInEnglishRichTextBox = new System.Windows.Forms.RichTextBox();
            this.BackToEnglishButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Amharic",
            "Arabic",
            "Chinese (Simplified)",
            "Chinese (Traditional)",
            "Czech",
            "Danish",
            "Dutch",
            "Esperanto",
            "Estonian",
            "Finnish",
            "French",
            "Georgian",
            "German",
            "Greek",
            "Hebrew",
            "Hindi",
            "Indonesian",
            "Irish",
            "Italian",
            "Japanese",
            "Korean",
            "Polish",
            "Portuguese",
            "Russian",
            "Spanish",
            "Thai",
            "Ukrainian",
            "Vietnamese",
            "Yiddish"});
            this.comboBox1.Location = new System.Drawing.Point(48, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(269, 33);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Tag = "";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // TranslateButton
            // 
            this.TranslateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TranslateButton.Location = new System.Drawing.Point(3, 3);
            this.TranslateButton.Name = "TranslateButton";
            this.TranslateButton.Size = new System.Drawing.Size(314, 33);
            this.TranslateButton.TabIndex = 5;
            this.TranslateButton.Text = "Translate selected text";
            this.TranslateButton.UseVisualStyleBackColor = true;
            this.TranslateButton.Click += new System.EventHandler(this.TranslateButton_Click);
            // 
            // TranslateRichTextBox
            // 
            this.TranslateRichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.TranslateRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TranslateRichTextBox.Location = new System.Drawing.Point(3, 81);
            this.TranslateRichTextBox.Name = "TranslateRichTextBox";
            this.TranslateRichTextBox.ReadOnly = true;
            this.TranslateRichTextBox.Size = new System.Drawing.Size(314, 371);
            this.TranslateRichTextBox.TabIndex = 6;
            this.TranslateRichTextBox.Text = "";
            // 
            // To
            // 
            this.To.BackColor = System.Drawing.SystemColors.ControlLight;
            this.To.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.To.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.To.Location = new System.Drawing.Point(3, 45);
            this.To.Name = "To";
            this.To.ReadOnly = true;
            this.To.Size = new System.Drawing.Size(39, 33);
            this.To.TabIndex = 7;
            this.To.Text = "To";
            // 
            // BackToEnglishTextBox
            // 
            this.BackToEnglishTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackToEnglishTextBox.Location = new System.Drawing.Point(3, 477);
            this.BackToEnglishTextBox.Name = "BackToEnglishTextBox";
            this.BackToEnglishTextBox.Size = new System.Drawing.Size(314, 55);
            this.BackToEnglishTextBox.TabIndex = 8;
            this.BackToEnglishTextBox.Text = "Write text to translate back to English";
            // 
            // BackInEnglishRichTextBox
            // 
            this.BackInEnglishRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackInEnglishRichTextBox.Location = new System.Drawing.Point(3, 582);
            this.BackInEnglishRichTextBox.Name = "BackInEnglishRichTextBox";
            this.BackInEnglishRichTextBox.ReadOnly = true;
            this.BackInEnglishRichTextBox.Size = new System.Drawing.Size(314, 55);
            this.BackInEnglishRichTextBox.TabIndex = 9;
            this.BackInEnglishRichTextBox.Text = "";
            // 
            // BackToEnglishButton
            // 
            this.BackToEnglishButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.BackToEnglishButton.Location = new System.Drawing.Point(3, 538);
            this.BackToEnglishButton.Name = "BackToEnglishButton";
            this.BackToEnglishButton.Size = new System.Drawing.Size(314, 38);
            this.BackToEnglishButton.TabIndex = 10;
            this.BackToEnglishButton.Text = "Back to English";
            this.BackToEnglishButton.UseVisualStyleBackColor = true;
            this.BackToEnglishButton.Click += new System.EventHandler(this.BackToEnglish_Click);
            // 
            // UserControlTranslate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.BackToEnglishButton);
            this.Controls.Add(this.BackInEnglishRichTextBox);
            this.Controls.Add(this.BackToEnglishTextBox);
            this.Controls.Add(this.To);
            this.Controls.Add(this.TranslateRichTextBox);
            this.Controls.Add(this.TranslateButton);
            this.Controls.Add(this.comboBox1);
            this.Name = "UserControlTranslate";
            this.Size = new System.Drawing.Size(320, 640);
            this.Load += new System.EventHandler(this.UserControlTranslate_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button TranslateButton;
        private System.Windows.Forms.RichTextBox TranslateRichTextBox;
        private System.Windows.Forms.RichTextBox To;
        private System.Windows.Forms.RichTextBox BackToEnglishTextBox;
        private System.Windows.Forms.RichTextBox BackInEnglishRichTextBox;
        private System.Windows.Forms.Button BackToEnglishButton;
    }
}
