namespace AnbarProgrami
{
    partial class ZAMehsul
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZAMehsul));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.excellexportBtn = new DevExpress.XtraEditors.SimpleButton();
            this.DGV1 = new DevExpress.XtraGrid.GridControl();
            this.DGW1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGW1)).BeginInit();
            this.SuspendLayout();
            // 
            // excellexportBtn
            // 
            this.excellexportBtn.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excellexportBtn.Appearance.Options.UseFont = true;
            this.excellexportBtn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.excellexportBtn.Image = ((System.Drawing.Image)(resources.GetObject("excellexportBtn.Image")));
            this.excellexportBtn.Location = new System.Drawing.Point(14, 30);
            this.excellexportBtn.Name = "excellexportBtn";
            this.excellexportBtn.Size = new System.Drawing.Size(119, 24);
            this.excellexportBtn.TabIndex = 127;
            this.excellexportBtn.Text = "Excell ə yazdır";
            this.excellexportBtn.Click += new System.EventHandler(this.excellexportBtn_Click);
            // 
            // DGV1
            // 
            this.DGV1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV1.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.RelationName = "Level1";
            gridLevelNode2.RelationName = "Level2";
            this.DGV1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.DGV1.Location = new System.Drawing.Point(195, 30);
            this.DGV1.MainView = this.DGW1;
            this.DGV1.Name = "DGV1";
            this.DGV1.Size = new System.Drawing.Size(449, 451);
            this.DGV1.TabIndex = 126;
            this.DGV1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.DGW1});
            this.DGV1.Visible = false;
            // 
            // DGW1
            // 
            this.DGW1.GridControl = this.DGV1;
            this.DGW1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.DGW1.Name = "DGW1";
            this.DGW1.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.DGW1.OptionsDetail.EnableMasterViewMode = false;
            this.DGW1.OptionsFind.FindNullPrompt = "Axtarılacaq sözü daxil edin...";
            this.DGW1.OptionsView.ColumnAutoWidth = false;
            this.DGW1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.DGW1.OptionsView.ShowAutoFilterRow = true;
            this.DGW1.OptionsView.ShowFooter = true;
            this.DGW1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // ZAMehsul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 483);
            this.Controls.Add(this.excellexportBtn);
            this.Controls.Add(this.DGV1);
            this.Name = "ZAMehsul";
            this.Text = "ZAMehsul";
            this.Load += new System.EventHandler(this.ZAMehsul_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGW1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton excellexportBtn;
        private DevExpress.XtraGrid.GridControl DGV1;
        private DevExpress.XtraGrid.Views.Grid.GridView DGW1;
    }
}