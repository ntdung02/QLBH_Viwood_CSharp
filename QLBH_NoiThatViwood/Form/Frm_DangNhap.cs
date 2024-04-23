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
    public partial class Frm_DangNhap : Form
    {
        
        public Frm_DangNhap()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Sự kiện click vào button Đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                if(txtDangNhap.Text.Equals("") || txtMatKhau.Text.Equals(""))
                    MessageBox.Show(" Vui lòng nhập đầy đủ thông tin đăng nhập");
                else
                {
                    var thongTin = db.NhanVien
                                    .Where(ct => ct.TaiKhoan == txtDangNhap.Text && ct.MatKhau == txtMatKhau.Text)
                                    .Select(s => new
                                        {
                                            TenNV = s.HoTen,
                                            ChucVu = s.PhongBan.TenPB,
                                            TaiKhoan = s.TaiKhoan
                                        })
                                        .FirstOrDefault();

                                if (thongTin != null)
                                {
                                    Frm_TrangChu frm_TrangChu = new Frm_TrangChu();
                                    frm_TrangChu.tenNhanVien = thongTin.TenNV;
                                    frm_TrangChu.chucVu = thongTin.ChucVu;
                                    frm_TrangChu.taiKhoan = thongTin.TaiKhoan;

                                    frm_TrangChu.ShowDialog();
                                }
                                 else
                                         MessageBox.Show("Tài khoản hoặc Mật khẩu không chính xác");
                }
            }
        }

    }
}
