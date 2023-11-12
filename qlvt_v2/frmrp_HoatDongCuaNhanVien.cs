using DevExpress.XtraReports.UI;
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
    public partial class frmrp_HoatDongCuaNhanVien : Form
    {
        public frmrp_HoatDongCuaNhanVien()
        {
            InitializeComponent();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.nhanVienBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        public static BindingSource bds_nv = new BindingSource();
        public static BindingSource bds_allnv = new BindingSource();


        private void getNV()
        {
            string query = "SELECT MANV, CONCAT(HO,' ',TEN) AS HOTEN FROM NhanVien";

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Program.connstr);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            conn.Close();
            bds_nv.DataSource = dt;
            ccbNV.DataSource = bds_nv;
            ccbNV.DisplayMember = "HOTEN";
            ccbNV.ValueMember = "MANV";

        }
        
        private void getALLNV()
        {
            string query = "SELECT MANV, CONCAT(HO,' ',TEN) AS HOTEN FROM NhanVien";

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Program.connstr_pulisher);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            conn.Close();
            bds_allnv.DataSource = dt;
            ccbNV.DataSource = bds_allnv;
            ccbNV.DisplayMember = "HOTEN";
            ccbNV.ValueMember = "MANV";

        }

        private void frmrp_HoatDongCuaNhanVien_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;

            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.dS.NhanVien);

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
                getALLNV();
            }
            else
            {
                ccbCN.Enabled = false;
                //pnTT.Enabled = true;
                getNV();
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
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.dS.NhanVien);

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

            Xrpt_HoatDongCuaNhanVien_v2 rpt = new Xrpt_HoatDongCuaNhanVien_v2(Convert.ToInt32(ccbNV.SelectedValue), from, to, ccbLoai.Text);

            rpt.lbMANV.Text = ccbNV.SelectedValue.ToString();
            rpt.lbHT.Text = ccbNV.Text;
            rpt.lbTO.Text = txtTO.DateTime.Date.ToString("dd/MM/yyyy");
            rpt.lbFROM.Text = txtFROM.DateTime.Date.ToString("dd/MM/yyyy");
            rpt.lbCN.Text = ccbCN.Text;
            rpt.lbLOAI.Text = ccbLoai.Text;

            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime a = txtTO.DateTime.Date;
          
            MessageBox.Show(a.ToString("dd/MM/yyyy"));

        }
    }
}
