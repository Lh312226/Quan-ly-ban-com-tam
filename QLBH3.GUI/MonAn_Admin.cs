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
    public partial class MonAn_Admin : Form
    {
        public MonAn_Admin()
        {
            InitializeComponent();
        }

        private void MonAn_Admin_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            using (QLBH2Entities db = new QLBH2Entities())
            {
                // Lấy tất cả dữ liệu từ bảng MonAn và chuyển thành danh sách
                var danhSachMonAn = db.MonAn
                                     .Select(ma => new
                                     {
                                         ma.MaMonAn,
                                         ma.TenMonAn,
                                         ma.Gia,
                                         ma.MoTa,
                                         ma.SoLuongTon,
                                         ma.Active
                                     })
                                     .ToList();

                // Gán dữ liệu vào DataGridView
                dgv_MonAn.DataSource = danhSachMonAn;
            }
        }
        private void ResetFields()
        {
            txt_maMonAn.Clear();
            txt_tenMonAn.Clear();
            txt_Gia.Clear();
            txt_moTa.Clear();
            txt_SL.Clear();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng MonAn mới dựa trên các thông tin nhập từ form
            MonAn monAnMoi = new MonAn()
            {
                TenMonAn = txt_tenMonAn.Text,
                Gia = decimal.Parse(txt_Gia.Text), // Hãy đảm bảo xử lý các ngoại lệ khi chuyển đổi nếu cần
                MoTa = string.IsNullOrEmpty(txt_moTa.Text) ? null : txt_moTa.Text, // Mô tả có thể là null
                SoLuongTon = int.TryParse(txt_SL.Text, out int soLuong) ? (int?)soLuong : null // Số lượng tồn có thể là null
            };
            // Tạo một đối tượng MonAn_Service để gọi phương thức
            MonAn_Service monAnService = new MonAn_Service();
            int result = monAnService.ThemMonAn(monAnMoi);

            // Xử lý kết quả và hiển thị các thông báo phù hợp cho người dùng
            switch (result)
            {
                case 0:
                    MessageBox.Show("Thêm món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView(); // Làm mới DataGridView sau khi thêm một món ăn mới
                    ResetFields();
                    break;
                case 1:
                    MessageBox.Show("Thông tin món ăn không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show("Món ăn đã tồn tại trong hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case -1:
                    MessageBox.Show("Có lỗi xảy ra khi thêm món ăn. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    MessageBox.Show("Lỗi không xác định.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin admin = new Admin();
            admin.ShowDialog();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các textbox
            MonAn monAnMoi = new MonAn()
            {
                MaMonAn = int.Parse(txt_maMonAn.Text), // Mã món ăn là bắt buộc để tìm món ăn

                // Chỉ gán giá trị nếu txt_tenMonAn không trống hoặc null
                TenMonAn = string.IsNullOrEmpty(txt_tenMonAn.Text) ? null : txt_tenMonAn.Text,

                // Chuyển đổi giá trị của txt_Gia và xử lý trường hợp null
                Gia = decimal.TryParse(txt_Gia.Text, out decimal gia) ? gia : 0, // Gán 0 nếu không có giá trị hợp lệ


                // Chỉ gán giá trị nếu txt_moTa không trống hoặc null
                MoTa = string.IsNullOrEmpty(txt_moTa.Text) ? null : txt_moTa.Text,

                // Chuyển đổi giá trị của txt_SL và xử lý trường hợp null
                SoLuongTon = int.TryParse(txt_SL.Text, out int soLuong) ? (int?)soLuong : null
            };


            // Gọi phương thức cập nhật món ăn từ BLL
            MonAn_Service monAnService = new MonAn_Service();
            int result = monAnService.CapNhatMonAn(monAnMoi);

            // Kiểm tra kết quả cập nhật và thông báo cho người dùng
            if (result == 0)
            {
                MessageBox.Show("Cập nhật món ăn thành công!");
                LoadDataGridView();
                ResetFields();
            }
            else if (result == 1)
            {
                MessageBox.Show("Thông tin món ăn không hợp lệ. Vui lòng nhập tên và giá món ăn.");
            }
            else if (result == 2)
            {
                MessageBox.Show("Không tìm thấy món ăn hoặc món ăn đã bị xóa để cập nhật.");
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật món ăn.");
            }
        }
        private void btn_Del_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã nhập mã món ăn hay chưa
            if (string.IsNullOrEmpty(txt_maMonAn.Text))
            {
                MessageBox.Show("Vui lòng nhập mã món ăn để xóa.");
                return;
            }
            var monAnMoi = int.Parse(txt_maMonAn.Text);
            
                // Gọi phương thức xóa món XoaMonAn
                MonAn_Service monAnService = new MonAn_Service();
                int result = monAnService.XoaMonAn(monAnMoi);

                if (result == 0)
                {
                    MessageBox.Show("Món ăn đã được xóa thành công!");
                    LoadDataGridView(); // Cập nhật lại DataGridView
                }
                else if (result == 1)
                {
                    MessageBox.Show("Không tìm thấy món ăn với mã đã nhập.");
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xóa món ăn.");
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn trong dataGridView1 không
            if (dgv_MonAn.SelectedRows.Count > 0)
            {
                // Lấy mã món ăn từ hàng được chọn
                int maMonAn = Convert.ToInt32(dgv_MonAn.SelectedRows[0].Cells["MaMonAn"].Value);

                // Tạo một đối tượng của lớp MonAn_Service
                MonAn_Service monAnService = new MonAn_Service();


                // Đặt lại số lượng tồn của món ăn được chọn về 0 (hoặc giá trị mặc định khác)
                monAnService.ResetSoLuongTon(maMonAn, null);

                // Tải lại dữ liệu vào dataGridView1 để cập nhật giao diện
                LoadDataGridView();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một món ăn để mở khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
