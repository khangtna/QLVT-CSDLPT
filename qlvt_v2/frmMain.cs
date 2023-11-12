using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace qlvt_v2
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        public void showMenu()
        {
            MessageBox.Show("Đăng nhập thành công.");

            //btCr.Enabled = true;
            ribDK.Visible = ribDX.Visible = ribRole.Visible = true;
            btnDangNhap.Enabled = false;

            if (Program.mGroup == "USER")
            {
                rbLD.Visible = rbVT.Visible = rbNV.Visible  = true;
                rbTK.Visible = true;
                rbBC.Visible = false;

                btnDangKy.Enabled = btnROLE.Enabled= btnDSNV.Enabled= btnDSVT.Enabled= btnTHPX.Enabled= btnKK.Enabled= btnDSDDH.Enabled= btnHDNV.Enabled = false;
            }

            else if (Program.mGroup == "CONGTY")
            {
                rbLD.Visible = rbVT.Visible = rbNV.Visible = rbBC.Visible = true;
                rbTK.Visible = true;
               // btnDangNhap.Enabled = false;
                //btnDangKy.Enabled = btnROLE.Enabled = true;
                btnDangKy.Enabled = btnROLE.Enabled = btnDSNV.Enabled = btnDSVT.Enabled = btnTHPX.Enabled = btnKK.Enabled = btnDSDDH.Enabled = btnHDNV.Enabled = true;



            }
            else
            {
                rbLD.Visible = rbVT.Visible = rbNV.Visible = rbBC.Visible = true;
                rbTK.Visible = true;
                //btnDangNhap.Enabled = false;
                //btnDangKy.Enabled = btnROLE.Enabled = true;
                //ribDK.Visible = ribDX.Visible = ribRole.Visible = true;
                btnDangKy.Enabled = btnROLE.Enabled = btnDSNV.Enabled = btnDSVT.Enabled = btnTHPX.Enabled = btnKK.Enabled = btnDSDDH.Enabled = btnHDNV.Enabled = true;

            }


        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmNhanVien));
            if (frm != null) frm.Activate();
            else
            {
                frmNhanVien f = new frmNhanVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDangNhap));
            if (frm != null)  frm.Activate();
            else
            {
                frmDangNhap f = new frmDangNhap();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDangKy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDangKy));
            if (frm != null) frm.Activate();
            else
            {
                frmDangKy f = new frmDangKy();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            rbLD.Visible = rbVT.Visible = rbNV.Visible = rbBC.Visible= false;
            rbTK.Visible = true;
            ribDK.Visible = ribDX.Visible= ribRole.Visible = false;
        }

        private void logout()
        {
            foreach (Form f in this.MdiChildren)
                f.Dispose();
        }

        private void btnLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            logout();

            rbLD.Visible = rbVT.Visible = rbNV.Visible = rbBC.Visible = false;
            rbTK.Visible = true;
            ribDK.Visible = ribDX.Visible = ribRole.Visible = false;
            btnDangNhap.Enabled = true;

            Program.frmChinh.MANV.Text = "Mã NV: ";
            Program.frmChinh.HOTEN.Text = "Họ và tên: " ;
            Program.frmChinh.NHOM.Text = "Nhóm: ";
        }

        private void aaa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         
        }

        private void btnLoaiHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmLoaiHang));
            if (frm != null) frm.Activate();
            else
            {
                frmLoaiHang f = new frmLoaiHang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnHangHoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmHangHoa));
            if (frm != null) frm.Activate();
            else
            {
                frmHangHoa f = new frmHangHoa();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmKho));
            if (frm != null) frm.Activate();
            else
            {
                frmKho f = new frmKho();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDDH));
            if (frm != null) frm.Activate();
            else
            {
                frmDDH f = new frmDDH();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void NHOM_Click(object sender, EventArgs e)
        {

        }

        private void btnPN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmPN));
            if (frm != null) frm.Activate();
            else
            {
                frmPN f = new frmPN();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnHD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmHD));
            if (frm != null) frm.Activate();
            else
            {
                frmHD f = new frmHD();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnCCN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Form frm = this.CheckExists(typeof(frmCCN));
            if (frm != null) frm.Activate();
            else
            {
                frmCCN f = new frmCCN();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTKK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmTKK));
            if (frm != null) frm.Activate();
            else
            {
                frmTKK f = new frmTKK();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmNCC));
            if (frm != null) frm.Activate();
            else
            {
                frmNCC f = new frmNCC();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmKH));
            if (frm != null) frm.Activate();
            else
            {
                frmKH f = new frmKH();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDSNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmrp_DSNV));
            if (frm != null) frm.Activate();
            else
            {
                frmrp_DSNV f = new frmrp_DSNV();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDSVT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmrp_DSVT));
            if (frm != null) frm.Activate();
            else
            {
                frmrp_DSVT f = new frmrp_DSVT();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDSDDH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
             Form frm = this.CheckExists(typeof(frmrp_REPORTDonhangkhongcoPhieuNhap));
            if (frm != null) frm.Activate();
            else
            {
                frmrp_REPORTDonhangkhongcoPhieuNhap f = new frmrp_REPORTDonhangkhongcoPhieuNhap();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnHDNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmrp_HoatDongCuaNhanVien));
            if (frm != null) frm.Activate();
            else
            {
                frmrp_HoatDongCuaNhanVien f = new frmrp_HoatDongCuaNhanVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTHPX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmrp_TongHopNhapXuat));
            if (frm != null) frm.Activate();
            else
            {
                frmrp_TongHopNhapXuat f = new frmrp_TongHopNhapXuat();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnROLE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmRole));
            if (frm != null) frm.Activate();
            else
            {
                frmRole f = new frmRole();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}
