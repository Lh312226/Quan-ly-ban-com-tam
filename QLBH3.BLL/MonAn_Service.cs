using QLBH3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH3.BLL
{
    public class MonAn_Service
    {
        public int ThemMonAn(MonAn monAnMoi)
        {
            // Kiểm tra nếu đối tượng món ăn rỗng (null) hoặc tên món ăn hay giá không có
            if (monAnMoi == null || string.IsNullOrEmpty(monAnMoi.TenMonAn) || monAnMoi.Gia == 0)
            {
                return 1; // 1 biểu thị lỗi do đối tượng món ăn rỗng hoặc thiếu tên món ăn hoặc giá
            }

            try
            {
                // Kết nối tới cơ sở dữ liệu
                using (QLBH2Entities db = new QLBH2Entities())
                {
                    // Kiểm tra xem món ăn đã tồn tại chưa
                    var existingMonAn = db.MonAn.FirstOrDefault(ma => ma.TenMonAn == monAnMoi.TenMonAn);
                    if (existingMonAn != null)
                    {
                        return 2; // 2 biểu thị lỗi do món ăn đã tồn tại
                    }

                    // Thêm món ăn mới vào cơ sở dữ liệu
                    db.MonAn.Add(monAnMoi);
                    db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }

                return 0; // 0 biểu thị thêm thành công
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý ngoại lệ
                Console.WriteLine("Error: " + ex.Message);
                return -1; // -1 biểu thị lỗi xảy ra khi thêm món ăn vào cơ sở dữ liệu
            }
        }
        public int CapNhatMonAn(MonAn monAnMoi)
        {
            // Kiểm tra nếu đối tượng món ăn rỗng (null) hoặc không có tên và giá
            if (monAnMoi == null || monAnMoi.MaMonAn ==0)
            {
                return 1; // 1 biểu thị lỗi do đối tượng món ăn rỗng hoặc thiếu tên món ăn hoặc giá
            }

            try
            {
                // Kết nối tới cơ sở dữ liệu
                using (QLBH2Entities db = new QLBH2Entities())
                {
                    // Tìm món ăn cần cập nhật trong cơ sở dữ liệu bằng MaMonAn
                    var existingMonAn = db.MonAn.FirstOrDefault(ma => ma.MaMonAn == monAnMoi.MaMonAn && ma.Active != 0);
                    if (existingMonAn == null)
                    {
                        return 2; // 2 biểu thị lỗi do không tìm thấy món ăn
                    }

                    // Cập nhật thông tin món ăn nếu các thuộc tính không null
                    if (!string.IsNullOrEmpty(monAnMoi.TenMonAn))
                    {
                        existingMonAn.TenMonAn = monAnMoi.TenMonAn;
                    }

                    if (monAnMoi.Gia != 0)
                    {
                        existingMonAn.Gia = monAnMoi.Gia;
                    }

                    if (!string.IsNullOrEmpty(monAnMoi.MoTa))
                    {
                        existingMonAn.MoTa = monAnMoi.MoTa;
                    }

                    if (monAnMoi.SoLuongTon.HasValue)
                    {
                        existingMonAn.SoLuongTon = monAnMoi.SoLuongTon;
                    }

                    // Lưu các thay đổi vào cơ sở dữ liệu
                    db.SaveChanges();
                }

                return 0; // 0 biểu thị cập nhật thành công
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý ngoại lệ
                Console.WriteLine("Error: " + ex.Message);
                return -1; // -1 biểu thị lỗi xảy ra khi cập nhật món ăn trong cơ sở dữ liệu
            }

        }
        public int XoaMonAn(int maMonAn)
        {
            try
            {
                using (QLBH2Entities db = new QLBH2Entities())
                {
                    // Tìm món ăn theo mã món ăn
                    var monAn = db.MonAn.FirstOrDefault(ma => ma.MaMonAn == maMonAn);
                    if (monAn == null)
                    {
                        return 1; // 1 biểu thị lỗi do không tìm thấy món ăn
                    }

                    // Đánh dấu món ăn là đã bị xóa thay vì xóa khỏi cơ sở dữ liệu
                    monAn.Active = 0;
                    db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                }

                return 0; // 0 biểu thị thành công
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý ngoại lệ
                Console.WriteLine("Error: " + ex.Message);
                return -1; // -1 biểu thị lỗi xảy ra khi xóa món ăn
            }
        }
        public void ResetSoLuongTon(int maMonAn, int? giaTriMacDinh = null)
        {
            using (QLBH2Entities db = new QLBH2Entities())
            {
                // Tìm món ăn theo MaMonAn
                var monAn = db.MonAn.FirstOrDefault(m => m.MaMonAn == maMonAn);

                // Nếu tìm thấy món ăn, đặt lại SoLuongTon
                if (monAn != null)
                {
                    monAn.SoLuongTon = giaTriMacDinh;
                    monAn.Active = null;
                    db.SaveChanges();
                }
            }
        }
    }
}
