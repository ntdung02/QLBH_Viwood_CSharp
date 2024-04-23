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
    public partial class _01_Frm_KhachHang : Form
    {
        public _01_Frm_KhachHang(  )
        {
            InitializeComponent();
            txtMaKhachHang.Enabled = false;//khóa textbox mã khách hàng  
        }
        KhachHang model = new KhachHang();


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
        /// Sự kiện Xử lý ngoại lệ nhập email hợp lệ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmailKH_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.
             Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmailKH.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmailKH.Text))
                {
                    MessageBox.Show("E-Mail không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmailKH.SelectAll();
                    e.Cancel = true;
                }
            }
        }


        /// <summary>
        /// Định dạng chỉ nhập số cho textbox số điện thoại khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPhoneKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPhoneKH.MaxLength = 10;
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
            btnThemKH.Enabled = true;
            txtMaKhachHang.Text = txtTenKhachHang.Text = txtDiaChiKH.Text
            = txtPhoneKH.Text = txtEmailKH.Text = txtGioiTinhKH.Text = "";
        }


        /// <summary>
        /// Phương thức Load dữ liệu lên DataGridView dgvDSKH
        /// </summary>
        void UpdateGridView()
        {
            dgvDSKH.AutoGenerateColumns = false;
            dgvDSKH.DataSource = model.listKhachHang();
        }


        /// <summary>
        /// Sự kiện Click vào GridView load dữ liệu lên các textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSKH_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThemKH.Enabled = false;
            model.MaKH = dgvDSKH.CurrentRow.Cells[0].Value.ToString();
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                model = db.KhachHang.Where(x => x.MaKH == model.MaKH).FirstOrDefault();
                txtMaKhachHang.Text = model.MaKH;
                txtTenKhachHang.Text = model.HoTenKH;
                txtDiaChiKH.Text = model.DiaChiKH;
                txtPhoneKH.Text = model.SDTKH;
                txtEmailKH.Text = model.EmailKH;
                txtGioiTinhKH.Text = model.GioiTinhKH;
            }
        }


        /// <summary>
        /// Sự kiện click vào button Tạo mới Đơn đặt hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaoMoiKH_Click(object sender, EventArgs e)
        {
            Clear();
            UpdateGridView();
        }


        /// <summary>
        /// Sự kiện click thêm thông tin khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTenKhachHang) == true)
            {
                if (XuLyNgoaiLe(txtDiaChiKH) == true)
                {
                    if (XuLyNgoaiLe(txtEmailKH) == true)
                    {
                        if (XuLyNgoaiLe(txtPhoneKH) == true)
                        {
                            if (XuLyNgoaiLe(txtGioiTinhKH) == true)
                            {
                                model.MaKH = txtMaKhachHang.Text;
                                model.HoTenKH = txtTenKhachHang.Text;
                                model.DiaChiKH = txtDiaChiKH.Text;
                                model.EmailKH = txtEmailKH.Text;
                                model.SDTKH = txtPhoneKH.Text;
                                model.GioiTinhKH = txtGioiTinhKH.Text;
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
        /// Sự kiện click Sửa thông tin khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTenKhachHang) == true)
            {
                if (XuLyNgoaiLe(txtDiaChiKH) == true)
                {
                    if (XuLyNgoaiLe(txtEmailKH) == true)
                    {
                        if (XuLyNgoaiLe(txtPhoneKH) == true)
                        {
                            if (XuLyNgoaiLe(txtGioiTinhKH) == true)
                            {
                                model.MaKH = txtMaKhachHang.Text;
                                model.HoTenKH = txtTenKhachHang.Text;
                                model.DiaChiKH = txtDiaChiKH.Text;
                                model.EmailKH = txtEmailKH.Text;
                                model.SDTKH = txtPhoneKH.Text;
                                model.GioiTinhKH = txtGioiTinhKH.Text;
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
        /// Sự kiện click xóa thông tin khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                string maKhachHang = dgvDSKH.CurrentRow.Cells[0].Value.ToString();
                model = db.KhachHang.FirstOrDefault(item => item.MaKH.Equals(maKhachHang));

                if (model != null)
                {
                    model.Delete(model, db);
                    UpdateGridView();
                    Clear();
                }
            }
        }


        /// <summary>
        /// Sự kiện load thông tin khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _01_Frm_KhachHang_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }


        /// <summary>
        /// Sự kiện thoát khỏi màn hình thông tin khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThoatKH_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Sự kiện click tìm kiếm theo tên or mã khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTimKiem) == true)
            {
                if (radMaKH.Checked == true)
                    dgvDSKH.DataSource = model.TimKiemTheoMaKH(txtTimKiem);
                if (radTenKH.Checked == true)
                    dgvDSKH.DataSource = model.TimKiemTheoTenKH(txtTimKiem);
            }
        }


        /// <summary>
        /// SỰ kiện click vào Xuất DS khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXuatDS_Click(object sender, EventArgs e)
        {
            Frm_ReportKhachHang form = new Frm_ReportKhachHang();
            form.ShowDialog();
        }
    }
}
