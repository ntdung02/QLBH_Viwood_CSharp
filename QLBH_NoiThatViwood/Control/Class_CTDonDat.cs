using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace QLBH_NoiThatViwood
{
    public partial class CTDonDatHang
    {
 

        /// <summary>
        /// Phương thức lấy danh sách mã Sản phẩm từ bảng Sản phẩm
        /// </summary>
        /// <returns> Danh sách mã Sản Phẩm </returns>
        public List<string> CbxMaSanPham()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.SanPham.Select(s => s.MaSP).ToList();
            }
        }


        /// <summary>
        /// Phương thức lấy dữ liệu từ view Chi tiết Đơn đặt hàng - vw_DSChiTietDonDatHang
        /// </summary>
        /// <param name="maDonDat"> Mã đơn đặt </param>
        /// <returns> Danh sách </returns>
        public List<vw_DSChiTietDonDatHang> List_ChiTietDonDatHang(TextBox maDonDat)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.vw_DSChiTietDonDatHang
                    .Where(s => s.MaDonDat == maDonDat.Text ) 
                    .ToList<vw_DSChiTietDonDatHang>();
            }
        }


        /// <summary>
        /// Tìm kiếm thông tin Chi tiết đơn đặt theo Mã Sản phẩm
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <param name="maDonDat"> Mã đơn đặt </param>
        /// <returns> Danh sách </returns>
        public List<vw_DSChiTietDonDatHang> TimKiemTheoMaMaSanPham(TextBox timkiem, TextBox maDonDat)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.vw_DSChiTietDonDatHang
                        .Where(s => s.MaSP.Contains(timkiem.Text.Trim()) && s.MaDonDat == maDonDat.Text)
                        .ToList<vw_DSChiTietDonDatHang>();
            }
        }


        /// <summary>
        /// Tìm kiếm thông tin Chi tiết đơn đặt theo Tên sản phẩm
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <param name="maDonDat"> Mã đơn đặt </param>
        /// <returns> Danh sách </returns>
        public List<vw_DSChiTietDonDatHang> TimKiemTheoMaTenSanPham(TextBox timkiem, TextBox maDonDat)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.vw_DSChiTietDonDatHang
                        .Where(s => s.TenSanPham.Contains(timkiem.Text.Trim()) && s.MaDonDat == maDonDat.Text)
                        .ToList<vw_DSChiTietDonDatHang>();
            }
        }


        /// <summary>
        /// Phương thức Thêm thông tin Chi tiết Đơn đặt hàng
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng CTDonDatHang </param>
        public void Insert(CTDonDatHang model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {  
                try
                {
                    if (IsDuplicateCTDonDatHang(model))
                    {
                        MessageBox.Show("Lỗi Thêm Chi tiết đơn đặt: Dữ liệu bị trùng lặp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        db.CTDonDatHang.Add(model);
                        db.SaveChanges();
                    }      
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Thêm Chi tiết đơn đặt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// Phương thức Xoá thông tin Chi tiết đơn đặt hàng
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng CTDonDatHang </param>
        /// <param name="db"> Đối tượng của lớp DB_QLCH_02Entities2 </param>
        public void Delete(CTDonDatHang model, DB_QLCH_02Entities2 db)
        {
            var entry = db.Entry(model);
            if (entry.State == EntityState.Detached)
                db.CTDonDatHang.Attach(model);

            // Xoá Chi tiết Đơn đặt hàng
            db.CTDonDatHang.Remove(model);
            db.SaveChanges();

        }


        /// <summary>
        /// Phương thức Sửa thông tin Chi tiết đơn đặt hàng
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng CTDonDatHang </param>
        public void Update(CTDonDatHang model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.Entry(model).State = EntityState.Modified; 
                db.SaveChanges();
            }
        }


        /// <summary>
        ///  Hàm kiểm tra xem Mã đơn đặt và Mã sản phẩm đã tồn tại trong cơ sở dữ liệu hay chưa
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng DonDatHang </param>
        /// <returns> true/false</returns>
        public bool IsDuplicateCTDonDatHang(CTDonDatHang model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.CTDonDatHang.Any(ct => ct.MaDonDat == model.MaDonDat && ct.MaSP == model.MaSP);
            }
                           
        }
    }

}
