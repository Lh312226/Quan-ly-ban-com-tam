using QLBH3.BLL;
using QLBH3.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH3.GUI
{
    public partial class Ad_DonHang : Form
    {
        private readonly QLBH2Entities contextDB;
        public Ad_DonHang()
        {
            InitializeComponent();
            contextDB = new QLBH2Entities();

        }

        private void LoadDataDonHang()
        {
            using (QLBH2Entities db = new QLBH2Entities())
            {
                // Lấy ngày được chọn từ DateTimePicker
                DateTime ngayChon = dateTimePicker1.Value.Date;

                // Lọc danh sách đơn hàng theo ngày được chọn
                var danhSachDonHang = db.DonHang
                    .Where(dh => DbFunctions.TruncateTime(dh.NgayDat) == ngayChon)
                    .Select(dh => new
                    {
                        dh.MaDonHang,
                        dh.NgayDat,
                        dh.MaKhachHang,
                        dh.TongTien,
                        dh.TrangThai
                    })
                    .ToList();

                // Gán danh sách vào DataGridView
                dtgDonHang.DataSource = danhSachDonHang;
            }
        }

        private void Ad_DonHang_Load(object sender, EventArgs e)
        {
            LoadDataDonHang();
        }

        private void dtgDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra chỉ số hàng hợp lệ (nghĩa là không phải tiêu đề hoặc ngoài giới hạn)
            if (e.RowIndex >= 0)
            {
                // Lấy hàng hiện tại được chọn
                DataGridViewRow row = dtgDonHang.Rows[e.RowIndex];

                // Lấy mã khách hàng từ hàng được chọn
                int maKhachHang = Convert.ToInt32(row.Cells["MaKhachHang"].Value);

                // Gọi hàm để lấy thông tin khách hàng từ cơ sở dữ liệu
                using (QLBH2Entities db = new QLBH2Entities())
                {
                    var khachHang = db.KhachHang.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);
                    if (khachHang != null)
                    {
                        // Gán thông tin khách hàng vào các TextBox
                        txt_HoTen.Text = khachHang.TenKhachHang; // Giả sử có thuộc tính HoTen trong KhachHang
                        txt_SoDienThoai.Text = khachHang.SoDienThoai; // Giả sử có thuộc tính SoDienThoai
                        txt_DiaChi.Text = khachHang.DiaChi; // Giả sử có thuộc tính DiaChi
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView hay không
            if (dtgDonHang.SelectedRows.Count > 0)
            {
                // Lấy mã đơn hàng từ hàng được chọn trong DataGridView
                int maDonHang = Convert.ToInt32(dtgDonHang.SelectedRows[0].Cells["MaDonHang"].Value);

                // Tạo đối tượng dịch vụ DonHang
                DonHang_Service donHangService = new DonHang_Service();

                // Lấy đơn hàng từ cơ sở dữ liệu
                DonHang donHang = donHangService.GetDonHangById(maDonHang);

                if (donHang != null)
                {
                    // Kiểm tra nếu trạng thái đơn hàng là "Chưa xác nhận"
                    if (donHang.TrangThai == "Chưa xác nhận")
                    {
                        // Cập nhật trạng thái đơn hàng thành "Đã hủy"
                        int result = donHangService.HuyDonHang(maDonHang);

                        // Kiểm tra kết quả
                        if (result == 0)
                        {
                            MessageBox.Show("Đơn hàng đã được hủy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataDonHang(); // Tải lại dữ liệu để hiển thị thay đổi
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi xảy ra khi hủy đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chỉ có thể hủy đơn hàng ở trạng thái 'Chưa xác nhận'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Thông báo nếu không có dòng nào được chọn trong DataGridView
                MessageBox.Show("Vui lòng chọn một đơn hàng từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView hay không
            if (dtgDonHang.SelectedRows.Count > 0)
            {
                // Lấy mã đơn hàng từ hàng được chọn trong DataGridView
                int maDonHang = Convert.ToInt32(dtgDonHang.SelectedRows[0].Cells["MaDonHang"].Value);

                // Gọi hàm trong BLL để lấy đơn hàng
                DonHang_Service donHangService = new DonHang_Service();
                var donHang = donHangService.GetDonHangById(maDonHang);

                // Kiểm tra đơn hàng và trạng thái của đơn hàng
                if (donHang != null)
                {
                    if (donHang.TrangThai == "Chưa xác nhận")
                    {
                        // Xác nhận đơn hàng
                        int result = donHangService.XacNhanDonHang(maDonHang);

                        // Kiểm tra kết quả
                        if (result == 0)
                        {
                            MessageBox.Show("Đơn hàng đã được xác nhận thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataDonHang(); // Tải lại dữ liệu để hiển thị thay đổi
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi xảy ra khi xác nhận đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chỉ có thể xác nhận đơn hàng ở trạng thái 'Chưa xác nhận'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Thông báo nếu không có dòng nào được chọn trong DataGridView
                MessageBox.Show("Vui lòng chọn một đơn hàng từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin admin = new Admin();
            admin.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadDataDonHang();
        }
    }
}
