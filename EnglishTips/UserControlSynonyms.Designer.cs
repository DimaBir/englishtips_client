﻿namespace MySupervisor
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
            this.AcronymsButton = new System.Windows.Forms.Button();
            this.HyponymyButton = new System.Windows.Forms.Button();
            this.HypernymyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SynonymsRichTextBox
            // 
            this.SynonymsRichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.SynonymsRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SynonymsRichTextBox.Location = new System.Drawing.Point(3, 81);
            this.SynonymsRichTextBox.Name = "SynonymsRichTextBox";
            this.SynonymsRichTextBox.ReadOnly = true;
            this.SynonymsRichTextBox.Size = new System.Drawing.Size(309, 488);
            this.SynonymsRichTextBox.TabIndex = 0;
            this.SynonymsRichTextBox.Text = "";
            // 
            // SynonymsButton
            // 
            this.SynonymsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SynonymsButton.Location = new System.Drawing.Point(3, 3);
            this.SynonymsButton.Name = "SynonymsButton";
            this.SynonymsButton.Size = new System.Drawing.Size(149, 33);
            this.SynonymsButton.TabIndex = 1;
            this.SynonymsButton.Text = "Synonyms";
            this.SynonymsButton.UseVisualStyleBackColor = true;
            this.SynonymsButton.Click += new System.EventHandler(this.SynonymsButton_Click);
            // 
            // AcronymsButton
            // 
            this.AcronymsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.AcronymsButton.Location = new System.Drawing.Point(158, 3);
            this.AcronymsButton.Name = "AcronymsButton";
            this.AcronymsButton.Size = new System.Drawing.Size(154, 33);
            this.AcronymsButton.TabIndex = 2;
            this.AcronymsButton.Text = "Acronyms";
            this.AcronymsButton.UseVisualStyleBackColor = true;
            this.AcronymsButton.Click += new System.EventHandler(this.AcronymsButton_Click);
            // 
            // HyponymyButton
            // 
            this.HyponymyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.HyponymyButton.Location = new System.Drawing.Point(3, 42);
            this.HyponymyButton.Name = "HyponymyButton";
            this.HyponymyButton.Size = new System.Drawing.Size(149, 33);
            this.HyponymyButton.TabIndex = 3;
            this.HyponymyButton.Text = "Hyponymy";
            this.HyponymyButton.UseVisualStyleBackColor = true;
            this.HyponymyButton.Click += new System.EventHandler(this.HyponymyButton_Click);
            // 
            // HypernymyButton
            // 
            this.HypernymyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.HypernymyButton.Location = new System.Drawing.Point(158, 42);
            this.HypernymyButton.Name = "HypernymyButton";
            this.HypernymyButton.Size = new System.Drawing.Size(154, 33);
            this.HypernymyButton.TabIndex = 4;
            this.HypernymyButton.Text = "Hypernymy";
            this.HypernymyButton.UseVisualStyleBackColor = true;
            this.HypernymyButton.Click += new System.EventHandler(this.HypernymyButton_Click);
            // 
            // UserControlSynonyms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.HypernymyButton);
            this.Controls.Add(this.HyponymyButton);
            this.Controls.Add(this.AcronymsButton);
            this.Controls.Add(this.SynonymsButton);
            this.Controls.Add(this.SynonymsRichTextBox);
            this.Name = "UserControlSynonyms";
            this.Size = new System.Drawing.Size(315, 572);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox SynonymsRichTextBox;
        private System.Windows.Forms.Button SynonymsButton;
        private System.Windows.Forms.Button AcronymsButton;
        private System.Windows.Forms.Button HyponymyButton;
        private System.Windows.Forms.Button HypernymyButton;
    }
}
