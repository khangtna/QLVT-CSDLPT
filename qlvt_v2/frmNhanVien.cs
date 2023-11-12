using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlvt_v2
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        SqlCommand cmd = new SqlCommand();
        int pos = 0;
        String macn = "";

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
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
            SqlConnection conn = new SqlConnection(Program.connstr_pulisher);
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

        private bool kiemTraDuLieuDauVao()
        {
            /*kiem tra txtMANV*/
            if (txtMANV.Text == "")
            {
                MessageBox.Show("Không bỏ trống mã nhân viên", "Thông báo", MessageBoxButtons.OK);
                txtMANV.Focus();
                return false;
            }

            if (Regex.IsMatch(txtMANV.Text, @"^[a-zA-Z0-9]+$") == false)
            {
                MessageBox.Show("Mã nhân viên chỉ chấp nhận số", "Thông báo", MessageBoxButtons.OK);
                txtMANV.Focus();
                return false;
            }
            /*kiem tra txtHO*/
            if (txtHO.Text == "")
            {
                MessageBox.Show("Không bỏ trống họ và tên", "Thông báo", MessageBoxButtons.OK);
                txtHO.Focus();
                return false;
            }
            //"^[0-9A-Za-z ]+$"
            if (Regex.IsMatch(txtHO.Text, @"^[A-Za-z ]+$") == false)
            {
                MessageBox.Show("Họ của người chỉ có chữ cái và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtHO.Focus();
                return false;
            }
            if (txtHO.Text.Length > 40)
            {
                MessageBox.Show("Họ không thể lớn hơn 40 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtHO.Focus();
                return false;
            }
            /*kiem tra txtTEN*/
            if (txtTEN.Text == "")
            {
                MessageBox.Show("Không bỏ trống họ và tên", "Thông báo", MessageBoxButtons.OK);
                txtTEN.Focus();
                return false;
            }

            if (Regex.IsMatch(txtTEN.Text, @"^[a-zA-Z ]+$") == false)
            {
                MessageBox.Show("Tên người chỉ có chữ cái và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtTEN.Focus();
                return false;
            }

            if (txtTEN.Text.Length > 10)
            {
                MessageBox.Show("Tên không thể lớn hơn 10 kí tự", "Thông báo", MessageBoxButtons.OK);
                txtTEN.Focus();
                return false;
            }
            /*kiem tra txtDIACHI*/
            if (txtDC.Text == "")
            {
                MessageBox.Show("Không bỏ trống địa chỉ", "Thông báo", MessageBoxButtons.OK);
                txtDC.Focus();
                return false;
            }

            if (Regex.IsMatch(txtDC.Text, @"^[a-zA-Z0-9, ]+$") == false)
            {
                MessageBox.Show("Địa chỉ chỉ chấp nhận chữ cái, số và khoảng trắng", "Thông báo", MessageBoxButtons.OK);
                txtDC.Focus();
                return false;
            }

            if (txtDC.Text.Length > 100)
            {
                MessageBox.Show("Không bỏ trống địa chỉ", "Thông báo", MessageBoxButtons.OK);
                txtDC.Focus();
                return false;
            }

            if (txtLUONG.Text.Length <= 0 )
            {
                MessageBox.Show("Mức lương không thể bỏ trống", "Thông báo", MessageBoxButtons.OK);
                txtLUONG.Focus();
                return false;
            }
            return true;
        }

        private void trangthaiCheckEdit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ccbcn_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.nhanVienTableAdapter.Fill(this.dS.NhanVien);
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMANV.Text == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống.");
                txtMANV.Focus();
                return;

            }
            else if (txtHO.Text == "")
            {
                MessageBox.Show("Họ không được để trống.");
                txtHO.Focus();
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
            else if (txtGT.Text == "")
            {
                MessageBox.Show("Giới tính không được để trống.");
                txtGT.Focus();
                return;

            }
            else if (txtSDT.Text == "")
            {
                MessageBox.Show("Số điện thoại không dc để trống.");
                txtSDT.Focus();
                return;

            }
            else if (txtMACN.Text == "")
            {
                MessageBox.Show("Mã chi nhánh không được để trống.");
                txtMACN.Focus();
                return;

            }
            else if (txtTT.Text == "")
            {
                MessageBox.Show("Trạng thái xóa không được để trống.");
                txtTT.Focus();
                return;
            }
            else if (txtLUONG.Text == "")
            {
                MessageBox.Show("Lương không được để trống.");
                txtLUONG.Focus();
                return;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(txtLUONG.Text, "[^0-9]"))
            {
                MessageBox.Show("Số tiền không hợp lệ.");
                txtLUONG.Text = txtLUONG.Text.Remove(txtLUONG.Text.Length - 1);
            }
            else if (int.Parse(txtLUONG.Text) < 99999)
            {
                MessageBox.Show("Số tiền không được bé hơn 100.000 VND .");
                txtLUONG.Focus();
                return;
            }

            if (checkID() == true)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại.");
            }
            else
            {
                try
                {

                    string query = "INSERT INTO NhanVien(MANV, HO, TEN, DIACHI, GIOITINH, SDT, LUONG, MACN, TrangThai)" +
                        "VALUES(@MANV ,@HO, @TEN, @DIACHI, @PHAI, @SODT, @LUONG, @MACN, @TrangThaiXoa)";

                    Program.conn.Open();
                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", txtMANV.Text);
                    cmd.Parameters.AddWithValue("@HO", txtHO.Text);
                    cmd.Parameters.AddWithValue("@TEN", txtTEN.Text);
                    cmd.Parameters.AddWithValue("@DIACHI", txtDC.Text);
                    cmd.Parameters.AddWithValue("@PHAI", txtGT.Text);
                    cmd.Parameters.AddWithValue("@SODT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@LUONG", txtLUONG.Text);
                    cmd.Parameters.AddWithValue("@MACN", txtMACN.Text);
                    cmd.Parameters.AddWithValue("@TrangThaiXoa", txtTT.Text);

                    cmd.ExecuteNonQuery();
                    this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.nhanVienTableAdapter.Fill(this.dS.NhanVien);

                    MessageBox.Show("Thêm thành công.");
                    Program.conn.Close();

                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnExit.Enabled = btnReload.Enabled = true;
                    btnGhi.Enabled = btnPH.Enabled = false;
                    gcNV.Enabled = true;

                }
                catch (Exception ex)
                {
                    Program.conn.Close();
                    return;
                }
            }
        
    }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pos = bdsNV.Position;
            //pnTT.Enabled = true;
            bdsNV.AddNew();
            txtMACN.Text = macn;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnExit.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnPH.Enabled = true;
            gcNV.Enabled = false;
        }

        private void txtLUONG_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMANV.Text == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống.");
                txtMANV.Focus();
                return;

            }
            else if (txtHO.Text == "")
            {
                MessageBox.Show("Họ không được để trống.");
                txtHO.Focus();
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
            else if (txtGT.Text == "")
            {
                MessageBox.Show("Giới tính không được để trống.");
                txtGT.Focus();
                return;

            }
            else if (txtSDT.Text == "")
            {
                MessageBox.Show("Số điện thoại không dc để trống.");
                txtSDT.Focus();
                return;

            }
            else if (txtMACN.Text == "")
            {
                MessageBox.Show("Mã chi nhánh không được để trống.");
                txtMACN.Focus();
                return;

            }
            else if (txtTT.Text == "")
            {
                MessageBox.Show("Trạng thái xóa không được để trống.");
                txtTT.Focus();
                return;
            }
            else if (txtLUONG.Text == "")
            {
                MessageBox.Show("Lương không được để trống.");
                txtLUONG.Focus();
                return;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(txtLUONG.Text, "[^0-9]"))
            {
                MessageBox.Show("Số tiền không hợp lệ.");
                txtLUONG.Text = txtLUONG.Text.Remove(txtLUONG.Text.Length - 1);
            }
            else if (int.Parse(txtLUONG.Text) < 99999)
            {
                MessageBox.Show("Số tiền không được bé hơn 100.000 VND .");
                txtLUONG.Focus();
                return;
            }

            string manv = ((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString();

            if (txtMANV.Text != manv)
            {
                MessageBox.Show("Mã nhân viên không trùng.");
            }
            else
            {
                try
                {
                    string query = "UPDATE NhanVien SET  HO= @HO, TEN= @TEN, DIACHI=@DIACHI, GIOITINH=@PHAI, SDT= @SODT, LUONG= @LUONG, MACN= @MACN, TrangThai=@TrangThaiXoa WHERE MANV=@MANV";

                    Program.conn.Open();
                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", txtMANV.Text);
                    cmd.Parameters.AddWithValue("@HO", txtHO.Text);
                    cmd.Parameters.AddWithValue("@TEN", txtTEN.Text);
                    cmd.Parameters.AddWithValue("@DIACHI", txtDC.Text);
                    cmd.Parameters.AddWithValue("@PHAI", txtGT.Text);
                    cmd.Parameters.AddWithValue("@SODT", txtSDT.Text);
                    cmd.Parameters.AddWithValue("@LUONG", txtLUONG.Text);
                    cmd.Parameters.AddWithValue("@MACN", txtMACN.Text);
                    cmd.Parameters.AddWithValue("@TrangThaiXoa", txtTT.Text);

                    cmd.ExecuteNonQuery();
                    this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.nhanVienTableAdapter.Fill(this.dS.NhanVien);

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

        private void gcNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsNV.CancelEdit();
            if (btnThem.Enabled == false) bdsNV.Position = pos;
            gcNV.Enabled = true;
            //pnTT.Enabled = false;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnExit.Enabled = btnReload.Enabled = true;
            btnGhi.Enabled = btnPH.Enabled = false;
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
                    string query = "DELETE FROM NhanVien WHERE MANV = @MANV";
                    Program.conn.Open();

                    //manv = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());
                    //bdsNV.RemoveCurrent();
                    //this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    //this.nhanVienTableAdapter.Update(this.dS.NhanVien);

                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", txtMANV.Text);

                    cmd.ExecuteNonQuery();
                    this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.nhanVienTableAdapter.Fill(this.dS.NhanVien);

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

            if (bdsNV.Count == 0) btnXoa.Enabled = false;
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}
