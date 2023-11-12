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
    public partial class frmLoaiHang : Form
    {
        public frmLoaiHang()
        {
            InitializeComponent();
        }

        private void loaiHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLH.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        SqlCommand cmd = new SqlCommand();
        int pos = 0;
        String macn = "";

        private bool checkID()
        {
            SqlConnection conn = new SqlConnection(Program.connstr_pulisher);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM LoaiHang WHERE (MALH = @manv)", conn);
            cmd.Parameters.AddWithValue("@manv", txtMALH.Text);
            int UserExist = (int)cmd.ExecuteScalar();

            if (UserExist > 0)
            {
                conn.Close();
                return true;

            }
            conn.Close();
            return false;

        }

        private void frmLoaiHang_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'dS.LoaiHang' table. You can move, or remove it, as needed.
            this.loaiHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.loaiHangTableAdapter.Fill(this.dS.LoaiHang);

            //macn = ((DataRowView)bdsLH[0])["MACN"].ToString();
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

        private void loaiHangBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void mALHTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.loaiHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.loaiHangTableAdapter.Fill(this.dS.LoaiHang);
        }

        private void btnPH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLH.CancelEdit();
            if (btnThem.Enabled == false) bdsLH.Position = pos;
            gcLH.Enabled = true;
            //pnTT.Enabled = false;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnExit.Enabled = btnReload.Enabled = true;
            btnGhi.Enabled = btnPH.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pos = bdsLH.Position;
            //pnTT.Enabled = true;
            bdsLH.AddNew();
            //txtMALH.Text = macn;

            btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnExit.Enabled = btnReload.Enabled = false;
            btnGhi.Enabled = btnPH.Enabled = true;
            gcLH.Enabled = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMALH.Text == "")
            {
                MessageBox.Show("Mã loại hàng không được để trống.");
                txtMALH.Focus();
                return;

            }
            else if (txtTEN.Text == "")
            {
                MessageBox.Show("Tên không được để trống.");
                txtTEN.Focus();
                return;

            }
            

            string manv = ((DataRowView)bdsLH[bdsLH.Position])["MALH"].ToString();

            if (txtMALH.Text != manv)
            {
                MessageBox.Show("Mã loại hàng không trùng.");
            }
            else
            {
                try
                {
                    string query = "UPDATE LoaiHang SET TENLH= @TEN WHERE MALH=@MALH";

                    Program.conn.Open();
                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MALH", txtMALH.Text);
                    cmd.Parameters.AddWithValue("@TEN", txtTEN.Text);
        

                    cmd.ExecuteNonQuery();
                    this.loaiHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.loaiHangTableAdapter.Fill(this.dS.LoaiHang);

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
            if (txtMALH.Text == "")
            {
                MessageBox.Show("Mã loại hàng không được để trống.");
                txtMALH.Focus();
                return;

            }
            else if (txtTEN.Text == "")
            {
                MessageBox.Show("Tên không được để trống.");
                txtTEN.Focus();
                return;

            }
            

            if (checkID() == true)
            {
                MessageBox.Show("Mã loại hàng đã tồn tại.");
            }
            else
            {
                try
                {

                    string query = "INSERT INTO LoaiHang(MALH, TENLH)" +
                        "VALUES(@MANV ,@TEN)";

                    Program.conn.Open();
                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", txtMALH.Text);
                    cmd.Parameters.AddWithValue("@TEN", txtTEN.Text);
   

                    cmd.ExecuteNonQuery();
                    this.loaiHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.loaiHangTableAdapter.Fill(this.dS.LoaiHang);

                    MessageBox.Show("Thêm thành công.");
                    Program.conn.Close();

                    btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnExit.Enabled = btnReload.Enabled = true;
                    btnGhi.Enabled = btnPH.Enabled = false;
                    gcLH.Enabled = true;

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
            if (txtMALH.Text == "")
            {
                MessageBox.Show("Mã loại hàng không được để trống.");
                txtMALH.Focus();
                return;

            }
            else if (txtTEN.Text == "")
            {
                MessageBox.Show("Tên không được để trống.");
                txtTEN.Focus();
                return;

            }

            if (MessageBox.Show("Bạn muốn xóa loại hàng này?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    string query = "DELETE FROM LoaiHang WHERE MALH = @MANV";
                    Program.conn.Open();

                    cmd = new SqlCommand(query, Program.conn);
                    cmd.Parameters.AddWithValue("@MANV", txtMALH.Text);

                    cmd.ExecuteNonQuery();
                    this.loaiHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.loaiHangTableAdapter.Fill(this.dS.LoaiHang);

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

            if (bdsLH.Count == 0) btnXoa.Enabled = false;
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
                this.loaiHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.loaiHangTableAdapter.Fill(this.dS.LoaiHang);
            }
        }
    }
    
}
