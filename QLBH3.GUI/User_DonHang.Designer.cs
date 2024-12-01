namespace QLBH3.GUI
{
    partial class User_DonHang
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
            this.dtgDonHang = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Done = new System.Windows.Forms.Button();
            this.tbn_ChiTiet = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgDonHang
            // 
            this.dtgDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDonHang.Location = new System.Drawing.Point(12, 59);
            this.dtgDonHang.Name = "dtgDonHang";
            this.dtgDonHang.RowHeadersWidth = 51;
            this.dtgDonHang.RowTemplate.Height = 24;
            this.dtgDonHang.Size = new System.Drawing.Size(776, 333);
            this.dtgDonHang.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(278, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đơn hàng của bạn";
            // 
            // btn_Done
            // 
            this.btn_Done.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Done.Location = new System.Drawing.Point(103, 398);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Size = new System.Drawing.Size(114, 40);
            this.btn_Done.TabIndex = 2;
            this.btn_Done.Text = "Đã nhận";
            this.btn_Done.UseVisualStyleBackColor = true;
            this.btn_Done.Click += new System.EventHandler(this.btn_Done_Click);
            // 
            // tbn_ChiTiet
            // 
            this.tbn_ChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbn_ChiTiet.Location = new System.Drawing.Point(251, 398);
            this.tbn_ChiTiet.Name = "tbn_ChiTiet";
            this.tbn_ChiTiet.Size = new System.Drawing.Size(167, 40);
            this.tbn_ChiTiet.TabIndex = 3;
            this.tbn_ChiTiet.Text = "Xem chi tiết";
            this.tbn_ChiTiet.UseVisualStyleBackColor = true;
            this.tbn_ChiTiet.Click += new System.EventHandler(this.tbn_ChiTiet_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Exit.Location = new System.Drawing.Point(674, 398);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(114, 40);
            this.btn_Exit.TabIndex = 4;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // User_DonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.tbn_ChiTiet);
            this.Controls.Add(this.btn_Done);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgDonHang);
            this.Name = "User_DonHang";
            this.Text = "User_DonHang";
            this.Load += new System.EventHandler(this.User_DonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDonHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgDonHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Done;
        private System.Windows.Forms.Button tbn_ChiTiet;
        private System.Windows.Forms.Button btn_Exit;
    }
}