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
    public partial class Frm_DonDatHang : Form
    {
        DonDatHang model = new DonDatHang();

        public Frm_DonDatHang()
        {
            InitializeComponent();
            txtMaDonDat.Enabled = false;
            txtNgayLapDon.Enabled = false;
        }

        /// <summary>
        /// Hàm bool xử lý ngoại lệ cho các ô textbox
        /// </summary>
        /// <param name="txt"> là ô textbox cần xử lý </param>
        /// <returns>true/false</returns>
        bool XyLyNgoaiLe(TextBox txt)
        {
            bool check = true;
            try
            {
                if (txt.Text.Equals(""))
                    throw new Exception();
            }
            catch (Exception)
            {
                check = false;
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin ô " +txt.Name);
            }
            return check;
        }


        /// <summary>
        /// Phương thức Refresh các ô textbox
        /// </summary>
        void Clear()
        {
            txtTinhTrang.Text = txtMaDonDat.Text = txtNgayLapDon.Text = txtTimKiem.Text= "";
            cbxMaKhachHang.SelectedIndex = cbxMaNhanVien.SelectedIndex = 0;
            model.MaDonDat = "";
        }


        /// <summary>
        /// Phương thức Load dữ liệu lên DataGridView dgvDSDonDatHang
        /// </summary>
        void UpdateGridView()
        {
                dgvDSDonDatHang.AutoGenerateColumns = false;
                dgvDSDonDatHang.DataSource = model.List_DonDatHang();
        }


        /// <summary>
        /// Sự kiện click button Xem Chi tiết Đơn đặt hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXemCTDD_Click(object sender, EventArgs e)
        {
            Frm_CTDonDatHang frm_CTDonDatHang = new Frm_CTDonDatHang();
            frm_CTDonDatHang.temp = txtMaDonDat.Text;
            frm_CTDonDatHang.ShowDialog();
        }


        /// <summary>
        /// Sự kiện Load form Frm_DonDatHang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_DonDatHang_Load(object sender, EventArgs e)
        {
            UpdateGridView();
            cbxMaKhachHang.DataSource = model.CbxMaKhachHang(); // Load dữ liệu MaKH vào Combobox
            cbxMaNhanVien.DataSource = model.CbxMaNhanVien();   // Load dữ liệu MaNV vào Combobox
            radMaDonDat.Checked = true;
        }


        /// <summary>
        /// Sự kiện Click vào GridView load dữ liệu lên các textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSHoaDon_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThem.Enabled = false;
            model.MaDonDat = dgvDSDonDatHang.CurrentRow.Cells[0].Value.ToString();
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                model = db.DonDatHang.Where(x => x.MaDonDat== model.MaDonDat).FirstOrDefault();
                txtMaDonDat.Text = dgvDSDonDatHang.CurrentRow.Cells[0].Value.ToString();
                cbxMaKhachHang.Text = model.MaKH;
                cbxMaNhanVien.Text = model.MaNV;
                txtNgayLapDon.Text = model.NgayLap.Value.ToString("dd/MM/yyyy hh:mm tt");
                txtTinhTrang.Text = model.TinhTrang;
 
            }
        }


        /// <summary>
        /// Sự kiện Click vào button Thêm Đơn đặt hàng 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(XyLyNgoaiLe(txtTinhTrang) == true )
            {
                model.MaDonDat = txtMaDonDat.Text;
                model.MaKH = cbxMaKhachHang.Text;
                model.MaNV = cbxMaNhanVien.Text;
                model.TinhTrang = txtTinhTrang.Text;
                model.NgayLap = DateTime.UtcNow;
                model.Insert(model);
                Clear();
                UpdateGridView();
            }
        }


        /// <summary>
        /// Sự kiện click vào button Tạo mới Đơn đặt hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            Clear();
            UpdateGridView();
        }


        /// <summary>
        /// Sự kiện click vào button Xoá Đơn đặt hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                string maDonDat = dgvDSDonDatHang.CurrentRow.Cells[0].Value.ToString();
                model = db.DonDatHang.FirstOrDefault(item => item.MaDonDat.Equals(maDonDat));

                if (model != null)
                {
                    model.Delete(model, db);   
                    UpdateGridView();
                    Clear();
                }
            }
        }


        /// <summary>
        /// Sự kiện click vào button Sửa thông tin Đơn đặt hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSua_Click(object sender, EventArgs e)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                try
                {
                    if (db.HoaDon.Any(ct => ct.MaDonDat == txtMaDonDat.Text) == true)
                    {
                        MessageBox.Show("Đơn hàng này đã có hoá đơn. Bạn không thể sửa nữa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (XyLyNgoaiLe(txtTinhTrang) == true)
                        {
                            model.MaDonDat = txtMaDonDat.Text;
                            model.MaKH = cbxMaKhachHang.Text;
                            model.MaNV = cbxMaNhanVien.Text;
                            model.TinhTrang = txtTinhTrang.Text;
                            model.NgayLap = DateTime.UtcNow;
                            model.Update(model);
                            Clear();
                            UpdateGridView();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Sửa Đơn đặt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }      
        }


        /// <summary>
        /// Sự kiện click vào button Tìm kiếm thông tin Đơn đặt hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(XyLyNgoaiLe(txtTimKiem)== true)
            {
                if (radMaDonDat.Checked == true)
                    dgvDSDonDatHang.DataSource = model.TimKiemTheoMaDon(txtTimKiem);
                if (radTenKhachHang.Checked == true)
                    dgvDSDonDatHang.DataSource = model.TimKiemTheoTenKH(txtTimKiem);
                if (radTenNhanVien.Checked == true)
                    dgvDSDonDatHang.DataSource = model.TimKiemTheoTenNV(txtTimKiem);
                
            }
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            HoaDon model1 = new HoaDon();

            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                try
                {
                    if (db.HoaDon.Any(ct => ct.MaDonDat == txtMaDonDat.Text) == true)
                    {
                        MessageBox.Show("Đơn hàng đã có hoá đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (db.CTDonDatHang.Any(ct => ct.MaDonDat == txtMaDonDat.Text)== false)
                    {
                        MessageBox.Show("Đơn hàng bị trống!!! Vui lòng thêm sản phẩm vào đơn hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        Frm_HoaDon frm_HoaDon = new Frm_HoaDon();
                        frm_HoaDon.temp = txtMaDonDat.Text;
                        frm_HoaDon.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Thêm Hoá đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public bool IsDuplicateCTDonDatHang(HoaDon model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.HoaDon.Any(ct => ct.MaDonDat == model.MaDonDat);
            }
        }

 
    }
}
