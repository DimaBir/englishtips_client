namespace EnglishTips
{
    partial class UserControlSynonyms
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
            this.SynonymsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SynonymsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SynonymsRichTextBox
            // 
            this.SynonymsRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.SynonymsRichTextBox.Location = new System.Drawing.Point(3, 42);
            this.SynonymsRichTextBox.Name = "SynonymsRichTextBox";
            this.SynonymsRichTextBox.ReadOnly = true;
            this.SynonymsRichTextBox.Size = new System.Drawing.Size(309, 527);
            this.SynonymsRichTextBox.TabIndex = 0;
            this.SynonymsRichTextBox.Text = "";
            // 
            // SynonymsButton
            // 
            this.SynonymsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SynonymsButton.Location = new System.Drawing.Point(3, 3);
            this.SynonymsButton.Name = "SynonymsButton";
            this.SynonymsButton.Size = new System.Drawing.Size(312, 33);
            this.SynonymsButton.TabIndex = 1;
            this.SynonymsButton.Text = "Get synonyms";
            this.SynonymsButton.UseVisualStyleBackColor = true;
            this.SynonymsButton.Click += new System.EventHandler(this.SynonymsButton_Click);
            // 
            // UserControlSynonyms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.SynonymsButton);
            this.Controls.Add(this.SynonymsRichTextBox);
            this.Name = "UserControlSynonyms";
            this.Size = new System.Drawing.Size(315, 572);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox SynonymsRichTextBox;
        private System.Windows.Forms.Button SynonymsButton;
    }
}
