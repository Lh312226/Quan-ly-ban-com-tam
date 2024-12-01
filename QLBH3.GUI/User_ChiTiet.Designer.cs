namespace QLBH3.GUI
{
    partial class User_ChiTiet
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
            this.dtgChiTietDonHang = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgChiTietDonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgChiTietDonHang
            // 
            this.dtgChiTietDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgChiTietDonHang.Location = new System.Drawing.Point(102, 111);
            this.dtgChiTietDonHang.Name = "dtgChiTietDonHang";
            this.dtgChiTietDonHang.RowHeadersWidth = 51;
            this.dtgChiTietDonHang.RowTemplate.Height = 24;
            this.dtgChiTietDonHang.Size = new System.Drawing.Size(589, 278);
            this.dtgChiTietDonHang.TabIndex = 0;
            // 
            // User_ChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtgChiTietDonHang);
            this.Name = "User_ChiTiet";
            this.Text = "User_ChiTiet";
            this.Load += new System.EventHandler(this.User_ChiTiet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgChiTietDonHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgChiTietDonHang;
    }
}