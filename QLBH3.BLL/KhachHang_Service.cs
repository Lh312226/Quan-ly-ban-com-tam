using QLBH3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH3.BLL
{
    public class KhachHang_Service
    {
        public int CapNhatKhachHang(KhachHang khachHangMoi)
        {
            // Kiểm tra nếu đối tượng khách hàng rỗng (null)
            if (khachHangMoi == null || string.IsNullOrEmpty(khachHangMoi.SoDienThoai))
            {
                return 1; // 1 biểu thị lỗi do đối tượng rỗng hoặc không có số điện thoại
            }

            try
            {
                // Tạo kết nối tới cơ sở dữ liệu
                using (QLBH2Entities db = new QLBH2Entities())
                {
                    // Tìm khách hàng cần cập nhật trong cơ sở dữ liệu bằng số điện thoại
                    var khachHang = db.KhachHang.FirstOrDefault(kh => kh.SoDienThoai == khachHangMoi.SoDienThoai);
                    if (khachHang == null)
                    {
                        return 2; // 2 biểu thị lỗi do không tìm thấy khách hàng
                    }

                    // Cập nhật thông tin khách hàng
                    khachHang.TenKhachHang = khachHangMoi.TenKhachHang;
                    khachHang.DiaChi = khachHangMoi.DiaChi;
                    khachHang.SoDienThoai = khachHangMoi.SoDienThoai;

                    // Lưu các thay đổi vào cơ sở dữ liệu
                    db.SaveChanges();
                }

                return 0; // 0 biểu thị cập nhật thành công
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý ngoại lệ
                Console.WriteLine("Error: " + ex.Message);
                return -1; // -1 biểu thị lỗi xảy ra khi cập nhật cơ sở dữ liệu
            }
        }
        public int XoaKhachHang(string soDienThoai)
        {
            // Kiểm tra nếu số điện thoại rỗng hoặc null
            if (string.IsNullOrEmpty(soDienThoai))
            {
                return 1; // 1 biểu thị lỗi do số điện thoại rỗng
            }

            try
            {
                // Tạo kết nối tới cơ sở dữ liệu
                using (QLBH2Entities db = new QLBH2Entities())
                {
                    // Tìm khách hàng trong cơ sở dữ liệu dựa trên số điện thoại
                    var khachHang = db.KhachHang.FirstOrDefault(kh => kh.SoDienThoai == soDienThoai);
                    if (khachHang == null)
                    {
                        return 2; // 2 biểu thị lỗi do không tìm thấy khách hàng
                    }

                    // Xóa khách hàng khỏi cơ sở dữ liệu
                    db.KhachHang.Remove(khachHang);
                    db.SaveChanges(); // Lưu các thay đổi vào cơ sở dữ liệu
                }

                return 0; // 0 biểu thị xóa thành công
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý ngoại lệ
                Console.WriteLine("Error: " + ex.Message);
                return -1; // -1 biểu thị lỗi xảy ra khi xóa từ cơ sở dữ liệu
            }
        }

    }
}
