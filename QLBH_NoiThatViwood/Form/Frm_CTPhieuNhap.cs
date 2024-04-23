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
    public partial class Frm_CTPhieuNhap : Form
    {
        CTNhapHang model = new CTNhapHang();
        SanPham model_SP = new SanPham();
        public string temp;
        public Frm_CTPhieuNhap()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xử lý ngoại lệ cho giá trị đầu vào
        /// </summary>
        /// <param name="soluong"> Tên ô textbox cần xử lý </param>
        /// <returns> true/false </returns>
        bool XyLyNgoaiLe(TextBox soluong)
        {
            bool check = true;
            try
            {
                if (string.IsNullOrEmpty(soluong.Text))
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin vào ô " + soluong.Name);
                }
                model.SoLuong = int.Parse(soluong.Text);
            }
            catch (FormatException)
            {
                check = false;
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ vào ô " + soluong.Name);
            }
            catch (Exception ex)
            {
                check = false;
                MessageBox.Show(ex.Message);
            }

            return check;
        }


        /// <summary>
        /// Sự kiện load form Frm_CTPhieuNhap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_CTPhieuNhap_Load(object sender, EventArgs e)
        {
            txtMaPhieuNhap.Enabled = false;
            radMaSanPham.Checked = true;
            txtMaPhieuNhap.Text = temp;
            cbxMaSanPham.DataSource = model.CbxMaSanPham();
            UpdateGridView();
        }


        /// <summary>
        /// Phương thức Tạo mới giá trị các ô textbox
        /// </summary>
        void Clear()
        {
            txtSoLuong.Text =  "";
            cbxMaSanPham.Enabled = true;
            cbxMaSanPham.SelectedIndex = 0;
        }


        /// <summary>
        /// Phương thức load dữ liệu Chi tiết phiếu nhập lên Datagridview
        /// </summary>
        void UpdateGridView( )
        {

            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                var rs = db.CTNhapHang
                    .Include(s => s.SanPham)
                    .Where (s=> s.MaNhapHang == txtMaPhieuNhap.Text)
                    .Select(s => new
                    {
                        MaNhapHang = s.MaNhapHang,
                        MaSP = s.MaSP,
                        TenSanPham = s.SanPham.TenSanPham,
                        SoLuong = s.SoLuong,
                        ThanhTien = s.SoLuong *s.SanPham.GiaNhap,
                    }).ToList();

                dgvDSCTNhapHang.AutoGenerateColumns = false;
                dgvDSCTNhapHang.DataSource = rs;
            }
        }


        /// <summary>
        /// Sự kiện click button Thêm thông tin Chi tiết phiếu nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (XyLyNgoaiLe(txtSoLuong) == true)
            {
                model.MaNhapHang = txtMaPhieuNhap.Text;
                model.MaSP = cbxMaSanPham.Text;
                model_SP.SoLuongTon += Convert.ToInt32(txtSoLuong.Text);

                model.Insert(model);
                Clear();
                UpdateGridView();
            }
        }


        /// <summary>
        /// Sự kiện click button Xoá thông tin chi tiết phiếu nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                string maSanPham = dgvDSCTNhapHang.CurrentRow.Cells[1].Value.ToString();
                model = db.CTNhapHang.FirstOrDefault(item => item.MaSP.Equals(maSanPham));

                if (model != null)
                {
                    model.Delete(model, db);
                    UpdateGridView();
                    Clear();
                }
            }
        }


        /// <summary>
        /// Sự kiện clic vào button Sửa thông tin phiếu nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (XyLyNgoaiLe(txtSoLuong) == true)
            {
                model.SoLuong= int.Parse(txtSoLuong.Text);

                model.Update(model);
                Clear();
                UpdateGridView();
                btnThem.Enabled = true;
            }
        }


        /// <summary>
        /// Sự kiện click vào datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSCTNhapHang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThem.Enabled = false;
            cbxMaSanPham.Enabled = false;
            model.MaSP = dgvDSCTNhapHang.CurrentRow.Cells[1].Value.ToString();
            model.MaNhapHang = dgvDSCTNhapHang.CurrentRow.Cells[0].Value.ToString();
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                model = db.CTNhapHang.Where(x => x.MaSP == model.MaSP && x.MaNhapHang == model.MaNhapHang).FirstOrDefault();
                cbxMaSanPham.Text = dgvDSCTNhapHang.CurrentRow.Cells[1].Value.ToString();
                txtMaPhieuNhap.Text = model.MaNhapHang;
                txtSoLuong.Text = model.SoLuong.ToString();
            }
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
                    if (radMaSanPham.Checked == true)
                        dgvDSCTNhapHang.DataSource = model.TimKiemTheoMaSanPham(txtTimKiem, txtMaPhieuNhap);
                    if (radTenSanPham.Checked == true)
                        dgvDSCTNhapHang.DataSource = model.TimKiemTheoTenSanPham(txtTimKiem, txtMaPhieuNhap);
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
