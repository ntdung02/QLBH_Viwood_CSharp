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
    public partial class Frm_PhieuNhap : Form
    {
        NhapHang model = new NhapHang();
        public Frm_PhieuNhap()
        {
            InitializeComponent();
            txtMaPhieuNhap.Enabled = false;
            txtNgayLapDon.Enabled = false;
            txtTongTien.Enabled = false;
        }

        /// <summary>
        /// Phương thức Refresh các ô textbox
        /// </summary>
        void Clear()
        {
            txtMaPhieuNhap.Text = txtNgayLapDon.Text = txtTongTien.Text =  "";
            cbxMaNCC.SelectedIndex = cbxMaNhanVien.SelectedIndex = 0;
            model.MaNhapHang = "";
        }

       
        /// <summary>
        /// Phương thức cập nhật dữ liệu Phiếu nhập lên Datagridview 
        /// </summary>
        void UpdateGridView()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                var rs = db.NhapHang
                    .Include(s => s.NhaCungCap)
                    .Include(s => s.NhanVien).Include(s => s.CTNhapHang)
                    .Select(s => new
                    {
                        MaNhapHang = s.MaNhapHang,
                        TenNCC = s.NhaCungCap.TenNCC,
                        HoTen = s.NhanVien.HoTen,
                        NgayLap = s.NgayLap,
                        TongTien = s.CTNhapHang.Sum(ct =>(int?) ct.ThanhTien)
                    }).ToList();

                dgvDSPhieuNhap.AutoGenerateColumns = false;
                dgvDSPhieuNhap.DataSource = rs;
            }

            

        }


        /// <summary>
        /// Sự kiện click button Xem chi tiết phiếu nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXemCTPN_Click(object sender, EventArgs e)
        {
            Frm_CTPhieuNhap frm_CTPhieuNhap = new Frm_CTPhieuNhap();
            frm_CTPhieuNhap.temp = txtMaPhieuNhap.Text;
            frm_CTPhieuNhap.ShowDialog();
        }


        /// <summary>
        /// Sự kiện load form Frm_PhieuNhap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_PhieuNhap_Load(object sender, EventArgs e)
        {
            UpdateGridView();
            cbxMaNCC.DataSource = model.CbxMaNhaCungCap(); // Load dữ liệu MaNCC vào Combobox
            cbxMaNhanVien.DataSource = model.CbxMaNhanVien();   // Load dữ liệu MaNV vào Combobox
            radMaPhieuNhap.Checked = true;
        }


        /// <summary>
        /// SỰ kiện click vào DatagridView dgvDSNhapHang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSPhieuNhap_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThem.Enabled = false;
            model.MaNhapHang= dgvDSPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                model = db.NhapHang.Where(x => x.MaNhapHang== model.MaNhapHang).FirstOrDefault();
                txtMaPhieuNhap.Text = dgvDSPhieuNhap.CurrentRow.Cells[0].Value.ToString();
                cbxMaNCC.Text = model.MaNCC;
                cbxMaNhanVien.Text = model.MaNV;
                txtNgayLapDon.Text = model.NgayLap.Value.ToString("dd/MM/yyyy hh:mm tt");
                int temp = Convert.ToInt32( model.TongTien);
                txtTongTien.Text = temp.ToString("#,###");

            }
        }


        /// <summary>
        /// Sự kiện click vào button Thêm thông tin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {
                model.MaNhapHang = txtMaPhieuNhap.Text;
                model.MaNCC = cbxMaNCC.Text;
                model.MaNV = cbxMaNhanVien.Text;
                model.NgayLap = DateTime.UtcNow;
                 model.TongTien = 0;
                model.Insert(model);
                Clear();
                UpdateGridView();

        }


        /// <summary>
        /// Sự kiện click vào button Xoá thông tin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                string maPhieuNhap = dgvDSPhieuNhap.CurrentRow.Cells[0].Value.ToString();
                model = db.NhapHang.FirstOrDefault(item => item.MaNhapHang.Equals(maPhieuNhap));

                if (model != null)
                {
                    model.Delete(model, db);
                    UpdateGridView();
                    Clear();
                }
            }
        }


        /// <summary>
        /// Sự kiện click vào button Sửa thông tin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSua_Click(object sender, EventArgs e)
        {

                model.MaNhapHang = txtMaPhieuNhap.Text;
                model.MaNCC = cbxMaNCC.Text;
                model.MaNV = cbxMaNhanVien.Text;
                model.NgayLap = DateTime.UtcNow;
                model.Update(model);
                Clear();
                UpdateGridView();

        }


        /// <summary>
        /// Sự kiện click vào button Tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTimKiem.Text))
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin vào ô tìm kiếm");
                }
                else
                {
                    if (radMaPhieuNhap.Checked == true)
                        dgvDSPhieuNhap.DataSource = model.TimKiemTheoMaNhapHang(txtTimKiem);
                    if (radMaNCC.Checked == true)
                        dgvDSPhieuNhap.DataSource = model.TimKiemTheoTenNCC(txtTimKiem);
                    if (radMaNhanVien.Checked == true)
                        dgvDSPhieuNhap.DataSource = model.TimKiemTheoTenNV(txtTimKiem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }


        /// <summary>
        /// Sự kiện click vào button Tạo mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            Clear();
            UpdateGridView();
        }
    
    }
}
