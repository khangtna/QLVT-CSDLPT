using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace qlvt_v2
{
    public partial class Xrpt_TonghopNhapXuat : DevExpress.XtraReports.UI.XtraReport
    {
        public Xrpt_TonghopNhapXuat()
        {
            //InitializeComponent();

        }
        public Xrpt_TonghopNhapXuat(DateTime from, DateTime to)
         {
             InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = from;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = to;
            this.sqlDataSource1.Fill();
          }
       }
   }
