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
    public partial class Frm_CTDonDatHang : Form
    {
        CTDonDatHang model = new CTDonDatHang();
        SanPham model_SP = new SanPham();
        public string temp;
        public Frm_CTDonDatHang()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hàm xử lý ngoại lệ cho textbox
        /// </summary>
        /// <param name="soluong"> textbox Số lượng đặt </param>
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
                model.SoLuongDat = int.Parse(soluong.Text);
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
        /// Phương thức Refresh các ô textbox
        /// </summary>
        void Clear() 
        {
            txtSoLuong.Text = txtTimKiem.Text = "";
            cbxMaSanPham.Enabled = true;
            cbxMaSanPham.SelectedIndex  = 0;
        }

        /// <summary>
        /// Sự kiện Load form Frm_CTDonDatHang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_CTDonDatHang_Load(object sender, EventArgs e)
        {
            txtMaDonDat.Enabled = false;
            radMaSanPham.Checked = true;
            txtMaDonDat.Text = temp;
            cbxMaSanPham.DataSource = model.CbxMaSanPham();
            UpdateGridView();
            
        }


        /// <summary>
        /// Phương thức Load dữ liệu từ vw_DSChiTietDonDatHang lên DataGridView dgvDSCTDonHang
        /// </summary>
        void UpdateGridView()
        {
            dgvDSCTDonHang.AutoGenerateColumns = false;
            dgvDSCTDonHang.DataSource = model.List_ChiTietDonDatHang(txtMaDonDat);
        }


        /// <summary>
        /// Sự kiện Click vào GridView load dữ liệu lên các textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSCTDonHang_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThem.Enabled = false;
            cbxMaSanPham.Enabled = false;
            model.MaSP = dgvDSCTDonHang.CurrentRow.Cells[1].Value.ToString();
            model.MaDonDat = dgvDSCTDonHang.CurrentRow.Cells[0].Value.ToString();
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                model = db.CTDonDatHang.Where(x => x.MaSP == model.MaSP && x.MaDonDat == model.MaDonDat).FirstOrDefault();
                cbxMaSanPham.Text = dgvDSCTDonHang.CurrentRow.Cells[1].Value.ToString();
                txtMaDonDat.Text = model.MaDonDat;
                txtSoLuong.Text = model.SoLuongDat.ToString();
            }
        }


        /// <summary>
        /// Sự kiện click vào button Thêm thông tin CHi tiết đơn đặt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (XyLyNgoaiLe(txtSoLuong) == true)
            {
                model.MaDonDat = txtMaDonDat.Text;
                model.MaSP= cbxMaSanPham.Text;
                model_SP.SoLuongTon -= Convert.ToInt32(txtSoLuong.Text);

                model.Insert(model);
                Clear();
                UpdateGridView();
            }
        }


        /// <summary>
        /// Sự kiện click vào button Tạo mới Thông tin Chi tiết đơn đặt
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
        /// Sự kiện click vào button Tìm kiếm thông tin 
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
                        dgvDSCTDonHang.DataSource = model.TimKiemTheoMaMaSanPham(txtTimKiem, txtMaDonDat);
                    if (radTenSanPham.Checked == true)
                        dgvDSCTDonHang.DataSource = model.TimKiemTheoMaTenSanPham(txtTimKiem, txtMaDonDat);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: "+ ex.Message);
            }
        }


        /// <summary>
        /// Sự kiện click vào button Xoá thông tin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                string maSanPham = dgvDSCTDonHang.CurrentRow.Cells[1].Value.ToString();
                model = db.CTDonDatHang.FirstOrDefault(item => item.MaSP.Equals(maSanPham));

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
            if (XyLyNgoaiLe(txtSoLuong) == true)
            {
                model.SoLuongDat = int.Parse(txtSoLuong.Text);

                model.Update(model);
                Clear();
                UpdateGridView();
                btnThem.Enabled = true;
            }
        }
    }
}
