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
    public partial class Frm_NhanVien : Form
    {
        NhanVien model = new NhanVien();
        PhongBan model2 = new PhongBan();
        public Frm_NhanVien()
        {
            InitializeComponent();
            txtMaNV.Enabled = false;
            txtMaPB_2.Enabled = false;
        }

        #region Chức năng Xử lý chung cho Nhân viên và Phòng ban

        /// <summary>
        /// Sự kiện load trong form tab NhanVien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_NhanVien_Load(object sender, EventArgs e)
        {
            cbxMaBP_NV.DataSource = model.CbxTenPhongBan();// Load dữ liệu MaBP vào Combobox
            UpdateGridView();
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
        /// Phương thức Load dữ liệu lên DataGridView dgvDSNhanVien
        /// </summary>
        void UpdateGridView()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                var rs= db.NhanVien
                    .Include(s=>s.PhongBan)
                    .Select(s=> new
                    {
                        MaNV = s.MaNV,
                        HoTen = s.HoTen,
                        GioiTinh = s.GioiTinh,
                        SDT = s.SDT,
                        Email = s.Email,
                        TenPB= s.PhongBan.TenPB,
                        TaiKhoan= s.TaiKhoan,
                        MatKhau = s.MatKhau
                    }).ToList();

                dgvDSNhanVien.AutoGenerateColumns = false;
                dgvDSNhanVien.DataSource = rs;
            }
            

            dgvDSPhongBan.AutoGenerateColumns = false;
            dgvDSPhongBan.DataSource = model2.listPhongBan();
        }
        #endregion

        #region xử lý trong form Nhân Viên

        /// <summary>
        /// sự kiện Xử lý ngoại lệ nhập email hợp lệ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmail.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmail.Text))
                {
                    MessageBox.Show("E-Mail không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.SelectAll();
                    e.Cancel = true;
                }
            }
        }


        /// <summary>
        /// Sự kiện keypress chỉ cho phép nhập số tối đa 10 ký tự
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtSoDienThoai.MaxLength = 10;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Phương thức Refresh các ô textbox
        /// </summary>
        void Clear()
        {
            txtMaNV.Text = txtTenNV.Text = txtSoDienThoai.Text = dtNgaySinh.Text
             = txtEmail.Text = txtTaiKhoan.Text = txtMatKhau.Text = "";
            cbxGioiTinh.SelectedIndex= cbxMaBP_NV.SelectedIndex = 0;
            btnThemNV.Enabled = true;
        }


        /// <summary>
        /// Sự kiện thêm nhân viên mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTenNV) == true)
            {           
                    if (XuLyNgoaiLe(txtSoDienThoai) == true)
                    {
                        if (XuLyNgoaiLe(txtEmail) == true)
                        {
                            if (XuLyNgoaiLe(txtTaiKhoan) == true)
                            {
                                if (XuLyNgoaiLe(txtMatKhau) == true)
                                {
                                    model.MaNV = txtMaNV.Text;
                                    model.HoTen = txtTenNV.Text;
                                    model.GioiTinh = cbxGioiTinh.Text;
                                    model.SDT = txtSoDienThoai.Text;
                                    model.Email = txtEmail.Text;
                                    model.MaPB = int.Parse(cbxMaBP_NV.Text);
                                    model.TaiKhoan = txtTaiKhoan.Text;
                                    model.MatKhau = txtMatKhau.Text;
                                    model.Insert(model);
                                    Clear();
                                    UpdateGridView();

                                }
                            }
                        }
                    }    
            }
        }

        /// <summary>
        /// Sự kiện click xóa thông tin khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                string maNhanVien = dgvDSNhanVien.CurrentRow.Cells[0].Value.ToString();
                model = db.NhanVien.FirstOrDefault(item => item.MaNV.Equals(maNhanVien));

                if (model != null)
                {
                    model.Delete(model, db);
                    UpdateGridView();
                    Clear();
                }
            }
        }


        /// <summary>
        /// Sự kiện click Sửa thông tin nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTenNV) == true)
            {
                    if (XuLyNgoaiLe(txtSoDienThoai) == true)
                    {
                        if (XuLyNgoaiLe(txtEmail) == true)
                        {
                            if (XuLyNgoaiLe(txtTaiKhoan) == true)
                            {
                                if (XuLyNgoaiLe(txtMatKhau) == true)
                                {
                                    model.MaNV = txtMaNV.Text;
                                    model.HoTen = txtTenNV.Text;
                                    model.GioiTinh = cbxGioiTinh.Text;
                                    model.SDT = txtSoDienThoai.Text;
                                    model.Email = txtEmail.Text;
                                    model.MaPB = int.Parse(cbxMaBP_NV.Text);
                                    model.TaiKhoan = txtTaiKhoan.Text;
                                    model.MatKhau = txtMatKhau.Text;
                                    model.Update(model);
                                    Clear();
                                    UpdateGridView();
                                }
                            }
                        }
                    }
            }
        }


        /// <summary>
        /// Sự kiến thoát khỏi giao diện nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThoatNV_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Sự kiện tìm kiếm thông tin nhân viên theo tên hoặc mã
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {

                if (XuLyNgoaiLe(txtTimKiemNV) == true)
                {
                    if (radMaNV.Checked == true)
                    {
                        var rs = db.NhanVien
                                .Include(s => s.PhongBan)
                                .Where(s => s.MaNV.Equals(txtTimKiemNV.Text.Trim()))
                                .Select(s => new
                                {
                                    MaNV = s.MaNV,
                                    HoTen = s.HoTen,
                                    GioiTinh = s.GioiTinh,
                                    SDT = s.SDT,
                                    Email = s.Email,
                                    TenPB = s.PhongBan.TenPB,
                                    TaiKhoan = s.TaiKhoan,
                                    MatKhau = s.MatKhau
                                }).ToList();

                        dgvDSNhanVien.DataSource = rs;
                    }
                    
                    if (radTenNV.Checked == true)
                    {
                        var rs2 = db.NhanVien
                                .Include(s => s.PhongBan)
                                .Where(s => s.HoTen.Contains(txtTimKiemNV.Text.Trim()))
                                .Select(s => new
                                {
                                    MaNV = s.MaNV,
                                    HoTen = s.HoTen,
                                    GioiTinh = s.GioiTinh,
                                    SDT = s.SDT,
                                    Email = s.Email,
                                    TenPB = s.PhongBan.TenPB,
                                    TaiKhoan = s.TaiKhoan,
                                    MatKhau = s.MatKhau
                                }).ToList();
                        dgvDSNhanVien.DataSource = rs2;
                    }    
                       
                }
            }
        }


        /// <summary>
        /// Sự kiện Click vào GridView load dữ liệu nhân viên lên các textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSNhanVien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThemNV.Enabled = false;
            model.MaNV = dgvDSNhanVien.CurrentRow.Cells[0].Value.ToString();
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                model = db.NhanVien.Where(x => x.MaNV == model.MaNV).FirstOrDefault();
                txtMaNV.Text = dgvDSNhanVien.CurrentRow.Cells[0].Value.ToString();
                txtTenNV.Text = model.HoTen;
                cbxGioiTinh.Text = model.GioiTinh;
                txtSoDienThoai.Text = model.SDT;
                txtEmail.Text = model.Email;
                cbxMaBP_NV.Text = model.MaPB.ToString();
                txtTaiKhoan.Text = model.TaiKhoan;
                txtMatKhau.Text = model.MatKhau;
            }
        }


        /// <summary>
        /// Sự kiện refresh các textbox trong thông tin nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            btnThemNV.Enabled = true;
            UpdateGridView();
            Clear();
        }

        #endregion


        #region xử lý trong form phòng ban

        void ClearPB()
        {
            txtMaPB_2.Text = txtTenPB_2.Text = "";
        }


        /// <summary>
        /// Sự kiên thêm thông tin phòng ban
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemPB_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTenPB_2) == true)
            {
                //model2.MaPB = int.Parse(txtMaPB_2.Text);
                model2.TenPB = txtTenPB_2.Text;
                model2.Insert(model2);
                ClearPB();
                UpdateGridView();
            }
        }


        /// <summary>
        /// Sự kiện sửa thông tin phòng ban
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaPB_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTenPB_2) == true)
            {
                model2.MaPB = int.Parse(txtMaPB_2.Text);
                model2.TenPB = txtTenPB_2.Text;
                model2.Update(model2);
                ClearPB();
                UpdateGridView();
            }
        }


        /// <summary>
        /// Sự kiện xóa thông tin phòng ban
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaPB_Click(object sender, EventArgs e)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                int MaPB = Convert.ToInt32(dgvDSPhongBan.CurrentRow.Cells[0].Value);
                model2 = db.PhongBan.FirstOrDefault(item => item.MaPB.Equals(MaPB));

                if (model2 != null)
                {
                    model2.Delete(model2, db);
                    UpdateGridView();
                    Clear();
                }
            }
        }


        /// <summary>
        /// Sự kiện thoát khỏi màn giao diện phòng ban
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThoatPB_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Sự kiện Nhân nút Tìm kiếm phòng ban
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemPB_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTimKiemPB) == true)
            {
                if (radMaPB.Checked == true)
                    dgvDSPhongBan.DataSource = model2.TimKiemTheoMaPB(txtTimKiemPB);
                if (radTenPB.Checked == true)
                    dgvDSPhongBan.DataSource = model2.TimKiemTheoTenPB(txtTimKiemPB);
            }
        }


        /// <summary>
        /// Sự kiện Click vào datagridview Phòng ban
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param
        private void dgvDSPhongBan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThemPB.Enabled = false;
            model2.MaPB = Convert.ToInt32(dgvDSPhongBan.CurrentRow.Cells[0].Value);
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                model2 = db.PhongBan.Where(x => x.MaPB == model2.MaPB).FirstOrDefault();
                txtMaPB_2.Text = dgvDSPhongBan.CurrentRow.Cells[0].Value.ToString();
                txtTenPB_2.Text = model2.TenPB;
            }
        }


        /// <summary>
        /// Sự kiện Click vào button Tạo mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param
        private void btnTaoMoiPB_Click(object sender, EventArgs e)
        {
            btnThemPB.Enabled = true;
            UpdateGridView();
            ClearPB();
        }

        #endregion

        private void btnXuatDanhSach_Click(object sender, EventArgs e)
        {
            Frm_reportNhanVien frm_ReportNhanVien = new Frm_reportNhanVien();
            frm_ReportNhanVien.ShowDialog();
        }

        private void btnXuatDS_Click(object sender, EventArgs e)
        {
            Report.Frm_reportNhanVienMaPB form = new Report.Frm_reportNhanVienMaPB();
            form.ShowDialog();
        }
    }


}
