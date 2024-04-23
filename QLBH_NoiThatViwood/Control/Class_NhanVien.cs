using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_NoiThatViwood
{
    partial class NhanVien
    {


        /// <summary>
        /// Phương thức Thêm thông tin nhân viên
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng nhân viên </param>
        public void Insert(NhanVien model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.NhanVien.Add(model);
                db.SaveChanges();
            }
        }



        /// <summary>
        /// Phương thức Xoá thông tin nhân viên
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng nhân viên</param>
        public void Delete(NhanVien model, DB_QLCH_02Entities2 db)
        {
            try
            {

                var entry = db.Entry(model);
                if (entry.State == EntityState.Detached)
                    db.NhanVien.Attach(model);
                db.NhanVien.Remove(model);
                db.SaveChanges();
            }
            catch (Exception )
            {
                MessageBox.Show("Không thể xóa nhân viên đang làm việc");
            }
        }


        /// <summary>
        /// Phương thức Sửa thông tin Nhân viên
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng nhân viên </param>
        public void Update(NhanVien model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Phương thức tìm kiếm thông tin nhân viên theo Mã nhân viên
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách </returns>
        //public List<NhanVien> TimKiemTheoMaNV(TextBox timkiem)
        //{
        //    using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
        //    {
        //        return db.NhanVien
        //                .Where(s => s.MaNV.Equals(timkiem.Text.Trim()))
        //                .ToList<NhanVien>();
        //    }
        //}



        /// <summary>
        /// Phương thức tìm kiếm thông tin nhân viên theo Tên nhân viên
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách</returns>
        //public List<NhanVien> TimKiemTheoTenNV(TextBox timkiem)
        //{
        //    using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
        //    {
        //        return db.NhanVien
        //                .Where(s => s.HoTen.Contains(timkiem.Text.Trim()))
        //                .ToList<NhanVien>();
        //    }
        //}



        /// <summary>
        /// Phương thức Lấy danh sách mã phong ban từ bảng phòng ban
        /// </summary>
        /// <returns>Danh sách mã phòng ban </returns>
        public List<int> CbxTenPhongBan()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.PhongBan.Select(s => s.MaPB).ToList();
            }
        }


    
}
}
