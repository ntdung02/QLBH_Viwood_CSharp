using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_NoiThatViwood
{
    partial class KhachHang
    {

        /// <summary>
        /// Phương thức Lấy danh sách Khách hàng từ bảng khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng </returns>
        public List<KhachHang> listKhachHang()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.KhachHang.ToList<KhachHang>();
            }
        }



        /// <summary>
        /// Phương thức tìm kiếm thông tin Khách hàng theo Mã khách hàng
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách </returns>
        public List<KhachHang> TimKiemTheoMaKH(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.KhachHang
                        .Where(s => s.MaKH.Equals(timkiem.Text.Trim()))
                        .ToList<KhachHang>();
            }
        }


        /// <summary>
        /// Phương thức tìm kiếm thông tin khách hàng theo Tên Khách Hàng
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách</returns>
        public List<KhachHang> TimKiemTheoTenKH(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.KhachHang
                        .Where(s => s.HoTenKH.Contains(timkiem.Text.Trim()))
                        .ToList<KhachHang>();
            }
        }


        /// <summary>
        /// Phương thức Thêm thông tin khách hàng
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng Khách hàng </param>
        public void Insert(KhachHang model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.KhachHang.Add(model);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Phương thức Xoá thông tin khách hàng
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng khách hàng</param>
        public void Delete(KhachHang model, DB_QLCH_02Entities2 db)
        {
            try
            {

                var entry = db.Entry(model);
                if (entry.State == EntityState.Detached)
                    db.KhachHang.Attach(model);
                db.KhachHang.Remove(model);
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xóa khách hàng đang có đơn đặt hàng");
            }

        }


        /// <summary>
        /// Phương thức Sửa thông tin khách hàng
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng khách hàng </param>
        public void Update(KhachHang model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

    }
}
