namespace EnglishTips
{
    partial class UserControlSummary
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
            this.SummaryButton = new System.Windows.Forms.Button();
            this.SummaryRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // SummaryButton
            // 
            this.SummaryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SummaryButton.Location = new System.Drawing.Point(80, 3);
            this.SummaryButton.Name = "SummaryButton";
            this.SummaryButton.Size = new System.Drawing.Size(160, 38);
            this.SummaryButton.TabIndex = 0;
            this.SummaryButton.Text = "Get summary";
            this.SummaryButton.UseVisualStyleBackColor = true;
            this.SummaryButton.Click += new System.EventHandler(this.SummaryButton_Click);
            // 
            // SummaryRichTextBox
            // 
            this.SummaryRichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.SummaryRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SummaryRichTextBox.Location = new System.Drawing.Point(0, 47);
            this.SummaryRichTextBox.Name = "SummaryRichTextBox";
            this.SummaryRichTextBox.ReadOnly = true;
            this.SummaryRichTextBox.Size = new System.Drawing.Size(317, 590);
            this.SummaryRichTextBox.TabIndex = 1;
            this.SummaryRichTextBox.Text = "";
            // 
            // UserControlSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.SummaryRichTextBox);
            this.Controls.Add(this.SummaryButton);
            this.Name = "UserControlSummary";
            this.Size = new System.Drawing.Size(320, 640);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SummaryButton;
        private System.Windows.Forms.RichTextBox SummaryRichTextBox;
    }
}
