namespace QLBH3.GUI
{
    partial class Doanh_thu
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
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.dtgDoanhThuMonAn = new System.Windows.Forms.DataGridView();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDoanhThuMonAn)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTongDoanhThu.Location = new System.Drawing.Point(12, 37);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(248, 36);
            this.lblTongDoanhThu.TabIndex = 0;
            this.lblTongDoanhThu.Text = "Tổng Doanh Thu:";
            // 
            // dtgDoanhThuMonAn
            // 
            this.dtgDoanhThuMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDoanhThuMonAn.Location = new System.Drawing.Point(12, 88);
            this.dtgDoanhThuMonAn.Name = "dtgDoanhThuMonAn";
            this.dtgDoanhThuMonAn.RowHeadersWidth = 51;
            this.dtgDoanhThuMonAn.RowTemplate.Height = 24;
            this.dtgDoanhThuMonAn.Size = new System.Drawing.Size(776, 310);
            this.dtgDoanhThuMonAn.TabIndex = 1;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Exit.Location = new System.Drawing.Point(686, 404);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(112, 34);
            this.btn_Exit.TabIndex = 4;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(541, 48);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(192, 22);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Doanh_thu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.dtgDoanhThuMonAn);
            this.Controls.Add(this.lblTongDoanhThu);
            this.Name = "Doanh_thu";
            this.Text = "Doanh_thu";
            this.Load += new System.EventHandler(this.Doanh_thu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDoanhThuMonAn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.DataGridView dtgDoanhThuMonAn;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}