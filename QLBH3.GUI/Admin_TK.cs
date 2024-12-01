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

namespace QLBH3.GUI
{
    public partial class Admin_TK : Form
    {
        public Admin_TK()
        {
            InitializeComponent();
        }

        private void Admin_TK_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLBH2DataSet.TaiKhoan' table. You can move, or remove it, as needed.
            this.taiKhoanTableAdapter.Fill(this.qLBH2DataSet.TaiKhoan);

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin admin = new Admin();
            admin.Show();
        }

        private void btn_Khoa_Click(object sender, EventArgs e)
        {
            // Giả sử bạn đã lấy mã tài khoản từ một TextBox
            if (string.IsNullOrEmpty(txt_MaTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập mã tài khoản!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Kết thúc hàm nếu mã tài khoản không được nhập
            }

            // Giả sử bạn đã lấy mã tài khoản từ một DataGridView hoặc một TextBox
            int maTaiKhoan = Convert.ToInt32(txt_MaTaiKhoan.Text);

            TaiKhoan_Service taiKhoanService = new TaiKhoan_Service();
            int result = taiKhoanService.KhoaTaiKhoan(maTaiKhoan);

            if (result > 0)
            {
                MessageBox.Show("Tài khoản đã được khóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == -1)
            {
                MessageBox.Show("Tài khoản này không thể khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra khi khóa tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_MoKhoa_Click(object sender, EventArgs e)
        {
            // Giả sử bạn đã lấy mã tài khoản từ một TextBox
            if (string.IsNullOrEmpty(txt_MaTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập mã tài khoản!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Kết thúc hàm nếu mã tài khoản không được nhập
            }

            // Giả sử bạn đã lấy mã tài khoản từ một DataGridView hoặc một TextBox
            int maTaiKhoan = Convert.ToInt32(txt_MaTaiKhoan.Text);
            if (maTaiKhoan == 0)
            {
                MessageBox.Show("Vui lòng nhập mã tài khoản!!!");
            }

            TaiKhoan_Service taiKhoanService = new TaiKhoan_Service();
            int result = taiKhoanService.MoKhoaTaiKhoan(maTaiKhoan);

            if (result > 0)
            {
                MessageBox.Show("Tài khoản đã được mở khóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == -1)
            {
                MessageBox.Show("Không tìm thấy tài khoản hoặc tài khoản không bị khóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra khi mở khóa tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
