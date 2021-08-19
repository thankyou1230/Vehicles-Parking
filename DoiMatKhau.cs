using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace BaiTap3
{
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Bai_3\Login.mdf;Integrated Security=True;Connect Timeout=30";
        string encryptpass, encryptnewpass, encryptnewpassxn;

        private void txb_mkmoi_TextChanged(object sender, EventArgs e)
        {
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(txb_mkmoi.Text);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                str_md5 += b.ToString("X2");
            }
            encryptnewpass = str_md5;
        }

        private void txb_xnmkmoi_TextChanged(object sender, EventArgs e)
        {
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(txb_xnmkmoi.Text);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                str_md5 += b.ToString("X2");
            }
            encryptnewpassxn = str_md5;
        }

        private void txb_matkhau_TextChanged(object sender, EventArgs e)
        {
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(txb_matkhau.Text);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                str_md5 += b.ToString("X2");
            }
            encryptpass = str_md5;
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            if (txb_matkhau.Text == "" || txb_mkmoi.Text == "" || txb_xnmkmoi.Text == "" || txb_tendn.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin");
                return;
            }
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            string check = "SELECT COUNT(*) FROM account WHERE Username LIKE '" + txb_tendn.Text + "' AND Password LIKE '" + encryptpass + "'";
            SqlCommand dangnhap = new SqlCommand(check, conn);
            if ((int)dangnhap.ExecuteScalar() > 0)
            {
                //check trùng pass hiện tại hay không
                string checksimilar = "SELECT COUNT(*) FROM account WHERE Username LIKE '" + txb_tendn.Text + "' AND Password LIKE '" + encryptnewpass + "'";
                SqlCommand checkexist = new SqlCommand(checksimilar, conn);
                if ((int)checkexist.ExecuteScalar() > 0)
                {
                    MessageBox.Show("Trùng mật khẩu hiện tại");
                }
                else
                {
                    if (encryptnewpass == encryptnewpassxn)
                    {
                        string changepass = "UPDATE account SET Password='" + encryptnewpass + "' WHERE Username LIKE'" + txb_tendn.Text + "'";
                        SqlCommand change = new SqlCommand(changepass, conn);
                        change.ExecuteNonQuery();
                        conn.Close();
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("Thay đổi mật khẩu thành công");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Xác nhận lại không trùng khớp");
                }
            }
            else
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            conn.Close();
        }
    }
}
