using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms;

namespace QLBH_NoiThatViwood
{
    public partial class HoaDon
    {

        /// <summary>
        /// Phương thức Lấy danh sách mã Nhân viên
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
        /// Phương thức thêm thông tin Hoá đơn
        /// </summary>
        /// <param name="model"> Tham số đầu vào để chứa thông tin về đối tượng HoaDon </param>
        public void Insert(HoaDon model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                try
                {
                    if (IsDuplicateHoaDon(model))
                    {
                        MessageBox.Show("Lỗi Thêm hoá đơn: Dữ liệu bị trùng lặp.", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                    else
                    {
                        db.HoaDon.Add(model);
                        db.SaveChanges();
                        MessageBox.Show("Thêm thông tin thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Thêm hoá đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// Phương thức tìm kiếm thông tin Hoá đơn theo mã
        /// </summary>
        /// <param name="timkiem"> thông tin tìm kiếm</param>
        /// <returns>Danh sách </returns>
        public List<HoaDon> TimKiemTheoMaHoaDon(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.HoaDon
                        .Where(s => s.MaHoaDon.Equals(timkiem.Text.Trim()))
                        .ToList<HoaDon>();
            }
        }


        /// <summary>
        /// Phương thức tìm kiếm thông tin hoá đơn theo mã đơn đặt hàng
        /// </summary>
        /// <param name="timkiem">thông tin tìm kiếm </param>
        /// <returns> danh sách </returns>
        public List<HoaDon> TimKiemTheoMaDonDat(TextBox timkiem)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.HoaDon
                        .Where(s => s.MaDonDat.Equals(timkiem.Text.Trim()))
                        .ToList<HoaDon>();
            }
        }


        /// <summary>
        /// Hàm kiểm tra xem Mã hoá đơn có tông tại trong CSDL không
        /// </summary>
        /// <param name="model">Tham số đầu vào để chứa thông tin về đối tượng HoaDon  </param>
        /// <returns> true/ false</returns>
        public bool IsDuplicateHoaDon(HoaDon model)
        {
            using (DB_QLCH_02Entities2 db = new DB_QLCH_02Entities2())
            {
                return db.HoaDon.Any(ct => ct.MaHoaDon == model.MaHoaDon );
            }
        }

    }

}
