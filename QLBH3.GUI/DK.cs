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
    public partial class DK : Form
    {
        public DK()
        {
            InitializeComponent();
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void btn_DK_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox trên giao diện
            string tenTaiKhoan = txt_TenTK.Text.Trim();
            string matKhau = txt_MK.Text.Trim();
            string tenKhachHang = txt_Name.Text.Trim();
            string soDienThoai = txt_Phone.Text.Trim();
            string diaChi = txt_Add.Text.Trim();

            if (string.IsNullOrEmpty(tenTaiKhoan) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin cần thiết.");
                return;
            }

            // Tạo đối tượng TaiKhoan
            TaiKhoan taiKhoan = new TaiKhoan
            {
                TenTaiKhoan = tenTaiKhoan,
                MatKhau = matKhau
            };

            // Tạo đối tượng KhachHang
            KhachHang khachHang = new KhachHang
            {
                TenKhachHang = tenKhachHang,
                SoDienThoai = soDienThoai,
                DiaChi = diaChi
            };

            // Gọi phương thức từ lớp BLL để thêm tài khoản và khách hàng
            TaiKhoan_Service service = new TaiKhoan_Service();
            int result = service.ThemTaiKhoanVaKhachHang(taiKhoan, khachHang);

            // Xử lý kết quả trả về
            if (result == 0)
            {
                MessageBox.Show("Thêm tài khoản thành công.");
            }
            else if (result == 1)
            {
                MessageBox.Show("Thông tin tài khoản không hợp lệ.");
            }
            else if (result == 2)
            {
                MessageBox.Show("Tài khoản đã tồn tại.");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm tài khoản và khách hàng.");
            }
        }
    }
}
