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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private SqlConnection conn_publisher = new SqlConnection();
        

        private int conn_SvPublisher()
        {
            if (conn_publisher != null && conn_publisher.State == ConnectionState.Open) conn_publisher.Close();

            try
            {
                conn_publisher.ConnectionString = Program.connstr_pulisher;
                conn_publisher.Open();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        private void getDSPM(String cmd)
        {

            DataTable dt = new DataTable();
            if (conn_publisher.State == ConnectionState.Closed) conn_publisher.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn_publisher);
            da.Fill(dt);
            conn_publisher.Close();
            Program.bds_dspm.DataSource = dt;
            ccbCN.DataSource = Program.bds_dspm;
            ccbCN.DisplayMember = "TENCN";
            ccbCN.ValueMember = "TENSERVER";


        }

        private bool checkUser()
        {
            SqlConnection conn = new SqlConnection(Program.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM NhanVien WHERE MANV = @manv AND TrangThai='True'", conn);
            cmd.Parameters.AddWithValue("@manv", Program.username);
            int UserExist = (int)cmd.ExecuteScalar();

            if (UserExist > 0)
            {
                conn.Close();
                return true;

            }
            conn.Close();
            return false;

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ccbCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = ccbCN.SelectedValue.ToString();
            }
            catch (Exception) { }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
            //Program.frmChinh.Close();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            if (txtTDN.Text.Trim() == "" || txtMK.Text.Trim() == "")
            {
                MessageBox.Show("Tên đăng nhập và Mật khẩu không được trống!");
                return;
            }

            Program.mlogin = txtTDN.Text;
            Program.password = txtMK.Text;
            if (Program.KetNoi() == 0) return;

            Program.mChinhanh = ccbCN.SelectedIndex;
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;

            String cmd = "EXEC SP_DANGNHAP '" + Program.mlogin + "' ";
            Program.myReader = Program.ExecSqlDataReader(cmd);
            if (Program.myReader == null) return;
            Program.myReader.Read();

            Program.username = Program.myReader.GetString(0);
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Bạn không có quyền truy cập!");
                return;
            }

            if (checkUser() == false)
            {
                MessageBox.Show("Nhân viên đang không hoạt động!");
                return;
            }


            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();
            Program.conn.Close();
            Program.frmChinh.manv2.Text = Program.username;
            Program.frmChinh.MANV.Text = "Mã NV: " + Program.username;
            Program.frmChinh.HOTEN.Text = "Họ và tên: " + Program.mHoten;
            Program.frmChinh.NHOM.Text = "Nhóm: " + Program.mGroup;
            Program.frmChinh.showMenu();

        }

       

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            if (conn_SvPublisher() == 0) return;
            getDSPM("SELECT * FROM V_DS_PHANMANH");
            ccbCN.SelectedIndex = 1;
            ccbCN.SelectedIndex = 0;
        }
    }
}
