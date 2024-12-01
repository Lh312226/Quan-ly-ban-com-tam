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
using System.Windows.Forms.VisualStyles;

namespace QLBH3.GUI
{
    public partial class Doanh_thu : Form
    {
        public Doanh_thu()
        {
            InitializeComponent();
        }
        // Hàm để lấy và hiển thị doanh thu theo từng món ăn dựa trên ngày
        private List<object> LoadDoanhThuTheoMonAn(DateTime selectedDate)
        {
            using (QLBH2Entities db = new QLBH2Entities())
            {
                // Tạo khoảng thời gian bắt đầu và kết thúc cho ngày được chọn
                DateTime startOfDay = selectedDate.Date; // Ngày được chọn, thời gian bắt đầu là 00:00:00
                DateTime endOfDay = startOfDay.AddDays(1); // Thời gian kết thúc là 23:59:59 của ngày đó

                // Truy vấn dữ liệu để lấy doanh thu theo từng món ăn vào ngày được chọn
                var doanhThuTheoMonAn = db.ChiTietDonHang
                    .Where(ct => ct.DonHang.NgayDat >= startOfDay && ct.DonHang.NgayDat < endOfDay
                                 && ct.DonHang.TrangThai == "Hoàn thành") // Lọc theo khoảng thời gian và trạng thái đơn hàng
                    .GroupBy(ct => new { ct.MaMonAn, ct.MonAn.TenMonAn }) // Nhóm theo Mã Món Ăn và Tên Món Ăn
                    .Select(group => new
                    {
                        MaMonAn = group.Key.MaMonAn,
                        TenMonAn = group.Key.TenMonAn,
                        SoLuongBan = group.Sum(ct => ct.SoLuong), // Tổng số lượng đã bán
                        DoanhThu = group.Sum(ct => ct.SoLuong * ct.GiaBan) // Tính tổng doanh thu của món ăn
                    })
                    .ToList()
                    .Select(x => (object)x) // Ép kiểu ẩn danh thành object
                    .ToList();

                // Đặt dữ liệu vào DataGridView
                dtgDoanhThuMonAn.Columns.Clear(); // Xóa các cột trước đó
                dtgDoanhThuMonAn.AutoGenerateColumns = false; // Tạo cột tự động là false

                // Tạo các cột hiển thị cho DataGridView
                dtgDoanhThuMonAn.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Mã Món Ăn",
                    DataPropertyName = "MaMonAn"
                });

                dtgDoanhThuMonAn.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Tên Món Ăn",
                    DataPropertyName = "TenMonAn"
                });

                dtgDoanhThuMonAn.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Số Lượng Bán",
                    DataPropertyName = "SoLuongBan"
                });

                dtgDoanhThuMonAn.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Doanh Thu",
                    DataPropertyName = "DoanhThu"
                });

                // Gán dữ liệu cho DataGridView
                dtgDoanhThuMonAn.DataSource = doanhThuTheoMonAn;

                // Trả về danh sách doanh thu để sử dụng sau này
                return doanhThuTheoMonAn;
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin admin = new Admin();
            admin.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Lấy ngày được chọn từ DateTimePicker
            DateTime selectedDate = dateTimePicker1.Value.Date;

            // Lấy danh sách doanh thu từ hàm LoadDoanhThuTheoMonAn theo ngày được chọn
            var doanhThuList = LoadDoanhThuTheoMonAn(selectedDate);

            // Tính tổng doanh thu từ các chi tiết đơn hàng
            decimal tongDoanhThu = doanhThuList.Sum(dh => (decimal)dh.GetType().GetProperty("DoanhThu").GetValue(dh));
            lblTongDoanhThu.Text = "Tổng Doanh Thu: " + tongDoanhThu.ToString("N3") + " VND";
        }

        private void Doanh_thu_Load(object sender, EventArgs e)
        {
            // Lấy ngày được chọn từ DateTimePicker
            DateTime selectedDate = dateTimePicker1.Value.Date;

            // Lấy danh sách doanh thu từ hàm LoadDoanhThuTheoMonAn theo ngày được chọn
            var doanhThuList = LoadDoanhThuTheoMonAn(selectedDate);

            // Tính tổng doanh thu từ các chi tiết đơn hàng
            decimal tongDoanhThu = doanhThuList.Sum(dh => (decimal)dh.GetType().GetProperty("DoanhThu").GetValue(dh));
            lblTongDoanhThu.Text = "Tổng Doanh Thu: " + tongDoanhThu.ToString("N3") + " VND";
        }
    }
}
