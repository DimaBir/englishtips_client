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
            this.Wordiness_comboBox = new System.Windows.Forms.ComboBox();
            this.Verbs_comboBox = new System.Windows.Forms.ComboBox();
            this.NounCompound_comboBox = new System.Windows.Forms.ComboBox();
            this.UncountableNouns_comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Wordiness_checkBox
            // 
            this.Wordiness_checkBox.AutoSize = true;
            this.Wordiness_checkBox.Location = new System.Drawing.Point(13, 16);
            this.Wordiness_checkBox.Name = "Wordiness_checkBox";
            this.Wordiness_checkBox.Size = new System.Drawing.Size(97, 21);
            this.Wordiness_checkBox.TabIndex = 3;
            this.Wordiness_checkBox.Text = "Wordiness";
            this.Wordiness_checkBox.UseVisualStyleBackColor = true;
            this.Wordiness_checkBox.CheckedChanged += new System.EventHandler(this.Wordiness_checkBox_CheckedChanged);
            // 
            // Verbs_checkBox
            // 
            this.Verbs_checkBox.AutoSize = true;
            this.Verbs_checkBox.Location = new System.Drawing.Point(13, 46);
            this.Verbs_checkBox.Name = "Verbs_checkBox";
            this.Verbs_checkBox.Size = new System.Drawing.Size(67, 21);
            this.Verbs_checkBox.TabIndex = 4;
            this.Verbs_checkBox.Text = "Verbs";
            this.Verbs_checkBox.UseVisualStyleBackColor = true;
            this.Verbs_checkBox.CheckedChanged += new System.EventHandler(this.Verbs_checkBox_CheckedChanged);
            // 
            // NounCompound_checkBox
            // 
            this.NounCompound_checkBox.AutoSize = true;
            this.NounCompound_checkBox.Location = new System.Drawing.Point(13, 76);
            this.NounCompound_checkBox.Name = "NounCompound_checkBox";
            this.NounCompound_checkBox.Size = new System.Drawing.Size(135, 21);
            this.NounCompound_checkBox.TabIndex = 5;
            this.NounCompound_checkBox.Text = "Noun-compound";
            this.NounCompound_checkBox.UseVisualStyleBackColor = true;
            this.NounCompound_checkBox.CheckedChanged += new System.EventHandler(this.NounCompound_checkBox_CheckedChanged);
            // 
            // UncountableNouns_checkBox
            // 
            this.UncountableNouns_checkBox.AutoSize = true;
            this.UncountableNouns_checkBox.Location = new System.Drawing.Point(13, 106);
            this.UncountableNouns_checkBox.Name = "UncountableNouns_checkBox";
            this.UncountableNouns_checkBox.Size = new System.Drawing.Size(153, 21);
            this.UncountableNouns_checkBox.TabIndex = 6;
            this.UncountableNouns_checkBox.Text = "Uncountable nouns";
            this.UncountableNouns_checkBox.UseVisualStyleBackColor = true;
            this.UncountableNouns_checkBox.CheckedChanged += new System.EventHandler(this.UncountableNouns_checkBox_CheckedChanged);
            // 
            // Wordiness_comboBox
            // 
            this.Wordiness_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Wordiness_comboBox.FormattingEnabled = true;
            this.Wordiness_comboBox.Items.AddRange(new object[] {
            "Blue",
            "Red"});
            this.Wordiness_comboBox.Location = new System.Drawing.Point(180, 14);
            this.Wordiness_comboBox.Name = "Wordiness_comboBox";
            this.Wordiness_comboBox.Size = new System.Drawing.Size(121, 24);
            this.Wordiness_comboBox.Sorted = true;
            this.Wordiness_comboBox.TabIndex = 7;
            // 
            // Verbs_comboBox
            // 
            this.Verbs_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Verbs_comboBox.FormattingEnabled = true;
            this.Verbs_comboBox.Location = new System.Drawing.Point(180, 44);
            this.Verbs_comboBox.Name = "Verbs_comboBox";
            this.Verbs_comboBox.Size = new System.Drawing.Size(121, 24);
            this.Verbs_comboBox.Sorted = true;
            this.Verbs_comboBox.TabIndex = 8;
            // 
            // NounCompound_comboBox
            // 
            this.NounCompound_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NounCompound_comboBox.FormattingEnabled = true;
            this.NounCompound_comboBox.Location = new System.Drawing.Point(180, 74);
            this.NounCompound_comboBox.Name = "NounCompound_comboBox";
            this.NounCompound_comboBox.Size = new System.Drawing.Size(121, 24);
            this.NounCompound_comboBox.Sorted = true;
            this.NounCompound_comboBox.TabIndex = 9;
            // 
            // UncountableNouns_comboBox
            // 
            this.UncountableNouns_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UncountableNouns_comboBox.FormattingEnabled = true;
            this.UncountableNouns_comboBox.Location = new System.Drawing.Point(180, 104);
            this.UncountableNouns_comboBox.Name = "UncountableNouns_comboBox";
            this.UncountableNouns_comboBox.Size = new System.Drawing.Size(121, 24);
            this.UncountableNouns_comboBox.Sorted = true;
            this.UncountableNouns_comboBox.TabIndex = 10;
            // 
            // UserControlColoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UncountableNouns_comboBox);
            this.Controls.Add(this.NounCompound_comboBox);
            this.Controls.Add(this.Verbs_comboBox);
            this.Controls.Add(this.Wordiness_comboBox);
            this.Controls.Add(this.UncountableNouns_checkBox);
            this.Controls.Add(this.NounCompound_checkBox);
            this.Controls.Add(this.Verbs_checkBox);
            this.Controls.Add(this.Wordiness_checkBox);
            this.Name = "UserControlColoring";
            this.Size = new System.Drawing.Size(320, 640);
            this.Load += new System.EventHandler(this.UserControlColoring_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox Wordiness_checkBox;
        private System.Windows.Forms.CheckBox Verbs_checkBox;
        private System.Windows.Forms.CheckBox NounCompound_checkBox;
        private System.Windows.Forms.CheckBox UncountableNouns_checkBox;
        private System.Windows.Forms.ComboBox Wordiness_comboBox;
        private System.Windows.Forms.ComboBox Verbs_comboBox;
        private System.Windows.Forms.ComboBox NounCompound_comboBox;
        private System.Windows.Forms.ComboBox UncountableNouns_comboBox;
    }
}
