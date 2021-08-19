namespace BaiTap3
{
    partial class DangNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_tendn = new System.Windows.Forms.TextBox();
            this.txb_matkhau = new System.Windows.Forms.TextBox();
            this.btn_dangnhap = new System.Windows.Forms.Button();
            this.btn_doimk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(28, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(28, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // txb_tendn
            // 
            this.txb_tendn.Location = new System.Drawing.Point(142, 22);
            this.txb_tendn.Name = "txb_tendn";
            this.txb_tendn.Size = new System.Drawing.Size(168, 20);
            this.txb_tendn.TabIndex = 2;
            this.txb_tendn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_tendn_KeyDown);
            // 
            // txb_matkhau
            // 
            this.txb_matkhau.Location = new System.Drawing.Point(142, 57);
            this.txb_matkhau.Name = "txb_matkhau";
            this.txb_matkhau.PasswordChar = '*';
            this.txb_matkhau.Size = new System.Drawing.Size(168, 20);
            this.txb_matkhau.TabIndex = 3;
            this.txb_matkhau.TextChanged += new System.EventHandler(this.txb_matkhau_TextChanged);
            this.txb_matkhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_matkhau_KeyDown);
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_dangnhap.Location = new System.Drawing.Point(61, 101);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(81, 23);
            this.btn_dangnhap.TabIndex = 4;
            this.btn_dangnhap.Text = "Đăng nhập";
            this.btn_dangnhap.UseVisualStyleBackColor = true;
            this.btn_dangnhap.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_doimk
            // 
            this.btn_doimk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_doimk.Location = new System.Drawing.Point(205, 101);
            this.btn_doimk.Name = "btn_doimk";
            this.btn_doimk.Size = new System.Drawing.Size(82, 23);
            this.btn_doimk.TabIndex = 5;
            this.btn_doimk.Text = "Đổi mật khẩu";
            this.btn_doimk.UseVisualStyleBackColor = true;
            this.btn_doimk.Click += new System.EventHandler(this.btn_doimk_Click);
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LPR_Laptrinhvb.Properties.Resources._1_X6MPg_YZX9GomWXjaYjIRw;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(359, 140);
            this.Controls.Add(this.btn_doimk);
            this.Controls.Add(this.btn_dangnhap);
            this.Controls.Add(this.txb_matkhau);
            this.Controls.Add(this.txb_tendn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DangNhap";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.DangNhap_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DangNhap_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_tendn;
        private System.Windows.Forms.TextBox txb_matkhau;
        private System.Windows.Forms.Button btn_dangnhap;
        private System.Windows.Forms.Button btn_doimk;
    }
}