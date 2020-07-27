namespace EnglishTips
{
    partial class UserControlColoring
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
            this.Wordiness_checkBox = new System.Windows.Forms.CheckBox();
            this.Verbs_checkBox = new System.Windows.Forms.CheckBox();
            this.NounCompound_checkBox = new System.Windows.Forms.CheckBox();
            this.UncountableNouns_checkBox = new System.Windows.Forms.CheckBox();
            this.Wordiness_button = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.Verbs_button = new System.Windows.Forms.Button();
            this.NounCompound_button = new System.Windows.Forms.Button();
            this.UncountableNouns_button = new System.Windows.Forms.Button();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.ColoringRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Wordiness_checkBox
            // 
            this.Wordiness_checkBox.AutoSize = true;
            this.Wordiness_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wordiness_checkBox.Location = new System.Drawing.Point(13, 16);
            this.Wordiness_checkBox.Name = "Wordiness_checkBox";
            this.Wordiness_checkBox.Size = new System.Drawing.Size(137, 29);
            this.Wordiness_checkBox.TabIndex = 3;
            this.Wordiness_checkBox.Text = "Wordiness";
            this.Wordiness_checkBox.UseVisualStyleBackColor = true;
            this.Wordiness_checkBox.CheckedChanged += new System.EventHandler(this.Wordiness_checkBox_CheckedChanged);
            // 
            // Verbs_checkBox
            // 
            this.Verbs_checkBox.AutoSize = true;
            this.Verbs_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Verbs_checkBox.Location = new System.Drawing.Point(13, 51);
            this.Verbs_checkBox.Name = "Verbs_checkBox";
            this.Verbs_checkBox.Size = new System.Drawing.Size(91, 29);
            this.Verbs_checkBox.TabIndex = 4;
            this.Verbs_checkBox.Text = "Verbs";
            this.Verbs_checkBox.UseVisualStyleBackColor = true;
            this.Verbs_checkBox.CheckedChanged += new System.EventHandler(this.Verbs_checkBox_CheckedChanged);
            // 
            // NounCompound_checkBox
            // 
            this.NounCompound_checkBox.AutoSize = true;
            this.NounCompound_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NounCompound_checkBox.Location = new System.Drawing.Point(13, 86);
            this.NounCompound_checkBox.Name = "NounCompound_checkBox";
            this.NounCompound_checkBox.Size = new System.Drawing.Size(193, 29);
            this.NounCompound_checkBox.TabIndex = 5;
            this.NounCompound_checkBox.Text = "Noun-compound";
            this.NounCompound_checkBox.UseVisualStyleBackColor = true;
            this.NounCompound_checkBox.CheckedChanged += new System.EventHandler(this.NounCompound_checkBox_CheckedChanged);
            // 
            // UncountableNouns_checkBox
            // 
            this.UncountableNouns_checkBox.AutoSize = true;
            this.UncountableNouns_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UncountableNouns_checkBox.Location = new System.Drawing.Point(13, 121);
            this.UncountableNouns_checkBox.Name = "UncountableNouns_checkBox";
            this.UncountableNouns_checkBox.Size = new System.Drawing.Size(220, 29);
            this.UncountableNouns_checkBox.TabIndex = 6;
            this.UncountableNouns_checkBox.Text = "Uncountable nouns";
            this.UncountableNouns_checkBox.UseVisualStyleBackColor = true;
            this.UncountableNouns_checkBox.CheckedChanged += new System.EventHandler(this.UncountableNouns_checkBox_CheckedChanged);
            // 
            // Wordiness_button
            // 
            this.Wordiness_button.BackColor = System.Drawing.Color.Red;
            this.Wordiness_button.Location = new System.Drawing.Point(234, 21);
            this.Wordiness_button.Name = "Wordiness_button";
            this.Wordiness_button.Size = new System.Drawing.Size(37, 23);
            this.Wordiness_button.TabIndex = 11;
            this.Wordiness_button.Text = "\r\n";
            this.Wordiness_button.UseVisualStyleBackColor = false;
            this.Wordiness_button.Click += new System.EventHandler(this.Wordiness_button_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.Location = new System.Drawing.Point(13, 168);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(258, 36);
            this.RefreshButton.TabIndex = 12;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // Verbs_button
            // 
            this.Verbs_button.BackColor = System.Drawing.Color.Blue;
            this.Verbs_button.Location = new System.Drawing.Point(234, 56);
            this.Verbs_button.Name = "Verbs_button";
            this.Verbs_button.Size = new System.Drawing.Size(37, 23);
            this.Verbs_button.TabIndex = 13;
            this.Verbs_button.UseVisualStyleBackColor = false;
            this.Verbs_button.Click += new System.EventHandler(this.Verbs_button_Click);
            // 
            // NounCompound_button
            // 
            this.NounCompound_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.NounCompound_button.Location = new System.Drawing.Point(234, 91);
            this.NounCompound_button.Name = "NounCompound_button";
            this.NounCompound_button.Size = new System.Drawing.Size(37, 23);
            this.NounCompound_button.TabIndex = 14;
            this.NounCompound_button.UseVisualStyleBackColor = false;
            this.NounCompound_button.Click += new System.EventHandler(this.NounCompound_button_Click);
            // 
            // UncountableNouns_button
            // 
            this.UncountableNouns_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.UncountableNouns_button.Location = new System.Drawing.Point(234, 126);
            this.UncountableNouns_button.Name = "UncountableNouns_button";
            this.UncountableNouns_button.Size = new System.Drawing.Size(37, 23);
            this.UncountableNouns_button.TabIndex = 15;
            this.UncountableNouns_button.UseVisualStyleBackColor = false;
            this.UncountableNouns_button.Click += new System.EventHandler(this.UncountableNouns_button_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveButton.Location = new System.Drawing.Point(13, 227);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(258, 36);
            this.RemoveButton.TabIndex = 16;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // ColoringRichTextBox
            // 
            this.ColoringRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.ColoringRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColoringRichTextBox.ForeColor = System.Drawing.Color.Red;
            this.ColoringRichTextBox.Location = new System.Drawing.Point(13, 285);
            this.ColoringRichTextBox.Name = "ColoringRichTextBox";
            this.ColoringRichTextBox.ReadOnly = true;
            this.ColoringRichTextBox.Size = new System.Drawing.Size(258, 169);
            this.ColoringRichTextBox.TabIndex = 17;
            this.ColoringRichTextBox.Text = "";
            this.ColoringRichTextBox.Visible = false;
            // 
            // UserControlColoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.ColoringRichTextBox);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.UncountableNouns_button);
            this.Controls.Add(this.NounCompound_button);
            this.Controls.Add(this.Verbs_button);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.Wordiness_button);
            this.Controls.Add(this.UncountableNouns_checkBox);
            this.Controls.Add(this.NounCompound_checkBox);
            this.Controls.Add(this.Verbs_checkBox);
            this.Controls.Add(this.Wordiness_checkBox);
            this.Name = "UserControlColoring";
            this.Size = new System.Drawing.Size(280, 640);
            this.Load += new System.EventHandler(this.UserControlColoring_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox Wordiness_checkBox;
        private System.Windows.Forms.CheckBox Verbs_checkBox;
        private System.Windows.Forms.CheckBox NounCompound_checkBox;
        private System.Windows.Forms.CheckBox UncountableNouns_checkBox;
        private System.Windows.Forms.Button Wordiness_button;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button Verbs_button;
        private System.Windows.Forms.Button NounCompound_button;
        private System.Windows.Forms.Button UncountableNouns_button;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.RichTextBox ColoringRichTextBox;
    }
}
