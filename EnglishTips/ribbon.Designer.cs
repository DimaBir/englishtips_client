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
            this.ReadAloud = this.Factory.CreateRibbonGroup();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.Mark = this.Factory.CreateRibbonToggleButton();
            this.Tips = this.Factory.CreateRibbonToggleButton();
            this.Analytics = this.Factory.CreateRibbonToggleButton();
            this.StartReadingButton = this.Factory.CreateRibbonButton();
            this.StopReadingButton = this.Factory.CreateRibbonButton();
            this.Translate = this.Factory.CreateRibbonToggleButton();
            this.toggleButton2 = this.Factory.CreateRibbonToggleButton();
            this.Synonyms = this.Factory.CreateRibbonToggleButton();
            this.AboutButton = this.Factory.CreateRibbonButton();
            this.tab2.SuspendLayout();
            this.group1.SuspendLayout();
            this.ReadAloud.SuspendLayout();
            this.group4.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab2
            // 
            this.tab2.Groups.Add(this.group1);
            this.tab2.Groups.Add(this.ReadAloud);
            this.tab2.Groups.Add(this.group4);
            this.tab2.Groups.Add(this.group2);
            this.tab2.Label = "MySupervisor";
            this.tab2.Name = "tab2";
            // 
            // group1
            // 
            this.group1.Items.Add(this.Mark);
            this.group1.Items.Add(this.Tips);
            this.group1.Items.Add(this.Analytics);
            this.group1.Label = "Grammar";
            this.group1.Name = "group1";
            // 
            // ReadAloud
            // 
            this.ReadAloud.Items.Add(this.StartReadingButton);
            this.ReadAloud.Items.Add(this.StopReadingButton);
            this.ReadAloud.Label = "Read selected text aloud";
            this.ReadAloud.Name = "ReadAloud";
            // 
            // group4
            // 
            this.group4.Items.Add(this.Translate);
            this.group4.Items.Add(this.toggleButton2);
            this.group4.Items.Add(this.Synonyms);
            this.group4.Label = "Dictionary";
            this.group4.Name = "group4";
            // 
            // group2
            // 
            this.group2.Items.Add(this.AboutButton);
            this.group2.Name = "group2";
            // 
            // Mark
            // 
            this.Mark.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Mark.Image = ((System.Drawing.Image)(resources.GetObject("Mark.Image")));
            this.Mark.Label = "Mark";
            this.Mark.Name = "Mark";
            this.Mark.ShowImage = true;
            this.Mark.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Mark_Click);
            // 
            // Tips
            // 
            this.Tips.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Tips.Image = ((System.Drawing.Image)(resources.GetObject("Tips.Image")));
            this.Tips.Label = "Tips";
            this.Tips.Name = "Tips";
            this.Tips.ShowImage = true;
            this.Tips.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Tips_Click);
            // 
            // Analytics
            // 
            this.Analytics.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.Analytics.Image = ((System.Drawing.Image)(resources.GetObject("Analytics.Image")));
            this.Analytics.Label = "Analytics";
            this.Analytics.Name = "Analytics";
            this.Analytics.ShowImage = true;
            this.Analytics.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AnalyticsToggleButton_Click);
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
            this.toggleButton2.Enabled = false;
            this.toggleButton2.Image = ((System.Drawing.Image)(resources.GetObject("toggleButton2.Image")));
            this.toggleButton2.Label = "Oxford";
            this.toggleButton2.Name = "toggleButton2";
            this.toggleButton2.ShowImage = true;
            this.toggleButton2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleButton2_Click);
            // 
            // Synonyms
            // 
            this.Synonyms.Label = "Synonyms";
            this.Synonyms.Name = "Synonyms";
            this.Synonyms.ShowImage = true;
            this.Synonyms.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.Synonyms_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.AboutButton.Image = ((System.Drawing.Image)(resources.GetObject("AboutButton.Image")));
            this.AboutButton.Label = "About";
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.ShowImage = true;
            this.AboutButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AboutButton_Click);
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
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Office.Tools.Ribbon.RibbonTab tab2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup ReadAloud;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleButton2;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton Mark;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton StartReadingButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton StopReadingButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton Translate;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton Synonyms;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton Tips;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton Analytics;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AboutButton;
    }

    partial class ThisRibbonCollection
    {
        internal ribbon Coloring
        {
            get { return this.GetRibbon<ribbon>(); }
        }
    }
}
