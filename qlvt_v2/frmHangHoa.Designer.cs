
namespace qlvt_v2
{
    partial class frmHangHoa
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label aaa;
            System.Windows.Forms.Label mAHHLabel;
            System.Windows.Forms.Label dVTLabel;
            System.Windows.Forms.Label mALHLabel;
            System.Windows.Forms.Label sOLUONGTONLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHangHoa));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnSua = new DevExpress.XtraBars.BarButtonItem();
            this.btnGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnPH = new DevExpress.XtraBars.BarButtonItem();
            this.btnReload = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ccbCN = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dS = new qlvt_v2.DS();
            this.bdsHH = new System.Windows.Forms.BindingSource(this.components);
            this.hangHoaTableAdapter = new qlvt_v2.DSTableAdapters.HangHoaTableAdapter();
            this.tableAdapterManager = new qlvt_v2.DSTableAdapters.TableAdapterManager();
            this.cTDDHTableAdapter = new qlvt_v2.DSTableAdapters.CTDDHTableAdapter();
            this.bdsCTDH = new System.Windows.Forms.BindingSource(this.components);
            this.dbsCTHD = new System.Windows.Forms.BindingSource(this.components);
            this.cTHDTableAdapter = new qlvt_v2.DSTableAdapters.CTHDTableAdapter();
            this.bdsCTPN = new System.Windows.Forms.BindingSource(this.components);
            this.cTPNTableAdapter = new qlvt_v2.DSTableAdapters.CTPNTableAdapter();
            this.txtTEN = new DevExpress.XtraEditors.TextEdit();
            this.txtMAHH = new DevExpress.XtraEditors.TextEdit();
            this.txtDVT = new DevExpress.XtraEditors.TextEdit();
            this.ccbMALH = new System.Windows.Forms.ComboBox();
            this.pnTT = new DevExpress.XtraEditors.PanelControl();
            this.txtSLT = new DevExpress.XtraEditors.TextEdit();
            this.gcHH = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOLUONGTON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMALH = new DevExpress.XtraGrid.Columns.GridColumn();
            aaa = new System.Windows.Forms.Label();
            mAHHLabel = new System.Windows.Forms.Label();
            dVTLabel = new System.Windows.Forms.Label();
            mALHLabel = new System.Windows.Forms.Label();
            sOLUONGTONLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsHH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsCTHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTPN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMAHH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDVT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnTT)).BeginInit();
            this.pnTT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSLT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // aaa
            // 
            aaa.AutoSize = true;
            aaa.Location = new System.Drawing.Point(55, 118);
            aaa.Name = "aaa";
            aaa.Size = new System.Drawing.Size(44, 13);
            aaa.TabIndex = 0;
            aaa.Text = "TENHH:";
            // 
            // mAHHLabel
            // 
            mAHHLabel.AutoSize = true;
            mAHHLabel.Location = new System.Drawing.Point(59, 74);
            mAHHLabel.Name = "mAHHLabel";
            mAHHLabel.Size = new System.Drawing.Size(40, 13);
            mAHHLabel.TabIndex = 2;
            mAHHLabel.Text = "MAHH:";
            // 
            // dVTLabel
            // 
            dVTLabel.AutoSize = true;
            dVTLabel.Location = new System.Drawing.Point(69, 164);
            dVTLabel.Name = "dVTLabel";
            dVTLabel.Size = new System.Drawing.Size(30, 13);
            dVTLabel.TabIndex = 4;
            dVTLabel.Text = "DVT:";
            // 
            // mALHLabel
            // 
            mALHLabel.AutoSize = true;
            mALHLabel.Location = new System.Drawing.Point(316, 113);
            mALHLabel.Name = "mALHLabel";
            mALHLabel.Size = new System.Drawing.Size(38, 13);
            mALHLabel.TabIndex = 8;
            mALHLabel.Text = "MALH:";
            // 
            // sOLUONGTONLabel
            // 
            sOLUONGTONLabel.AutoSize = true;
            sOLUONGTONLabel.Location = new System.Drawing.Point(274, 70);
            sOLUONGTONLabel.Name = "sOLUONGTONLabel";
            sOLUONGTONLabel.Size = new System.Drawing.Size(80, 13);
            sOLUONGTONLabel.TabIndex = 9;
            sOLUONGTONLabel.Text = "SOLUONGTON:";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockWindowTabFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnSua,
            this.btnGhi,
            this.btnXoa,
            this.btnPH,
            this.btnReload,
            this.btnExit});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThem),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSua),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGhi),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnXoa),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPH),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnReload),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit)});
            this.bar1.Text = "Tools";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.LargeImage")));
            this.btnThem.Name = "btnThem";
            this.btnThem.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnSua
            // 
            this.btnSua.Caption = "Sửa";
            this.btnSua.Id = 1;
            this.btnSua.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.Image")));
            this.btnSua.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSua.ImageOptions.LargeImage")));
            this.btnSua.Name = "btnSua";
            this.btnSua.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSua_ItemClick);
            // 
            // btnGhi
            // 
            this.btnGhi.Caption = "Ghi";
            this.btnGhi.Id = 2;
            this.btnGhi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGhi.ImageOptions.Image")));
            this.btnGhi.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGhi.ImageOptions.LargeImage")));
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnGhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnGhi_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xoá";
            this.btnXoa.Id = 3;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.LargeImage")));
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnPH
            // 
            this.btnPH.Caption = "Phục hồi";
            this.btnPH.Id = 4;
            this.btnPH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPH.ImageOptions.Image")));
            this.btnPH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPH.ImageOptions.LargeImage")));
            this.btnPH.Name = "btnPH";
            this.btnPH.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnPH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPH_ItemClick);
            // 
            // btnReload
            // 
            this.btnReload.Caption = "Reload";
            this.btnReload.Id = 5;
            this.btnReload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.ImageOptions.Image")));
            this.btnReload.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnReload.ImageOptions.LargeImage")));
            this.btnReload.Name = "btnReload";
            this.btnReload.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.Id = 6;
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.LargeImage")));
            this.btnExit.Name = "btnExit";
            this.btnExit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1009, 45);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 793);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1009, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 45);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 748);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1009, 45);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 748);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ccbCN);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1009, 66);
            this.panelControl1.TabIndex = 5;
            // 
            // ccbCN
            // 
            this.ccbCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ccbCN.FormattingEnabled = true;
            this.ccbCN.Location = new System.Drawing.Point(138, 21);
            this.ccbCN.Name = "ccbCN";
            this.ccbCN.Size = new System.Drawing.Size(327, 21);
            this.ccbCN.TabIndex = 1;
            this.ccbCN.SelectedIndexChanged += new System.EventHandler(this.ccbCN_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi nhánh: ";
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsHH
            // 
            this.bdsHH.DataMember = "HangHoa";
            this.bdsHH.DataSource = this.dS;
            // 
            // hangHoaTableAdapter
            // 
            this.hangHoaTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.CTDDHTableAdapter = this.cTDDHTableAdapter;
            this.tableAdapterManager.CTHDTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.DonDatHangTableAdapter = null;
            this.tableAdapterManager.HangHoaTableAdapter = this.hangHoaTableAdapter;
            this.tableAdapterManager.HOADONTableAdapter = null;
            this.tableAdapterManager.KhachHangTableAdapter = null;
            this.tableAdapterManager.KHOTableAdapter = null;
            this.tableAdapterManager.LoaiHangTableAdapter = null;
            this.tableAdapterManager.NhaCungCapTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = qlvt_v2.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // cTDDHTableAdapter
            // 
            this.cTDDHTableAdapter.ClearBeforeFill = true;
            // 
            // bdsCTDH
            // 
            this.bdsCTDH.DataMember = "FK_CTDDH_HangHoa";
            this.bdsCTDH.DataSource = this.bdsHH;
            // 
            // dbsCTHD
            // 
            this.dbsCTHD.DataMember = "FK_CTHD_HangHoa";
            this.dbsCTHD.DataSource = this.bdsHH;
            // 
            // cTHDTableAdapter
            // 
            this.cTHDTableAdapter.ClearBeforeFill = true;
            // 
            // bdsCTPN
            // 
            this.bdsCTPN.DataMember = "FK_CTPN_HangHoa";
            this.bdsCTPN.DataSource = this.bdsHH;
            // 
            // cTPNTableAdapter
            // 
            this.cTPNTableAdapter.ClearBeforeFill = true;
            // 
            // txtTEN
            // 
            this.txtTEN.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsHH, "TENHH", true));
            this.txtTEN.Location = new System.Drawing.Point(105, 115);
            this.txtTEN.MenuManager = this.barManager1;
            this.txtTEN.Name = "txtTEN";
            this.txtTEN.Size = new System.Drawing.Size(100, 20);
            this.txtTEN.TabIndex = 1;
            // 
            // txtMAHH
            // 
            this.txtMAHH.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsHH, "MAHH", true));
            this.txtMAHH.Location = new System.Drawing.Point(105, 71);
            this.txtMAHH.MenuManager = this.barManager1;
            this.txtMAHH.Name = "txtMAHH";
            this.txtMAHH.Size = new System.Drawing.Size(100, 20);
            this.txtMAHH.TabIndex = 3;
            // 
            // txtDVT
            // 
            this.txtDVT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsHH, "DVT", true));
            this.txtDVT.Location = new System.Drawing.Point(105, 161);
            this.txtDVT.MenuManager = this.barManager1;
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(100, 20);
            this.txtDVT.TabIndex = 5;
            // 
            // ccbMALH
            // 
            this.ccbMALH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsHH, "MALH", true));
            this.ccbMALH.FormattingEnabled = true;
            this.ccbMALH.Location = new System.Drawing.Point(360, 110);
            this.ccbMALH.Name = "ccbMALH";
            this.ccbMALH.Size = new System.Drawing.Size(121, 21);
            this.ccbMALH.TabIndex = 9;
            this.ccbMALH.SelectedIndexChanged += new System.EventHandler(this.ccbMALH_SelectedIndexChanged);
            // 
            // pnTT
            // 
            this.pnTT.Controls.Add(sOLUONGTONLabel);
            this.pnTT.Controls.Add(this.txtSLT);
            this.pnTT.Controls.Add(mALHLabel);
            this.pnTT.Controls.Add(this.ccbMALH);
            this.pnTT.Controls.Add(dVTLabel);
            this.pnTT.Controls.Add(this.txtDVT);
            this.pnTT.Controls.Add(mAHHLabel);
            this.pnTT.Controls.Add(this.txtMAHH);
            this.pnTT.Controls.Add(aaa);
            this.pnTT.Controls.Add(this.txtTEN);
            this.pnTT.Location = new System.Drawing.Point(0, 331);
            this.pnTT.Name = "pnTT";
            this.pnTT.Size = new System.Drawing.Size(1009, 462);
            this.pnTT.TabIndex = 7;
            // 
            // txtSLT
            // 
            this.txtSLT.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsHH, "SOLUONGTON", true));
            this.txtSLT.Location = new System.Drawing.Point(360, 67);
            this.txtSLT.MenuManager = this.barManager1;
            this.txtSLT.Name = "txtSLT";
            this.txtSLT.Size = new System.Drawing.Size(100, 20);
            this.txtSLT.TabIndex = 10;
            // 
            // gcHH
            // 
            this.gcHH.DataSource = this.bdsHH;
            this.gcHH.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcHH.Location = new System.Drawing.Point(0, 111);
            this.gcHH.MainView = this.gridView2;
            this.gcHH.MenuManager = this.barManager1;
            this.gcHH.Name = "gcHH";
            this.gcHH.Size = new System.Drawing.Size(1009, 220);
            this.gcHH.TabIndex = 10;
            this.gcHH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAHH,
            this.colTENHH,
            this.colDVT,
            this.colSOLUONGTON,
            this.colMALH});
            this.gridView2.GridControl = this.gcHH;
            this.gridView2.Name = "gridView2";
            // 
            // colMAHH
            // 
            this.colMAHH.FieldName = "MAHH";
            this.colMAHH.Name = "colMAHH";
            this.colMAHH.Visible = true;
            this.colMAHH.VisibleIndex = 0;
            // 
            // colTENHH
            // 
            this.colTENHH.FieldName = "TENHH";
            this.colTENHH.Name = "colTENHH";
            this.colTENHH.Visible = true;
            this.colTENHH.VisibleIndex = 1;
            // 
            // colDVT
            // 
            this.colDVT.FieldName = "DVT";
            this.colDVT.Name = "colDVT";
            this.colDVT.Visible = true;
            this.colDVT.VisibleIndex = 2;
            // 
            // colSOLUONGTON
            // 
            this.colSOLUONGTON.FieldName = "SOLUONGTON";
            this.colSOLUONGTON.Name = "colSOLUONGTON";
            this.colSOLUONGTON.Visible = true;
            this.colSOLUONGTON.VisibleIndex = 3;
            // 
            // colMALH
            // 
            this.colMALH.FieldName = "MALH";
            this.colMALH.Name = "colMALH";
            this.colMALH.Visible = true;
            this.colMALH.VisibleIndex = 4;
            // 
            // frmHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1009, 749);
            this.Controls.Add(this.gcHH);
            this.Controls.Add(this.pnTT);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmHangHoa";
            this.Text = "frmHangHoa";
            this.Load += new System.EventHandler(this.frmHangHoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsHH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsCTHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCTPN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTEN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMAHH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDVT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnTT)).EndInit();
            this.pnTT.ResumeLayout(false);
            this.pnTT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSLT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcHH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnSua;
        private DevExpress.XtraBars.BarButtonItem btnGhi;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnPH;
        private DevExpress.XtraBars.BarButtonItem btnReload;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox ccbCN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bdsHH;
        private DS dS;
        private DSTableAdapters.HangHoaTableAdapter hangHoaTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DSTableAdapters.CTDDHTableAdapter cTDDHTableAdapter;
        private System.Windows.Forms.BindingSource bdsCTDH;
        private System.Windows.Forms.BindingSource dbsCTHD;
        private DSTableAdapters.CTHDTableAdapter cTHDTableAdapter;
        private System.Windows.Forms.BindingSource bdsCTPN;
        private DSTableAdapters.CTPNTableAdapter cTPNTableAdapter;
        private DevExpress.XtraEditors.PanelControl pnTT;
        private DevExpress.XtraEditors.TextEdit txtSLT;
        private System.Windows.Forms.ComboBox ccbMALH;
        private DevExpress.XtraEditors.TextEdit txtDVT;
        private DevExpress.XtraEditors.TextEdit txtMAHH;
        private DevExpress.XtraEditors.TextEdit txtTEN;
        private DevExpress.XtraGrid.GridControl gcHH;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colMAHH;
        private DevExpress.XtraGrid.Columns.GridColumn colTENHH;
        private DevExpress.XtraGrid.Columns.GridColumn colDVT;
        private DevExpress.XtraGrid.Columns.GridColumn colSOLUONGTON;
        private DevExpress.XtraGrid.Columns.GridColumn colMALH;
    }
}