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
    public partial class frmDDH : Form
    {
        public frmDDH()
        {
            InitializeComponent();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void donDatHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsDH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        SqlCommand cmd = new SqlCommand();
        int pos = 0;
        String macn = "";
        DateTime dt = DateTime.Today;

        public static BindingSource bds_kho = new BindingSource();
        public static BindingSource bds_ncc = new BindingSource();
        public static BindingSource bds_ddh2 = new BindingSource();
        public static BindingSource bds_hh = new BindingSource();



        private void getMAKHO()
        {
            string query = "SELECT * FROM KHO";

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Program.connstr);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            conn.Close();
            bds_kho.DataSource = dt;
            ccbMAKHO.DataSource = bds_kho;
            ccbMAKHO.DisplayMember = "TENKHO";
            ccbMAKHO.ValueMember = "MAKHO";

        }

        private void getMANCC()
        {
            string query = "SELECT * FROM NhaCungCap";

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Program.connstr_pulisher);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            conn.Close();
            bds_ncc.DataSource = dt;
            ccbMANCC.DataSource = bds_ncc;
            ccbMANCC.DisplayMember = "TEN";
            ccbMANCC.ValueMember = "MANCC";

        }

        private void getMADDH()
        {
            string query = "SELECT * FROM DonDatHang";

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Program.connstr);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            conn.Close();
            bds_ddh2.DataSource = dt;
            ccbMADDH2.DataSource = bds_ddh2;
            ccbMADDH2.DisplayMember = "MADDH";
            ccbMADDH2.ValueMember = "MADDH";

        }

        private void getMAHH()
        {
            string query = "SELECT * FROM HangHoa";

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Program.connstr);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            conn.Close();
            bds_hh.DataSource = dt;
            ccbMAHH2.DataSource = bds_hh;
            ccbMAHH2.DisplayMember = "TENHH";
            ccbMAHH2.ValueMember = "MAHH";

        }
        private void frmDDH_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;

            this.donDatHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.donDatHangTableAdapter.Fill(this.dS.DonDatHang);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);

            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.dS.CTDDH);

           

            getMAKHO();
            getMANCC();
            getMADDH();
            getMAHH();

            btnTDH.Enabled = btnTCTDN.Enabled = true;

            btnThem.Enabled = btnXoa.Enabled = btnPH.Enabled = btnGhi.Enabled = false;
            pnTT.Enabled = false;

            btnThem2.Enabled = btnXoa2.Enabled = btnPH2.Enabled = btnGhi2.Enabled = false;
            pnTT2.Enabled = false;

            //macn = ((DataRowView)bdsDH[0])["MACN"].ToString();
            ccbCN.DataSource = Program.bds_dspm;
            ccbCN.DisplayMember = "TENCN";
            ccbCN.ValueMember = "TENSERVER";
            ccbCN.SelectedIndex = Program.mChinhanh;

            if (Program.mGroup == "CONGTY")
            {
                ccbCN.Enabled = true;
                btnThem.Enabled = btnXoa.Enabled  = btnPH.Enabled = btnGhi.Enabled = false;
                pnTT.Enabled = false;

                btnThem2.Enabled = btnXoa2.Enabled = btnPH2.Enabled = btnGhi2.Enabled = false;
                pnTT2.Enabled = false;
            }
            else
            {
                ccbCN.Enabled = false;
                pnTT.Enabled = true;

                pnTT2.Enabled = true;
            }

        }

        private bool checkID()
        {
            SqlConnection conn = new SqlConnection(Program.connstr_pulisher);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM DonDatHang WHERE (MADDH = @manv)", conn);
            cmd.Parameters.AddWithValue("@manv", txtMADDH.Text);
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

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pos = bdsDH.Position;
            //pnTT.Enabled = true;
            bdsDH.AddNew();
            txtMANV.Text = Program.frmChinh.manv2.Text;
            txtDate.DateTime = dt;

            btnThem.Enabled = btnXoa.Enabled = btnExit.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnPH.Enabled = true;
            gcDH.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMADDH.Text == "")
            {
                MessageBox.Show("Mã đơn đặt hàng không được để trống.");
                txtMANV.Focus();
                return;

            }
            else if (ccbMAKHO.Text == "")
            {
                MessageBox.Show("Mã kho không được để trống.");
                ccbMAKHO.Focus();
                return;

            }
            else if (ccbMANCC.Text == "")
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống.");
                ccbMANCC.Focus();
                return;

            }



            if (checkID() == true)
            {
                MessageBox.Show("Mã đơn đặt hàng đã tồn tại.");
            }
            else
            {
                try
                {

                    string query = "INSERT INTO DonDatHang(MADDH, Ngay, MAKHO, MANV, MANCC)" +
                        "VALUES(@MADDH ,@Ngay, @MAKHO, @MANV, @MANCC)";

                    Program.conn.Open();
                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MADDH", txtMADDH.Text);
                    cmd.Parameters.AddWithValue("@Ngay", txtDate.DateTime);
                    cmd.Parameters.AddWithValue("@MANV", txtMANV.Text);
                    cmd.Parameters.AddWithValue("@MAKHO", ccbMAKHO.SelectedValue);
                    cmd.Parameters.AddWithValue("@MANCC", ccbMANCC.SelectedValue);


                    cmd.ExecuteNonQuery();
                    this.donDatHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.donDatHangTableAdapter.Fill(this.dS.DonDatHang);

                    MessageBox.Show("Thêm thành công.");
                    Program.conn.Close();

                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnExit.Enabled = btnReload.Enabled = true;
                    btnGhi.Enabled = btnPH.Enabled = false;
                    gcDH.Enabled = true;

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
                MessageBox.Show("Không thể đơn đặt hàng này vì đã lập phiếu nhập.");
                return;
            }
            if (bdsCTDH.Count > 0)
            {
                MessageBox.Show("Không thể đơn đặt hàng này vì đã lập chi tiết đơn hàng.");
                return;
            }


            if (MessageBox.Show("Bạn muốn xóa đơn đặt hàng này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    string query = "DELETE FROM DonDatHang WHERE MADDH = @MANV";
                    Program.conn.Open();

                    //manv = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());
                    //bdsNV.RemoveCurrent();
                    //this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    //this.nhanVienTableAdapter.Update(this.dS.NhanVien);

                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", txtMADDH.Text);

                    cmd.ExecuteNonQuery();
                    this.donDatHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.donDatHangTableAdapter.Fill(this.dS.DonDatHang);

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

            if (bdsDH.Count == 0) btnXoa.Enabled = false;
        }

        private void btnPH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsDH.CancelEdit();
            if (btnThem.Enabled == false) bdsDH.Position = pos;
            gcDH.Enabled = true;
            //pnTT.Enabled = false;

            btnThem.Enabled = btnXoa.Enabled = btnExit.Enabled = btnReload.Enabled = true;
            btnGhi.Enabled = btnPH.Enabled = false;
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.donDatHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.donDatHangTableAdapter.Fill(this.dS.DonDatHang);
        }

        private void btnExit2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnReload2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
        }

        private void btnPH2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsCTDH.CancelEdit();
            if (btnThem.Enabled == false) bdsCTDH.Position = pos;
            gcCTDH.Enabled = true;
            //pnTT.Enabled = false;

            btnThem2.Enabled = btnXoa2.Enabled = btnExit2.Enabled = btnReload2.Enabled = true;
            btnGhi2.Enabled = btnPH2.Enabled = false;
        }

        private void btnThem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pos = bdsCTDH.Position;
            //pnTT.Enabled = true;
            bdsCTDH.AddNew();
            //txtMANV.Text = Program.frmChinh.manv2.Text;
            //txtDate.DateTime = dt;

            btnThem2.Enabled = btnXoa2.Enabled = btnExit2.Enabled = btnReload2.Enabled = false;
            btnGhi2.Enabled = btnPH2.Enabled = true;
            gcCTDH.Enabled = false;
        }

        private void btnGhi2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ccbMADDH2.Text == "")
            {
                MessageBox.Show("Mã đơn đặt hàng không được để trống.");
                txtMANV.Focus();
                return;

            }
            else if (ccbMAHH2.Text == "")
            {
                MessageBox.Show("Mã hàng không được để trống.");
                ccbMAKHO.Focus();
                return;

            }
            else if (txtDG2.Text == "")
            {
                MessageBox.Show("Đơn giá không được để trống.");
                txtDG2.Focus();
                return;

            }
            else if (txtSL2.Text == "")
            {
                MessageBox.Show("Số lượng không được để trống.");
                txtSL2.Focus();
                return;

            }

            if (System.Text.RegularExpressions.Regex.IsMatch(txtDG2.Text, "[^0-9]"))
            {
                MessageBox.Show("Đơn giá không hợp lệ.");
                txtDG2.Text = txtDG2.Text.Remove(txtDG2.Text.Length - 1);
            }
            else if (int.Parse(txtDG2.Text) <= 0)
            {
                MessageBox.Show("Đơn giá không được bé hơn 0 VND.");
                txtDG2.Focus();
                return;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(txtSL2.Text, "[^0-9]"))
            {
                MessageBox.Show("Số lượng không hợp lệ.");
                txtSL2.Text = txtSL2.Text.Remove(txtSL2.Text.Length - 1);
            }
            else if (int.Parse(txtSL2.Text) <= 0)
            {
                MessageBox.Show("Số lượng không được bé hơn 0.");
                txtSL2.Focus();
                return;
            }

            try
                {

                    string query = "INSERT INTO CTDDH(MADDH, MAHH, SOLUONG, DONGIA)" +
                        "VALUES(@MADDH ,@MAHH, @SL, @DG)";

                    Program.conn.Open();
                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MADDH", ccbMADDH2.SelectedValue);
                    cmd.Parameters.AddWithValue("@MAHH", ccbMAHH2.SelectedValue);
                    cmd.Parameters.AddWithValue("@SL", txtSL2.Text);
                    cmd.Parameters.AddWithValue("@DG", txtDG2.Text);


                    cmd.ExecuteNonQuery();
                this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTDDHTableAdapter.Fill(this.dS.CTDDH);

                MessageBox.Show("Thêm thành công.");
                    Program.conn.Close();

                    btnThem2.Enabled = btnXoa2.Enabled  = btnExit2.Enabled = btnReload2.Enabled = true;
                    btnGhi2.Enabled = btnPH2.Enabled = false;
                    gcCTDH.Enabled = true;

                }
                catch (Exception ex)
                {
                    Program.conn.Close();
                    return;
                }
            }

        private void btnXoa2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           


            if (MessageBox.Show("Bạn muốn xóa chi tiết đơn đặt hàng này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    string query = "DELETE FROM CTDDH WHERE MADDH = @MANV and MAHH= @MAHH";
                    Program.conn.Open();

                    //manv = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());
                    //bdsNV.RemoveCurrent();
                    //this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    //this.nhanVienTableAdapter.Update(this.dS.NhanVien);

                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", ccbMADDH2.SelectedValue);
                    cmd.Parameters.AddWithValue("@MAHH", ccbMAHH2.SelectedValue);

                    cmd.ExecuteNonQuery();
                    this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTDDHTableAdapter.Fill(this.dS.CTDDH);

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

            if (bdsCTDH.Count == 0) btnXoa2.Enabled = false;
        }

        private void btnTDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThem.Enabled = btnXoa.Enabled = btnPH.Enabled = btnGhi.Enabled = true;
            pnTT.Enabled = true;

            btnThem2.Enabled = btnXoa2.Enabled = btnPH2.Enabled = btnGhi2.Enabled = false;
            pnTT2.Enabled = false;

            btnTDH.Enabled = false;
            btnTCTDN.Enabled = true;
        }

        private void btnTCTDN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThem.Enabled = btnXoa.Enabled = btnPH.Enabled = btnGhi.Enabled = false;
            pnTT.Enabled = false;

            btnThem2.Enabled = btnXoa2.Enabled = btnPH2.Enabled = btnGhi2.Enabled = true;
            pnTT2.Enabled = true;

            btnTCTDN.Enabled = false;
            btnTDH.Enabled = true;
        }

        private void gcCTDH_Click(object sender, EventArgs e)
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
                this.donDatHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.donDatHangTableAdapter.Fill(this.dS.DonDatHang);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);

                this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
            }
        }
    }
}
