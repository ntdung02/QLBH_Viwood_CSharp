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
    public partial class Frm_XuatHoaDon : Form
    {
        public string temp;
        public Frm_XuatHoaDon()
        {
            InitializeComponent();
        }

        private void Frm_XuatHoaDon_Load(object sender, EventArgs e)
        {
            txtMaHoaDon.Text = temp;
            // TODO: This line of code loads data into the 'DataSet1.XuatHoaDon' table. You can move, or remove it, as needed.
            this.XuatHoaDonTableAdapter.Fill(this.DataSet1.XuatHoaDon, txtMaHoaDon.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
