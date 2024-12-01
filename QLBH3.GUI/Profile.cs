using QLBH3.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBH3.BLL;

namespace QLBH3.GUI
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }


        private void Profile_Load(object sender, EventArgs e)
        {
            //Khai báo biến tên tài khoản ở form1
            int currentAccount = Form1.loggedInAccountID;
            using (QLBH2Entities db = new QLBH2Entities())
            {
                // Tìm khách hàng dựa trên TenTaiKhoan
                var khachHang = db.KhachHang.FirstOrDefault(kh => kh.MaTaiKhoan == currentAccount);
                if (khachHang != null)
                {
                    // Gán giá trị của khách hàng vào các TextBox
                    txt_TenKH.Text = khachHang.TenKhachHang;
                    txt_SDT.Text = khachHang.SoDienThoai;
                    txt_DiaChi.Text = khachHang.DiaChi;
                }
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            // Chuyển trạng thái của các TextBox sang có thể chỉnh sửa
            txt_TenKH.ReadOnly = false;
            txt_SDT.ReadOnly = false;
            txt_DiaChi.ReadOnly = false;

            // Thông báo rằng người dùng có thể cập nhật thông tin
            MessageBox.Show("Bạn có thể cập nhật thông tin khách hàng.");

            // Đổi nút "Cập nhật" thành "Lưu"
            btn_Update.Text = "Lưu";
            btn_Update.Click -= btn_Update_Click; // Hủy bỏ sự kiện cũ
            btn_Update.Click += btn_Save_Click; // Gán sự kiện mới
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            // Khởi tạo đối tượng KhachHang_Service từ lớp BLL
            KhachHang_Service khachHangService = new KhachHang_Service();

            // Lấy thông tin mới từ các TextBox
            KhachHang khachHangMoi = new KhachHang
            {
                TenKhachHang = txt_TenKH.Text,
                SoDienThoai = txt_SDT.Text,
                DiaChi = txt_DiaChi.Text
            };

            // Gọi phương thức CapNhatKhachHang trong BLL
            int result = khachHangService.CapNhatKhachHang(khachHangMoi);

            // Kiểm tra kết quả trả về
            if (result == 0)
            {
                MessageBox.Show("Thông tin khách hàng đã được cập nhật thành công!");
            }
            else if (result == 1)
            {
                MessageBox.Show("Thông tin khách hàng không hợp lệ hoặc thiếu số điện thoại.");
            }
            else if (result == 2)
            {
                MessageBox.Show("Không tìm thấy khách hàng.");
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật thông tin khách hàng.");
            }

            // Đặt lại trạng thái chỉ đọc cho các TextBox
            txt_TenKH.ReadOnly = true;
            txt_SDT.ReadOnly = true;
            txt_DiaChi.ReadOnly = true;

            // Đổi lại nút "Lưu" thành "Cập nhật"
            btn_Update.Text = "Cập nhật";
            btn_Update.Click -= btn_Save_Click; // Hủy bỏ sự kiện cũ
            btn_Update.Click += btn_Update_Click; // Gán lại sự kiện "Cập nhật"
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            User user = new User();
            user.Show();
        }
    }
}
