
namespace BaiTap3
{
    partial class DoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoiMatKhau));
            this.txb_matkhau = new System.Windows.Forms.TextBox();
            this.txb_tendn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_mkmoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_xnmkmoi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_xacnhan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txb_matkhau
            // 
            this.txb_matkhau.Location = new System.Drawing.Point(146, 56);
            this.txb_matkhau.Name = "txb_matkhau";
            this.txb_matkhau.PasswordChar = '*';
            this.txb_matkhau.Size = new System.Drawing.Size(148, 20);
            this.txb_matkhau.TabIndex = 7;
            this.txb_matkhau.TextChanged += new System.EventHandler(this.txb_matkhau_TextChanged);
            // 
            // txb_tendn
            // 
            this.txb_tendn.Location = new System.Drawing.Point(146, 21);
            this.txb_tendn.Name = "txb_tendn";
            this.txb_tendn.Size = new System.Drawing.Size(148, 20);
            this.txb_tendn.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mật khẩu:";
            // 
            // txb_mkmoi
            // 
            this.txb_mkmoi.Location = new System.Drawing.Point(146, 89);
            this.txb_mkmoi.Name = "txb_mkmoi";
            this.txb_mkmoi.PasswordChar = '*';
            this.txb_mkmoi.Size = new System.Drawing.Size(148, 20);
            this.txb_mkmoi.TabIndex = 9;
            this.txb_mkmoi.TextChanged += new System.EventHandler(this.txb_mkmoi_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mật khẩu mới";
            // 
            // txb_xnmkmoi
            // 
            this.txb_xnmkmoi.Location = new System.Drawing.Point(146, 124);
            this.txb_xnmkmoi.Name = "txb_xnmkmoi";
            this.txb_xnmkmoi.PasswordChar = '*';
            this.txb_xnmkmoi.Size = new System.Drawing.Size(148, 20);
            this.txb_xnmkmoi.TabIndex = 11;
            this.txb_xnmkmoi.TextChanged += new System.EventHandler(this.txb_xnmkmoi_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Xác nhận mật khẩu mới";
            // 
            // btn_xacnhan
            // 
            this.btn_xacnhan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_xacnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_xacnhan.Location = new System.Drawing.Point(100, 169);
            this.btn_xacnhan.Name = "btn_xacnhan";
            this.btn_xacnhan.Size = new System.Drawing.Size(99, 32);
            this.btn_xacnhan.TabIndex = 12;
            this.btn_xacnhan.Text = "Xác nhận";
            this.btn_xacnhan.UseVisualStyleBackColor = true;
            this.btn_xacnhan.Click += new System.EventHandler(this.btn_xacnhan_Click);
            // 
            // DoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 213);
            this.Controls.Add(this.btn_xacnhan);
            this.Controls.Add(this.txb_xnmkmoi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_mkmoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txb_matkhau);
            this.Controls.Add(this.txb_tendn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txb_matkhau;
        private System.Windows.Forms.TextBox txb_tendn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_mkmoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_xnmkmoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_xacnhan;
    }
}