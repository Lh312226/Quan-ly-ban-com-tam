namespace QLBH3.GUI
{
    partial class Admin_TK
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.maTaiKhoanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenTaiKhoanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matKhauDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaiTaiKhoanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taiKhoanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLBH2DataSet = new QLBH3.GUI.QLBH2DataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.taiKhoanTableAdapter = new QLBH3.GUI.QLBH2DataSetTableAdapters.TaiKhoanTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_MaTaiKhoan = new System.Windows.Forms.TextBox();
            this.btn_Khoa = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_MoKhoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLBH2DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maTaiKhoanDataGridViewTextBoxColumn,
            this.tenTaiKhoanDataGridViewTextBoxColumn,
            this.matKhauDataGridViewTextBoxColumn,
            this.loaiTaiKhoanDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.taiKhoanBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(428, 348);
            this.dataGridView1.TabIndex = 0;
            // 
            // maTaiKhoanDataGridViewTextBoxColumn
            // 
            this.maTaiKhoanDataGridViewTextBoxColumn.DataPropertyName = "MaTaiKhoan";
            this.maTaiKhoanDataGridViewTextBoxColumn.HeaderText = "MaTaiKhoan";
            this.maTaiKhoanDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.maTaiKhoanDataGridViewTextBoxColumn.Name = "maTaiKhoanDataGridViewTextBoxColumn";
            this.maTaiKhoanDataGridViewTextBoxColumn.ReadOnly = true;
            this.maTaiKhoanDataGridViewTextBoxColumn.Width = 125;
            // 
            // tenTaiKhoanDataGridViewTextBoxColumn
            // 
            this.tenTaiKhoanDataGridViewTextBoxColumn.DataPropertyName = "TenTaiKhoan";
            this.tenTaiKhoanDataGridViewTextBoxColumn.HeaderText = "TenTaiKhoan";
            this.tenTaiKhoanDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tenTaiKhoanDataGridViewTextBoxColumn.Name = "tenTaiKhoanDataGridViewTextBoxColumn";
            this.tenTaiKhoanDataGridViewTextBoxColumn.Width = 125;
            // 
            // matKhauDataGridViewTextBoxColumn
            // 
            this.matKhauDataGridViewTextBoxColumn.DataPropertyName = "MatKhau";
            this.matKhauDataGridViewTextBoxColumn.HeaderText = "MatKhau";
            this.matKhauDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.matKhauDataGridViewTextBoxColumn.Name = "matKhauDataGridViewTextBoxColumn";
            this.matKhauDataGridViewTextBoxColumn.Width = 125;
            // 
            // loaiTaiKhoanDataGridViewTextBoxColumn
            // 
            this.loaiTaiKhoanDataGridViewTextBoxColumn.DataPropertyName = "LoaiTaiKhoan";
            this.loaiTaiKhoanDataGridViewTextBoxColumn.HeaderText = "LoaiTaiKhoan";
            this.loaiTaiKhoanDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.loaiTaiKhoanDataGridViewTextBoxColumn.Name = "loaiTaiKhoanDataGridViewTextBoxColumn";
            this.loaiTaiKhoanDataGridViewTextBoxColumn.Width = 125;
            // 
            // taiKhoanBindingSource
            // 
            this.taiKhoanBindingSource.DataMember = "TaiKhoan";
            this.taiKhoanBindingSource.DataSource = this.qLBH2DataSet;
            // 
            // qLBH2DataSet
            // 
            this.qLBH2DataSet.DataSetName = "QLBH2DataSet";
            this.qLBH2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(86, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách tài khoản";
            // 
            // taiKhoanTableAdapter
            // 
            this.taiKhoanTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(509, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nhập mã tài khoản";
            // 
            // txt_MaTaiKhoan
            // 
            this.txt_MaTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_MaTaiKhoan.Location = new System.Drawing.Point(514, 140);
            this.txt_MaTaiKhoan.Name = "txt_MaTaiKhoan";
            this.txt_MaTaiKhoan.Size = new System.Drawing.Size(274, 38);
            this.txt_MaTaiKhoan.TabIndex = 3;
            // 
            // btn_Khoa
            // 
            this.btn_Khoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Khoa.Location = new System.Drawing.Point(514, 200);
            this.btn_Khoa.Name = "btn_Khoa";
            this.btn_Khoa.Size = new System.Drawing.Size(126, 43);
            this.btn_Khoa.TabIndex = 4;
            this.btn_Khoa.Text = "Khóa";
            this.btn_Khoa.UseVisualStyleBackColor = true;
            this.btn_Khoa.Click += new System.EventHandler(this.btn_Khoa_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Exit.Location = new System.Drawing.Point(685, 395);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(103, 43);
            this.btn_Exit.TabIndex = 5;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_MoKhoa
            // 
            this.btn_MoKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_MoKhoa.Location = new System.Drawing.Point(646, 200);
            this.btn_MoKhoa.Name = "btn_MoKhoa";
            this.btn_MoKhoa.Size = new System.Drawing.Size(142, 43);
            this.btn_MoKhoa.TabIndex = 6;
            this.btn_MoKhoa.Text = "Mở khóa";
            this.btn_MoKhoa.UseVisualStyleBackColor = true;
            this.btn_MoKhoa.Click += new System.EventHandler(this.btn_MoKhoa_Click);
            // 
            // Admin_TK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_MoKhoa);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Khoa);
            this.Controls.Add(this.txt_MaTaiKhoan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Admin_TK";
            this.Text = "Admin_TK";
            this.Load += new System.EventHandler(this.Admin_TK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLBH2DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private QLBH2DataSet qLBH2DataSet;
        private System.Windows.Forms.BindingSource taiKhoanBindingSource;
        private QLBH2DataSetTableAdapters.TaiKhoanTableAdapter taiKhoanTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn maTaiKhoanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenTaiKhoanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matKhauDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loaiTaiKhoanDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_MaTaiKhoan;
        private System.Windows.Forms.Button btn_Khoa;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_MoKhoa;
    }
}