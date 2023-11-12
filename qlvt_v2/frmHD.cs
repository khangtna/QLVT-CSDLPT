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
    public partial class frmHD : Form
    {
        public frmHD()
        {
            InitializeComponent();
        }

        private void hOADONBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsHD.EndEdit();
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


        private void getMAHD()
        {
            string query = "SELECT * FROM HOADON";

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Program.connstr);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            conn.Close();
            bds_pn.DataSource = dt;
            ccbMAHD2.DataSource = bds_pn;
            ccbMAHD2.DisplayMember = "SOHD";
            ccbMAHD2.ValueMember = "SOHD";

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

        private void getMAKH()
        {
            string query = "SELECT * FROM KhachHang";

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Program.connstr);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            conn.Close();
            bds_ddh2.DataSource = dt;
            ccbMAKH.DataSource = bds_ddh2;
            ccbMAKH.DisplayMember = "TEN";
            ccbMAKH.ValueMember = "MAKH";

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

        private void frmHD_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;

            this.hOADONTableAdapter.Connection.ConnectionString = Program.connstr;
            this.hOADONTableAdapter.Fill(this.dS.HOADON);

            this.cTHDTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTHDTableAdapter.Fill(this.dS.CTHD);

            getMAHD();
            getMAHH();
            getMAKHO();
            getMAKH();

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

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnExit2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnReload2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            

            this.cTHDTableAdapter.Connection.ConnectionString = Program.connstr;
            this.cTHDTableAdapter.Fill(this.dS.CTHD);
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.hOADONTableAdapter.Connection.ConnectionString = Program.connstr;
            this.hOADONTableAdapter.Fill(this.dS.HOADON);
        }

        private void btnPH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsHD.CancelEdit();
            if (btnThem.Enabled == false) bdsHD.Position = pos;
            gcHD.Enabled = true;
            //pnTT.Enabled = false;

            btnThem.Enabled = btnXoa.Enabled = btnExit.Enabled = btnReload.Enabled = true;
            btnGhi.Enabled = btnPH.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pos = bdsHD.Position;
            //pnTT.Enabled = true;
            bdsHD.AddNew();
            txtMANV.Text = Program.frmChinh.manv2.Text;
            txtDate.DateTime = dt;

            btnThem.Enabled = btnXoa.Enabled = btnExit.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnPH.Enabled = true;
            gcHD.Enabled = false;
        }

        private bool checkID()
        {
            SqlConnection conn = new SqlConnection(Program.connstr_pulisher);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM HOADON WHERE (SOHD = @manv)", conn);
            cmd.Parameters.AddWithValue("@manv", txtMAHD.Text);
            int UserExist = (int)cmd.ExecuteScalar();

            if (UserExist > 0)
            {
                conn.Close();
                return true;

            }
            conn.Close();
            return false;

        }

        private bool checkSLT(string sl)
        {
            //int soluongton = -1;

            SqlConnection conn = new SqlConnection(Program.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT total FROM VIEW_SLT_KHO WHERE MAHH = @manv and MAKHO= (select MAKHO from HOADON where SOHD= @sohd)", conn);
            cmd.Parameters.AddWithValue("@manv", ccbMAHH2.SelectedValue);
            cmd.Parameters.AddWithValue("@sohd", ccbMAHD2.SelectedValue);
            int soluongton = (int)cmd.ExecuteScalar();
 
            int soluong;


            if (int.TryParse(sl, out soluong) && soluongton >= soluong)
            {
                conn.Close();
                return true;

            }
            conn.Close();
            return false;

        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMAHD.Text == "")
            {
                MessageBox.Show("Số hoá đơn không được để trống.");
                txtMAHD.Focus();
                return;

            }
            else if (ccbMAKHO.Text == "")
            {
                MessageBox.Show("Mã kho không được để trống.");
                ccbMAKHO.Focus();
                return;

            }
            else if (ccbMAKH.Text == "")
            {
                MessageBox.Show("Mã khách hàng không được để trống.");
                ccbMAKH.Focus();
                return;

            }



            if (checkID() == true)
            {
                MessageBox.Show("Số hoá đơn đã tồn tại.");
            }
            else
            {
                try
                {

                    string query = "INSERT INTO HOADON(SOHD, MAKH, NGAY, MAKHO, MANV)" +
                        "VALUES(@SoPN ,@MAKH, @NGAY, @MAKHO, @MANV)";

                    Program.conn.Open();
                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@SoPN", txtMAHD.Text);
                    cmd.Parameters.AddWithValue("@NGAY", txtDate.DateTime);
                    cmd.Parameters.AddWithValue("@MAKH", ccbMAKH.SelectedValue);
                    cmd.Parameters.AddWithValue("@MAKHO", ccbMAKHO.SelectedValue);
                    cmd.Parameters.AddWithValue("@MANV", txtMANV.Text);


                    cmd.ExecuteNonQuery();
                    this.hOADONTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.hOADONTableAdapter.Fill(this.dS.HOADON);
                    MessageBox.Show("Thêm thành công.");
                    Program.conn.Close();

                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnExit.Enabled = btnReload.Enabled = true;
                    btnGhi.Enabled = btnPH.Enabled = false;
                    gcHD.Enabled = true;

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

            if (bdsCTHD.Count > 0)
            {
                MessageBox.Show("Không thể xoá hoá đơn này vì đã lập chi tiết hoá đơn.");
                return;
            }


            if (MessageBox.Show("Bạn muốn xóa hoá đơn này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    string query = "DELETE FROM HOADON WHERE SOHD = @MANV";
                    Program.conn.Open();

                    //manv = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());
                    //bdsNV.RemoveCurrent();
                    //this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                    //this.nhanVienTableAdapter.Update(this.dS.NhanVien);

                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", txtMAHD.Text);

                    cmd.ExecuteNonQuery();
                    this.hOADONTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.hOADONTableAdapter.Fill(this.dS.HOADON);

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

            if (bdsHD.Count == 0) btnXoa.Enabled = false;
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
                this.hOADONTableAdapter.Connection.ConnectionString = Program.connstr;
                this.hOADONTableAdapter.Fill(this.dS.HOADON);

                this.cTHDTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTHDTableAdapter.Fill(this.dS.CTHD);
            }
        }

        private void btnThem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pos = bdsCTHD.Position;
            //pnTT.Enabled = true;
            bdsCTHD.AddNew();
            //txtMANV.Text = Program.frmChinh.manv2.Text;
            //txtDate.DateTime = dt;

            btnThem2.Enabled = btnXoa2.Enabled = btnExit2.Enabled = btnReload2.Enabled = false;
            btnGhi2.Enabled = btnPH2.Enabled = true;
            gcCTHD.Enabled = false;
        }

        private void btnGhi2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ccbMAHD2.Text == "")
            {
                MessageBox.Show("Số hoá đơn không được để trống.");
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

            //int sl = int(txtSL2.Text.Trim());

            if (checkSLT(txtSL2.Text.Trim())== false)
            {
                MessageBox.Show("Số lượng tồn trong kho này không đủ.");
                return;
            }


            try
            {

                string query2 = "EXEC SP_GIAMSL_KHO @MAHH, @SOHD, @SL";

                Program.conn.Open();
                cmd2 = new SqlCommand(query2, Program.conn);
                cmd2.Parameters.AddWithValue("@MAHH", ccbMAHH2.SelectedValue);
                cmd2.Parameters.AddWithValue("@SL", txtSL2.Text);
                cmd2.Parameters.AddWithValue("@SOHD", ccbMAHD2.SelectedValue);


                cmd2.ExecuteNonQuery();

                string query = "INSERT INTO CTHD(SOHD, MAHH, SOLUONG, DONGIA)" +
                    "VALUES(@SoPN ,@MAHH, @SL, @DG)";

                //Program.conn.Open();
                cmd = new SqlCommand(query, Program.conn);
                cmd.Parameters.AddWithValue("@SoPN", ccbMAHD2.SelectedValue);
                cmd.Parameters.AddWithValue("@MAHH", ccbMAHH2.SelectedValue);
                cmd.Parameters.AddWithValue("@SL", txtSL2.Text);
                cmd.Parameters.AddWithValue("@DG", txtDG2.Text);
                cmd.ExecuteNonQuery();


                
                this.cTHDTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTHDTableAdapter.Fill(this.dS.CTHD);

                MessageBox.Show("Thêm thành công.");
                Program.conn.Close();

                btnThem2.Enabled = btnXoa2.Enabled = btnExit2.Enabled = btnReload2.Enabled = true;
                btnGhi2.Enabled = btnPH2.Enabled = false;
                gcCTHD.Enabled = true;

            }
            catch (Exception ex)
            {
                Program.conn.Close();
                return;
            }
        }

        private void btnXoa2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {



            if (MessageBox.Show("Bạn muốn xóa chi tiết hoá đơn này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    string query2 = "EXEC SP_TANGSL_KHO @MAHH, @SOHD, @SL";
                    //string query2 = "EXEC SP_XOA_HD @MAHH, @SL, @SOHD";

                    Program.conn.Open();
                    cmd3 = new SqlCommand(query2, Program.conn);
                    cmd3.Parameters.AddWithValue("@MAHH", ccbMAHH2.SelectedValue);
                    cmd3.Parameters.AddWithValue("@SL", txtSL2.Text.Trim());
                    cmd3.Parameters.AddWithValue("@SOHD", ccbMAHD2.SelectedValue);


                    cmd3.ExecuteNonQuery();

                    string query = "DELETE FROM CTHD WHERE SOHD = @MANV and MAHH= @MAHH";
                    

                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", ccbMAHD2.SelectedValue);
                    cmd.Parameters.AddWithValue("@MAHH", ccbMAHH2.SelectedValue);

                    cmd.ExecuteNonQuery();
                    //Program.conn.Close();

                   

                    this.cTHDTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTHDTableAdapter.Fill(this.dS.CTHD);

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

            if (bdsCTHD.Count == 0) btnXoa2.Enabled = false;
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

        private void btnPH2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsCTHD.CancelEdit();
            if (btnThem.Enabled == false) bdsCTHD.Position = pos;
            gcCTHD.Enabled = true;
            //pnTT.Enabled = false;

            btnThem2.Enabled = btnXoa2.Enabled = btnExit2.Enabled = btnReload2.Enabled = true;
            btnGhi2.Enabled = btnPH2.Enabled = false;
        }
    }
}
