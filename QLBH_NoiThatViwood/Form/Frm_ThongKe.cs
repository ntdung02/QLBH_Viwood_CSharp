using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_NoiThatViwood
{
    public partial class Frm_ThongKe : Form
    {
        public Frm_ThongKe()
        {
            InitializeComponent();
        }

        private void Frm_ThongKe_Load(object sender, EventArgs e)
        {
           

        }

        private void btnThongKe_DDH_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.DonDatHang' table. You can move, or remove it, as needed.
            this.DonDatHangTableAdapter.Fill(this.DataSet1.DonDatHang, dtpTuNgay_DDH.Value, dtpDenNgay_DDH.Value);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.NhapHang' table. You can move, or remove it, as needed.
            this.NhapHangTableAdapter.Fill(this.DataSet1.NhapHang, dtpTuNgay_PN.Value, dtpDenNgay_PN.Value);

            this.reportViewer2.RefreshReport();
        }

        private void btnThongKe_HD_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.HoaDon' table. You can move, or remove it, as needed.
            this.HoaDonTableAdapter.Fill(this.DataSet1.HoaDon, dtpTuNgay_HD.Value, dtpDenNgay_HD.Value);

            this.reportViewer3.RefreshReport();
        }
    }
}
