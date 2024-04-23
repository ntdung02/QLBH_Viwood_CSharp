using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;


namespace QLBH_NoiThatViwood
{
    public partial class NhapHang
    {

        /// <summary>
        /// Lấy danh sách nhà cung cấp
        /// </summary>
        /// <returns> Danh sách </returns>
        public List<string> CbxMaNhaCungCap()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.NhaCungCap.Select(s => s.MaNCC).ToList();
            }
        }


        /// <summary>
        /// Lấy danh sách mã nhân viên
        /// </summary>
        /// <returns> Danh sách </returns>
        public List<string> CbxMaNhanVien()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.NhanVien.Select(s => s.MaNV).ToList();
            }
        }


        /// <summary>
        /// Lấy thông tin danh sách Phiếu nhập theo view vw_DSNhapHang 
        /// </summary>
        /// <returns> Danh sách </returns>
        public List<vw_DSNhapHang> List_NhapHang()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.vw_DSNhapHang.ToList<vw_DSNhapHang>();
            }
        }


        /// <summary>
        /// Phương thức Thêm thông tin Phiếu nhập
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng PhieuNhap </param>
        public void Insert(NhapHang model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.NhapHang.Add(model);
                db.SaveChanges();
                MessageBox.Show("Thêm thông tin thành công!");
            }
        }


        /// <summary>
        /// Phương thức Xoá thông tin Phiếu nhập
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng NhapHang</param>
        /// <param name="db"> Đối tượng của lớp DB_QLCH_02Entities2 </param>
        public void Delete(NhapHang model, DB_QLCH_02Entities2 db)
        {
            var entry = db.Entry(model);
            if (entry.State == EntityState.Detached)
                db.NhapHang.Attach(model);
            // Xoá các Chi tiết đơn đặt hàng liên quan
            db.CTNhapHang.RemoveRange(model.CTNhapHang);

            // Xoá Đơn đặt hàng
            db.NhapHang.Remove(model);
            db.SaveChanges();
            MessageBox.Show("Xoá thông tin thành công!");
        }


        /// <summary>
        /// Phương thức Chỉnh sửa thông tin Phiếu nhập
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng NhapHang </param>
        public void Update(NhapHang model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                MessageBox.Show("Sửa thông tin thành công!");
            }
        }


        /// <summary>
        /// Phương thức tìm kiếm thông tin phiếu nhập theo Mã phiếu nhập
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách </returns>
        public List<vw_DSNhapHang> TimKiemTheoMaNhapHang(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.vw_DSNhapHang
                        .Where(s => s.MaNhapHang.Equals(timkiem.Text.Trim()))
                        .ToList<vw_DSNhapHang>();
            }
        }

        /// <summary>
        /// Phương thức tìm kiếm thông tin phiếu nhập theo Tên nhân viên
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách </returns>
        public List<vw_DSNhapHang> TimKiemTheoTenNV(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.vw_DSNhapHang
                        .Where(s => s.HoTen.Contains(timkiem.Text.Trim()))
                        .ToList<vw_DSNhapHang>();
            }
        }

        /// <summary>
        /// Phương thức tìm kiếm thông tin phiếu nhập theo tên nhà cung cấp
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách </returns>
        public List<vw_DSNhapHang> TimKiemTheoTenNCC(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.vw_DSNhapHang
                        .Where(s => s.TenNCC.Contains(timkiem.Text.Trim()))
                        .ToList<vw_DSNhapHang>();
            }
        }
    }
}
