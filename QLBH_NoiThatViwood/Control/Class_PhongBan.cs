using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_NoiThatViwood
{
    partial class PhongBan
    {

        /// <summary>
        /// Phương thức Lấy danh sách phòng ban từ bảng phòng ban
        /// </summary>
        /// <returns>Danh sách phòng ban </returns>
        public List<PhongBan> listPhongBan()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.PhongBan.ToList<PhongBan>();
            }
        }


        /// <summary>
        /// Phương thức Thêm thông tin phòng ban
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng phòng ban </param>
        public void Insert(PhongBan model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.PhongBan.Add(model);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Phương thức Xoá thông tin phòng ban
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng phòng ban</param>
        public void Delete(PhongBan model, DB_QLCH_02Entities2 db)
        {
            try
            {
                var entry = db.Entry(model);
                if (entry.State == EntityState.Detached)
                    db.PhongBan.Attach(model);
                db.PhongBan.Remove(model);
                db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xóa phòng ban hiện hành");
            }

        }


        /// <summary>
        /// Phương thức Sửa thông tin phòng ban
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng phòng ban </param>
        public void Update(PhongBan model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }



        /// <summary>
        /// Phương thức tìm kiếm thông tin theo Tên phòng ban
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách</returns>
        public List<PhongBan> TimKiemTheoTenPB(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.PhongBan
                        .Where(s => s.TenPB.Contains(timkiem.Text.Trim()))
                        .ToList<PhongBan>();
            }
        }


        /// <summary>
        /// Phương thức tìm kiếm thông tin theo mã phòng ban
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách</returns>
        public List<PhongBan> TimKiemTheoMaPB(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                int maPb;
                if (int.TryParse(timkiem.Text.Trim(), out maPb))
                {
                    return db.PhongBan
                             .Where(s => s.MaPB == maPb)
                             .ToList<PhongBan>();
                }
                else
                {
                    return new List<PhongBan>();
                }

            }
        }


    }
}
