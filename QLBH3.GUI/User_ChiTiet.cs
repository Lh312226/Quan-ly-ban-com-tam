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
    public partial class User_ChiTiet : Form
    {
        private int maDonHang;
        public User_ChiTiet()
        {
            maDonHang = User_DonHang.IDDon;
            InitializeComponent();
        }
        
        private void User_ChiTiet_Load(object sender, EventArgs e)
        {
            using (QLBH2Entities db = new QLBH2Entities())
            {
                // Lấy danh sách chi tiết đơn hàng từ cơ sở dữ liệu theo mã đơn hàng
                var chiTietDonHang = db.ChiTietDonHang
                    .Where(ct => ct.MaDonHang == maDonHang)
                    .Select(ct => new
                    {
                        ct.MaMonAn,
                        ct.MonAn.TenMonAn, // Giả sử có liên kết với bảng MonAn để lấy tên món ăn
                        ct.SoLuong,
                        ct.GiaBan
                    }).ToList();

                // Gán danh sách vào DataGridView
                dtgChiTietDonHang.DataSource = chiTietDonHang;
            }
        }
    }
}
