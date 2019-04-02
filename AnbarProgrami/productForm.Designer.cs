namespace AnbarProgrami
{
    partial class productForm
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                
                if (baqlanti != null)
                {
                    baqlanti.Dispose();
                    baqlanti = null;
                }
                if (kommand != null)
                {
                    kommand.Dispose();
                    kommand = null;
                }
                if (table != null)
                {
                    table.Dispose();
                    table = null;
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(productForm));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode4 = new DevExpress.XtraGrid.GridLevelNode();
            this.addEditGroupBox = new System.Windows.Forms.GroupBox();
            this.KategoryComboBox = new System.Windows.Forms.ComboBox();
            this.kategiryLabel = new System.Windows.Forms.Label();
            this.mehsulNoteTxt = new System.Windows.Forms.TextBox();
            this.productNoteLabel = new System.Windows.Forms.Label();
            this.mehsulUnitTxt = new System.Windows.Forms.TextBox();
            this.mehsulTypeTxt = new System.Windows.Forms.TextBox();
            this.mehsulNameTxt = new System.Windows.Forms.TextBox();
            this.productUnitLabel = new System.Windows.Forms.Label();
            this.productTypeLabel = new System.Windows.Forms.Label();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cancelSearchBtn = new DevExpress.XtraEditors.SimpleButton();
            this.chooseLabel = new System.Windows.Forms.Label();
            this.searchLabel = new System.Windows.Forms.Label();
            this.excellexportBtn = new DevExpress.XtraEditors.SimpleButton();
            this.deleteEditeFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.showEditBtn = new DevExpress.XtraEditors.SimpleButton();
            this.hideEditBtn = new DevExpress.XtraEditors.SimpleButton();
            this.showDeleteBtn = new DevExpress.XtraEditors.SimpleButton();
            this.hideDeleteBtn = new DevExpress.XtraEditors.SimpleButton();
            this.commonFLPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addEditFLPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addBtn = new DevExpress.XtraEditors.SimpleButton();
            this.editBtn = new DevExpress.XtraEditors.SimpleButton();
            this.deleteBtn = new DevExpress.XtraEditors.SimpleButton();
            this.addEditGFLPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addGBtn = new DevExpress.XtraEditors.SimpleButton();
            this.editGBtn = new DevExpress.XtraEditors.SimpleButton();
            this.hideGBtn = new DevExpress.XtraEditors.SimpleButton();
            this.DGV = new DevExpress.XtraGrid.GridControl();
            this.DGW = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.addEditGroupBox.SuspendLayout();
            this.deleteEditeFlowLayoutPanel.SuspendLayout();
            this.commonFLPanel.SuspendLayout();
            this.addEditFLPanel.SuspendLayout();
            this.addEditGFLPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addEditGroupBox
            // 
            this.addEditGroupBox.Controls.Add(this.KategoryComboBox);
            this.addEditGroupBox.Controls.Add(this.kategiryLabel);
            this.addEditGroupBox.Controls.Add(this.mehsulNoteTxt);
            this.addEditGroupBox.Controls.Add(this.productNoteLabel);
            this.addEditGroupBox.Controls.Add(this.mehsulUnitTxt);
            this.addEditGroupBox.Controls.Add(this.mehsulTypeTxt);
            this.addEditGroupBox.Controls.Add(this.mehsulNameTxt);
            this.addEditGroupBox.Controls.Add(this.productUnitLabel);
            this.addEditGroupBox.Controls.Add(this.productTypeLabel);
            this.addEditGroupBox.Controls.Add(this.productNameLabel);
            this.addEditGroupBox.Location = new System.Drawing.Point(3, 42);
            this.addEditGroupBox.Name = "addEditGroupBox";
            this.addEditGroupBox.Size = new System.Drawing.Size(374, 142);
            this.addEditGroupBox.TabIndex = 39;
            this.addEditGroupBox.TabStop = false;
            this.addEditGroupBox.Visible = false;
            // 
            // KategoryComboBox
            // 
            this.KategoryComboBox.FormattingEnabled = true;
            this.KategoryComboBox.Location = new System.Drawing.Point(119, 9);
            this.KategoryComboBox.Name = "KategoryComboBox";
            this.KategoryComboBox.Size = new System.Drawing.Size(238, 21);
            this.KategoryComboBox.TabIndex = 81;
            // 
            // kategiryLabel
            // 
            this.kategiryLabel.AutoSize = true;
            this.kategiryLabel.Location = new System.Drawing.Point(6, 12);
            this.kategiryLabel.Name = "kategiryLabel";
            this.kategiryLabel.Size = new System.Drawing.Size(112, 13);
            this.kategiryLabel.TabIndex = 42;
            this.kategiryLabel.Text = "Məhsulun kategoriyası";
            // 
            // mehsulNoteTxt
            // 
            this.mehsulNoteTxt.Location = new System.Drawing.Point(119, 114);
            this.mehsulNoteTxt.Name = "mehsulNoteTxt";
            this.mehsulNoteTxt.Size = new System.Drawing.Size(237, 20);
            this.mehsulNoteTxt.TabIndex = 40;
            // 
            // productNoteLabel
            // 
            this.productNoteLabel.AutoSize = true;
            this.productNoteLabel.Location = new System.Drawing.Point(6, 117);
            this.productNoteLabel.Name = "productNoteLabel";
            this.productNoteLabel.Size = new System.Drawing.Size(32, 13);
            this.productNoteLabel.TabIndex = 39;
            this.productNoteLabel.Text = "Qeyd";
            // 
            // mehsulUnitTxt
            // 
            this.mehsulUnitTxt.Location = new System.Drawing.Point(119, 87);
            this.mehsulUnitTxt.Name = "mehsulUnitTxt";
            this.mehsulUnitTxt.Size = new System.Drawing.Size(237, 20);
            this.mehsulUnitTxt.TabIndex = 32;
            // 
            // mehsulTypeTxt
            // 
            this.mehsulTypeTxt.Location = new System.Drawing.Point(119, 61);
            this.mehsulTypeTxt.Name = "mehsulTypeTxt";
            this.mehsulTypeTxt.Size = new System.Drawing.Size(237, 20);
            this.mehsulTypeTxt.TabIndex = 31;
            // 
            // mehsulNameTxt
            // 
            this.mehsulNameTxt.Location = new System.Drawing.Point(119, 35);
            this.mehsulNameTxt.Name = "mehsulNameTxt";
            this.mehsulNameTxt.Size = new System.Drawing.Size(237, 20);
            this.mehsulNameTxt.TabIndex = 30;
            // 
            // productUnitLabel
            // 
            this.productUnitLabel.AutoSize = true;
            this.productUnitLabel.Location = new System.Drawing.Point(6, 90);
            this.productUnitLabel.Name = "productUnitLabel";
            this.productUnitLabel.Size = new System.Drawing.Size(107, 13);
            this.productUnitLabel.TabIndex = 28;
            this.productUnitLabel.Text = "Məhsulun ölçü vahidi";
            // 
            // productTypeLabel
            // 
            this.productTypeLabel.AutoSize = true;
            this.productTypeLabel.Location = new System.Drawing.Point(6, 64);
            this.productTypeLabel.Name = "productTypeLabel";
            this.productTypeLabel.Size = new System.Drawing.Size(80, 13);
            this.productTypeLabel.TabIndex = 27;
            this.productTypeLabel.Text = "Məhsulun növü";
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Location = new System.Drawing.Point(6, 38);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(70, 13);
            this.productNameLabel.TabIndex = 26;
            this.productNameLabel.Text = "Məhsulun adı";
            // 
            // cancelSearchBtn
            // 
            this.cancelSearchBtn.Location = new System.Drawing.Point(0, 0);
            this.cancelSearchBtn.Name = "cancelSearchBtn";
            this.cancelSearchBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelSearchBtn.TabIndex = 0;
            // 
            // chooseLabel
            // 
            this.chooseLabel.AutoSize = true;
            this.chooseLabel.Location = new System.Drawing.Point(50, 11);
            this.chooseLabel.Name = "chooseLabel";
            this.chooseLabel.Size = new System.Drawing.Size(26, 13);
            this.chooseLabel.TabIndex = 48;
            this.chooseLabel.Text = "Seç";
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(198, 11);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(31, 13);
            this.searchLabel.TabIndex = 49;
            this.searchLabel.Text = "Axtar";
            // 
            // excellexportBtn
            // 
            this.excellexportBtn.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excellexportBtn.Appearance.Options.UseFont = true;
            this.excellexportBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.excellexportBtn.Image = ((System.Drawing.Image)(resources.GetObject("excellexportBtn.Image")));
            this.excellexportBtn.Location = new System.Drawing.Point(397, 32);
            this.excellexportBtn.Name = "excellexportBtn";
            this.excellexportBtn.Size = new System.Drawing.Size(119, 24);
            this.excellexportBtn.TabIndex = 78;
            this.excellexportBtn.Text = "Excell ə yazdır";
            this.excellexportBtn.Click += new System.EventHandler(this.excellexportBtn_Click);
            // 
            // deleteEditeFlowLayoutPanel
            // 
            this.deleteEditeFlowLayoutPanel.Controls.Add(this.showEditBtn);
            this.deleteEditeFlowLayoutPanel.Controls.Add(this.hideEditBtn);
            this.deleteEditeFlowLayoutPanel.Controls.Add(this.showDeleteBtn);
            this.deleteEditeFlowLayoutPanel.Controls.Add(this.hideDeleteBtn);
            this.deleteEditeFlowLayoutPanel.Location = new System.Drawing.Point(532, 29);
            this.deleteEditeFlowLayoutPanel.Name = "deleteEditeFlowLayoutPanel";
            this.deleteEditeFlowLayoutPanel.Size = new System.Drawing.Size(590, 27);
            this.deleteEditeFlowLayoutPanel.TabIndex = 79;
            // 
            // showEditBtn
            // 
            this.showEditBtn.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showEditBtn.Appearance.Options.UseFont = true;
            this.showEditBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.showEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("showEditBtn.Image")));
            this.showEditBtn.Location = new System.Drawing.Point(3, 3);
            this.showEditBtn.Name = "showEditBtn";
            this.showEditBtn.Size = new System.Drawing.Size(166, 23);
            this.showEditBtn.TabIndex = 16;
            this.showEditBtn.Text = "Redaktə olanları göstər";
            this.showEditBtn.Click += new System.EventHandler(this.showEditBtn_Click);
            // 
            // hideEditBtn
            // 
            this.hideEditBtn.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hideEditBtn.Appearance.Options.UseFont = true;
            this.hideEditBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.hideEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("hideEditBtn.Image")));
            this.hideEditBtn.Location = new System.Drawing.Point(175, 3);
            this.hideEditBtn.Name = "hideEditBtn";
            this.hideEditBtn.Size = new System.Drawing.Size(157, 24);
            this.hideEditBtn.TabIndex = 17;
            this.hideEditBtn.Text = "Redaktə olanları gizlə";
            this.hideEditBtn.Visible = false;
            this.hideEditBtn.Click += new System.EventHandler(this.hideEditBtn_Click);
            // 
            // showDeleteBtn
            // 
            this.showDeleteBtn.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showDeleteBtn.Appearance.Options.UseFont = true;
            this.showDeleteBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.showDeleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("showDeleteBtn.Image")));
            this.showDeleteBtn.Location = new System.Drawing.Point(338, 3);
            this.showDeleteBtn.Name = "showDeleteBtn";
            this.showDeleteBtn.Size = new System.Drawing.Size(123, 24);
            this.showDeleteBtn.TabIndex = 18;
            this.showDeleteBtn.Text = "Silinənləri göstər";
            this.showDeleteBtn.Click += new System.EventHandler(this.showDeleteBtn_Click);
            // 
            // hideDeleteBtn
            // 
            this.hideDeleteBtn.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hideDeleteBtn.Appearance.Options.UseFont = true;
            this.hideDeleteBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.hideDeleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("hideDeleteBtn.Image")));
            this.hideDeleteBtn.Location = new System.Drawing.Point(467, 3);
            this.hideDeleteBtn.Name = "hideDeleteBtn";
            this.hideDeleteBtn.Size = new System.Drawing.Size(115, 24);
            this.hideDeleteBtn.TabIndex = 19;
            this.hideDeleteBtn.Text = "Silinənləri gizlə";
            this.hideDeleteBtn.Visible = false;
            this.hideDeleteBtn.Click += new System.EventHandler(this.hideDeleteBtn_Click);
            // 
            // commonFLPanel
            // 
            this.commonFLPanel.Controls.Add(this.addEditFLPanel);
            this.commonFLPanel.Controls.Add(this.addEditGroupBox);
            this.commonFLPanel.Controls.Add(this.addEditGFLPanel);
            this.commonFLPanel.Location = new System.Drawing.Point(9, 32);
            this.commonFLPanel.Name = "commonFLPanel";
            this.commonFLPanel.Size = new System.Drawing.Size(382, 235);
            this.commonFLPanel.TabIndex = 80;
            // 
            // addEditFLPanel
            // 
            this.addEditFLPanel.Controls.Add(this.addBtn);
            this.addEditFLPanel.Controls.Add(this.editBtn);
            this.addEditFLPanel.Controls.Add(this.deleteBtn);
            this.addEditFLPanel.Location = new System.Drawing.Point(3, 3);
            this.addEditFLPanel.Name = "addEditFLPanel";
            this.addEditFLPanel.Size = new System.Drawing.Size(357, 33);
            this.addEditFLPanel.TabIndex = 78;
            // 
            // addBtn
            // 
            this.addBtn.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Appearance.Options.UseFont = true;
            this.addBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.addBtn.Image = ((System.Drawing.Image)(resources.GetObject("addBtn.Image")));
            this.addBtn.Location = new System.Drawing.Point(3, 3);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(110, 24);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "Əlavə  et";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Appearance.Options.UseFont = true;
            this.editBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.editBtn.Image = ((System.Drawing.Image)(resources.GetObject("editBtn.Image")));
            this.editBtn.Location = new System.Drawing.Point(119, 3);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(117, 24);
            this.editBtn.TabIndex = 5;
            this.editBtn.Text = "Redaktə";
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Appearance.Options.UseFont = true;
            this.deleteBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.deleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteBtn.Image")));
            this.deleteBtn.Location = new System.Drawing.Point(242, 3);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(104, 24);
            this.deleteBtn.TabIndex = 6;
            this.deleteBtn.Text = "Sil";
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // addEditGFLPanel
            // 
            this.addEditGFLPanel.Controls.Add(this.addGBtn);
            this.addEditGFLPanel.Controls.Add(this.editGBtn);
            this.addEditGFLPanel.Controls.Add(this.hideGBtn);
            this.addEditGFLPanel.Location = new System.Drawing.Point(3, 190);
            this.addEditGFLPanel.Name = "addEditGFLPanel";
            this.addEditGFLPanel.Size = new System.Drawing.Size(357, 32);
            this.addEditGFLPanel.TabIndex = 0;
            this.addEditGFLPanel.Visible = false;
            // 
            // addGBtn
            // 
            this.addGBtn.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addGBtn.Appearance.Options.UseFont = true;
            this.addGBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.addGBtn.Image = ((System.Drawing.Image)(resources.GetObject("addGBtn.Image")));
            this.addGBtn.Location = new System.Drawing.Point(3, 3);
            this.addGBtn.Name = "addGBtn";
            this.addGBtn.Size = new System.Drawing.Size(110, 24);
            this.addGBtn.TabIndex = 12;
            this.addGBtn.Text = "Əlavə  et";
            this.addGBtn.Click += new System.EventHandler(this.addGBtn_Click);
            // 
            // editGBtn
            // 
            this.editGBtn.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editGBtn.Appearance.Options.UseFont = true;
            this.editGBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.editGBtn.Image = ((System.Drawing.Image)(resources.GetObject("editGBtn.Image")));
            this.editGBtn.Location = new System.Drawing.Point(119, 3);
            this.editGBtn.Name = "editGBtn";
            this.editGBtn.Size = new System.Drawing.Size(117, 24);
            this.editGBtn.TabIndex = 13;
            this.editGBtn.Text = "Redaktə";
            this.editGBtn.Click += new System.EventHandler(this.editGBtn_Click);
            // 
            // hideGBtn
            // 
            this.hideGBtn.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hideGBtn.Appearance.Options.UseFont = true;
            this.hideGBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.hideGBtn.Image = ((System.Drawing.Image)(resources.GetObject("hideGBtn.Image")));
            this.hideGBtn.Location = new System.Drawing.Point(242, 3);
            this.hideGBtn.Name = "hideGBtn";
            this.hideGBtn.Size = new System.Drawing.Size(104, 24);
            this.hideGBtn.TabIndex = 14;
            this.hideGBtn.Text = "Gizlə";
            this.hideGBtn.Click += new System.EventHandler(this.hideGBtn_Click);
            // 
            // DGV
            // 
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode3.RelationName = "Level1";
            gridLevelNode4.RelationName = "Level2";
            this.DGV.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode3,
            gridLevelNode4});
            this.DGV.Location = new System.Drawing.Point(397, 62);
            this.DGV.MainView = this.DGW;
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(730, 656);
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
            this.menuStrip1.Size = new System.Drawing.Size(1131, 24);
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
            // productForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 719);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.commonFLPanel);
            this.Controls.Add(this.excellexportBtn);
            this.Controls.Add(this.deleteEditeFlowLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "productForm";
            this.Text = "Məhsul səhifəsi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.productForm_FormClosed);
            this.Load += new System.EventHandler(this.ProductForm_Load);
            this.addEditGroupBox.ResumeLayout(false);
            this.addEditGroupBox.PerformLayout();
            this.deleteEditeFlowLayoutPanel.ResumeLayout(false);
            this.commonFLPanel.ResumeLayout(false);
            this.addEditFLPanel.ResumeLayout(false);
            this.addEditGFLPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGW)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox addEditGroupBox;
        private System.Windows.Forms.TextBox mehsulNoteTxt;
        private System.Windows.Forms.Label productNoteLabel;
        private System.Windows.Forms.TextBox mehsulUnitTxt;
        private System.Windows.Forms.TextBox mehsulTypeTxt;
        private System.Windows.Forms.TextBox mehsulNameTxt;
        private System.Windows.Forms.Label productUnitLabel;
        private System.Windows.Forms.Label productTypeLabel;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label chooseLabel;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.Label kategiryLabel;
        private DevExpress.XtraEditors.SimpleButton excellexportBtn;
        private System.Windows.Forms.FlowLayoutPanel deleteEditeFlowLayoutPanel;
        private DevExpress.XtraEditors.SimpleButton showEditBtn;
        private DevExpress.XtraEditors.SimpleButton hideEditBtn;
        private DevExpress.XtraEditors.SimpleButton showDeleteBtn;
        private DevExpress.XtraEditors.SimpleButton hideDeleteBtn;
        private System.Windows.Forms.FlowLayoutPanel commonFLPanel;
        private System.Windows.Forms.FlowLayoutPanel addEditFLPanel;
        private DevExpress.XtraEditors.SimpleButton addBtn;
        private DevExpress.XtraEditors.SimpleButton editBtn;
        private DevExpress.XtraEditors.SimpleButton deleteBtn;
        private System.Windows.Forms.FlowLayoutPanel addEditGFLPanel;
        private DevExpress.XtraEditors.SimpleButton addGBtn;
        private DevExpress.XtraEditors.SimpleButton editGBtn;
        private DevExpress.XtraEditors.SimpleButton hideGBtn;
        private DevExpress.XtraEditors.SimpleButton cancelSearchBtn;
        private System.Windows.Forms.ComboBox KategoryComboBox;
        private DevExpress.XtraGrid.GridControl DGV;
        private DevExpress.XtraGrid.Views.Grid.GridView DGW;
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
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem mailləGöndərToolStripMenuItem;
    }
}