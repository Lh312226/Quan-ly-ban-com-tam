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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdatePass updatePass = new UpdatePass();
            updatePass.Show();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Profile profile = new Profile();
            profile.Show();
        }
        private void LoadDataGridView1()
        {
            using (QLBH2Entities db = new QLBH2Entities())
            {
                var danhSachMonAn = db.MonAn
                    .Where(ma => ma.Active !=0) // Chỉ lấy những món ăn chưa bị xóa
                    .Select(ma => new
                    {
                        ma.MaMonAn,
                        ma.TenMonAn,
                        ma.Gia,
                        ma.MoTa,
                        ma.SoLuongTon
                    }).ToList();

                dataGridView1.DataSource = danhSachMonAn;
            }
        }

        private void User_Load(object sender, EventArgs e)
        {
            LoadDataGridView1(); // Tải dữ liệu khi form được tải
            SetupDataGridView2();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu dòng được chọn không phải là tiêu đề
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Lấy dữ liệu từ các ô của dòng được chọn
                int maMonAn = Convert.ToInt32(selectedRow.Cells["MaMonAn"].Value);
                string tenMonAn = selectedRow.Cells["TenMonAn"].Value.ToString();
                decimal gia = Convert.ToDecimal(selectedRow.Cells["Gia"].Value);
                string moTa = selectedRow.Cells["MoTa"].Value?.ToString(); // Có thể null
                int soLuongTon = Convert.ToInt32(selectedRow.Cells["SoLuongTon"].Value);

                // Tạo một dòng mới để thêm vào dataGridView2
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dataGridView2);

                // Gán các giá trị vào các ô của dòng mới
                newRow.Cells[0].Value = maMonAn;
                newRow.Cells[1].Value = tenMonAn;
                newRow.Cells[2].Value = gia;
                newRow.Cells[3].Value = moTa;
                newRow.Cells[4].Value = soLuongTon;

                // Thêm dòng mới vào dataGridView2
                dataGridView2.Rows.Add(newRow);
            }
        }
        private void SetupDataGridView2()
        {
            // Nếu bạn muốn tự tạo cột cho dataGridView2
            dataGridView2.Columns.Add("MaMonAn", "Mã Món Ăn");
            dataGridView2.Columns.Add("TenMonAn", "Tên Món Ăn");
            dataGridView2.Columns.Add("Gia", "Giá");
            dataGridView2.Columns.Add("MoTa", "Mô Tả");
            dataGridView2.Columns.Add("SoLuongTon", "Số Lượng Tồn");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Khởi tạo đối tượng đơn hàng mới
            DonHang donHangMoi = new DonHang
            {
                NgayDat = DateTime.Now,
                MaKhachHang = Form1.loggedUserID, // Giả định bạn có thông tin người dùng đang đăng nhập
                TrangThai = "Chưa xác nhận" // Đặt trạng thái đơn là "Chưa xác nhận"
            };

            // Tạo danh sách các chi tiết đơn hàng từ dataGridView2
            List<ChiTietDonHang> chiTietDonHangs = new List<ChiTietDonHang>();

            using (QLBH2Entities db = new QLBH2Entities())
            {
                // Tạo từ điển để lưu tổng số lượng đặt của mỗi món ăn
                Dictionary<int, int> soLuongTheoMonAn = new Dictionary<int, int>();

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.IsNewRow) continue; // Bỏ qua dòng mới trống

                    // Lấy mã món ăn và số lượng đặt từ dataGridView2
                    int maMonAn = Convert.ToInt32(row.Cells["MaMonAn"].Value);
                    int soLuong = 1; // Giả định mỗi dòng là một đơn vị đặt của món ăn, hoặc chỉnh lại dựa trên cột chứa số lượng

                    // Cộng dồn số lượng đặt của từng món ăn vào từ điển
                    if (soLuongTheoMonAn.ContainsKey(maMonAn))
                    {
                        soLuongTheoMonAn[maMonAn] += soLuong;
                    }
                    else
                    {
                        soLuongTheoMonAn[maMonAn] = soLuong;
                    }
                }

                // Kiểm tra tồn kho từ bảng MonAn
                foreach (var item in soLuongTheoMonAn)
                {
                    int maMonAn = item.Key;
                    int soLuongDat = item.Value;

                    // Lấy thông tin tồn kho của món ăn từ cơ sở dữ liệu
                    var monAn = db.MonAn.FirstOrDefault(m => m.MaMonAn == maMonAn);
                    if (monAn != null && monAn.SoLuongTon < soLuongDat)
                    {
                        MessageBox.Show($"Số lượng món ăn \"{monAn.TenMonAn}\" không đủ trong kho. Vui lòng điều chỉnh số lượng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Hủy quá trình đặt hàng nếu không đủ số lượng tồn
                    }
                }

                // Nếu qua kiểm tra tồn kho, thêm các chi tiết vào danh sách chi tiết đơn hàng
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.IsNewRow) continue;

                    int maMonAn = Convert.ToInt32(row.Cells["MaMonAn"].Value);
                    int soLuong = 1; // Số lượng mỗi món ăn là 1

                    if (soLuong == 0) continue;

                    ChiTietDonHang chiTiet = new ChiTietDonHang
                    {
                        MaMonAn = maMonAn,
                        SoLuong = soLuong,
                        GiaBan = Convert.ToDecimal(row.Cells["Gia"].Value)
                    };
                    chiTietDonHangs.Add(chiTiet);
                }
            }

            // Kiểm tra nếu không có chi tiết đơn hàng nào được thêm
            if (chiTietDonHangs.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một món ăn có số lượng lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tính tổng tiền
            donHangMoi.TongTien = chiTietDonHangs.Sum(ct => ct.GiaBan * ct.SoLuong);

            // Gọi hàm trong BLL để tạo đơn hàng
            DonHang_Service donHangService = new DonHang_Service();
            int result = donHangService.TaoDonHang(donHangMoi, chiTietDonHangs);

            // Kiểm tra kết quả và hiển thị thông báo
            if (result == 0)
            {
                // Đặt đơn thành công, cập nhật lại số lượng tồn
                donHangService.CapNhatSoLuongTonSauKhiDat(chiTietDonHangs);

                MessageBox.Show("Đặt đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView2.DataSource = null; // Xóa dữ liệu trong dataGridView2 sau khi đặt đơn
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra khi đặt đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadDataGridView1(); // Tải dữ liệu khi form được tải
            Reset();
        }

        private void đơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_DonHang user_DonHang = new User_DonHang();
            user_DonHang.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn đơn hàng hay chưa
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Kiểm tra xem người dùng đã chọn hàng nào trong DataGridView hay chưa
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    // Xác nhận xóa
                    var result = MessageBox.Show("Bạn có chắc chắn muốn xóa món ăn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Lấy chỉ số hàng được chọn
                        int rowIndex = dataGridView2.SelectedRows[0].Index;

                        // Xóa hàng khỏi DataGridView
                        dataGridView2.Rows.RemoveAt(rowIndex);
                    }
                }
                else
                {
                    // Thông báo nếu không có hàng nào được chọn
                    MessageBox.Show("Vui lòng chọn một món ăn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void Reset()
        {
            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();
            SetupDataGridView2();
        }
    }
}
