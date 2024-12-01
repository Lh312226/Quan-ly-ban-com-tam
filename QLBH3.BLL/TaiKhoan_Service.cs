using QLBH3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace QLBH3.BLL
{
    public class TaiKhoan_Service
    {
        public int ThemTaiKhoanVaKhachHang(TaiKhoan taiKhoan, KhachHang khachHang)
        {
            if (taiKhoan == null || khachHang == null)
            {
                return 1; // 1 biểu thị lỗi do đối tượng tài khoản hoặc khách hàng rỗng (null)
            }

            try
            {
                using (QLBH2Entities db = new QLBH2Entities())
                {
                    // Kiểm tra xem tài khoản đã tồn tại trong cơ sở dữ liệu chưa
                    var existingAccount = db.TaiKhoan.FirstOrDefault(a => a.TenTaiKhoan == taiKhoan.TenTaiKhoan);
                    if (existingAccount != null)
                    {
                        return 2; // 2 biểu thị lỗi do tài khoản đã tồn tại
                    }

                    // Thêm tài khoản vào bảng TaiKhoan
                    taiKhoan.LoaiTaiKhoan = 1;
                    taiKhoan.Active = 1;
                    db.TaiKhoan.Add(taiKhoan);
                    db.SaveChanges(); // Lưu để tài khoản mới được thêm vào

                    // Lấy MaTaiKhoan vừa được tạo sau khi thêm tài khoản
                    int maTaiKhoanMoi = taiKhoan.MaTaiKhoan;

                    // Gán MaTaiKhoan mới vào khách hàng và thêm vào bảng KhachHang
                    khachHang.MaTaiKhoan = maTaiKhoanMoi;
                    db.KhachHang.Add(khachHang);
                    db.SaveChanges(); // Lưu các thay đổi vào cơ sở dữ liệu
                }

                return 0; // 0 biểu thị thêm thành công
            }
            catch (Exception ex)
            {
                // Ghi log hoặc xử lý ngoại lệ
                Console.WriteLine("Error: " + ex.Message);
                return -1; // -1 biểu thị lỗi khi thêm vào cơ sở dữ liệu
            }
        }
        public int Cap_Nhat(int accountID, string currentPassword, string newPassword)
        {
            using (QLBH2Entities db = new QLBH2Entities())
            {
                var existingAccount = db.TaiKhoan.FirstOrDefault(a => a.MaTaiKhoan == accountID);
                if (existingAccount == null)
                {
                    return 1; // 1: tài khoản không tồn tại
                }

                // Kiểm tra mật khẩu hiện tại
                if (existingAccount.MatKhau != currentPassword)
                {
                    return 2; // 2: mật khẩu hiện tại không đúng
                }

                // Cập nhật mật khẩu mới
                existingAccount.MatKhau = newPassword;
                db.SaveChanges(); // Lưu thay đổi
            }

            return 0; // 0: thành công
        }
        // Phương thức khóa tài khoản
        public int KhoaTaiKhoan(int maTaiKhoan)
        {
            using (QLBH2Entities db = new QLBH2Entities())
            {
                // Tìm tài khoản dựa trên mã tài khoản
                var taiKhoan = db.TaiKhoan.FirstOrDefault(a => a.MaTaiKhoan == maTaiKhoan);
                if (taiKhoan != null && taiKhoan.MaTaiKhoan !=1)
                {
                    // Đặt giá trị thuộc tính active thành 0 (hoặc giá trị tương ứng để chỉ định khóa tài khoản)
                    taiKhoan.Active = 0;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    return db.SaveChanges(); // Trả về số lượng bản ghi đã được thay đổi
                }
                return -1; // Trả về -1 nếu không tìm thấy tài khoản
            }
        }
        public int MoKhoaTaiKhoan(int maTaiKhoan)
        {
            using (QLBH2Entities db = new QLBH2Entities())
            {
                // Tìm tài khoản dựa trên mã tài khoản
                var taiKhoan = db.TaiKhoan.FirstOrDefault(a => a.MaTaiKhoan == maTaiKhoan);
                if (taiKhoan != null && taiKhoan.MaTaiKhoan != 1) // Kiểm tra tài khoản có tồn tại và đang bị khóa (Active == 0)
                {
                    // Đặt giá trị thuộc tính active thành 1 để mở khóa tài khoản
                    taiKhoan.Active = 1;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    return db.SaveChanges(); // Trả về số lượng bản ghi đã được thay đổi
                }
                return -1; // Trả về -1 nếu không tìm thấy tài khoản hoặc tài khoản không bị khóa
            }
        }

    }
}
