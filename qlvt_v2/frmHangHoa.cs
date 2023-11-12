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
    public partial class frmHangHoa : Form
    {
        public frmHangHoa()
        {
            InitializeComponent();
        }

        private void hangHoaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsHH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        SqlCommand cmd = new SqlCommand();
        int pos = 0;
        String macn = "";

        public static BindingSource bds_loaihang = new BindingSource();

        private void getMALH()
        {
            string query = "SELECT * FROM LoaiHang";

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Program.connstr_pulisher);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            conn.Close();
            bds_loaihang.DataSource = dt;
            ccbMALH.DataSource = bds_loaihang;
            ccbMALH.DisplayMember = "MALH";
            ccbMALH.ValueMember = "MALH";


        }

            private void frmHangHoa_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;

            this.hangHoaTableAdapter.Connection.ConnectionString = Program.connstr;
            this.hangHoaTableAdapter.Fill(this.dS.HangHoa);

            this.hangHoaTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.dS.CTPN);

            this.hangHoaTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTHDTableAdapter.Fill(this.dS.CTHD);

            this.hangHoaTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.dS.CTDDH);


            //Program.conn.Open();

            getMALH();


            //macn = ((DataRowView)bdsHH[0])["MACN"].ToString();
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
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM HangHoa WHERE (MAHH = @manv)", conn);
            cmd.Parameters.AddWithValue("@manv", txtMAHH.Text);
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
            this.hangHoaTableAdapter.Connection.ConnectionString = Program.connstr;
            this.hangHoaTableAdapter.Fill(this.dS.HangHoa);
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pos = bdsHH.Position;
            //pnTT.Enabled = true;
            bdsHH.AddNew();
            //txtMACN.Text = macn;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnExit.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnPH.Enabled = true;
            gcHH.Enabled = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMAHH.Text == "")
            {
                MessageBox.Show("Mã hàng hoá không được để trống.");
                txtMAHH.Focus();
                return;

            }
            else if (txtDVT.Text == "")
            {
                MessageBox.Show("DVT không được để trống.");
                txtDVT.Focus();
                return;

            }
            else if (txtTEN.Text == "")
            {
                MessageBox.Show("Tên không được để trống.");
                txtTEN.Focus();
                return;

            }
            else if (txtSLT.Text == "")
            {
                MessageBox.Show("Số lượng tồn không được để trống.");
                txtSLT.Focus();
                return;

            }
            
            if (System.Text.RegularExpressions.Regex.IsMatch(txtSLT.Text, "[^0-9]"))
            {
                MessageBox.Show("Số tiền không hợp lệ.");
                txtSLT.Text = txtSLT.Text.Remove(txtSLT.Text.Length - 1);
            }
            else if (int.Parse(txtSLT.Text) < 0)
            {
                MessageBox.Show("Số tiền không được bé hơn 0.");
                txtSLT.Focus();
                return;
            }

            string manv = ((DataRowView)bdsHH[bdsHH.Position])["MAHH"].ToString();

            if (txtMAHH.Text != manv)
            {
                MessageBox.Show("Mã hàng hoá không trùng.");
            }
            else
            {
                try
                {
                    string query = "UPDATE HangHoa SET  DVT= @DVT, TENHH= @TEN, SOLUONGTON=@SLT WHERE MAHH=@MANV";

                    Program.conn.Open();
                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", txtMAHH.Text);
                    cmd.Parameters.AddWithValue("@DVT", txtDVT.Text);
                    cmd.Parameters.AddWithValue("@TEN", txtTEN.Text);
                    cmd.Parameters.AddWithValue("@SLT", txtSLT.Text);
                    

                    cmd.ExecuteNonQuery();
                    this.hangHoaTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.hangHoaTableAdapter.Fill(this.dS.HangHoa);

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
            if (txtMAHH.Text == "")
            {
                MessageBox.Show("Mã hàng hoá không được để trống.");
                txtMAHH.Focus();
                return;

            }
            else if (txtDVT.Text == "")
            {
                MessageBox.Show("DVT không được để trống.");
                txtDVT.Focus();
                return;

            }
            else if (txtTEN.Text == "")
            {
                MessageBox.Show("Tên không được để trống.");
                txtTEN.Focus();
                return;

            }
            else if (txtSLT.Text == "")
            {
                MessageBox.Show("Số lượng tồn không được để trống.");
                txtSLT.Focus();
                return;

            }

            if (System.Text.RegularExpressions.Regex.IsMatch(txtSLT.Text, "[^0-9]"))
            {
                MessageBox.Show("Số tiền không hợp lệ.");
                txtSLT.Text = txtSLT.Text.Remove(txtSLT.Text.Length - 1);
            }
            else if (int.Parse(txtSLT.Text) < 0)
            {
                MessageBox.Show("Số tiền không được bé hơn 0.");
                txtSLT.Focus();
                return;
            }

            if (checkID() == true)
            {
                MessageBox.Show("Mã hàng hoá đã tồn tại.");
            }
            else
            {
                try
                {

                    string query = "INSERT INTO HangHoa(MAHH, DVT, TENHH, SOLUONGTON, MALH)" +
                        "VALUES(@MANV ,@DVT, @TEN, @SLT, @MALH)";

                    Program.conn.Open();
                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", txtMAHH.Text);
                    cmd.Parameters.AddWithValue("@DVT", txtDVT.Text);
                    cmd.Parameters.AddWithValue("@TEN", txtTEN.Text);
                    cmd.Parameters.AddWithValue("@SLT", txtSLT.Text);
                    cmd.Parameters.AddWithValue("@MALH", ccbMALH.Text);


                    cmd.ExecuteNonQuery();
                    this.hangHoaTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.hangHoaTableAdapter.Fill(this.dS.HangHoa);

                    MessageBox.Show("Thêm thành công.");
                    Program.conn.Close();

                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnExit.Enabled = btnReload.Enabled = true;
                    btnGhi.Enabled = btnPH.Enabled = false;
                    gcHH.Enabled = true;

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
            if (bdsCTPN.Count > 0)
            {
                MessageBox.Show("Không thể xóa hàng hoá này vì đã lập phiếu nhập.");
                return;
            }
            if (dbsCTHD.Count > 0)
            {
                MessageBox.Show("Không thể xóa hàng hoá này vì đã lập hoá đơn.");
                return;
            }
            if (bdsCTDH.Count > 0)
            {
                MessageBox.Show("Không thể xóa hàng hoá này vì đã lập đơn hàng.");
                return;
            }

            if (MessageBox.Show("Bạn muốn xóa hàng hoá này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    string query = "DELETE FROM HangHoa WHERE MAHH = @MANV";
                    Program.conn.Open();

                    //manv = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());
                    //bdsNV.RemoveCurrent();
                    //this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    //this.nhanVienTableAdapter.Update(this.dS.NhanVien);

                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", txtMAHH.Text);

                    cmd.ExecuteNonQuery();
                    this.hangHoaTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.hangHoaTableAdapter.Fill(this.dS.HangHoa);

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

            if (bdsHH.Count == 0) btnXoa.Enabled = false;
        }

        private void btnPH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsHH.CancelEdit();
            if (btnThem.Enabled == false) bdsHH.Position = pos;
            gcHH.Enabled = true;
            //pnTT.Enabled = false;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnExit.Enabled = btnReload.Enabled = true;
            btnGhi.Enabled = btnPH.Enabled = false;
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

                this.hangHoaTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Fill(this.dS.CTPN);

                this.hangHoaTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTHDTableAdapter.Fill(this.dS.CTHD);

                this.hangHoaTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
            }
        }

        private void ccbMALH_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
