using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_NoiThatViwood
{
    partial class NhaCungCap
    {

        /// <summary>
        /// Phương thức Lấy danh sách nhà cung cấp từ bảng nhà cung cấp
        /// </summary>
        /// <returns>Danh sách nhà cung cấp</returns>
        public List<NhaCungCap> listNhaCungCap()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.NhaCungCap.ToList<NhaCungCap>();
            }
        }



        /// <summary>
        /// Phương thức tìm kiếm thông tin nhà cung cấp theo Mã nhà cung cấp
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách </returns>
        public List<NhaCungCap> TimKiemTheoMaNCC(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.NhaCungCap
                        .Where(s => s.MaNCC.Equals(timkiem.Text.Trim()))
                        .ToList<NhaCungCap>();
            }
        }


        /// <summary>
        /// Phương thức tìm kiếm thông tin nhà cung cấp theo Tên nhà cung cấp
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách</returns>
        public List<NhaCungCap> TimKiemTheoTenNCC(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.NhaCungCap
                        .Where(s => s.TenNCC.Contains(timkiem.Text.Trim()))
                        .ToList<NhaCungCap>();
            }
        }


        /// <summary>
        /// Phương thức Thêm thông tin Nhà cung cấp
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng Nhà cung cấp </param>
        public void Insert(NhaCungCap model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.NhaCungCap.Add(model);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Phương thức Xoá thông tin Nhà cung cấp
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng Nhà cung cấp</param>
        public void Delete(NhaCungCap model, DB_QLCH_02Entities2 db)
        {
            try
            {
                var entry = db.Entry(model);
                if (entry.State == EntityState.Detached)
                    db.NhaCungCap.Attach(model);
                db.NhaCungCap.Remove(model);
                db.SaveChanges();
            }
            catch (Exception )
            {
                MessageBox.Show("Không thể xóa được nhà cung cấp hiện hành");
            }
        }


        /// <summary>
        /// Phương thức Sửa thông tin Nhà cung cấp
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng Nhà cung cấp </param>
        public void Update(NhaCungCap model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
