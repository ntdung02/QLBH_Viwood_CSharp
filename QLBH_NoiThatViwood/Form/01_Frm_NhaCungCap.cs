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
    public partial class _01_Frm_NhaCungCap : Form
    {
        public _01_Frm_NhaCungCap()
        {
            InitializeComponent();
            txtMaNCC.Enabled = false;
        }

        NhaCungCap model = new NhaCungCap();

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
        /// Sự kiện click chỉ nhập tối đa 10 số
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPhoneNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPhoneNCC.MaxLength = 10;
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
        /// Sự kiện click chỉ nhập email hợp lệ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmailNCC_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txtEmailNCC.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txtEmailNCC.Text))
                {
                    MessageBox.Show("E-Mail không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmailNCC.SelectAll();
                    e.Cancel = true;
                }
            }
        }


        /// <summary>
        /// Phương thức Refresh các ô textbox
        /// </summary>
        void Clear()
        {
            btnThemNCC.Enabled = true;
            txtMaNCC.Text = txtTenNCC.Text = txtEmailNCC.Text
             = txtDiaChiNCC.Text = txtPhoneNCC.Text = "";
        }


        /// <summary>
        /// Phương thức Load dữ liệu lên DataGridView dgvDSNCC
        /// </summary>
        void UpdateGridView()
        {
            dgvDSNCC.AutoGenerateColumns = false;
            dgvDSNCC.DataSource = model.listNhaCungCap();
        }



        /// <summary>
        /// Sự kiện click thêm nhà cung cấp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTenNCC) == true)
            {
                if (XuLyNgoaiLe(txtPhoneNCC) == true)
                {
                    if (XuLyNgoaiLe(txtEmailNCC) == true)
                    {
                        if (XuLyNgoaiLe(txtDiaChiNCC) == true)
                        {
                            model.MaNCC = txtMaNCC.Text;
                            model.TenNCC = txtTenNCC.Text;
                            model.DiaChiNCC = txtDiaChiNCC.Text;
                            model.EmailNCC = txtEmailNCC.Text;
                            model.DienThoaiNCC = txtPhoneNCC.Text;
                            model.Insert(model);
                            Clear();
                            UpdateGridView();

                        }
                    }
                }
            }
        }


        /// <summary>
        /// Sựu kiện click xóa nhà cung cấp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                string maNhaCungCap = dgvDSNCC.CurrentRow.Cells[0].Value.ToString();
                model = db.NhaCungCap.FirstOrDefault(item => item.MaNCC.Equals(maNhaCungCap));

                if (model != null)
                {
                    model.Delete(model, db);
                    UpdateGridView();
                    Clear();
                }
            }
        }


        /// <summary>
        /// Sự kiện click Sửa thông tin nhà cung cấp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTenNCC) == true)
            {
                if (XuLyNgoaiLe(txtPhoneNCC) == true)
                {
                    if (XuLyNgoaiLe(txtEmailNCC) == true)
                    {
                        if (XuLyNgoaiLe(txtDiaChiNCC) == true)
                        {
                            model.MaNCC = txtMaNCC.Text;
                            model.TenNCC = txtTenNCC.Text;
                            model.DiaChiNCC = txtDiaChiNCC.Text;
                            model.EmailNCC = txtEmailNCC.Text;
                            model.DienThoaiNCC = txtPhoneNCC.Text;
                            model.Update(model);
                            Clear();
                            UpdateGridView();

                        }
                    }
                }
            }
        }


        /// <summary>
        /// Sự kiện click thoát khỏi màn hình nhà cung cấp 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThoatNCC_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Sự kiện click tạo mới nhà cung cấp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaoMoiNCC_Click(object sender, EventArgs e)
        {
            UpdateGridView();
            btnThemNCC.Enabled = true;
            Clear();
        }


        /// <summary>
        /// Sự kiện click tìm kiếm nhà cung cấp theo mã hoặc tên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemNCC_Click(object sender, EventArgs e)
        {
            if (XuLyNgoaiLe(txtTimKiemNCC) == true)
            {
                if (radMaNCC.Checked == true)
                    dgvDSNCC.DataSource = model.TimKiemTheoMaNCC(txtTimKiemNCC);
                if (radTenNCC.Checked == true)
                    dgvDSNCC.DataSource = model.TimKiemTheoTenNCC(txtTimKiemNCC);
            }
        }


        /// <summary>
        /// Sự kiện click trên datagridview hiển thị thông tin nhà cung cấp lên các ô textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDSNCC_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnThemNCC.Enabled = false;
            model.MaNCC = dgvDSNCC.CurrentRow.Cells[0].Value.ToString();
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                model = db.NhaCungCap.Where(x => x.MaNCC == model.MaNCC).FirstOrDefault();

                txtMaNCC.Text = model.MaNCC;
                txtTenNCC.Text = model.TenNCC;
                txtPhoneNCC.Text = model.DienThoaiNCC;
                txtDiaChiNCC.Text = model.DiaChiNCC;
                txtEmailNCC.Text = model.EmailNCC;

            }
        }

        private void _01_Frm_NhaCungCap_Load(object sender, EventArgs e)
        {
            UpdateGridView();
        }

        private void btnXuatDS_Click(object sender, EventArgs e)
        {
            Report.Frm_reportNCC form = new Report.Frm_reportNCC();
            form.ShowDialog();
        }
    }
}
