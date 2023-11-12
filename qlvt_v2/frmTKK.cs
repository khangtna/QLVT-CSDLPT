using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlvt_v2
{
    public partial class frmTKK : Form
    {
        public frmTKK()
        {
            InitializeComponent();
        }
        SqlCommand cmd = new SqlCommand();
        int pos = 0;
        String macn = "";

        private void frmTKK_Load(object sender, EventArgs e)
        {
            dsview.EnforceConstraints = false;

            this.vIEW_SLT_KHOTableAdapter.Connection.ConnectionString = Program.connstr;
            this.vIEW_SLT_KHOTableAdapter.Fill(this.dsview.VIEW_SLT_KHO);

            //macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
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
                this.vIEW_SLT_KHOTableAdapter.Connection.ConnectionString = Program.connstr;
                this.vIEW_SLT_KHOTableAdapter.Fill(this.dsview.VIEW_SLT_KHO);
            }
        }
    }
}
