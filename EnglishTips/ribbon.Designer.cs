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
            this.checkBox2 = this.Factory.CreateRibbonCheckBox();
            this.checkBox1 = this.Factory.CreateRibbonCheckBox();
            this.checkBox3 = this.Factory.CreateRibbonCheckBox();
            this.checkBox4 = this.Factory.CreateRibbonCheckBox();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.editBox1 = this.Factory.CreateRibbonEditBox();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.btn_refresh_coloring = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.toggleButton1 = this.Factory.CreateRibbonToggleButton();
            this.toggleButton2 = this.Factory.CreateRibbonToggleButton();
            this.tab2.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group3.SuspendLayout();
            this.group4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab2
            // 
            this.tab2.Groups.Add(this.group1);
            this.tab2.Groups.Add(this.group2);
            this.tab2.Groups.Add(this.group3);
            this.tab2.Groups.Add(this.group4);
            this.tab2.Label = "English Tips";
            this.tab2.Name = "tab2";
            // 
            // group1
            // 
            this.group1.Items.Add(this.checkBox2);
            this.group1.Items.Add(this.checkBox1);
            this.group1.Items.Add(this.checkBox3);
            this.group1.Items.Add(this.checkBox4);
            this.group1.Items.Add(this.btn_refresh_coloring);
            this.group1.Label = "Coloring";
            this.group1.Name = "group1";
            // 
            // checkBox2
            // 
            this.checkBox2.Label = "Verbs";
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.checkBox2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Label = "Wordiness";
            this.checkBox1.Name = "checkBox1";
            // 
            // checkBox3
            // 
            this.checkBox3.Label = "Noun-compound";
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.checkBox3_Click);
            // 
            // checkBox4
            // 
            this.checkBox4.Label = "Uncountable nouns";
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.checkBox4_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.button1);
            this.group2.Label = "group2";
            this.group2.Name = "group2";
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
            this.group4.Items.Add(this.toggleButton1);
            this.group4.Items.Add(this.toggleButton2);
            this.group4.Label = "Dictionary";
            this.group4.Name = "group4";
            // 
            // btn_refresh_coloring
            // 
            this.btn_refresh_coloring.Label = "Refresh";
            this.btn_refresh_coloring.Name = "btn_refresh_coloring";
            this.btn_refresh_coloring.ShowImage = true;
            this.btn_refresh_coloring.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Label = "Read aloud";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // toggleButton1
            // 
            this.toggleButton1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.toggleButton1.Image = ((System.Drawing.Image)(resources.GetObject("toggleButton1.Image")));
            this.toggleButton1.Label = "Translate";
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.ShowImage = true;
            this.toggleButton1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleButton1_Click);
            // 
            // toggleButton2
            // 
            this.toggleButton2.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.toggleButton2.Image = ((System.Drawing.Image)(resources.GetObject("toggleButton2.Image")));
            this.toggleButton2.Label = "Oxford Dictionary";
            this.toggleButton2.Name = "toggleButton2";
            this.toggleButton2.ShowImage = true;
            this.toggleButton2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.toggleButton2_Click);
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
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Office.Tools.Ribbon.RibbonTab tab2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox checkBox1;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox checkBox2;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox checkBox3;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox checkBox4;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_refresh_coloring;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleButton1;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton toggleButton2;
    }

    partial class ThisRibbonCollection
    {
        internal ribbon Coloring
        {
            get { return this.GetRibbon<ribbon>(); }
        }
    }
}
