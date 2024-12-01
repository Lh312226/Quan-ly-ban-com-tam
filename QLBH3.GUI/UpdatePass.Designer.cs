namespace QLBH3.GUI
{
    partial class UpdatePass
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_oldPass = new System.Windows.Forms.TextBox();
            this.txt_newPass = new System.Windows.Forms.TextBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.txt_comfirmPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(37, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhập mật khẩu hiện tại";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(277, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đổi mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(37, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nhập mật khẩu mới";
            // 
            // txt_oldPass
            // 
            this.txt_oldPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_oldPass.Location = new System.Drawing.Point(283, 140);
            this.txt_oldPass.Name = "txt_oldPass";
            this.txt_oldPass.PasswordChar = '*';
            this.txt_oldPass.Size = new System.Drawing.Size(326, 30);
            this.txt_oldPass.TabIndex = 4;
            // 
            // txt_newPass
            // 
            this.txt_newPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_newPass.Location = new System.Drawing.Point(283, 195);
            this.txt_newPass.Name = "txt_newPass";
            this.txt_newPass.PasswordChar = '*';
            this.txt_newPass.Size = new System.Drawing.Size(326, 30);
            this.txt_newPass.TabIndex = 5;
            // 
            // btn_update
            // 
            this.btn_update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_update.Location = new System.Drawing.Point(320, 314);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(153, 43);
            this.btn_update.TabIndex = 7;
            this.btn_update.Text = "Đổi mật khẩu";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_Exit.Location = new System.Drawing.Point(498, 312);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(111, 45);
            this.btn_Exit.TabIndex = 8;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // txt_comfirmPass
            // 
            this.txt_comfirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_comfirmPass.Location = new System.Drawing.Point(283, 250);
            this.txt_comfirmPass.Name = "txt_comfirmPass";
            this.txt_comfirmPass.PasswordChar = '*';
            this.txt_comfirmPass.Size = new System.Drawing.Size(326, 30);
            this.txt_comfirmPass.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(37, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Xác nhận mật khẩu mới";
            // 
            // UpdatePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_comfirmPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.txt_newPass);
            this.Controls.Add(this.txt_oldPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "UpdatePass";
            this.Text = "UpdatePass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_oldPass;
        private System.Windows.Forms.TextBox txt_newPass;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.TextBox txt_comfirmPass;
        private System.Windows.Forms.Label label4;
    }
}