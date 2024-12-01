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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btn_taiKhoan_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_TK admin_TK = new Admin_TK();
            admin_TK.Show();
        }

        private void btn_monAn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MonAn_Admin mon_Admin = new MonAn_Admin();
            mon_Admin.Show();
        }

        private void btn_donHang_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ad_DonHang ad_DonHang = new Ad_DonHang();
            ad_DonHang.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void btn_doanhThu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Doanh_thu doanh_Thu = new Doanh_thu();
            doanh_Thu.ShowDialog();
        }
    }
}
