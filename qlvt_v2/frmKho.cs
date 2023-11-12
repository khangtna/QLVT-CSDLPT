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
    public partial class frmKho : Form
    {
        public frmKho()
        {
            InitializeComponent();
        }

        private void kHOBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKHO.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        SqlCommand cmd = new SqlCommand();
        int pos = 0;
        String macn = "";

        private void frmKho_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;

            this.kHOTableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHOTableAdapter.Fill(this.dS.KHO);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);

            this.hOADONTableAdapter.Connection.ConnectionString = Program.connstr;
            this.hOADONTableAdapter.Fill(this.dS.HOADON);

            this.donDatHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.donDatHangTableAdapter.Fill(this.dS.DonDatHang);


            macn = ((DataRowView)bdsKHO[0])["MACN"].ToString();
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
            SqlConnection conn = new SqlConnection(Program.connstr_pulisher);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM KHO WHERE (MAKHO = @manv)", conn);
            cmd.Parameters.AddWithValue("@manv", txtMAKHO.Text);
            int UserExist = (int)cmd.ExecuteScalar();

            if (UserExist > 0)
            {
                conn.Close();
                return true;

            }
            conn.Close();
            return false;

        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.kHOTableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHOTableAdapter.Fill(this.dS.KHO);
        }

        private void btnPH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKHO.CancelEdit();
            if (btnThem.Enabled == false) bdsKHO.Position = pos;
            gcKho.Enabled = true;
            //pnTT.Enabled = false;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnExit.Enabled = btnReload.Enabled = true;
            btnGhi.Enabled = btnPH.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pos = bdsKHO.Position;
            //pnTT.Enabled = true;
            bdsKHO.AddNew();
            txtMACN.Text = macn;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnExit.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnPH.Enabled = true;
            gcKho.Enabled = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMAKHO.Text == "")
            {
                MessageBox.Show("Mã kho không được để trống.");
                txtMAKHO.Focus();
                return;

            }
            else if (txtMACN.Text == "")
            {
                MessageBox.Show("Mã chi nhánh không được để trống.");
                txtMACN.Focus();
                return;

            }
            else if (txtTEN.Text == "")
            {
                MessageBox.Show("Tên không được để trống.");
                txtTEN.Focus();
                return;

            }
            else if (txtDC.Text == "")
            {
                MessageBox.Show("Địa chỉ không được để trống.");
                txtDC.Focus();
                return;

            }
            

            string manv = ((DataRowView)bdsKHO[bdsKHO.Position])["MAKHO"].ToString();

            if (txtMAKHO.Text != manv)
            {
                MessageBox.Show("Mã kho không trùng.");
            }
            else
            {
                try
                {
                    string query = "UPDATE KHO SET TENKHO= @TEN, DIACHI=@DIACHI WHERE MAKHO=@MANV";

                    Program.conn.Open();
                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", txtMAKHO.Text);
                    cmd.Parameters.AddWithValue("@TEN", txtTEN.Text);
                    cmd.Parameters.AddWithValue("@DIACHI", txtDC.Text);
              

                    cmd.ExecuteNonQuery();
                    this.kHOTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.kHOTableAdapter.Fill(this.dS.KHO);

                    MessageBox.Show("Sửa thành công.");
                    Program.conn.Close();

                }
                catch (Exception ex)
                {
                    Program.conn.Close();
                    return;
                }
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMAKHO.Text == "")
            {
                MessageBox.Show("Mã kho không được để trống.");
                txtMAKHO.Focus();
                return;

            }
            else if (txtMACN.Text == "")
            {
                MessageBox.Show("Mã chi nhánh không được để trống.");
                txtMACN.Focus();
                return;

            }
            else if (txtTEN.Text == "")
            {
                MessageBox.Show("Tên không được để trống.");
                txtTEN.Focus();
                return;

            }
            else if (txtDC.Text == "")
            {
                MessageBox.Show("Địa chỉ không được để trống.");
                txtDC.Focus();
                return;

            }

            if (checkID() == true)
            {
                MessageBox.Show("Mã kho đã tồn tại.");
            }
            else
            {
                try
                {

                    string query = "INSERT INTO KHO(MAKHO, TENKHO, DIACHI, MACN)" +
                        "VALUES(@MANV, @TEN, @DIACHI, @MACN)";

                    Program.conn.Open();
                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", txtMAKHO.Text);
                    cmd.Parameters.AddWithValue("@TEN", txtTEN.Text);
                    cmd.Parameters.AddWithValue("@DIACHI", txtDC.Text);
                    cmd.Parameters.AddWithValue("@MACN", txtMACN.Text);


                    cmd.ExecuteNonQuery();
                    this.kHOTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.kHOTableAdapter.Fill(this.dS.KHO);

                    MessageBox.Show("Thêm thành công.");
                    Program.conn.Close();

                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnExit.Enabled = btnReload.Enabled = true;
                    btnGhi.Enabled = btnPH.Enabled = false;
                    gcKho.Enabled = true;

                }
                catch (Exception ex)
                {
                    Program.conn.Close();
                    return;
                }
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bdsPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập phiếu nhập.");
                return;
            }
            if (bdsHD.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập hoá đơn.");
                return;
            }
            if (bdsDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập đơn hàng.");
                return;
            }

            if (MessageBox.Show("Bạn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    string query = "DELETE FROM KHO WHERE MAKHO = @MANV";
                    Program.conn.Open();

                    //manv = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());
                    //bdsNV.RemoveCurrent();
                    //this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    //this.nhanVienTableAdapter.Update(this.dS.NhanVien);

                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", txtMAKHO.Text);

                    cmd.ExecuteNonQuery();
                    this.kHOTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.kHOTableAdapter.Fill(this.dS.KHO);

                    MessageBox.Show("Xóa thành công.");
                    Program.conn.Close();

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

            if (bdsKHO.Count == 0) btnXoa.Enabled = false;
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
                this.kHOTableAdapter.Connection.ConnectionString = Program.connstr;
                this.kHOTableAdapter.Fill(this.dS.KHO);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);

                this.hOADONTableAdapter.Connection.ConnectionString = Program.connstr;
                this.hOADONTableAdapter.Fill(this.dS.HOADON);

                this.donDatHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.donDatHangTableAdapter.Fill(this.dS.DonDatHang);
            }
        }
    }
}
