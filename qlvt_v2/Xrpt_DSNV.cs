using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace qlvt_v2
{
    public partial class Xrpt_DSNV : DevExpress.XtraReports.UI.XtraReport
    {
        
        public Xrpt_DSNV()
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Fill();
        }
    }
}
