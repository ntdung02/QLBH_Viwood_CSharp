using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace QLBH_NoiThatViwood
{
    public partial class Frm_CTHoaDon : Form
    {
        public string tempHD;
        public string tempDD;
        public Frm_CTHoaDon()
        {
            InitializeComponent();
        }


        private void Frm_CTHoaDon_Load(object sender, EventArgs e)
        {
            txtMaHoaDon.Text = tempHD;
            txtMaDonDat.Text = tempDD;
            UpdateGridView();
            txtMaHoaDon.Enabled = false;
        }

        void UpdateGridView()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                var rs = db.CTHoaDon
                      .Include(s => s.SanPham)
                      .Where(s => s.MaHoaDon == txtMaHoaDon.Text)
                      .Select(s => new
                      {
                          MaSP = s.MaSP,
                          TenSanPham = s.SanPham.TenSanPham,
                          SoLuong = s.SoLuong,
                          ThanhTien = s.SoLuong * s.SanPham.GiaBan,
                      }).ToList();


                dgvDSHoaDon.AutoGenerateColumns = false;
                dgvDSHoaDon.DataSource = rs;
            }
        }
    }
}
