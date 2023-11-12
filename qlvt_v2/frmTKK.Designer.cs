
namespace qlvt_v2
{
    partial class frmTKK
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
            this.dsview = new qlvt_v2.dsview();
            this.vIEW_SLT_KHOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vIEW_SLT_KHOTableAdapter = new qlvt_v2.dsviewTableAdapters.VIEW_SLT_KHOTableAdapter();
            this.tableAdapterManager = new qlvt_v2.dsviewTableAdapters.TableAdapterManager();
            this.vIEW_SLT_KHOGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltotal = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vIEW_SLT_KHOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vIEW_SLT_KHOGridControl)).BeginInit();
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
            this.panelControl1.TabIndex = 5;
            // 
            // ccbCN
            // 
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
            // dsview
            // 
            this.dsview.DataSetName = "dsview";
            this.dsview.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vIEW_SLT_KHOBindingSource
            // 
            this.vIEW_SLT_KHOBindingSource.DataMember = "VIEW_SLT_KHO";
            this.vIEW_SLT_KHOBindingSource.DataSource = this.dsview;
            // 
            // vIEW_SLT_KHOTableAdapter
            // 
            this.vIEW_SLT_KHOTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = qlvt_v2.dsviewTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // vIEW_SLT_KHOGridControl
            // 
            this.vIEW_SLT_KHOGridControl.DataSource = this.vIEW_SLT_KHOBindingSource;
            this.vIEW_SLT_KHOGridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.vIEW_SLT_KHOGridControl.Location = new System.Drawing.Point(0, 66);
            this.vIEW_SLT_KHOGridControl.MainView = this.gridView1;
            this.vIEW_SLT_KHOGridControl.Name = "vIEW_SLT_KHOGridControl";
            this.vIEW_SLT_KHOGridControl.Size = new System.Drawing.Size(800, 220);
            this.vIEW_SLT_KHOGridControl.TabIndex = 6;
            this.vIEW_SLT_KHOGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAHH,
            this.colTENHH,
            this.colMAKHO,
            this.coltotal});
            this.gridView1.GridControl = this.vIEW_SLT_KHOGridControl;
            this.gridView1.Name = "gridView1";
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
            // colMAKHO
            // 
            this.colMAKHO.FieldName = "MAKHO";
            this.colMAKHO.Name = "colMAKHO";
            this.colMAKHO.Visible = true;
            this.colMAKHO.VisibleIndex = 2;
            // 
            // coltotal
            // 
            this.coltotal.FieldName = "total";
            this.coltotal.Name = "coltotal";
            this.coltotal.Visible = true;
            this.coltotal.VisibleIndex = 3;
            // 
            // frmTKK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.vIEW_SLT_KHOGridControl);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmTKK";
            this.Text = "frmTKK";
            this.Load += new System.EventHandler(this.frmTKK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vIEW_SLT_KHOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vIEW_SLT_KHOGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox ccbCN;
        private System.Windows.Forms.Label label1;
        private dsview dsview;
        private System.Windows.Forms.BindingSource vIEW_SLT_KHOBindingSource;
        private dsviewTableAdapters.VIEW_SLT_KHOTableAdapter vIEW_SLT_KHOTableAdapter;
        private dsviewTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl vIEW_SLT_KHOGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAHH;
        private DevExpress.XtraGrid.Columns.GridColumn colTENHH;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKHO;
        private DevExpress.XtraGrid.Columns.GridColumn coltotal;
    }
}