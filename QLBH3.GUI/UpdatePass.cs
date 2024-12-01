using QLBH3.BLL;
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
    public partial class UpdatePass : Form
    {
        public UpdatePass()
        {
            InitializeComponent();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            User user = new User();
            user.Show();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string currentPassword = txt_oldPass.Text;
            string newPassword = txt_newPass.Text;
            string confirmPassword = txt_comfirmPass.Text;

            // Kiểm tra nếu các trường mật khẩu trống
            if (string.IsNullOrEmpty(currentPassword))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại.");
                return;
            }
            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới.");
                return;
            }
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.");
                return;
            }
            int currentAccount = Form1.loggedInAccountID;
            if (currentAccount != 0)
            {
                // Gọi hàm Cap_nhat trong lớp BLL
                TaiKhoan_Service service = new TaiKhoan_Service();
                int result = service.Cap_Nhat(currentAccount, currentPassword, newPassword);

                // Xử lý kết quả trả về
                if (result == 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công.");
                }
                else if (result == 1)
                {
                    MessageBox.Show("Tài khoản không tồn tại.");
                }
                else if (result == 2)
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng.");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa đăng nhập.");
            }
        }
    }
}
