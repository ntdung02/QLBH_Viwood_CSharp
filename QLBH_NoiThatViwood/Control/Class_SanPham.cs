using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_NoiThatViwood
{
    partial class SanPham
    {
      
        /// <summary>
        /// Phương thức Thêm thông tin sản phẩm
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng sản phẩm </param>
        public void Insert(SanPham model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.SanPham.Add(model);
                db.SaveChanges();
            }
        }


        /// <summary>
        /// Phương thức Xoá thông tin sản phẩm
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng sản phẩm</param>
        public void Delete(SanPham model, DB_QLCH_02Entities2 db)
        {
            try
            {
                var entry = db.Entry(model);
                if (entry.State == EntityState.Detached)
                    db.SanPham.Attach(model);
                db.SanPham.Remove(model);
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Không thể xóa sản phẩm hiện hành");
            }

        }



        /// <summary>
        /// Phương thức Sửa thông tin Sản phẩm
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng sản phẩm</param>
        public void Update(SanPham model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
        }



        /// <summary>
        /// Phương thức tìm kiếm thông tin sản phẩm  theo Mã sản phẩm 
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách </returns>
        public List<SanPham> TimKiemTheoMaSP(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.SanPham
                        .Where(s => s.MaSP.Equals(timkiem.Text.Trim()))
                        .ToList<SanPham>();
            }
        }



        /// <summary>
        /// Phương thức tìm kiếm thông tin nhân viên theo Tên sản phẩm
        /// </summary>
        /// <param name="timkiem"> Thông tin tìm kiếm </param>
        /// <returns> Danh sách</returns>
        public List<SanPham> TimKiemTheoTenSP(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.SanPham
                        .Where(s => s.TenSanPham.Contains(timkiem.Text.Trim()))
                        .ToList<SanPham>();
            }
        }


        /// <summary>
        /// Phương thức Lấy danh sách mã nhóm từ bảng nhóm hàng
        /// </summary>
        /// <returns>Danh sách mã nhóm hàng </returns>
        public List<string> CbxMaNhom()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.Nhom.Select(s => s.MaNhom).ToList();
            }
        }


        /// <summary>
        /// Phương thức Lấy danh sách mã nhà cung cấp từ bảng nhà cung cấp
        /// <returns>Danh sách mã nhà cung cấp </returns>
        public List<string> CbxMaNCC()
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.NhaCungCap.Select(s => s.MaNCC).ToList();
            }
        }



    }
}
