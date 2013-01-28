namespace Soldiers
{
    partial class SoldiersForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoldiersForm));
            this.listViewSoldiers = new System.Windows.Forms.ListView();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItemPrintBook = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItemPrintLatexBook = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItemOpenDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItemCreateDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripViewSoldierList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItemAdvancedSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.buttonAddSoldier = new System.Windows.Forms.Button();
            this.buttonRemoveSoldier = new System.Windows.Forms.Button();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.labelFilter = new System.Windows.Forms.Label();
            this.buttonSubmitToMaster = new System.Windows.Forms.Button();
            this.buttonCreateDuplicate = new System.Windows.Forms.Button();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewSoldiers
            // 
            this.listViewSoldiers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSoldiers.Location = new System.Drawing.Point(12, 27);
            this.listViewSoldiers.MultiSelect = false;
            this.listViewSoldiers.Name = "listViewSoldiers";
            this.listViewSoldiers.Size = new System.Drawing.Size(1070, 493);
            this.listViewSoldiers.TabIndex = 0;
            this.listViewSoldiers.UseCompatibleStateImageBehavior = false;
            this.listViewSoldiers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewSoldiers_ColumnClick);
            this.listViewSoldiers.SelectedIndexChanged += new System.EventHandler(this.listViewSoldiers_SelectedIndexChanged);
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuStripView,
            this.menuStripHelp});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1094, 24);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripItemPrintBook,
            this.menuStripItemPrintLatexBook,
            this.menuStripItemOpenDatabase,
            this.menuStripItemCreateDatabase});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menuStripItemPrintBook
            // 
            this.menuStripItemPrintBook.Name = "menuStripItemPrintBook";
            this.menuStripItemPrintBook.Size = new System.Drawing.Size(217, 22);
            this.menuStripItemPrintBook.Text = "Print Text Book";
            this.menuStripItemPrintBook.Click += new System.EventHandler(this.menuStripItemPrintBook_Click);
            // 
            // menuStripItemPrintLatexBook
            // 
            this.menuStripItemPrintLatexBook.Enabled = false;
            this.menuStripItemPrintLatexBook.Name = "menuStripItemPrintLatexBook";
            this.menuStripItemPrintLatexBook.Size = new System.Drawing.Size(217, 22);
            this.menuStripItemPrintLatexBook.Text = "Print Latex Book";
            this.menuStripItemPrintLatexBook.Click += new System.EventHandler(this.menuStripItemPrintLatexBook_Click);
            // 
            // menuStripItemOpenDatabase
            // 
            this.menuStripItemOpenDatabase.Name = "menuStripItemOpenDatabase";
            this.menuStripItemOpenDatabase.Size = new System.Drawing.Size(217, 22);
            this.menuStripItemOpenDatabase.Text = "Open  Secondary Database";
            this.menuStripItemOpenDatabase.Click += new System.EventHandler(this.menuStripItemOpenDatabase_Click);
            // 
            // menuStripItemCreateDatabase
            // 
            this.menuStripItemCreateDatabase.Name = "menuStripItemCreateDatabase";
            this.menuStripItemCreateDatabase.Size = new System.Drawing.Size(217, 22);
            this.menuStripItemCreateDatabase.Text = "Create Secondary Database";
            this.menuStripItemCreateDatabase.Click += new System.EventHandler(this.menuStripItemCreateDatabase_Click);
            // 
            // menuStripView
            // 
            this.menuStripView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripViewSoldierList,
            this.menuStripItemAdvancedSearch});
            this.menuStripView.Name = "menuStripView";
            this.menuStripView.Size = new System.Drawing.Size(44, 20);
            this.menuStripView.Text = "View";
            // 
            // menuStripViewSoldierList
            // 
            this.menuStripViewSoldierList.Name = "menuStripViewSoldierList";
            this.menuStripViewSoldierList.Size = new System.Drawing.Size(165, 22);
            this.menuStripViewSoldierList.Text = "Soldier List";
            this.menuStripViewSoldierList.Click += new System.EventHandler(this.menuStripViewSoldierList_Click);
            // 
            // menuStripItemAdvancedSearch
            // 
            this.menuStripItemAdvancedSearch.Name = "menuStripItemAdvancedSearch";
            this.menuStripItemAdvancedSearch.Size = new System.Drawing.Size(165, 22);
            this.menuStripItemAdvancedSearch.Text = "Advanced Search";
            this.menuStripItemAdvancedSearch.Click += new System.EventHandler(this.menuStripItemAdvancedSearch_Click);
            // 
            // menuStripHelp
            // 
            this.menuStripHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStripItemAbout});
            this.menuStripHelp.Name = "menuStripHelp";
            this.menuStripHelp.Size = new System.Drawing.Size(44, 20);
            this.menuStripHelp.Text = "Help";
            // 
            // menuStripItemAbout
            // 
            this.menuStripItemAbout.Name = "menuStripItemAbout";
            this.menuStripItemAbout.Size = new System.Drawing.Size(107, 22);
            this.menuStripItemAbout.Text = "About";
            this.menuStripItemAbout.Click += new System.EventHandler(this.menuStripItemAbout_Click);
            // 
            // buttonDetails
            // 
            this.buttonDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDetails.Location = new System.Drawing.Point(12, 527);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(75, 23);
            this.buttonDetails.TabIndex = 2;
            this.buttonDetails.Text = "Details";
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
            // 
            // buttonAddSoldier
            // 
            this.buttonAddSoldier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddSoldier.Location = new System.Drawing.Point(93, 527);
            this.buttonAddSoldier.Name = "buttonAddSoldier";
            this.buttonAddSoldier.Size = new System.Drawing.Size(75, 23);
            this.buttonAddSoldier.TabIndex = 3;
            this.buttonAddSoldier.Text = "Add Soldier";
            this.buttonAddSoldier.UseVisualStyleBackColor = true;
            this.buttonAddSoldier.Click += new System.EventHandler(this.buttonAddSoldier_Click);
            // 
            // buttonRemoveSoldier
            // 
            this.buttonRemoveSoldier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveSoldier.Location = new System.Drawing.Point(174, 527);
            this.buttonRemoveSoldier.Name = "buttonRemoveSoldier";
            this.buttonRemoveSoldier.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveSoldier.TabIndex = 4;
            this.buttonRemoveSoldier.Text = "Remove";
            this.buttonRemoveSoldier.UseVisualStyleBackColor = true;
            this.buttonRemoveSoldier.Click += new System.EventHandler(this.buttonRemoveSoldier_Click);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilter.Location = new System.Drawing.Point(818, 529);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(264, 20);
            this.textBoxFilter.TabIndex = 5;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            // 
            // labelFilter
            // 
            this.labelFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFilter.AutoSize = true;
            this.labelFilter.Location = new System.Drawing.Point(749, 532);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(63, 13);
            this.labelFilter.TabIndex = 6;
            this.labelFilter.Text = "Name Filter:";
            // 
            // buttonSubmitToMaster
            // 
            this.buttonSubmitToMaster.Location = new System.Drawing.Point(356, 527);
            this.buttonSubmitToMaster.Name = "buttonSubmitToMaster";
            this.buttonSubmitToMaster.Size = new System.Drawing.Size(103, 23);
            this.buttonSubmitToMaster.TabIndex = 7;
            this.buttonSubmitToMaster.Text = "Sumbit To Master";
            this.buttonSubmitToMaster.UseVisualStyleBackColor = true;
            this.buttonSubmitToMaster.Visible = false;
            this.buttonSubmitToMaster.Click += new System.EventHandler(this.buttonSubmitToMaster_Click);
            // 
            // buttonCreateDuplicate
            // 
            this.buttonCreateDuplicate.Location = new System.Drawing.Point(255, 527);
            this.buttonCreateDuplicate.Name = "buttonCreateDuplicate";
            this.buttonCreateDuplicate.Size = new System.Drawing.Size(95, 23);
            this.buttonCreateDuplicate.TabIndex = 8;
            this.buttonCreateDuplicate.Text = "Create Duplicate";
            this.buttonCreateDuplicate.UseVisualStyleBackColor = true;
            this.buttonCreateDuplicate.Click += new System.EventHandler(this.buttonCreateDuplicate_Click);
            // 
            // SoldiersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 558);
            this.Controls.Add(this.buttonCreateDuplicate);
            this.Controls.Add(this.buttonSubmitToMaster);
            this.Controls.Add(this.labelFilter);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.buttonRemoveSoldier);
            this.Controls.Add(this.buttonAddSoldier);
            this.Controls.Add(this.buttonDetails);
            this.Controls.Add(this.listViewSoldiers);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "SoldiersForm";
            this.Text = "Revolutionary War Soldiers";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListView listViewSoldiers;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem menuStripView;
        private System.Windows.Forms.ToolStripMenuItem menuStripViewSoldierList;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.Button buttonAddSoldier;
        private System.Windows.Forms.Button buttonRemoveSoldier;
        private System.Windows.Forms.ToolStripMenuItem menuStripHelp;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemAbout;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemPrintBook;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemOpenDatabase;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemPrintLatexBook;
        private System.Windows.Forms.Button buttonSubmitToMaster;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemCreateDatabase;
        private System.Windows.Forms.Button buttonCreateDuplicate;
        private System.Windows.Forms.ToolStripMenuItem menuStripItemAdvancedSearch;
    }
}

