using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Collections;

namespace QLBH_NoiThatViwood
{
    public partial class DonDatHang
    {

        /// <summary>
        /// Phương thức Lấy danh sách mã Khách hàng từ bảng Khách hàng
        /// </summary>
        /// <returns> Danh sách  </returns>
        public List<string> CbxMaKhachHang()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.KhachHang.Select(s => s.MaKH).ToList();
            }
        }


        /// <summary>
        /// Phương thức Lấy danh sách mã Nhân viên từ bảng Nhân Viên
        /// </summary>
        /// <returns>Danh sách mã Nhân Viên </returns>
        public List<string> CbxMaNhanVien()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.NhanVien.Select(s => s.MaNV).ToList();
            }
        }


        /// <summary>
        /// Phương thức lấy dữ liệu từ view Đơn đặt hàng - vw_DSDonDatHang
        /// </summary>
        /// <returns> Danh sách </returns>
        public List<vw_DSDonDatHang> List_DonDatHang()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.vw_DSDonDatHang.ToList<vw_DSDonDatHang>();
            }
        }


        /// <summary>
        /// Phương thức tìm kiếm thông tin đơn đặt hàng  theo Mã đơn đặt
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách </returns>
        public List<vw_DSDonDatHang> TimKiemTheoMaDon(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.vw_DSDonDatHang
                        .Where(s => s.MaDonDat.Contains(timkiem.Text.Trim()))
                        .ToList<vw_DSDonDatHang>();  
            }
        }


        /// <summary>
        /// Phương thức tìm kiếm thông tin đơn đặt hàng  theo Tên Nhân Viên
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm</param>
        /// <returns> Danh sách </returns>
        public List<vw_DSDonDatHang> TimKiemTheoTenNV(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.vw_DSDonDatHang
                        .Where(s => s.HoTen.Contains(timkiem.Text.Trim()))
                        .ToList<vw_DSDonDatHang>();
            }
        }


        /// <summary>
        /// Phương thức tìm kiếm thông tin đơn đặt hàng  theo Tên Khách Hàng
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách</returns>
        public List<vw_DSDonDatHang> TimKiemTheoTenKH(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.vw_DSDonDatHang
                        .Where(s => s.HoTenKH.Contains(timkiem.Text.Trim()))
                        .ToList<vw_DSDonDatHang>();
            }
        }


        /// <summary>
        /// Phương thức Thêm thông tin Đơn đặt hàng
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng DonDatHang </param>
        public void Insert(DonDatHang model)
        {

            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.DonDatHang.Add(model);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Phương thức xoá thông tin đơn đặt
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng DonDatHang </param>
        /// <param name="db"> Đối tượng của lớp DB_QLCH_02Entities2 </param>
        public void Delete(DonDatHang model,  DB_QLCH_02Entities2 db)
        {
            try
            {
                var entry = db.Entry(model);
                if (entry.State == EntityState.Detached)
                    db.DonDatHang.Attach(model);
                // Xoá các Chi tiết đơn đặt hàng liên quan
                db.CTDonDatHang.RemoveRange(model.CTDonDatHang);

                // Xoá Đơn đặt hàng
                db.DonDatHang.Remove(model);
                db.SaveChanges();

            }
            catch(Exception)
            {
                MessageBox.Show("Không thể xoá vì Đơn hàng này đã được thanh toán ");
            }
            
                

        }


        /// <summary>
        /// Phương thức Sửa thông tin Đơn đặt hàng
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng DonDatHang </param>
        public void Update(DonDatHang model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

    }

}
