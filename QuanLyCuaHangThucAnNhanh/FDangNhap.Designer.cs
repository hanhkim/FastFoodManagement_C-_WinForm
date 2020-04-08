namespace QuanLyCuaHangThucAnNhanh
{
    partial class flogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radioNhanVien = new System.Windows.Forms.RadioButton();
            this.radioQuanLy = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.cbx1 = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.lbPass = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txbID = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 272);
            this.panel1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.radioNhanVien);
            this.panel5.Controls.Add(this.radioQuanLy);
            this.panel5.Location = new System.Drawing.Point(223, 138);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(415, 40);
            this.panel5.TabIndex = 4;
            // 
            // radioNhanVien
            // 
            this.radioNhanVien.AutoSize = true;
            this.radioNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.radioNhanVien.Location = new System.Drawing.Point(218, 11);
            this.radioNhanVien.Name = "radioNhanVien";
            this.radioNhanVien.Size = new System.Drawing.Size(107, 24);
            this.radioNhanVien.TabIndex = 1;
            this.radioNhanVien.TabStop = true;
            this.radioNhanVien.Text = "Nhân Viên";
            this.radioNhanVien.UseVisualStyleBackColor = true;
            // 
            // radioQuanLy
            // 
            this.radioQuanLy.AutoSize = true;
            this.radioQuanLy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.radioQuanLy.Location = new System.Drawing.Point(18, 11);
            this.radioQuanLy.Name = "radioQuanLy";
            this.radioQuanLy.Size = new System.Drawing.Size(93, 24);
            this.radioQuanLy.TabIndex = 0;
            this.radioQuanLy.TabStop = true;
            this.radioQuanLy.Text = "Quản Lý";
            this.radioQuanLy.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnexit);
            this.panel4.Controls.Add(this.btnLogin);
            this.panel4.Controls.Add(this.cbx1);
            this.panel4.Location = new System.Drawing.Point(13, 184);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(625, 73);
            this.panel4.TabIndex = 3;
            // 
            // btnexit
            // 
            this.btnexit.Font = new System.Drawing.Font("Arial", 12F);
            this.btnexit.Location = new System.Drawing.Point(428, 12);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(184, 37);
            this.btnexit.TabIndex = 2;
            this.btnexit.Text = "Thoát";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click_1);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Arial", 12F);
            this.btnLogin.Location = new System.Drawing.Point(226, 12);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(184, 37);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // cbx1
            // 
            this.cbx1.AutoSize = true;
            this.cbx1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbx1.Location = new System.Drawing.Point(20, 27);
            this.cbx1.Name = "cbx1";
            this.cbx1.Size = new System.Drawing.Size(160, 23);
            this.cbx1.TabIndex = 0;
            this.cbx1.Text = "Hiển thị password";
            this.cbx1.UseVisualStyleBackColor = true;
            this.cbx1.CheckedChanged += new System.EventHandler(this.cbx1_CheckedChanged_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtpass);
            this.panel3.Controls.Add(this.lbPass);
            this.panel3.Location = new System.Drawing.Point(13, 87);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(625, 52);
            this.panel3.TabIndex = 2;
            // 
            // txtpass
            // 
            this.txtpass.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtpass.Location = new System.Drawing.Point(220, 14);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(392, 30);
            this.txtpass.TabIndex = 1;
            this.txtpass.UseSystemPasswordChar = true;
            // 
            // lbPass
            // 
            this.lbPass.AutoSize = true;
            this.lbPass.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbPass.Location = new System.Drawing.Point(25, 12);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(97, 24);
            this.lbPass.TabIndex = 0;
            this.lbPass.Text = "Mật khẩu";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txbID);
            this.panel2.Controls.Add(this.lbID);
            this.panel2.Location = new System.Drawing.Point(13, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(625, 66);
            this.panel2.TabIndex = 0;
            // 
            // txbID
            // 
            this.txbID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txbID.Location = new System.Drawing.Point(220, 14);
            this.txbID.Name = "txbID";
            this.txbID.Size = new System.Drawing.Size(392, 30);
            this.txbID.TabIndex = 1;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbID.Location = new System.Drawing.Point(25, 12);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(152, 24);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "Tên đăng nhập";
            // 
            // flogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(677, 295);
            this.Controls.Add(this.panel1);
            this.Name = "flogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.flogin_FormClosing_1);
            this.Load += new System.EventHandler(this.flogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox cbx1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.Label lbPass;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbID;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton radioNhanVien;
        private System.Windows.Forms.RadioButton radioQuanLy;
    }
}

