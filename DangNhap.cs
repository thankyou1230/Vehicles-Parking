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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        string encryptpass;
        string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Bai_3\Login.mdf;Integrated Security=True;Connect Timeout=30";
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            string check = "SELECT COUNT(*) FROM account WHERE Username LIKE '" + txb_tendn.Text + "' AND Password LIKE '" + encryptpass + "'";
            SqlCommand dangnhap = new SqlCommand(check, conn);
            if ((int)dangnhap.ExecuteScalar() > 0)
            {
                string checkrole = "SELECT Type FROM account WHERE Username LIKE '" + txb_tendn.Text + "'";
                SqlCommand dangnhaprole = new SqlCommand(checkrole, conn);
                if (dangnhaprole.ExecuteScalar().ToString() == "1")
                {
                    string lastlogin = "UPDATE account SET [Last Login]='" + DateTime.Now.ToString("G") + "' WHERE Username LIKE '" + txb_tendn.Text + "'";
                    SqlCommand updll = new SqlCommand(lastlogin, conn);
                    updll.ExecuteNonQuery();
                    Frm_QuanLiGiuXe softw = new Frm_QuanLiGiuXe();
                    this.Visible = false;
                    if (softw.ShowDialog() == DialogResult.Cancel)
                    {
                        this.Close();
                        txb_matkhau.Text = "";
                        txb_tendn.Text = "";
                    }
                }
                else if ((string)dangnhaprole.ExecuteScalar() == "0")
                {
                    string lastlogin = "UPDATE account SET [Last Login]='" + DateTime.Now.ToString("G") + "' WHERE Username LIKE '" + txb_tendn.Text + "'";
                    SqlCommand updll = new SqlCommand(lastlogin, conn);
                    updll.ExecuteNonQuery();
                    Frm_QuanLiGiuXe softw = new Frm_QuanLiGiuXe("user");
                    this.Visible = false;
                    if (softw.ShowDialog() == DialogResult.Cancel)
                    {
                        this.Close();
                        txb_matkhau.Text = "";
                        txb_tendn.Text = "";
                    }
                }
            }
            else
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            conn.Close();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

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

        private void txb_matkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                SqlConnection conn = new SqlConnection(s);
                conn.Open();
                string check = "SELECT COUNT(*) FROM account WHERE Username LIKE '" + txb_tendn.Text + "' AND Password LIKE '" + encryptpass + "'";
                SqlCommand dangnhap = new SqlCommand(check, conn);
                if ((int)dangnhap.ExecuteScalar() > 0)
                {
                    string checkrole = "SELECT Type FROM account WHERE Username LIKE '" + txb_tendn.Text + "'";
                    SqlCommand dangnhaprole = new SqlCommand(checkrole, conn);
                    if (dangnhaprole.ExecuteScalar().ToString() == "1")
                    {
                        string lastlogin = "UPDATE account SET [Last Login]='" + DateTime.Now.ToString("G") + "' WHERE Username LIKE '" + txb_tendn.Text + "'";
                        SqlCommand updll = new SqlCommand(lastlogin, conn);
                        updll.ExecuteNonQuery();
                        Frm_QuanLiGiuXe softw = new Frm_QuanLiGiuXe();
                        this.Visible = false;
                        if (softw.ShowDialog() == DialogResult.Cancel)
                        {
                            this.Close();
                            txb_matkhau.Text = "";
                            txb_tendn.Text = "";
                        }
                    }
                    else if ((string)dangnhaprole.ExecuteScalar() == "0")
                    {
                        string lastlogin = "UPDATE account SET [Last Login]='" + DateTime.Now.ToString("G") + "' WHERE Username LIKE '" + txb_tendn.Text + "'";
                        SqlCommand updll = new SqlCommand(lastlogin, conn);
                        updll.ExecuteNonQuery();
                        Frm_QuanLiGiuXe softw = new Frm_QuanLiGiuXe("user");
                        this.Visible = false;
                        if (softw.ShowDialog() == DialogResult.Cancel)
                        {
                            this.Close();
                            txb_matkhau.Text = "";
                            txb_tendn.Text = "";
                        }
                    }
                }
                else
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                conn.Close();
            }
        }

        private void txb_tendn_KeyDown(object sender, KeyEventArgs e)
        {

            {
                if (e.KeyData == Keys.Enter)
                {
                    SqlConnection conn = new SqlConnection(s);
                    conn.Open();
                    string check = "SELECT COUNT(*) FROM account WHERE Username LIKE '" + txb_tendn.Text + "' AND Password LIKE '" + encryptpass + "'";
                    SqlCommand dangnhap = new SqlCommand(check, conn);
                    if ((int)dangnhap.ExecuteScalar() > 0)
                    {
                        string checkrole = "SELECT Type FROM account WHERE Username LIKE '" + txb_tendn.Text + "'";
                        SqlCommand dangnhaprole = new SqlCommand(checkrole, conn);
                        if (dangnhaprole.ExecuteScalar().ToString() == "1")
                        {
                            string lastlogin = "UPDATE account SET [Last Login]='" + DateTime.Now.ToString("G") + "' WHERE Username LIKE '" + txb_tendn.Text + "'";
                            SqlCommand updll = new SqlCommand(lastlogin, conn);
                            updll.ExecuteNonQuery();
                            Frm_QuanLiGiuXe softw = new Frm_QuanLiGiuXe();
                            this.Visible = false;
                            if (softw.ShowDialog() == DialogResult.Cancel)
                            {
                                this.Close();
                                txb_matkhau.Text = "";
                                txb_tendn.Text = "";
                            }
                        }
                        else if ((string)dangnhaprole.ExecuteScalar() == "0")
                        {
                            string lastlogin = "UPDATE account SET [Last Login]='" + DateTime.Now.ToString("G") + "' WHERE Username LIKE '" + txb_tendn.Text + "'";
                            SqlCommand updll = new SqlCommand(lastlogin, conn);
                            updll.ExecuteNonQuery();
                            Frm_QuanLiGiuXe softw = new Frm_QuanLiGiuXe("user");
                            this.Visible = false;
                            if (softw.ShowDialog() == DialogResult.Cancel)
                            {
                                this.Close();
                                txb_matkhau.Text = "";
                                txb_tendn.Text = "";
                            }
                        }
                    }
                    else
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                    conn.Close();
                }
            }
        }

        private void DangNhap_KeyDown(object sender, KeyEventArgs e)
        {

            {
                if (e.KeyData == Keys.Enter)
                {
                    SqlConnection conn = new SqlConnection(s);
                    conn.Open();
                    string check = "SELECT COUNT(*) FROM account WHERE Username LIKE '" + txb_tendn.Text + "' AND Password LIKE '" + encryptpass + "'";
                    SqlCommand dangnhap = new SqlCommand(check, conn);
                    if ((int)dangnhap.ExecuteScalar() > 0)
                    {
                        string checkrole = "SELECT Type FROM account WHERE Username LIKE '" + txb_tendn.Text + "'";
                        SqlCommand dangnhaprole = new SqlCommand(checkrole, conn);
                        if (dangnhaprole.ExecuteScalar().ToString() == "1")
                        {
                            string lastlogin = "UPDATE account SET [Last Login]='" + DateTime.Now.ToString("G") + "' WHERE Username LIKE '" + txb_tendn.Text + "'";
                            SqlCommand updll = new SqlCommand(lastlogin, conn);
                            updll.ExecuteNonQuery();
                            Frm_QuanLiGiuXe softw = new Frm_QuanLiGiuXe();
                            this.Visible = false;
                            if (softw.ShowDialog() == DialogResult.Cancel)
                            {
                                this.Close();
                                txb_matkhau.Text = "";
                                txb_tendn.Text = "";
                            }
                        }
                        else if ((string)dangnhaprole.ExecuteScalar() == "0")
                        {
                            string lastlogin = "UPDATE account SET [Last Login]='" + DateTime.Now.ToString("G") + "' WHERE Username LIKE '" + txb_tendn.Text + "'";
                            SqlCommand updll = new SqlCommand(lastlogin, conn);
                            updll.ExecuteNonQuery();
                            Frm_QuanLiGiuXe softw = new Frm_QuanLiGiuXe("user");
                            this.Visible = false;
                            if (softw.ShowDialog() == DialogResult.Cancel)
                            {
                                this.Close();
                                txb_matkhau.Text = "";
                                txb_tendn.Text = "";
                            }
                        }
                    }
                    else
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                    conn.Close();
                }
            }
        }

        private void btn_doimk_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            dmk.ShowDialog();
        }
    }
}
