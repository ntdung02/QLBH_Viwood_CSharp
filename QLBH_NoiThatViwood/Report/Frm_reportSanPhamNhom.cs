using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_NoiThatViwood.Report
{
    public partial class Frm_reportSanPhamNhom : Form
    {
        public Frm_reportSanPhamNhom()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.sanPhamNhomTableAdapter.Fill(this.dataSet1.SanPhamNhom, txtTenNhom.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
