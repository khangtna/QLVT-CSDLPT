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
    public partial class frmCCN : Form
    {
        public frmCCN()
        {
            InitializeComponent();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }
        SqlCommand cmd = new SqlCommand();
        int pos = 0;
        String macn = "";

        public static BindingSource bds_cn = new BindingSource();

        private void getDSPM()
        {
            string query = "SELECT * FROM ChiNhanh";

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Program.connstr_pulisher);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            conn.Close();
            bds_cn.DataSource = dt;
            ccbCN2.DataSource = bds_cn;
            ccbCN2.DisplayMember = "MACN";
            ccbCN2.ValueMember = "MACN";

        }

        private void frmCCN_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;

            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.dS.NhanVien);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);

            this.hOADONTableAdapter.Connection.ConnectionString = Program.connstr;
            this.hOADONTableAdapter.Fill(this.dS.HOADON);

            this.donDatHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.donDatHangTableAdapter.Fill(this.dS.DonDatHang);

            getDSPM();

            macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            ccbCN.DataSource = Program.bds_dspm;
            ccbCN.DisplayMember = "TENCN";
            ccbCN.ValueMember = "TENSERVER";
            ccbCN.SelectedIndex = Program.mChinhanh;

            if (Program.mGroup == "CONGTY")
            {
                ccbCN.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPH.Enabled = btnGhi.Enabled = false;
                pnTT.Enabled = false;
            }
            else
            {
                ccbCN.Enabled = false;
                pnTT.Enabled = true;
            }

        }

        private bool checkID()
        {
            SqlConnection conn = new SqlConnection(Program.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM NhanVien WHERE (MANV = @manv)", conn);
            cmd.Parameters.AddWithValue("@manv", txtMANV.Text);
            int UserExist = (int)cmd.ExecuteScalar();

            if (UserExist > 0)
            {
                conn.Close();
                return true;

            }
            conn.Close();
            return false;

        }
        
        private bool checkCN()
        {
            SqlConnection conn = new SqlConnection(Program.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM NhanVien WHERE MANV = @manv AND MACN = @macn AND TrangThai = 'True'", conn);
            cmd.Parameters.AddWithValue("@manv", txtMANV.Text);
            cmd.Parameters.AddWithValue("@macn", ccbCN2.SelectedValue);
            int UserExist = (int)cmd.ExecuteScalar();

            if (UserExist > 0)
            {
                conn.Close();
                return true;

            }
            conn.Close();
            return false;
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

                this.donDatHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.donDatHangTableAdapter.Fill(this.dS.DonDatHang);
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            this.nhanVienTableAdapter.Fill(this.dS.NhanVien);

        }

        private void btnPH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsNV.CancelEdit();
            if (btnThem.Enabled == false) bdsNV.Position = pos;
            gcNV.Enabled = true;
            //pnTT.Enabled = false;

            btnThem.Enabled = btnSua.Enabled = btnExit.Enabled = btnReload.Enabled = true;
            btnGhi.Enabled = btnPH.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnGhi.Enabled = btnExit.Enabled = btnPH.Enabled = true;
            btnThem.Enabled  = btnReload.Enabled = false;

            gcNV.Enabled = false;

           // txtMANV.Enabled = txtHO.Enabled = txtTEN.Enabled = txtSDT.Enabled = txtTT.Enabled = txtLUONG.Enabled = txtDC.Enabled = txtGT.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ccbCN2.Text == "")
            {
                MessageBox.Show("Chi nhánh không được để trống.");
                ccbCN2.Focus();
                return;

            }
            if (txtMANV.Text == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống.");
                txtMANV.Focus();
                return;

            }

            if (checkID() == false)
            {
                MessageBox.Show("Mã nhân viên không tồn tại.");
                return;

            }

            if (checkCN() == true)
            {
                MessageBox.Show("Nhân viên đã tồn tại ở chi nhánh này.");
                return;

            }


            if (MessageBox.Show("Bạn muốn chuyển nhân viên này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    string query = "EXEC SP_CCN @MANV, @MACN";
                    Program.conn.Open();

                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", txtMANV.Text);
                    cmd.Parameters.AddWithValue("@MACN", ccbCN2.SelectedValue);

                    cmd.ExecuteNonQuery();
                    this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.nhanVienTableAdapter.Fill(this.dS.NhanVien);

                    MessageBox.Show("Chuyển thành công.");
                    Program.conn.Close();

                    btnThem.Enabled  = btnExit.Enabled = btnReload.Enabled = true;
                    btnGhi.Enabled = btnPH.Enabled = false;
                    gcNV.Enabled = true;

                }
                catch (Exception ex)
                {
                    Program.conn.Close();
                    //MessageBox.Show("Error: " + ex.Message);
                    //this.nhanVienTableAdapter.Fill(this.dS.NhanVien);
                    //bdsNV.Position = bdsNV.Find("MANV", manv);
                    return;

                }
            }
        }
    }
}
