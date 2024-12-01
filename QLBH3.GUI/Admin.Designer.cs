namespace QLBH3.GUI
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_taiKhoan = new System.Windows.Forms.Button();
            this.btn_doanhThu = new System.Windows.Forms.Button();
            this.btn_monAn = new System.Windows.Forms.Button();
            this.btn_donHang = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_taiKhoan
            // 
            this.btn_taiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_taiKhoan.Location = new System.Drawing.Point(60, 36);
            this.btn_taiKhoan.Name = "btn_taiKhoan";
            this.btn_taiKhoan.Size = new System.Drawing.Size(306, 199);
            this.btn_taiKhoan.TabIndex = 0;
            this.btn_taiKhoan.Text = "Tài khoản";
            this.btn_taiKhoan.UseVisualStyleBackColor = true;
            this.btn_taiKhoan.Click += new System.EventHandler(this.btn_taiKhoan_Click);
            // 
            // btn_doanhThu
            // 
            this.btn_doanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_doanhThu.Location = new System.Drawing.Point(60, 263);
            this.btn_doanhThu.Name = "btn_doanhThu";
            this.btn_doanhThu.Size = new System.Drawing.Size(306, 199);
            this.btn_doanhThu.TabIndex = 1;
            this.btn_doanhThu.Text = "Doanh thu";
            this.btn_doanhThu.UseVisualStyleBackColor = true;
            this.btn_doanhThu.Click += new System.EventHandler(this.btn_doanhThu_Click);
            // 
            // btn_monAn
            // 
            this.btn_monAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_monAn.Location = new System.Drawing.Point(451, 36);
            this.btn_monAn.Name = "btn_monAn";
            this.btn_monAn.Size = new System.Drawing.Size(306, 199);
            this.btn_monAn.TabIndex = 1;
            this.btn_monAn.Text = "Món ăn";
            this.btn_monAn.UseVisualStyleBackColor = true;
            this.btn_monAn.Click += new System.EventHandler(this.btn_monAn_Click);
            // 
            // btn_donHang
            // 
            this.btn_donHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_donHang.Location = new System.Drawing.Point(451, 263);
            this.btn_donHang.Name = "btn_donHang";
            this.btn_donHang.Size = new System.Drawing.Size(306, 199);
            this.btn_donHang.TabIndex = 2;
            this.btn_donHang.Text = "Đơn hàng";
            this.btn_donHang.UseVisualStyleBackColor = true;
            this.btn_donHang.Click += new System.EventHandler(this.btn_donHang_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 477);
            this.Controls.Add(this.btn_donHang);
            this.Controls.Add(this.btn_monAn);
            this.Controls.Add(this.btn_doanhThu);
            this.Controls.Add(this.btn_taiKhoan);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Admin";
            this.Text = "Admin";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_taiKhoan;
        private System.Windows.Forms.Button btn_doanhThu;
        private System.Windows.Forms.Button btn_monAn;
        private System.Windows.Forms.Button btn_donHang;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
    }
}