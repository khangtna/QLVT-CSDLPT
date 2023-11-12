
namespace qlvt_v2
{
    partial class frmNCC
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ccbCN = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dS = new qlvt_v2.DS();
            this.nhaCungCapBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nhaCungCapTableAdapter = new qlvt_v2.DSTableAdapters.NhaCungCapTableAdapter();
            this.tableAdapterManager = new qlvt_v2.DSTableAdapters.TableAdapterManager();
            this.nhaCungCapGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMANCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSODIENTHOAI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrowguid = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhaCungCapBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhaCungCapGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ccbCN);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 66);
            this.panelControl1.TabIndex = 6;
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
            // nhaCungCapBindingSource
            // 
            this.nhaCungCapBindingSource.DataMember = "NhaCungCap";
            this.nhaCungCapBindingSource.DataSource = this.dS;
            // 
            // nhaCungCapTableAdapter
            // 
            this.nhaCungCapTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChiNhanhTableAdapter = null;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTHDTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.DonDatHangTableAdapter = null;
            this.tableAdapterManager.HangHoaTableAdapter = null;
            this.tableAdapterManager.HOADONTableAdapter = null;
            this.tableAdapterManager.KhachHangTableAdapter = null;
            this.tableAdapterManager.KHOTableAdapter = null;
            this.tableAdapterManager.LoaiHangTableAdapter = null;
            this.tableAdapterManager.NhaCungCapTableAdapter = this.nhaCungCapTableAdapter;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = qlvt_v2.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // nhaCungCapGridControl
            // 
            this.nhaCungCapGridControl.DataSource = this.nhaCungCapBindingSource;
            this.nhaCungCapGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.nhaCungCapGridControl.Location = new System.Drawing.Point(0, 66);
            this.nhaCungCapGridControl.MainView = this.gridView1;
            this.nhaCungCapGridControl.Name = "nhaCungCapGridControl";
            this.nhaCungCapGridControl.Size = new System.Drawing.Size(800, 220);
            this.nhaCungCapGridControl.TabIndex = 7;
            this.nhaCungCapGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMANCC,
            this.colTEN,
            this.colDIACHI,
            this.colSODIENTHOAI,
            this.colrowguid});
            this.gridView1.GridControl = this.nhaCungCapGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colMANCC
            // 
            this.colMANCC.FieldName = "MANCC";
            this.colMANCC.Name = "colMANCC";
            this.colMANCC.Visible = true;
            this.colMANCC.VisibleIndex = 0;
            // 
            // colTEN
            // 
            this.colTEN.FieldName = "TEN";
            this.colTEN.Name = "colTEN";
            this.colTEN.Visible = true;
            this.colTEN.VisibleIndex = 1;
            // 
            // colDIACHI
            // 
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 2;
            // 
            // colSODIENTHOAI
            // 
            this.colSODIENTHOAI.FieldName = "SODIENTHOAI";
            this.colSODIENTHOAI.Name = "colSODIENTHOAI";
            this.colSODIENTHOAI.Visible = true;
            this.colSODIENTHOAI.VisibleIndex = 3;
            // 
            // colrowguid
            // 
            this.colrowguid.FieldName = "rowguid";
            this.colrowguid.Name = "colrowguid";
            this.colrowguid.Visible = true;
            this.colrowguid.VisibleIndex = 4;
            // 
            // frmNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nhaCungCapGridControl);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmNCC";
            this.Text = "frmNCC";
            this.Load += new System.EventHandler(this.frmNCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhaCungCapBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhaCungCapGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox ccbCN;
        private System.Windows.Forms.Label label1;
        private DS dS;
        private System.Windows.Forms.BindingSource nhaCungCapBindingSource;
        private DSTableAdapters.NhaCungCapTableAdapter nhaCungCapTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl nhaCungCapGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMANCC;
        private DevExpress.XtraGrid.Columns.GridColumn colTEN;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colSODIENTHOAI;
        private DevExpress.XtraGrid.Columns.GridColumn colrowguid;
    }
}