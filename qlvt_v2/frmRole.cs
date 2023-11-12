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
    public partial class frmRole : Form
    {
        public frmRole()
        {
            InitializeComponent();
        }

        private void ccbChinhanh_SelectedIndexChanged(object sender, EventArgs e)
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

        private void frmRole_Load(object sender, EventArgs e)
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
            else if (ccbRole.Text == "")
            {
                MessageBox.Show("Role không được để trống.");
                ccbRole.Focus();
                return;

            }


            if (checkID() == false)
            {
                MessageBox.Show("Mã nhân viên không tồn tại trong chi nhánh này.");
                txtMANV.Focus();
                return;
            }
            
 
            string manv = txtMANV.Text;
            string oldrole = Program.mGroup;
            string newrole = ccbRole.Text;

            String query = "exec SP_CHANGE_ROLE '" + manv + "', '" + oldrole + "', '" + newrole + "'";
            int check = Program.ExecSqlNonQuery(query, Program.connstr);

            if (check == 0)
            {

                MessageBox.Show("Thay đổi thành công.");
                Program.conn.Close();

            }
            else
            {
                MessageBox.Show("Thay đổi thất bại.");
                Program.conn.Close();
            }
        }
    }
}
