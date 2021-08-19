using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaiTap3
{
    public partial class DangKyGuiThang : Form
    {
        public string ten, diachi, sdt, bienso, loaixe, giayphep;
        public DangKyGuiThang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txb_ten.Text == "" || txb_sdt.Text == "" || txb_loaixe.Text == "" || txb_giayphep.Text == "" || txb_diachi.Text == "" || txb_bienso.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
            else
            {
                ten = txb_ten.Text;
                diachi = txb_diachi.Text;
                sdt = txb_sdt.Text;
                bienso = txb_bienso.Text;
                loaixe = txb_loaixe.Text;
                giayphep = txb_giayphep.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
