using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_NoiThatViwood
{
    partial class Nhom
    {
        /// <summary>
        /// Phương thức Lấy danh sách nhóm từ bảng nhóm hàng
        /// </summary>
        /// <returns>Danh sách nhóm hàng </returns>
        public List<Nhom> listNhom()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.Nhom.ToList<Nhom>();
            }
        }


        /// <summary>
        /// Phương thức Thêm thông tin Nhóm
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng nhóm  </param>
        public void Insert(Nhom model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.Nhom.Add(model);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Phương thức Xoá thông tin nhóm
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng nhóm</param>
        public void Delete(Nhom model, DB_QLCH_02Entities2 db)
        {
            try
            {
                var entry = db.Entry(model);
                if (entry.State == EntityState.Detached)
                    db.Nhom.Attach(model);
                db.Nhom.Remove(model);
                db.SaveChanges();
            }
            catch (Exception )
            {
                MessageBox.Show("Không thể xóa được nhóm hiện hành");
            }
        }


        /// <summary>
        /// Phương thức Sửa thông tin nhóm
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng nhóm </param>
        public void Update(Nhom model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Phương thức tìm kiếm thông tin theo Tên nhóm
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách</returns>
        public List<Nhom> TimKiemTheoTenNhom(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.Nhom
                        .Where(s => s.TenNhom.Contains(timkiem.Text.Trim()))
                        .ToList<Nhom>();
            }
        }


        /// <summary>
        /// Phương thức tìm kiếm thông tin theo mã nhóm
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách</returns>
        public List<Nhom> TimKiemTheoMaNhom(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.Nhom
                        .Where(s => s.MaNhom.Equals(timkiem.Text.Trim()))
                        .ToList<Nhom>();
            }
        }

    }
}
