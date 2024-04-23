using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QLBH_NoiThatViwood
{
    public partial class Frm_HoaDon : Form
    {
        HoaDon model = new HoaDon();
        public string temp;
        public Frm_HoaDon()
        {
            InitializeComponent();
            txtMaDonDat.Enabled = false;
            txtNgayLap.Enabled = false;
            txtTongTien.Enabled = false;
        }


        /// <summary>
        /// Xử lý ngoại lệ ô textbox
        /// </summary>
        /// <param name="txt">ô textbox cần xử lý</param>
        /// <returns> true / false</returns>
        bool XyLyNgoaiLe(TextBox txt)
        {
            bool check = true;
            try
            {
                if (txt.Text.Equals(""))
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin vào ô " + txt.Name);
                }
            }
            catch (FormatException)
            {
                check = false;
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ vào ô " + txt.Name);
            }
            catch (Exception ex)
            {
                check = false;
                MessageBox.Show(ex.Message);
            }

            return check;
        }


        /// <summary>
        /// Phương thức tạo mới các ô textbox
        /// </summary>
        void Clear()
        {
            txtMaHoaDon.Text = txtMaDonDat.Text = txtNgayLap.Text = txtTongTien.Text = "";
            cbxMaNhanVien.SelectedIndex = 0;

        }

        /// <summary>
        /// Sự kiện click vào button Xem chi tiết hoá đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXemCTHD_Click(object sender, EventArgs e)
        {
            Frm_CTHoaDon frm_CTHoaDon = new Frm_CTHoaDon();
            frm_CTHoaDon.tempHD = txtMaHoaDon.Text;
            frm_CTHoaDon.tempDD = txtMaDonDat.Text;
            frm_CTHoaDon.ShowDialog();
        }


        /// <summary>
        /// Sự kiện load form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_HoaDon_Load(object sender, EventArgs e)
        {
            txtMaDonDat.Text = temp;
            UpdateGridView();
            cbxMaNhanVien.DataSource = model.CbxMaNhanVien();

        }


        /// <summary>
        /// Phương thức load dữ liệu lên datagridview
        /// </summary>
        void UpdateGridView()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                var rs = db.HoaDon
                      .Include(s => s.NhanVien)
                      .Include(s =>s.CTHoaDon)
                      .Include(s=>s.CTHoaDon)
                      
                      .Select(s => new
                      {
                          MaHoaDon = s.MaHoaDon,
                          MaDonDat = s.MaDonDat,
                          HoTen = s.NhanVien.HoTen,
                          NgayLapHD = s.NgayLap,
     
                          TongTien = s.CTHoaDon.Sum(ct => ct.ThanhTien)
                      }).ToList();

                dgvDSHoaDon.AutoGenerateColumns = false;
                dgvDSHoaDon.DataSource = rs;
            }

        }


        /// <summary>
        /// Sự kiện click vào datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSHoaDon_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThem.Enabled = false;
            model.MaHoaDon = dgvDSHoaDon.CurrentRow.Cells[0].Value.ToString();
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                model = db.HoaDon.Where(x => x.MaHoaDon == model.MaHoaDon).FirstOrDefault();
                txtMaHoaDon.Text = dgvDSHoaDon.CurrentRow.Cells[0].Value.ToString();
                cbxMaNhanVien.Text = model.MaNV;
                txtMaDonDat.Text = model.MaDonDat;
                txtNgayLap.Text = model.NgayLap.Value.ToString("dd/MM/yyyy hh:mm tt");
                int temp = Convert.ToInt32(model.TongTien);
                txtTongTien.Text = temp.ToString("#,###");

            }
        }


        /// <summary>
        /// SỰ kiện click vào button Thêm thông tin hoá đơn 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (XyLyNgoaiLe(txtMaHoaDon) == true)
            {
                model.MaHoaDon = txtMaHoaDon.Text;
                model.MaDonDat = txtMaDonDat.Text;
                model.MaNV = cbxMaNhanVien.Text;
                model.NgayLap = DateTime.UtcNow;
                model.TongTien = 0;

                model.Insert(model);
                Clear();
                UpdateGridView();
            }
        }


        /// <summary>
        /// Sự kiện click vào button tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (XyLyNgoaiLe(txtTimKiem) == true)
            {
                if (radMaHoaDon.Checked == true)
                    dgvDSHoaDon.DataSource = model.TimKiemTheoMaHoaDon(txtTimKiem);
                if (radMaDonDat.Checked == true)
                    dgvDSHoaDon.DataSource = model.TimKiemTheoMaDonDat(txtTimKiem);
                if (radTenNhanVien.Checked == true)
                {
                    using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
                    {
                        var rs = db.HoaDon
                                .Include(s => s.NhanVien)
                                .Where(s => s.NhanVien.HoTen.Contains(txtTimKiem.Text.Trim()))
                                .Select(s => new
                                {
                                    MaHoaDon = s.MaHoaDon,
                                    MaDonDat = s.MaDonDat,
                                    HoTen = s.NhanVien.HoTen,
                                    NgayLapHD = s.NgayLap,
                                    TongTien = s.TongTien
                                })
                                .ToList();

                        dgvDSHoaDon.DataSource = rs;
                    }
                };

            }
        }


        /// <summary>
        /// SỰ kiện click vào button Tạo mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            Clear();
            UpdateGridView();
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            Frm_XuatHoaDon frm_XuatHoaDon = new Frm_XuatHoaDon();
            frm_XuatHoaDon.temp = txtMaHoaDon.Text;
            frm_XuatHoaDon.ShowDialog();
        }

    }
    
}
