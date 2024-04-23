using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace QLBH_NoiThatViwood
{
    public partial class CTNhapHang
    {
        /// <summary>
        /// Lấy danh sách Mã sản phẩm
        /// </summary>
        /// <returns>Danh sách </returns>
        public List<string> CbxMaSanPham()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.SanPham.Select(s => s.MaSP).ToList();
            }
        }


        /// <summary>
        /// Phương thức lấy danh sách Chi tiết nhập hàng từ view vw_DSCTNhapHang
        /// </summary>
        /// <param name="maNhapHang"> Mã phiếu nhập</param>
        /// <returns>Danh sách </returns>
        public List<vw_DSCTNhapHang> List_ChiTietNhapHang(TextBox maNhapHang)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.vw_DSCTNhapHang
                    .Where(s => s.MaNhapHang == maNhapHang.Text)
                    .ToList<vw_DSCTNhapHang>();
            }
        }


        /// <summary>
        /// Phương thức Thêm thông tin CT phiếu nhập
        /// </summary>
        /// <param name="model">Tham số đầu vào để chứa thông tin về đối tượng CTPhieuNhap</param>
        public void Insert(CTNhapHang model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                try
                {
                    if (IsDuplicateCTDonDatHang(model))
                    {
                        MessageBox.Show("Lỗi Thêm Chi tiết phiếu nhập: Dữ liệu bị trùng lặp.", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        db.CTNhapHang.Add(model);
                        db.SaveChanges();
                        MessageBox.Show("Thêm thông tin thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Thêm Chi tiết phiếu nhập: " + ex.Message, "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// Phương thức Xoá thông tin CT phiếu nhập
        /// </summary>
        /// <param name="model">ham số đầu vào để chứa thông tin về đối tượng CTPhieuNhap </param>
        /// <param name="db"> Đối tượng của lớp DB_QLCH_02Entities2 </param>
        public void Delete(CTNhapHang model, DB_QLCH_02Entities2 db)
        {
            var entry = db.Entry(model);
            if (entry.State == EntityState.Detached)
                db.CTNhapHang.Attach(model);

            // Xoá Chi tiết Đơn đặt hàng
            db.CTNhapHang.Remove(model);
            db.SaveChanges();
            MessageBox.Show("Xoá thông tin thành công!");

        }


        /// <summary>
        /// Phương thức Sửa thông tin Chi tiết phiếu nhập
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng CTPhieuNhap </param>
        public void Update(CTNhapHang model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("Sửa thông tin thành công!");
            }
        }


        /// <summary>
        /// Tìm kiếm thông tin Chi tiết đơn đặt theo Mã Sản phẩm
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <param name="maNhapHang"> Mã đơn đặt </param>
        /// <returns> Danh sách </returns>
        public List<vw_DSCTNhapHang> TimKiemTheoMaSanPham(TextBox timkiem, TextBox maNhapHang)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.vw_DSCTNhapHang
                        .Where(s => s.MaSP.Equals(timkiem.Text.Trim()) && s.MaNhapHang == maNhapHang.Text)
                        .ToList<vw_DSCTNhapHang>();
            }
        }


        /// <summary>
        /// Tìm kiếm thông tin Chi tiết đơn đặt theo Tên sản phẩm
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <param name="maDonDat"> Mã đơn đặt </param>
        /// <returns>Danh sách </returns>
        public List<vw_DSCTNhapHang> TimKiemTheoTenSanPham(TextBox timkiem, TextBox maDonDat)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.vw_DSCTNhapHang
                        .Where(s => s.TenSanPham.Contains(timkiem.Text.Trim()) && s.MaNhapHang == maDonDat.Text)
                        .ToList<vw_DSCTNhapHang>();
            }
        }


        /// <summary>
        /// Hàm kiểm tra xem Mã phiếu nhập và Mã sản phẩm đã tồn tại trong cơ sở dữ liệu hay chưa
        /// </summary>
        /// <param name="model">Tham số đầu vào để chứa thông tin về đối tượng CTPhieuNhap </param>
        /// <returns> true/ false </returns>
        public bool IsDuplicateCTDonDatHang(CTNhapHang model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.CTNhapHang.Any(ct => ct.MaNhapHang == model.MaNhapHang && ct.MaSP == model.MaSP);
            }
        }
    }
}
