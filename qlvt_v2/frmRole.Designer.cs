
namespace qlvt_v2
{
    partial class frmRole
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ccbRole = new System.Windows.Forms.ComboBox();
            this.ccbChinhanh = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDK = new System.Windows.Forms.Button();
            this.txtMANV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ccbRole);
            this.panelControl1.Controls.Add(this.ccbChinhanh);
            this.panelControl1.Controls.Add(this.label7);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Controls.Add(this.btnDK);
            this.panelControl1.Controls.Add(this.txtMANV);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Location = new System.Drawing.Point(47, 63);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(642, 236);
            this.panelControl1.TabIndex = 1;
            // 
            // ccbRole
            // 
            this.ccbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ccbRole.FormattingEnabled = true;
            this.ccbRole.Location = new System.Drawing.Point(216, 68);
            this.ccbRole.Name = "ccbRole";
            this.ccbRole.Size = new System.Drawing.Size(167, 21);
            this.ccbRole.TabIndex = 15;
            // 
            // ccbChinhanh
            // 
            this.ccbChinhanh.FormattingEnabled = true;
            this.ccbChinhanh.Location = new System.Drawing.Point(216, 31);
            this.ccbChinhanh.Name = "ccbChinhanh";
            this.ccbChinhanh.Size = new System.Drawing.Size(167, 21);
            this.ccbChinhanh.TabIndex = 14;
            this.ccbChinhanh.SelectedIndexChanged += new System.EventHandler(this.ccbChinhanh_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(108, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Chi nhánh:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(108, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Role:";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(454, 157);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(99, 31);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDK
            // 
            this.btnDK.Location = new System.Drawing.Point(304, 157);
            this.btnDK.Name = "btnDK";
            this.btnDK.Size = new System.Drawing.Size(99, 31);
            this.btnDK.TabIndex = 9;
            this.btnDK.Text = "Lưu";
            this.btnDK.UseVisualStyleBackColor = true;
            this.btnDK.Click += new System.EventHandler(this.btnDK_Click);
            // 
            // txtMANV
            // 
            this.txtMANV.Location = new System.Drawing.Point(216, 102);
            this.txtMANV.Name = "txtMANV";
            this.txtMANV.Size = new System.Drawing.Size(167, 21);
            this.txtMANV.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã nhân viên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thay đổi role của user";
            // 
            // frmRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmRole";
            this.Text = "frmRole";
            this.Load += new System.EventHandler(this.frmRole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.ComboBox ccbRole;
        private System.Windows.Forms.ComboBox ccbChinhanh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDK;
        private System.Windows.Forms.TextBox txtMANV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}