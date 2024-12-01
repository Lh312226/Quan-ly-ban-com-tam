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
    public partial class User_DonHang : Form
    {
        public User_DonHang()
        {
            InitializeComponent();
        }
        private void LoadDataDonHang()
        {
            // Kiểm tra xem người dùng đã đăng nhập hay chưa (đảm bảo `loggedUserID` không phải là 0)
            if (Form1.loggedUserID != 0)
            {
                using (QLBH2Entities db = new QLBH2Entities())
                {
                    // Lấy danh sách đơn hàng cho tài khoản đã đăng nhập
                    var danhSachDonHang = db.DonHang
                        .Where(dh => dh.MaKhachHang == Form1.loggedUserID) // Lọc theo mã khách hàng đã đăng nhập
                        .Select(dh => new
                        {
                            dh.MaDonHang,
                            dh.NgayDat,
                            dh.TongTien,
                            TrangThai = dh.TrangThai
                        })
                        .ToList();

                    // Gán dữ liệu vào DataGridView
                    dtgDonHang.DataSource = danhSachDonHang;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản đã đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void User_DonHang_Load(object sender, EventArgs e)
        {
            LoadDataDonHang();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            User  user = new User();
            user.Show();
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn đơn hàng hay chưa
            if (dtgDonHang.SelectedRows.Count > 0)
            {
                // Lấy mã đơn hàng từ hàng được chọn
                int maDonHang = Convert.ToInt32(dtgDonHang.SelectedRows[0].Cells["MaDonHang"].Value);

                // Lấy trạng thái hiện tại của đơn hàng
                string trangThaiHienTai = dtgDonHang.SelectedRows[0].Cells["TrangThai"].Value.ToString();

                // Kiểm tra xem đơn hàng có trạng thái là "Đã xác nhận" hay không
                if (trangThaiHienTai == "Đã xác nhận")
                {
                    // Gọi hàm trong BLL để cập nhật trạng thái đơn hàng thành "Hoàn thành"
                    DonHang_Service donHangService = new DonHang_Service();
                    int result = donHangService.ChuyenTrangThaiDonHang(maDonHang, "Hoàn thành"); // Giả sử 3 là mã cho trạng thái "Hoàn thành"

                    // Kiểm tra kết quả
                    if (result == 0)
                    {
                        MessageBox.Show("Đơn hàng đã được chuyển sang trạng thái 'Hoàn thành' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataDonHang(); // Tải lại dữ liệu để hiển thị thay đổi
                    }
                    else if (result == 1)
                    {
                        MessageBox.Show("Không tìm thấy đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi xảy ra khi cập nhật trạng thái đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Thông báo nếu trạng thái hiện tại không phải là "Đã xác nhận"
                    MessageBox.Show("Chỉ có thể hoàn thành đơn hàng ở trạng thái 'Đã xác nhận'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Thông báo nếu không có đơn hàng nào được chọn
                MessageBox.Show("Vui lòng chọn một đơn hàng để hoàn thành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static int IDDon;
        private void tbn_ChiTiet_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn đơn hàng hay chưa
            if (dtgDonHang.SelectedRows.Count > 0)
            {
                // Lấy mã đơn hàng từ hàng được chọn
                int maDonHang = Convert.ToInt32(dtgDonHang.SelectedRows[0].Cells["MaDonHang"].Value);
                IDDon = maDonHang;
                // Khởi tạo form ChiTietDonHang và truyền mã đơn hàng sang
                User_ChiTiet chiTietForm = new User_ChiTiet();
                chiTietForm.Show();
            }
            else
            {
                // Thông báo nếu không có đơn hàng nào được chọn
                MessageBox.Show("Vui lòng chọn một đơn hàng để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
