using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;

namespace QLBH_NoiThatViwood
{
    public partial class _01_Frm_SanPham : Form
    {
        SanPham model = new SanPham();
        Nhom model2 = new Nhom();
        public _01_Frm_SanPham()
        {
            InitializeComponent();
            txtMaSP.Enabled = false;
            txtMaNhomSP.Enabled = false;
        }

        #region xư lý chung cho Sản phẩm và nhóm hàng

        /// <summary>
        /// Sự kiện load trong form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _01_Frm_SanPham_Load(object sender, EventArgs e)
        {
            cbxNhomSP_SP.DataSource = model.CbxMaNhom();
            cbxNCC_SP.DataSource = model.CbxMaNCC();
            UpdateGridView();
            UpdateGridView2();
            
        }

        /// <summary>
        /// Hàm bool xử lý ngoại lệ cho các ô textbox
        /// </summary>
        /// <param name="txt"> là ô textbox cần xử lý </param>
        /// <returns>true/false</returns>
        bool XuLyNgoaiLe(TextBox txt)
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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin ô " + txt.Name);
            }
            return check;
        }

       
        /// <summary>
        /// Phương thức Load dữ liệu lên DataGridView dgvDSSanPham
        /// </summary>
        void UpdateGridView()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                var rs= db.SanPham
                    .Include(s=>s.Nhom)
                    .Include(s=> s.NhaCungCap)
                    .Select(s => new
                    {
                        MaSP = s.MaSP,
                        TenSanPham = s.TenSanPham,
                        TenNhom = s.Nhom.TenNhom,
                        TenNCC = s.NhaCungCap.TenNCC,
                        GiaNhap =s.GiaNhap,
                        GiaBan= s.GiaBan,
                        SoLuongTon = s.SoLuongTon, 
                        TinhTrang = s.TinhTrang

                    })
                    .ToList();
                dgvDSSanPham.AutoGenerateColumns = false;
                dgvDSSanPham.DataSource = rs;
            }
            

        }

        /// <summary>
        /// Phương thức Load dữ liệu lên DataGridView dgvDSNhomSP
        /// </summary>
        void UpdateGridView2()
        {
            dgvDSNhomSanPham.AutoGenerateColumns = false;
            dgvDSNhomSanPham.DataSource = model2.listNhom();

        }
        #endregion


        #region xử lý trong form SanPham

        /// <summary>
        /// Phương thức Refresh các ô textbox
        /// </summary>
        void Clear()
        {
            btnThemSP.Enabled = true;
            txtMaSP.Text = txtTenSP.Text = txtTonKho.Text = txtGiaNhap.Text
             = txtGiaBan.Text = "";
            cbxNCC_SP.SelectedIndex = 0;
            cbxNhomSP_SP.SelectedIndex = 0;
        }


        /// <summary>
        /// Sự kiện thêm sản phẩm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTenSP) == true)
            {
                if (XuLyNgoaiLe(txtTonKho) == true)
                {
                    if (XuLyNgoaiLe(txtGiaNhap) == true)
                    {
                        if (XuLyNgoaiLe(txtGiaBan) == true)
                        {
                            model.MaSP = txtMaSP.Text;
                            model.TenSanPham = txtTenSP.Text;
                            model.TinhTrang = txtTinhTrang.Text;
                            model.GiaNhap = double.Parse(txtGiaNhap.Text);
                            model.GiaBan = double.Parse(txtGiaBan.Text);
                            model.SoLuongTon = int.Parse(txtTonKho.Text); 
                            model.MaNCC = cbxNCC_SP.Text;
                            model.MaNhom = cbxNhomSP_SP.Text;
                            model.Insert(model);
                            Clear();
                            UpdateGridView();
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Sự kiện click xóa thông tin sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                string maSanPham = dgvDSSanPham.CurrentRow.Cells[0].Value.ToString();
                model = db.SanPham.FirstOrDefault(item => item.MaSP.Equals(maSanPham));

                if (model != null)
                {
                    model.Delete(model, db);
                    UpdateGridView();
                    Clear();
                }
            }
        }


        /// <summary>
        /// Sự kiện click sửa thông tin sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTenSP) == true)
            {
                if (XuLyNgoaiLe(txtTonKho) == true)
                {
                    if (XuLyNgoaiLe(txtGiaNhap) == true)
                    {
                        if (XuLyNgoaiLe(txtGiaBan) == true)
                        {
                            txtMaSP.Text = dgvDSSanPham.CurrentRow.Cells[0].Value.ToString();
                            model.TenSanPham = txtTenSP.Text;
                            model.TinhTrang = txtTinhTrang.Text;
                            model.GiaNhap = double.Parse(txtGiaNhap.Text);
                            model.GiaBan = double.Parse(txtGiaBan.Text);
                            model.SoLuongTon = int.Parse(txtTonKho.Text);
                            model.MaNCC = cbxNCC_SP.Text;
                            model.MaNhom = cbxNhomSP_SP.Text;
                            model.Update(model);
                            Clear();
                            UpdateGridView();
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Sự kiện click thoát khỏi màn hình sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThoatSP_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Sự kiện refresh các textbox trong thông tin sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaoMoiSP_Click(object sender, EventArgs e)
        {
            btnThemSP.Enabled = true;
            UpdateGridView();
            Clear();
        }


        /// <summary>
        /// Sự kiện tìm kiếm thông tin sản phẩm theo tên hoặc mã
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemSP_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTimKiemSP) == true)
            {
                if (radMaSP.Checked == true)
                    dgvDSSanPham.DataSource = model.TimKiemTheoMaSP(txtTimKiemSP);
                if (radTenSP.Checked == true)
                    dgvDSSanPham.DataSource = model.TimKiemTheoTenSP(txtTimKiemSP);
            }
        }


        /// <summary>
        /// Sự kiện Click vào GridView load dữ liệu sản phẩm lên các textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSSanPham_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThemSP.Enabled = false;
            model.MaSP = dgvDSSanPham.CurrentRow.Cells[0].Value.ToString();
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                model = db.SanPham.Where(x => x.MaSP == model.MaSP).FirstOrDefault();
                txtMaSP.Text = dgvDSSanPham.CurrentRow.Cells[0].Value.ToString();
                txtTenSP.Text = model.TenSanPham;
                txtTinhTrang.Text = model.TinhTrang;
                txtGiaNhap.Text = model.GiaNhap.ToString();
                txtGiaBan.Text = model.GiaBan.ToString();
                txtTonKho.Text = model.SoLuongTon.ToString();
                model.MaNCC = cbxNCC_SP.Text;
                model.MaNhom = cbxNhomSP_SP.Text;

            }
        }

        #endregion


        #region xử lý trong form Nhóm

        void ClearNhom()
        {
            btnThemNhomSP.Enabled = true;
            txtMaNhomSP.Text = txtTenNhomSP.Text = "";
        }


        /// <summary>
        /// Sự kiên thêm thông tin nhóm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemNhomSP_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTenNhomSP) == true)
            {
                model2.MaNhom = txtMaNhomSP.Text;
                model2.TenNhom = txtTenNhomSP.Text;
                model2.Insert(model2);
                ClearNhom();
                UpdateGridView2();
            }
        }


        /// <summary>
        /// Sự kiện sửa thông tin nhóm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaNhomSP_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTenNhomSP) == true)
            {
                model2.TenNhom = txtTenNhomSP.Text;
                model2.Update(model2);
                ClearNhom();
                UpdateGridView2();
            }
        }

        /// <summary>
        /// Sự kiện xóa thông tin nhóm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaNhomSP_Click(object sender, EventArgs e)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                string maNhomSanPham = dgvDSNhomSanPham.CurrentRow.Cells[0].Value.ToString();
                model2 = db.Nhom.FirstOrDefault(item => item.MaNhom.Equals(maNhomSanPham));

                if (model2 != null)
                {
                    model2.Delete(model2, db);
                    UpdateGridView();
                    Clear();
                }
            }
        }


        /// <summary>
        /// Sự kiện thoát khỏi màn giao diện nhóm sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThoatNhomSP_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Sự kiện click tìm kiếm nhóm sản phẩm theo mã hoặc tên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemNhomSP_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTimkiemNhomSP) == true)
            {
                if (radMaNhomSP.Checked == true)
                    dgvDSNhomSanPham.DataSource = model2.TimKiemTheoMaNhom(txtTimkiemNhomSP);
                if (radTenNhomSP.Checked == true)
                    dgvDSNhomSanPham.DataSource = model2.TimKiemTheoTenNhom(txtTimkiemNhomSP);
            }
        }


        /// <summary>
        /// Sự kiện mouse click hiển thị giá trị lên các ô textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSNhomSanPham_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThemNhomSP.Enabled = false;
            model2.MaNhom = dgvDSNhomSanPham.CurrentRow.Cells[0].Value.ToString();
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                model2 = db.Nhom.Where(x => x.MaNhom == model2.MaNhom).FirstOrDefault();
                txtMaNhomSP.Text = dgvDSNhomSanPham.CurrentRow.Cells[0].Value.ToString();
                txtTenNhomSP.Text = model2.TenNhom;
            }
        }


        /// <summary>
        /// Sự kiện  click Tạo mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaoMoiNhom_Click(object sender, EventArgs e)
        {
            btnThemNhomSP.Enabled = true;
            ClearNhom();
        }


        #endregion


        /// <summary>
        /// Sự kiện định dạng chỉ nhập số và bắt lỗi nhập ký tự khác số trong ô textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string text = textBox.Text.Replace(",", ""); // Loại bỏ dấu phẩy nếu có
                if (long.TryParse(text, out long number))
                {
                    textBox.Text = number.ToString("N0"); // Định dạng số
                    textBox.SelectionStart = textBox.Text.Length; // Di chuyển con trỏ đến cuối ô văn bản
                }
            }
        }


        /// <summary>
        /// Sự kiện định dạng chỉ nhập số và bắt lỗi nhập ký tự khác số trong ô textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGiaBan_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string text = textBox.Text.Replace(",", ""); // Loại bỏ dấu phẩy nếu có
                if (long.TryParse(text, out long number))
                {
                    textBox.Text = number.ToString("N0"); // Định dạng số
                    textBox.SelectionStart = textBox.Text.Length; // Di chuyển con trỏ đến cuối ô văn bản
                }
            }
        }


        /// <summary>
        /// Sự kiện click xuất báo cáo danh sách sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXuatDS_Click(object sender, EventArgs e)
        {
            Frm_reportSanPham form = new Frm_reportSanPham();
            form.ShowDialog();
        }

        /// <summary>
        /// Sự kiện click xuất báo cáo danh sách sản phẩm theo nhóm hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXuatDS_MaNhom_Click(object sender, EventArgs e)
        {
            Report.Frm_reportSanPhamNhom form = new Report.Frm_reportSanPhamNhom();
            form.ShowDialog();
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

       
    }
}
