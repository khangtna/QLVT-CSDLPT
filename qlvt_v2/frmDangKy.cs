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
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }

        SqlCommand cmd = new SqlCommand();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

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
        private bool checkUsername()
        {
            SqlConnection conn = new SqlConnection(Program.connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM master.dbo.syslogins WHERE (name = @username)", conn);
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            int UserExist = (int)cmd.ExecuteScalar();

            if (UserExist > 0)
            {
                conn.Close();
                return true;

            }
            conn.Close();
            return false;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            if (txtMANV.Text == "")
            {
                MessageBox.Show("Mã nhân viên không được để trống.");
                txtMANV.Focus();
                return;

            }
            else if (txtUsername.Text == "")
            {
                MessageBox.Show("Username không được để trống.");
                txtUsername.Focus();
                return;

            }
            else if (txtPass.Text == "")
            {
                MessageBox.Show("Tên không được để trống.");
                txtPass.Focus();
                return;

            }
            else if (txtConfirm.Text == "")
            {
                MessageBox.Show("Xác nhận password không được để trống.");
                txtConfirm.Focus();
                return;

            }

            if (txtPass.Text != txtConfirm.Text)
            {
                MessageBox.Show("Xác nhận password không trùng với password.");
                txtConfirm.Focus();
                return;

            }
            if (checkID() == false)
            {
                MessageBox.Show("Mã nhân viên không tồn tại trong chi nhánh này.");
                txtMANV.Focus();
                return;
            }
            if (checkUsername() == true)
            {
                MessageBox.Show("Username đã tồn tại.");
                txtUsername.Focus();
                return;

            }

            string username = txtUsername.Text;
            string manv = txtMANV.Text;
            string pass = txtPass.Text;
            string role = ccbRole.Text;

            String query = "exec sp_Dangky '" + username + "', '" + pass + "', '" + manv + "', '" + role + "'";
            int check = Program.ExecSqlNonQuery(query, Program.connstr);

            if (check == 0)
            {

                MessageBox.Show("Đăng ký thành công.");
                Program.conn.Close();

            }
            else
            {
                MessageBox.Show("Nhân viên này đã có tài khoản.");
                Program.conn.Close();
            }

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            ccbChinhanh.DataSource = Program.bds_dspm;
            ccbChinhanh.DisplayMember = "TENCN";
            ccbChinhanh.ValueMember = "TENSERVER";
            ccbChinhanh.SelectedIndex = Program.mChinhanh;

            ccbChinhanh.Enabled = false;

            //txtRole.Text = Program.mGroup;

            if (Program.mGroup == "CONGTY")
            {
                ccbRole.Items.Add("CONGTY");
                ccbRole.Items.Add("CHINHANH");
                ccbRole.Items.Add("USER");


            }
            else
            {
                ccbRole.Items.Add("CHINHANH");
                ccbRole.Items.Add("USER");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnTest_Click(object sender, EventArgs e)
        {


            MessageBox.Show(ccbRole.Text.ToString());
        }

        private void ccbChinhanh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

