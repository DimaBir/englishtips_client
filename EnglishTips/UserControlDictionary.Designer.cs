namespace MySupervisor
{
    partial class UserControlDictionary
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
            this.DictionaryButton = new System.Windows.Forms.Button();
            this.DictionaryRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // DictionaryButton
            // 
            this.DictionaryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DictionaryButton.Location = new System.Drawing.Point(80, 3);
            this.DictionaryButton.Name = "DictionaryButton";
            this.DictionaryButton.Size = new System.Drawing.Size(160, 30);
            this.DictionaryButton.TabIndex = 0;
            this.DictionaryButton.Text = "Get definition";
            this.DictionaryButton.UseVisualStyleBackColor = true;
            this.DictionaryButton.Click += new System.EventHandler(this.DictionaryButton_Click);
            // 
            // DictionaryRichTextBox
            // 
            this.DictionaryRichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.DictionaryRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DictionaryRichTextBox.Location = new System.Drawing.Point(3, 39);
            this.DictionaryRichTextBox.Name = "DictionaryRichTextBox";
            this.DictionaryRichTextBox.ReadOnly = true;
            this.DictionaryRichTextBox.Size = new System.Drawing.Size(314, 598);
            this.DictionaryRichTextBox.TabIndex = 1;
            this.DictionaryRichTextBox.Text = "";
            // 
            // UserControlDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.DictionaryRichTextBox);
            this.Controls.Add(this.DictionaryButton);
            this.Name = "UserControlDictionary";
            this.Size = new System.Drawing.Size(320, 640);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DictionaryButton;
        private System.Windows.Forms.RichTextBox DictionaryRichTextBox;
    }
}
