
namespace qlvt_v2
{
    partial class frmrp_TongHopNhapXuat
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtTO = new DevExpress.XtraEditors.DateEdit();
            this.txtFROM = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ccbCN = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dS = new qlvt_v2.DS();
            this.hOADONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hOADONTableAdapter = new qlvt_v2.DSTableAdapters.HOADONTableAdapter();
            this.tableAdapterManager = new qlvt_v2.DSTableAdapters.TableAdapterManager();
            this.phieuNhapBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.phieuNhapTableAdapter = new qlvt_v2.DSTableAdapters.PhieuNhapTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTO.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFROM.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFROM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOADONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phieuNhapBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtTO);
            this.panelControl2.Controls.Add(this.txtFROM);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.label3);
            this.panelControl2.Controls.Add(this.btnExit);
            this.panelControl2.Controls.Add(this.btnPre);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 66);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(928, 100);
            this.panelControl2.TabIndex = 14;
            // 
            // txtTO
            // 
            this.txtTO.EditValue = null;
            this.txtTO.Location = new System.Drawing.Point(376, 36);
            this.txtTO.Name = "txtTO";
            this.txtTO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTO.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTO.Size = new System.Drawing.Size(100, 20);
            this.txtTO.TabIndex = 9;
            this.txtTO.EditValueChanged += new System.EventHandler(this.txtTO_EditValueChanged);
            // 
            // txtFROM
            // 
            this.txtFROM.EditValue = null;
            this.txtFROM.Location = new System.Drawing.Point(152, 36);
            this.txtFROM.Name = "txtFROM";
            this.txtFROM.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFROM.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFROM.Size = new System.Drawing.Size(100, 20);
            this.txtFROM.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Đến ngày:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Từ ngày:";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(687, 28);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 35);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(548, 28);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(101, 35);
            this.btnPre.TabIndex = 1;
            this.btnPre.Text = "Preview";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ccbCN);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(928, 66);
            this.panelControl1.TabIndex = 13;
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
            // hOADONBindingSource
            // 
            this.hOADONBindingSource.DataMember = "HOADON";
            this.hOADONBindingSource.DataSource = this.dS;
            // 
            // hOADONTableAdapter
            // 
            this.hOADONTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.HOADONTableAdapter = this.hOADONTableAdapter;
            this.tableAdapterManager.KhachHangTableAdapter = null;
            this.tableAdapterManager.KHOTableAdapter = null;
            this.tableAdapterManager.LoaiHangTableAdapter = null;
            this.tableAdapterManager.NhaCungCapTableAdapter = null;
            this.tableAdapterManager.NhanVienTableAdapter = null;
            this.tableAdapterManager.PhieuNhapTableAdapter = this.phieuNhapTableAdapter;
            this.tableAdapterManager.UpdateOrder = qlvt_v2.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // phieuNhapBindingSource
            // 
            this.phieuNhapBindingSource.DataMember = "PhieuNhap";
            this.phieuNhapBindingSource.DataSource = this.dS;
            // 
            // phieuNhapTableAdapter
            // 
            this.phieuNhapTableAdapter.ClearBeforeFill = true;
            // 
            // frmrp_TongHopNhapXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 207);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmrp_TongHopNhapXuat";
            this.Text = "frmrp_TongHopNhapXuat";
            this.Load += new System.EventHandler(this.frmrp_TongHopNhapXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTO.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFROM.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFROM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hOADONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phieuNhapBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.DateEdit txtTO;
        private DevExpress.XtraEditors.DateEdit txtFROM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPre;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox ccbCN;
        private System.Windows.Forms.Label label1;
        private DS dS;
        private System.Windows.Forms.BindingSource hOADONBindingSource;
        private DSTableAdapters.HOADONTableAdapter hOADONTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private DSTableAdapters.PhieuNhapTableAdapter phieuNhapTableAdapter;
        private System.Windows.Forms.BindingSource phieuNhapBindingSource;
    }
}