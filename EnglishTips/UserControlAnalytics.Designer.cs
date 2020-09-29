namespace MySupervisor
{
    partial class UserControlAnalytics
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
            this.RefreshButton = new System.Windows.Forms.Button();
            this.AnalyticsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RefreshButton
            // 
            this.RefreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.RefreshButton.Location = new System.Drawing.Point(3, 3);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(314, 34);
            this.RefreshButton.TabIndex = 0;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // AnalyticsRichTextBox
            // 
            this.AnalyticsRichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.AnalyticsRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnalyticsRichTextBox.Location = new System.Drawing.Point(3, 43);
            this.AnalyticsRichTextBox.Name = "AnalyticsRichTextBox";
            this.AnalyticsRichTextBox.ReadOnly = true;
            this.AnalyticsRichTextBox.Size = new System.Drawing.Size(314, 594);
            this.AnalyticsRichTextBox.TabIndex = 1;
            this.AnalyticsRichTextBox.Text = "";
            // 
            // UserControlAnalytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.AnalyticsRichTextBox);
            this.Controls.Add(this.RefreshButton);
            this.Name = "UserControlAnalytics";
            this.Size = new System.Drawing.Size(320, 640);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.RichTextBox AnalyticsRichTextBox;
    }
}
