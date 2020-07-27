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
            this.comboBox1.Location = new System.Drawing.Point(3, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(314, 33);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // TranslateButton
            // 
            this.TranslateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TranslateButton.Location = new System.Drawing.Point(3, 42);
            this.TranslateButton.Name = "TranslateButton";
            this.TranslateButton.Size = new System.Drawing.Size(314, 33);
            this.TranslateButton.TabIndex = 5;
            this.TranslateButton.Text = "Translate";
            this.TranslateButton.UseVisualStyleBackColor = true;
            this.TranslateButton.Click += new System.EventHandler(this.TranslateButton_Click);
            // 
            // TranslateRichTextBox
            // 
            this.TranslateRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.TranslateRichTextBox.Location = new System.Drawing.Point(3, 81);
            this.TranslateRichTextBox.Name = "TranslateRichTextBox";
            this.TranslateRichTextBox.ReadOnly = true;
            this.TranslateRichTextBox.Size = new System.Drawing.Size(314, 556);
            this.TranslateRichTextBox.TabIndex = 6;
            this.TranslateRichTextBox.Text = "";
            // 
            // UserControlTranslate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
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
    }
}
