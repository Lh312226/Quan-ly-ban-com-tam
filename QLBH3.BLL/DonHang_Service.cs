using QLBH3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH3.BLL
{
    public class DonHang_Service
    {
        public int TaoDonHang(DonHang donHang, List<ChiTietDonHang> chiTietDonHangs)
        {
            try
            {
                using (var db = new QLBH2Entities())
                {
                    // Thêm đơn hàng vào cơ sở dữ liệu
                    db.DonHang.Add(donHang);
                    db.SaveChanges(); // Lưu thay đổi để tạo MaDonHang

                    // Thêm các chi tiết đơn hàng vào cơ sở dữ liệu
                    foreach (var chiTiet in chiTietDonHangs)
                    {
                        chiTiet.MaDonHang = donHang.MaDonHang; // Gán MaDonHang từ đơn hàng đã được lưu
                        db.ChiTietDonHang.Add(chiTiet);
                    }
                    db.SaveChanges(); // Lưu các chi tiết đơn hàng

                    return 0; // Thành công
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return -1; // Lỗi
            }
        }
        public int XacNhanDonHang(int maDonHang)
        {
            try
            {
                using (QLBH2Entities db = new QLBH2Entities())
                {
                    // Tìm đơn hàng theo mã
                    var donHang = db.DonHang.FirstOrDefault(dh => dh.MaDonHang == maDonHang);

                    if (donHang == null)
                    {
                        return 1; // Không tìm thấy đơn hàng
                    }

                    // Cập nhật trạng thái đơn hàng
                    donHang.TrangThai = "Đã xác nhận";
                    db.SaveChanges();
                    return 0; // Thành công
                }
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                Console.WriteLine("Error: " + ex.Message);
                return -1; // Lỗi
            }
        }
        public int HuyDonHang(int maDonHang)
        {
            try
            {
                using (QLBH2Entities db = new QLBH2Entities())
                {
                    // Tìm đơn hàng cần hủy bằng mã đơn hàng
                    var donHang = db.DonHang.FirstOrDefault(dh => dh.MaDonHang == maDonHang);
                    if (donHang == null)
                    {
                        return 1; // 1 biểu thị không tìm thấy đơn hàng
                    }

                    // Cập nhật trạng thái đơn hàng thành "Đã hủy"
                    donHang.TrangThai = "Đã hủy";
                    db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                    return 0; // 0 biểu thị hủy đơn hàng thành công
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý ngoại lệ
                Console.WriteLine("Error: " + ex.Message);
                return -1; // -1 biểu thị lỗi xảy ra khi hủy đơn hàng
            }
        }
        public DonHang GetDonHangById(int maDonHang)
        {
            using (QLBH2Entities db = new QLBH2Entities())
            {
                return db.DonHang.FirstOrDefault(dh => dh.MaDonHang == maDonHang);
            }
        }
        public int ChuyenTrangThaiDonHang(int maDonHang, string trangThaiMoi)
        {
            try
            {
                using (QLBH2Entities db = new QLBH2Entities())
                {
                    // Tìm đơn hàng với mã đơn hàng
                    var donHang = db.DonHang.FirstOrDefault(dh => dh.MaDonHang == maDonHang);
                    if (donHang != null)
                    {
                        // Cập nhật trạng thái đơn hàng
                        donHang.TrangThai = trangThaiMoi;
                        db.SaveChanges();
                        return 0; // Thành công
                    }
                    return 1; // Không tìm thấy đơn hàng
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return -1; // Lỗi xảy ra khi cập nhật trạng thái
            }
        }
        public void CapNhatSoLuongTonSauKhiDat(List<ChiTietDonHang> chiTietDonHangs)
        {
            using (QLBH2Entities db = new QLBH2Entities())
            {
                foreach (var chiTiet in chiTietDonHangs)
                {
                    var monAn = db.MonAn.FirstOrDefault(m => m.MaMonAn == chiTiet.MaMonAn);
                    if (monAn != null)
                    {
                        monAn.SoLuongTon -= chiTiet.SoLuong;
                        if (monAn.SoLuongTon < 0) monAn.SoLuongTon = 0; // Đảm bảo không có số lượng âm
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
