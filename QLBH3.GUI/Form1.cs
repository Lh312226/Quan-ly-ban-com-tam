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
using static QLBH3.BLL.TaiKhoan_Service;

namespace QLBH3.GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Khai báo biến toàn cục để lưu tên tài khoản

        // Khai báo biến tĩnh để lưu tên tài khoản đăng nhập
        public static int loggedInAccountID;
        public static int loggedUserID;
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string tentk = txt_tenTK.Text;
            string mk = txt_MK.Text;

            // Kiểm tra xem tên tài khoản và mật khẩu có được nhập hay không
            if (string.IsNullOrEmpty(tentk))
            {
                MessageBox.Show("Vui lòng nhập tài khoản");
                return;
            }

            if (string.IsNullOrEmpty(mk))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                return;
            }

            // Xác thực thông tin đăng nhập
            using (QLBH2Entities db = new QLBH2Entities())
            {
                // Tìm tài khoản trong cơ sở dữ liệu
                var account = db.TaiKhoan.FirstOrDefault(a => a.TenTaiKhoan == tentk && a.MatKhau == mk);

                if (account != null)
                {
                    // Kiểm tra thuộc tính Active
                    if (account.Active != 1)
                    {
                        MessageBox.Show("Tài khoản không được phép đăng nhập!");
                        return;
                    }

                    // Đăng nhập thành công
                    MessageBox.Show("Đăng nhập thành công!");

                    // Lưu tên tài khoản vào biến tĩnh
                    loggedInAccountID = account.MaTaiKhoan;

                    // Tìm thông tin khách hàng dựa trên mã tài khoản
                    var khachHang = db.KhachHang.FirstOrDefault(kh => kh.MaTaiKhoan == account.MaTaiKhoan);
                    if (khachHang != null)
                    {
                        loggedUserID = khachHang.MaKhachHang;
                    }

                    // Kiểm tra loại tài khoản từ cơ sở dữ liệu
                    if (account.LoaiTaiKhoan == 2)
                    {
                        // Chuyển hướng đến form Admin
                        Admin formAdmin = new Admin();
                        formAdmin.Show();
                    }
                    else if (account.LoaiTaiKhoan == 1)
                    {
                        // Chuyển hướng đến form Khách hàng
                        User formKhachHang = new User();
                        formKhachHang.Show();
                    }
                    this.Hide();
                    
                }
                else
                {
                    // Thông báo đăng nhập không thành công
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng!");
                }
            }
        }

        private void btn_signUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            DK dK = new DK();
            dK.Show();
        }
    }
}
