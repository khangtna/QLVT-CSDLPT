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
    public partial class frmrp_DSVT : Form
    {
        public frmrp_DSVT()
        {
            InitializeComponent();
        }

        private void frmrp_DSVT_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;

            this.hangHoaTableAdapter.Connection.ConnectionString = Program.connstr;
            this.hangHoaTableAdapter.Fill(this.dS.HangHoa);

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

        private void hangHoaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.hangHoaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

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
                this.hangHoaTableAdapter.Connection.ConnectionString = Program.connstr;
                this.hangHoaTableAdapter.Fill(this.dS.HangHoa);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            Xrpt_DSVT rpt = new Xrpt_DSVT();

            //rpt.lblTieuDe.Text = “DANH SÁCH PHIẾU “ +cmbLoai.Text.ToUpper() + “ NHÂN VIÊN LẬP TRONG NĂM “ +cmbNam.Text;
            rpt.txtCN.Text = ccbCN.Text;

            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }
    }
}
