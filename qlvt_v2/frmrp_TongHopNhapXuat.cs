using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlvt_v2
{
    public partial class frmrp_TongHopNhapXuat : Form
    {
        public frmrp_TongHopNhapXuat()
        {
            InitializeComponent();
        }

        private void hOADONBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.hOADONBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmrp_TongHopNhapXuat_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;
            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);

            this.hOADONTableAdapter.Connection.ConnectionString = Program.connstr;
            this.hOADONTableAdapter.Fill(this.dS.HOADON);

            ccbCN.DataSource = Program.bds_dspm;
            ccbCN.DisplayMember = "TENCN";
            ccbCN.ValueMember = "TENSERVER";
            ccbCN.SelectedIndex = Program.mChinhanh;

            if (Program.mGroup == "CONGTY")
            {
                ccbCN.Enabled = true;
                //btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPH.Enabled = btnGhi.Enabled = false;
                //pnTT.Enabled = false;
            }
            else
            {
                ccbCN.Enabled = false;
                //pnTT.Enabled = true;
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtTO_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ccbCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ccbCN.SelectedValue.ToString() == "System.Data.DataRowView") return;

            Program.servername = ccbCN.SelectedValue.ToString();

            if (ccbCN.SelectedIndex != Program.mChinhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;

            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }

            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối!");
            }
            else
            {

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);

                this.hOADONTableAdapter.Connection.ConnectionString = Program.connstr;
                this.hOADONTableAdapter.Fill(this.dS.HOADON);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            DateTime to = txtTO.DateTime.Date;
            DateTime from = txtFROM.DateTime.Date;

            //DateTime to = new DateTime(2023, 10, 11);
            //DateTime from = new DateTime(2023, 11, 11);

            Xrpt_TonghopNhapXuat rpt = new Xrpt_TonghopNhapXuat( from, to);

            rpt.lbTO.Text = txtTO.DateTime.Date.ToString("dd/MM/yyyy");
            rpt.lbFROM.Text = txtFROM.DateTime.Date.ToString("dd/MM/yyyy");
            rpt.lbCN.Text = ccbCN.Text;

            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
}
