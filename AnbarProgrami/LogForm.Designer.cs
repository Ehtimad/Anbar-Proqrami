namespace AnbarProgrami
{
    partial class logForm
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(logForm));
            this.Ad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DGV = new DevExpress.XtraGrid.GridControl();
            this.DGW = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pagesToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.homePageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kateqoriyaSəhifəsiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.factoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alisZavodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hesabatlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ödənişlərToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alisSatisOdenisHesabatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.userChangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitprogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupÇıxarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailləGöndərToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.workerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ad
            // 
            this.Ad.Caption = "İşcinin ID-si";
            this.Ad.FieldName = "Ad";
            this.Ad.Name = "Ad";
            this.Ad.OptionsColumn.AllowEdit = false;
            this.Ad.Visible = true;
            this.Ad.VisibleIndex = 1;
            this.Ad.Width = 82;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "İşcinin ID-si";
            this.gridColumn1.FieldName = "Ad";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 82;
            // 
            // DGV
            // 
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.RelationName = "Level1";
            gridLevelNode2.RelationName = "Level2";
            this.DGV.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.DGV.Location = new System.Drawing.Point(0, 27);
            this.DGV.MainView = this.DGW;
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(813, 422);
            this.DGV.TabIndex = 97;
            this.DGV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DGW});
            // 
            // DGW
            // 
            this.DGW.GridControl = this.DGV;
            this.DGW.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.DGW.Name = "DGW";
            this.DGW.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.DGW.OptionsDetail.EnableMasterViewMode = false;
            this.DGW.OptionsFind.FindNullPrompt = "Axtarılacaq sözü daxil edin...";
            this.DGW.OptionsView.ColumnAutoWidth = false;
            this.DGW.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.DGW.OptionsView.ShowAutoFilterRow = true;
            this.DGW.OptionsView.ShowFooter = true;
            this.DGW.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pagesToolStripMenu,
            this.hesabatlarToolStripMenuItem,
            this.usersToolStripMenu,
            this.backupToolStripMenuItem,
            this.adminToolStripMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(813, 24);
            this.menuStrip1.TabIndex = 99;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pagesToolStripMenu
            // 
            this.pagesToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homePageToolStripMenuItem,
            this.kateqoriyaSəhifəsiToolStripMenuItem,
            this.productToolStripMenuItem,
            this.factoryToolStripMenuItem,
            this.marketToolStripMenuItem,
            this.alisZavodToolStripMenuItem,
            this.purchaseToolStripMenuItem,
            this.salesToolStripMenuItem});
            this.pagesToolStripMenu.Name = "pagesToolStripMenu";
            this.pagesToolStripMenu.Size = new System.Drawing.Size(64, 20);
            this.pagesToolStripMenu.Text = "Səhifələr";
            // 
            // homePageToolStripMenuItem
            // 
            this.homePageToolStripMenuItem.Name = "homePageToolStripMenuItem";
            this.homePageToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.homePageToolStripMenuItem.Text = "Ana səhifə";
            this.homePageToolStripMenuItem.Click += new System.EventHandler(this.homePageToolStripMenuItem_Click);
            // 
            // kateqoriyaSəhifəsiToolStripMenuItem
            // 
            this.kateqoriyaSəhifəsiToolStripMenuItem.Name = "kateqoriyaSəhifəsiToolStripMenuItem";
            this.kateqoriyaSəhifəsiToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.kateqoriyaSəhifəsiToolStripMenuItem.Text = "Kateqoriya səhifəsi";
            this.kateqoriyaSəhifəsiToolStripMenuItem.Click += new System.EventHandler(this.kateqoriyaSəhifəsiToolStripMenuItem_Click);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.productToolStripMenuItem.Text = "Məhsullar";
            this.productToolStripMenuItem.Click += new System.EventHandler(this.productToolStripMenuItem_Click);
            // 
            // factoryToolStripMenuItem
            // 
            this.factoryToolStripMenuItem.Name = "factoryToolStripMenuItem";
            this.factoryToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.factoryToolStripMenuItem.Text = "Zavodlar";
            this.factoryToolStripMenuItem.Click += new System.EventHandler(this.factoryToolStripMenuItem_Click);
            // 
            // marketToolStripMenuItem
            // 
            this.marketToolStripMenuItem.Name = "marketToolStripMenuItem";
            this.marketToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.marketToolStripMenuItem.Text = "Marketlər";
            this.marketToolStripMenuItem.Click += new System.EventHandler(this.marketToolStripMenuItem_Click);
            // 
            // alisZavodToolStripMenuItem
            // 
            this.alisZavodToolStripMenuItem.Name = "alisZavodToolStripMenuItem";
            this.alisZavodToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.alisZavodToolStripMenuItem.Text = "Qaimə";
            this.alisZavodToolStripMenuItem.Click += new System.EventHandler(this.alisZavodToolStripMenuItem_Click);
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.purchaseToolStripMenuItem.Text = "Alışlar";
            this.purchaseToolStripMenuItem.Click += new System.EventHandler(this.purchaseToolStripMenuItem_Click);
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.salesToolStripMenuItem.Text = "Satışlar";
            this.salesToolStripMenuItem.Click += new System.EventHandler(this.salesToolStripMenuItem_Click);
            // 
            // hesabatlarToolStripMenuItem
            // 
            this.hesabatlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ödənişlərToolStripMenuItem,
            this.alisSatisOdenisHesabatToolStripMenuItem});
            this.hesabatlarToolStripMenuItem.Name = "hesabatlarToolStripMenuItem";
            this.hesabatlarToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.hesabatlarToolStripMenuItem.Text = "Hesabatlar";
            // 
            // ödənişlərToolStripMenuItem
            // 
            this.ödənişlərToolStripMenuItem.Name = "ödənişlərToolStripMenuItem";
            this.ödənişlərToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.ödənişlərToolStripMenuItem.Text = "Ödənişlər";
            this.ödənişlərToolStripMenuItem.Click += new System.EventHandler(this.ödənişlərToolStripMenuItem_Click);
            // 
            // alisSatisOdenisHesabatToolStripMenuItem
            // 
            this.alisSatisOdenisHesabatToolStripMenuItem.Name = "alisSatisOdenisHesabatToolStripMenuItem";
            this.alisSatisOdenisHesabatToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.alisSatisOdenisHesabatToolStripMenuItem.Text = "Hesabatlar";
            this.alisSatisOdenisHesabatToolStripMenuItem.Click += new System.EventHandler(this.alisSatisOdenisHesabatToolStripMenuItem_Click);
            // 
            // usersToolStripMenu
            // 
            this.usersToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userChangeToolStripMenuItem,
            this.exitprogramToolStripMenuItem});
            this.usersToolStripMenu.Name = "usersToolStripMenu";
            this.usersToolStripMenu.Size = new System.Drawing.Size(79, 20);
            this.usersToolStripMenu.Text = "İstifadəçilər";
            // 
            // userChangeToolStripMenuItem
            // 
            this.userChangeToolStripMenuItem.Name = "userChangeToolStripMenuItem";
            this.userChangeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.userChangeToolStripMenuItem.Text = "İstifadəçini dəyiş";
            this.userChangeToolStripMenuItem.Click += new System.EventHandler(this.userChangeToolStripMenuItem_Click);
            // 
            // exitprogramToolStripMenuItem
            // 
            this.exitprogramToolStripMenuItem.Name = "exitprogramToolStripMenuItem";
            this.exitprogramToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.exitprogramToolStripMenuItem.Text = "Proqramı bağla";
            this.exitprogramToolStripMenuItem.Click += new System.EventHandler(this.exitprogramToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupÇıxarToolStripMenuItem,
            this.mailləGöndərToolStripMenuItem});
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.backupToolStripMenuItem.Text = "Backup";
            // 
            // backupÇıxarToolStripMenuItem
            // 
            this.backupÇıxarToolStripMenuItem.Name = "backupÇıxarToolStripMenuItem";
            this.backupÇıxarToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.backupÇıxarToolStripMenuItem.Text = "Backup çıxar";
            this.backupÇıxarToolStripMenuItem.Click += new System.EventHandler(this.backupÇıxarToolStripMenuItem_Click);
            // 
            // mailləGöndərToolStripMenuItem
            // 
            this.mailləGöndərToolStripMenuItem.Name = "mailləGöndərToolStripMenuItem";
            this.mailləGöndərToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.mailləGöndərToolStripMenuItem.Text = "Maillə Göndər";
            this.mailləGöndərToolStripMenuItem.Click += new System.EventHandler(this.mailləGöndərToolStripMenuItem_Click);
            // 
            // adminToolStripMenu
            // 
            this.adminToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.workerToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.logsToolStripMenuItem});
            this.adminToolStripMenu.Name = "adminToolStripMenu";
            this.adminToolStripMenu.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenu.Text = "Admin";
            // 
            // workerToolStripMenuItem
            // 
            this.workerToolStripMenuItem.Name = "workerToolStripMenuItem";
            this.workerToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.workerToolStripMenuItem.Text = "İşcilər";
            this.workerToolStripMenuItem.Click += new System.EventHandler(this.workerToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.usersToolStripMenuItem.Text = "İstifadəçilər";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.logsToolStripMenuItem.Text = "Loglar";
            this.logsToolStripMenuItem.Click += new System.EventHandler(this.logsToolStripMenuItem_Click);
            // 
            // logForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 452);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.DGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "logForm";
            this.Text = "Log səhifəsi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.logForm_FormClosed);
            this.Load += new System.EventHandler(this.LogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.Columns.GridColumn Ad;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.GridControl DGV;
        private DevExpress.XtraGrid.Views.Grid.GridView DGW;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pagesToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem homePageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kateqoriyaSəhifəsiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem factoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alisZavodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hesabatlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ödənişlərToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alisSatisOdenisHesabatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem userChangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitprogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupÇıxarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem workerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mailləGöndərToolStripMenuItem;
    }
}