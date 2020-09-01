namespace EnglishTips
{
    partial class ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ribbon));
            this.tab2 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.Mark = this.Factory.CreateRibbonToggleButton();
            this.ReadAloud = this.Factory.CreateRibbonGroup();
            this.StartReadingButton = this.Factory.CreateRibbonButton();
            this.StopReadingButton = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.editBox1 = this.Factory.CreateRibbonEditBox();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.Translate = this.Factory.CreateRibbonToggleButton();
            this.toggleButton2 = this.Factory.CreateRibbonToggleButton();
            this.Synonyms = this.Factory.CreateRibbonToggleButton();
            this.Acronyms = this.Factory.CreateRibbonToggleButton();
            this.Hyponymy = this.Factory.CreateRibbonToggleButton();
            this.Hypernymy = this.Factory.CreateRibbonToggleButton();
            this.Tips = this.Factory.CreateRibbonToggleButton();
            this.tab2.SuspendLayout();
            this.group1.SuspendLayout();
            this.ReadAloud.SuspendLayout();
            this.group3.SuspendLayout();
            this.group4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab2
            // 
            this.tab2.Groups.Add(this.group1);
            this.tab2.Groups.Add(this.ReadAloud);
            this.tab2.Groups.Add(this.group3);
            this.tab2.Groups.Add(this.group4);
            this.tab2.Label = "English Tips";
            this.tab2.Name = "tab2";
            // 
            // group1
            // 
            this.group1.Items.Add(this.Mark);
            this.group1.Items.Add(this.Tips);
            this.group1.Label = "Coloring";
            this.group1.Name = "group1";
            // 
            // Mark
            // 
            this.Mark.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Mark.Label = "Mark";
            this.Mark.Name = "Mark";
            this.Mark.ShowImage = true;
            this.Mark.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Mark_Click);
            // 
            // ReadAloud
            // 
            this.ReadAloud.Items.Add(this.StartReadingButton);
            this.ReadAloud.Items.Add(this.StopReadingButton);
            this.ReadAloud.Label = "Read aloud";
            this.ReadAloud.Name = "ReadAloud";
            // 
            // StartReadingButton
            // 
            this.StartReadingButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.StartReadingButton.Image = ((System.Drawing.Image)(resources.GetObject("StartReadingButton.Image")));
            this.StartReadingButton.Label = "Start";
            this.StartReadingButton.Name = "StartReadingButton";
            this.StartReadingButton.ShowImage = true;
            this.StartReadingButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.StartReadingButton_Click);
            // 
            // StopReadingButton
            // 
            this.StopReadingButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.StopReadingButton.Image = ((System.Drawing.Image)(resources.GetObject("StopReadingButton.Image")));
            this.StopReadingButton.Label = "Stop";
            this.StopReadingButton.Name = "StopReadingButton";
            this.StopReadingButton.ShowImage = true;
            this.StopReadingButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.StopReadingButton_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.editBox1);
            this.group3.Label = "Analytics";
            this.group3.Name = "group3";
            // 
            // editBox1
            // 
            this.editBox1.Label = "Amount of words";
            this.editBox1.MaxLength = 2;
            this.editBox1.Name = "editBox1";
            this.editBox1.Text = "10";
            // 
            // group4
            // 
            this.group4.Items.Add(this.Translate);
            this.group4.Items.Add(this.toggleButton2);
            this.group4.Items.Add(this.Synonyms);
            this.group4.Items.Add(this.Acronyms);
            this.group4.Items.Add(this.Hyponymy);
            this.group4.Items.Add(this.Hypernymy);
            this.group4.Label = "Dictionary";
            this.group4.Name = "group4";
            // 
            // Translate
            // 
            this.Translate.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Translate.Image = ((System.Drawing.Image)(resources.GetObject("Translate.Image")));
            this.Translate.Label = "Translate";
            this.Translate.Name = "Translate";
            this.Translate.ShowImage = true;
            this.Translate.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Translate_Click);
            // 
            // toggleButton2
            // 
            this.toggleButton2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.toggleButton2.Image = ((System.Drawing.Image)(resources.GetObject("toggleButton2.Image")));
            this.toggleButton2.Label = "Oxford";
            this.toggleButton2.Name = "toggleButton2";
            this.toggleButton2.ShowImage = true;
            this.toggleButton2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleButton2_Click);
            // 
            // Synonyms
            // 
            this.Synonyms.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Synonyms.Image = ((System.Drawing.Image)(resources.GetObject("Synonyms.Image")));
            this.Synonyms.Label = "Synonyms";
            this.Synonyms.Name = "Synonyms";
            this.Synonyms.ShowImage = true;
            this.Synonyms.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Synonyms_Click);
            // 
            // Acronyms
            // 
            this.Acronyms.Label = "Acronyms";
            this.Acronyms.Name = "Acronyms";
            this.Acronyms.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Acronyms_Click);
            // 
            // Hyponymy
            // 
            this.Hyponymy.Label = "Hyponymy ";
            this.Hyponymy.Name = "Hyponymy";
            this.Hyponymy.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Hyponymy_Click);
            // 
            // Hypernymy
            // 
            this.Hypernymy.Label = "Hypernymy";
            this.Hypernymy.Name = "Hypernymy";
            this.Hypernymy.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Hypernymy_Click);
            // 
            // Tips
            // 
            this.Tips.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Tips.Label = "Tips";
            this.Tips.Name = "Tips";
            this.Tips.ShowImage = true;
            this.Tips.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Tips_Click);
            // 
            // ribbon
            // 
            this.Name = "ribbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab2);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Coloring_Load);
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ReadAloud.ResumeLayout(false);
            this.ReadAloud.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Office.Tools.Ribbon.RibbonTab tab2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup ReadAloud;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleButton2;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton Mark;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton StartReadingButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton StopReadingButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton Translate;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton Synonyms;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton Hyponymy;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton Hypernymy;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton Acronyms;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton Tips;
    }

    partial class ThisRibbonCollection
    {
        internal ribbon Coloring
        {
            get { return this.GetRibbon<ribbon>(); }
        }
    }
}
