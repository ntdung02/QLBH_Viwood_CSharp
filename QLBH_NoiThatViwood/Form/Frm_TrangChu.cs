using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBH_NoiThatViwood.Properties;

namespace QLBH_NoiThatViwood
{
    public partial class Frm_TrangChu : Form
    {
        // Fields
        private Button currenButton;
        private Random random;
        private Form activeForm;
        private bool isColappsed;

        public string chucVu;
        public string tenNhanVien;
        public string taiKhoan;


        public Frm_TrangChu()
        {
            InitializeComponent();
            random = new Random();
        }


        /// <summary>
        /// Phương thức chọn ngẫu nhiên một màu từ danh sách màu 
        /// </summary>
        /// <returns> Màu sắc </returns>
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }


        /// <summary>
        /// Phương thức thiết lập trạng thái của nút được bấm
        /// </summary>
        /// <param name="btnSender"> đối tượng nút đã được bấm </param>
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currenButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currenButton = (Button)btnSender;
                    currenButton.BackColor = color;
                    currenButton.ForeColor = Color.White;
                    currenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitle.BackColor = color;
                    btnLogo.BackColor = Color.White;
                }
            }
        }



        /// <summary>
        /// Phương thức Vô hiệu hóa tất cả các nút trong menu (đổi màu nền, màu chữ, font).
        /// </summary>
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(224, 224, 224);
                    previousBtn.ForeColor = Color.Black;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildFromn(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDeskTop.Controls.Add(childForm);
            this.panelDeskTop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbTitle.Text = childForm.Text;
        }


        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            OpenChildFromn(new Frm_PhieuNhap(), sender);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
           OpenChildFromn(new Frm_ThongKe(), sender);
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            //OpenChildFromn(new Frm_QuanLyThongTin(), sender);
            timer1.Start();
        }

        private void btnDơnDatHang_Click(object sender, EventArgs e)
        {
            OpenChildFromn(new Frm_DonDatHang(), sender);
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildFromn(new Frm_HoaDon(), sender);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
                Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isColappsed)
            {
                btnThongTin.Image = Resources.up_arrow_5343047;
                panelThongTin.Height += 10;
                if (panelThongTin.Size == panelThongTin.MaximumSize)
                {
                    timer1.Stop();
                    isColappsed = false;
                }
            }
            else
            {
                btnThongTin.Image = Resources.down;
                panelThongTin.Height -= 10;
                if (panelThongTin.Size == panelThongTin.MinimumSize)
                {
                    timer1.Stop();
                    isColappsed = true;
                }
            }
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildFromn(new Frm_NhanVien(), sender);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildFromn(new _01_Frm_KhachHang(), sender);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            OpenChildFromn(new _01_Frm_NhaCungCap(), sender);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            OpenChildFromn(new _01_Frm_SanPham(), sender);
        }

        private void Frm_TrangChu_Load(object sender, EventArgs e)
        {
            labChucVu.Text = chucVu;
            labHoTenNV.Text = tenNhanVien;
            labTenDangNhap.Text = taiKhoan;

            if (labChucVu.Text == "Bán hàng")
                btnNhapHang.Enabled = btnNhanVien.Enabled = btnThongKe.Enabled = btnSanPham.Enabled = false;

            if (labChucVu.Text == "Kho")
                btnHoaDon.Enabled = btnDơnDatHang.Enabled = btnThongKe.Enabled = btnNhanVien.Enabled
                    =btnKhachHang.Enabled = btnSanPham.Enabled = false;
        }
    }
}
