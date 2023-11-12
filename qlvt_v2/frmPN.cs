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
    public partial class frmPN : Form
    {
        public frmPN()
        {
            InitializeComponent();
        }

        private void phieuNhapBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsPN.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        SqlCommand cmd3 = new SqlCommand();
        int pos = 0;
        String macn = "";
        DateTime dt = DateTime.Today;

        public static BindingSource bds_kho = new BindingSource();
        public static BindingSource bds_pn = new BindingSource();
        public static BindingSource bds_ddh2 = new BindingSource();
        public static BindingSource bds_hh = new BindingSource();


        private void getMAPN()
        {
            string query = "SELECT * FROM PhieuNhap";

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Program.connstr);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            conn.Close();
            bds_pn.DataSource = dt;
            ccbMAPN2.DataSource = bds_pn;
            ccbMAPN2.DisplayMember = "SoPN";
            ccbMAPN2.ValueMember = "SoPN";

        }

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

        private void getMADDH()
        {
            string query = "SELECT * FROM DonDatHang";

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Program.connstr);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            conn.Close();
            bds_ddh2.DataSource = dt;
            ccbMADDH.DataSource = bds_ddh2;
            ccbMADDH.DisplayMember = "MADDH";
            ccbMADDH.ValueMember = "MADDH";

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
        private void frmPN_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;

            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.dS.CTPN);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);

            getMAPN();
            getMAHH();
            getMAKHO();
            getMADDH();

            btnTDH.Enabled = btnTCTDN.Enabled = true;

            btnLoad.Enabled= btnLoad2.Enabled = false;

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
                btnThem.Enabled = btnXoa.Enabled = btnPH.Enabled = btnGhi.Enabled = false;
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
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM PhieuNhap WHERE (SoPN = @manv)", conn);
            cmd.Parameters.AddWithValue("@manv", txtMAPN.Text);
            int UserExist = (int)cmd.ExecuteScalar();

            if (UserExist > 0)
            {
                conn.Close();
                return true;

            }
            conn.Close();
            return false;

        }

        private void btnExit2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
            this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);
        }

        private void btnReload2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTPNTableAdapter.Fill(this.dS.CTPN);
        }

        private void btnPH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsPN.CancelEdit();
            if (btnThem.Enabled == false) bdsPN.Position = pos;
            gcPN.Enabled = true;
            //pnTT.Enabled = false;

            btnThem.Enabled = btnXoa.Enabled = btnExit.Enabled = btnReload.Enabled = true;
            btnGhi.Enabled = btnPH.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pos = bdsPN.Position;
            //pnTT.Enabled = true;
            bdsPN.AddNew();
            txtMANV.Text = Program.frmChinh.manv2.Text;
            txtDate.DateTime = dt;

            btnThem.Enabled = btnXoa.Enabled = btnExit.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnPH.Enabled = true;
            gcPN.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMAPN.Text == "")
            {
                MessageBox.Show("Số phiếu không được để trống.");
                txtMANV.Focus();
                return;

            }
            else if (ccbMAKHO.Text == "")
            {
                MessageBox.Show("Mã kho không được để trống.");
                ccbMAKHO.Focus();
                return;

            }
            else if (ccbMADDH.Text == "")
            {
                MessageBox.Show("Mã đơn đặt hàng không được để trống.");
                ccbMADDH.Focus();
                return;

            }



            if (checkID() == true)
            {
                MessageBox.Show("Số phiếu đã tồn tại.");
            }
            else
            {
                try
                {

                    string query = "INSERT INTO PhieuNhap(SoPN, NGAY, MADDH, MAKHO, MANV)" +
                        "VALUES(@SoPN ,@Ngay, @MADDH, @MAKHO, @MANV)";

                    Program.conn.Open();
                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@SoPN", txtMAPN.Text);
                    cmd.Parameters.AddWithValue("@Ngay", txtDate.DateTime);
                    cmd.Parameters.AddWithValue("@MADDH", ccbMADDH.SelectedValue);
                    cmd.Parameters.AddWithValue("@MAKHO", ccbMAKHO.SelectedValue);
                    cmd.Parameters.AddWithValue("@MANV", txtMANV.Text);


                    cmd.ExecuteNonQuery();
                    this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);

                    MessageBox.Show("Thêm thành công.");
                    Program.conn.Close();

                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnExit.Enabled = btnReload.Enabled = true;
                    btnGhi.Enabled = btnPH.Enabled = false;
                    gcPN.Enabled = true;

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
                MessageBox.Show("Không thể phiếu nhập này vì đã lập chi tiết phiếu nhập.");
                return;
            }


            if (MessageBox.Show("Bạn muốn xóa đơn đặt hàng này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    string query = "DELETE FROM PhieuNhap WHERE SoPN = @MANV";
                    Program.conn.Open();

                    //manv = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());
                    //bdsNV.RemoveCurrent();
                    //this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    //this.nhanVienTableAdapter.Update(this.dS.NhanVien);

                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", txtMAPN.Text);

                    cmd.ExecuteNonQuery();
                    this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);

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

            if (bdsPN.Count == 0) btnXoa.Enabled = false;
        }

        private void btnThem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pos = bdsCTPN.Position;
            //pnTT.Enabled = true;
            bdsCTPN.AddNew();
            //txtMANV.Text = Program.frmChinh.manv2.Text;
            //txtDate.DateTime = dt;

            btnThem2.Enabled = btnXoa2.Enabled = btnExit2.Enabled = btnReload2.Enabled= btnLoad.Enabled= btnLoad2.Enabled = false;
            btnGhi2.Enabled = btnPH2.Enabled = true;
            gcCTPN.Enabled = false;
        }

        private void btnGhi2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ccbMAPN2.Text == "")
            {
                MessageBox.Show("Số phiếu không được để trống.");
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

                string query = "INSERT INTO CTPN(SoPN, MAHH, SOLUONG, DONGIA)" +
                    "VALUES(@SoPN ,@MAHH, @SL, @DG)";

                Program.conn.Open();
                cmd = new SqlCommand(query, Program.conn);
                cmd.Parameters.AddWithValue("@SoPN", ccbMAPN2.SelectedValue);
                cmd.Parameters.AddWithValue("@MAHH", ccbMAHH2.SelectedValue);
                cmd.Parameters.AddWithValue("@SL", txtSL2.Text);
                cmd.Parameters.AddWithValue("@DG", txtDG2.Text);
                cmd.ExecuteNonQuery();
                

                string query2 = "EXEC SP_TANGSL @MAHH, @SL";

                //Program.conn.Open();
                cmd2 = new SqlCommand(query2, Program.conn);
                cmd2.Parameters.AddWithValue("@MAHH", ccbMAHH2.SelectedValue);
                cmd2.Parameters.AddWithValue("@SL", txtSL2.Text);


                cmd2.ExecuteNonQuery();
                this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Fill(this.dS.CTPN);

                MessageBox.Show("Thêm thành công.");
                Program.conn.Close();

                btnThem2.Enabled = btnXoa2.Enabled = btnExit2.Enabled = btnReload2.Enabled = btnLoad.Enabled= true;
                btnGhi2.Enabled = btnPH2.Enabled= btnLoad2.Enabled = false;
                gcCTPN.Enabled = true;

            }
            catch (Exception ex)
            {
                Program.conn.Close();
                return;
            }
        }

        private void btnXoa2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {



            if (MessageBox.Show("Bạn muốn xóa chi tiết phiếu nhập này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    string query2 = "EXEC SP_GIAMSL @MAHH, @SL";

                    Program.conn.Open();
                    cmd3 = new SqlCommand(query2, Program.conn);
                    cmd3.Parameters.AddWithValue("@MAHH", ccbMAHH2.SelectedValue);
                    cmd3.Parameters.AddWithValue("@SL", txtSL2.Text.Trim());

                    cmd3.ExecuteNonQuery();


                    string query = "DELETE FROM CTPN WHERE SoPN = @MANV AND MAHH= @MAHH";
                    //Program.conn.Open();

                    //manv = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());
                    //bdsNV.RemoveCurrent();
                    //this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    //this.nhanVienTableAdapter.Update(this.dS.NhanVien);

                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", ccbMAPN2.SelectedValue);
                    cmd.Parameters.AddWithValue("@MAHH", ccbMAHH2.SelectedValue);

                    cmd.ExecuteNonQuery();

                    

                    this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPNTableAdapter.Fill(this.dS.CTPN);

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

            if (bdsCTPN.Count == 0) btnXoa2.Enabled = false;
        }

        private void btnTDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThem.Enabled = btnXoa.Enabled = btnPH.Enabled = btnGhi.Enabled = true;
            pnTT.Enabled = true;

            btnThem2.Enabled = btnXoa2.Enabled = btnPH2.Enabled = btnGhi2.Enabled = false;
            pnTT2.Enabled = false;

            btnTDH.Enabled = false;
            btnTCTDN.Enabled = true;

            btnLoad.Enabled = btnLoad2.Enabled = false;
        }

        private void btnTCTDN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnThem.Enabled = btnXoa.Enabled = btnPH.Enabled = btnGhi.Enabled = false;
            pnTT.Enabled = false;

            btnThem2.Enabled = btnXoa2.Enabled = btnPH2.Enabled = btnGhi2.Enabled = true;
            pnTT2.Enabled = true;

            btnTCTDN.Enabled = false;
            btnTDH.Enabled = true;

            btnLoad.Enabled = btnLoad2.Enabled = true;
        }

        private void btnPH2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsCTPN.CancelEdit();
            if (btnThem.Enabled == false) bdsCTPN.Position = pos;
            gcCTPN.Enabled = true;
            //pnTT.Enabled = false;

            btnThem2.Enabled = btnXoa2.Enabled = btnExit2.Enabled = btnReload2.Enabled = btnLoad.Enabled = true;
            btnGhi2.Enabled = btnPH2.Enabled = btnLoad2.Enabled= false;
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
                this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Fill(this.dS.CTPN);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.connstr;
                this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pos = bdsCTPN.Position;
            //pnTT.Enabled = true;
            bdsCTPN.AddNew();
            //txtMANV.Text = Program.frmChinh.manv2.Text;
            //txtDate.DateTime = dt;

            ccbMAHH2.Enabled = txtDG2.Enabled = txtSL2.Enabled = false;

            btnThem2.Enabled = btnXoa2.Enabled = btnExit2.Enabled = btnReload2.Enabled = btnGhi2.Enabled= btnLoad.Enabled = false;
            btnPH2.Enabled = btnLoad2.Enabled= true;
            gcCTPN.Enabled = false;

        }

        private void btnLoad2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ccbMAPN2.Text == "")
            {
                MessageBox.Show("Số phiếu không được để trống.");
                txtMANV.Focus();
                return;
            }


            try
            {
           
                string query2 = "EXEC SP_CLONE_CTDDH @SOPN";

                Program.conn.Open();
                cmd2 = new SqlCommand(query2, Program.conn);
                cmd2.Parameters.AddWithValue("@SOPN", ccbMAPN2.SelectedValue);

                cmd2.ExecuteNonQuery();
                this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Fill(this.dS.CTPN);

                MessageBox.Show("Load thành công.");
                Program.conn.Close();

                btnThem2.Enabled = btnXoa2.Enabled = btnExit2.Enabled = btnReload2.Enabled = btnLoad.Enabled = true;
                btnGhi2.Enabled = btnPH2.Enabled = btnLoad2.Enabled = false;
                gcCTPN.Enabled = true;

                ccbMAPN2.Enabled = txtDG2.Enabled = txtSL2.Enabled = true;


            }
            catch (Exception ex)
            {
                Program.conn.Close();
                return;
            }

        }
    }
}
