using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.ML;
using Emgu.CV.ML.Structure;
using Emgu.CV.UI;
using Emgu.Util;
using System.Diagnostics;
using Emgu.CV.CvEnum;
using System.IO;
using System.Linq;
using tesseract;
using System.Collections;
using LaptrinhVBLibs;
using System.Data;
using System.Data.SqlClient;
using System.Speech.Synthesis;
using System.Security.Cryptography;

namespace BaiTap3
{
    public partial class Frm_QuanLiGiuXe : Form
    {

        public Frm_QuanLiGiuXe()
        {
            InitializeComponent();
            Point pos = new Point(0, 27);
            panel_giaodienchinh.Location = pos;
            panel_giaodienchinh.Width = 834;
            panel_giaodienchinh.Height = 547;
            panel_xetrongbai.Location = pos;
            panel_xetrongbai.Width = 834;
            panel_xetrongbai.Height = 547;
            panel_log.Location = pos;
            panel_log.Width = 834;
            panel_log.Height = 547;
            panel_xeguithang.Location = pos;
            panel_xeguithang.Width = 834;
            panel_xeguithang.Height = 547;
            panel_philog.Location = pos;
            panel_philog.Width = 834;
            panel_philog.Height = 547;
            panel_quanlitk.Location = pos;
            panel_quanlitk.Width = 834;
            panel_quanlitk.Height = 547;
            dgv_xetrongbai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_xeguithang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_log.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_philog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_account.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public Frm_QuanLiGiuXe(string a="user")
        {
            InitializeComponent();
            Point pos = new Point(0, 27);
            panel_giaodienchinh.Location = pos;
            panel_giaodienchinh.Width = 834;
            panel_giaodienchinh.Height = 547;
            panel_xetrongbai.Location = pos;
            panel_xetrongbai.Width = 834;
            panel_xetrongbai.Height = 547;
            panel_log.Location = pos;
            panel_log.Width = 834;
            panel_log.Height = 547;
            panel_xeguithang.Location = pos;
            panel_xeguithang.Width = 834;
            panel_xeguithang.Height = 547;
            panel_philog.Location = pos;
            panel_philog.Width = 834;
            panel_philog.Height = 547;
            panel_quanlitk.Location = pos;
            panel_quanlitk.Width = 834;
            panel_quanlitk.Height = 547;
            dgv_xetrongbai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_xeguithang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_log.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_philog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LichsuToolStripMenuItem.Visible = false;
            lichsuthutienToolStripMenuItem.Visible = false;
            quảnLýTàiKhoảnToolStripMenuItem.Visible = false;
            dgv_account.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #region khai báo (declare)
        List<Image<Bgr, Byte>> PlateImagesList = new List<Image<Bgr, byte>>();
        List<string> PlateTextList = new List<string>();
        List<Rectangle> listRect = new List<Rectangle>();
        PictureBox[] box = new PictureBox[12];

        public TesseractProcessor full_tesseract = null;
        public TesseractProcessor ch_tesseract = null;
        public TesseractProcessor num_tesseract = null;
        private string m_path = Application.StartupPath + @"\data\";
        private List<string> lstimages = new List<string>();
        private const string m_lang = "eng";
        private string _Caption = "Thông báo";
        public string startupPath;
        private Capture capture;
        private bool takeSnapshot = true;
        string path;
        Image<Bgr, byte> capturedImage;
        int trangthai;
        int phithang = 50000;
        int phivanglai = 2000;
        string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Bai_3\DTB.mdf;Integrated Security=True;Connect Timeout=30";
        string s1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Bai_3\Login.mdf;Integrated Security=True;Connect Timeout=30";

        #endregion
        
        private void ReSetCSDL()
        {
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            string del1 = "DELETE FROM tb_LichSuThuPhi";
            string del2 = "DELETE FROM tb_LichSuGuiXe";
            string del3 = "DELETE FROM tb_XeGuiThang";
            string del4 = "DELETE FROM tb_XeTrongBai";
            SqlCommand sqlcom1 = new SqlCommand(del1, conn);
            SqlCommand sqlcom2 = new SqlCommand(del2, conn);
            SqlCommand sqlcom3 = new SqlCommand(del3, conn);
            SqlCommand sqlcom4 = new SqlCommand(del4, conn);
            sqlcom1.ExecuteNonQuery();
            sqlcom2.ExecuteNonQuery();
            sqlcom3.ExecuteNonQuery();
            sqlcom4.ExecuteNonQuery();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'loginDataSet1.account' table. You can move, or remove it, as needed.
            this.accountTableAdapter1.Fill(this.loginDataSet1.account);
            // TODO: This line of code loads data into the 'loginDataSet.account' table. You can move, or remove it, as needed.
            this.accountTableAdapter.Fill(this.loginDataSet.account);
            // TODO: This line of code loads data into the 'dTBDataSet3.tb_XeGuiThang' table. You can move, or remove it, as needed.
            this.tb_XeGuiThangTableAdapter.Fill(this.dTBDataSet3.tb_XeGuiThang);
            // TODO: This line of code loads data into the 'dTBDataSet2.tb_LichSuThuPhi' table. You can move, or remove it, as needed.
            this.tb_LichSuThuPhiTableAdapter.Fill(this.dTBDataSet2.tb_LichSuThuPhi);
            // TODO: This line of code loads data into the 'dTBDataSet1.tb_LichSuGuiXe' table. You can move, or remove it, as needed.
            this.tb_LichSuGuiXeTableAdapter.Fill(this.dTBDataSet1.tb_LichSuGuiXe);
            // TODO: This line of code loads data into the 'dTBDataSet.tb_XeTrongBai' table. You can move, or remove it, as needed.
            this.tb_XeTrongBaiTableAdapter.Fill(this.dTBDataSet.tb_XeTrongBai);
            // TODO: This line of code loads data into the 'doAnCsharpDataSet1.tbl_Xetrongbai' table. You can move, or remove it, as needed.

            full_tesseract = new TesseractProcessor();
            bool succeed = full_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Lỗi thư viện Tesseract", _Caption);
                Application.Exit();
            }
            full_tesseract.SetVariable("tessedit_char_whitelist", "ACDFHKLMNPRSTVXY1234567890.").ToString();

            ch_tesseract = new TesseractProcessor();
            succeed = ch_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Lỗi thư viện Tesseract", _Caption);
                Application.Exit();
            }
            ch_tesseract.SetVariable("tessedit_char_whitelist", "ACDEFHKLMNPRSTUVXY.").ToString();

            num_tesseract = new TesseractProcessor();
            succeed = num_tesseract.Init(m_path, m_lang, 3);
            if (!succeed)
            {
                MessageBox.Show("Lỗi thư viện Tesseract", _Caption);
                Application.Exit();
            }
            num_tesseract.SetVariable("tessedit_char_whitelist", "1234567890.").ToString();

            System.Environment.CurrentDirectory = System.IO.Path.GetFullPath(m_path);
            for (int i = 0; i < box.Length; i++)
            {
                box[i] = new PictureBox();
            }
            string folder = Application.StartupPath + "\\ImageTest";
            foreach (string fileName in Directory.GetFiles(folder, "*.bmp", SearchOption.TopDirectoryOnly))
            {
                lstimages.Add(Path.GetFullPath(fileName));
            }
            foreach (string fileName in Directory.GetFiles(folder, "*.jpg", SearchOption.TopDirectoryOnly))
            {
                lstimages.Add(Path.GetFullPath(fileName));
            }
            #region capture
            // Make sure we only initialize webcam capture if the capture element is still null
            if (capture == null)
            {
                try
                {
                    // Start grabbing data, change the number if you want to use another camera
                    capture = new Capture(0);
                }
                catch (NullReferenceException excpt)
                {
                    // No camera has been found
                    MessageBox.Show(excpt.Message);
                }
            }

            // When the capture is initialized, start processing the images in the PorcessFrame method
            if (capture != null)
                Application.Idle += ProcessFrame;
            #endregion
            DemXeTrongBai();
            this.Text = "Quản lí bãi giữ xe máy - Giao diện chính";
            panel_giaodienchinh.Visible = true;
            panel_xetrongbai.Visible = false;
            panel_log.Visible = false;
            panel_xeguithang.Visible = false;
            panel_philog.Visible = false;
            panel_quanlitk.Visible = false;
            updqualitk();
        }
        private void updqualitk()
        {
            SqlConnection conn = new SqlConnection(s1);
            conn.Open();
            string upd = "SELECT Username,[Last Login],Type FROM account";
            SqlCommand load = new SqlCommand(upd, conn);
            SqlDataAdapter sqlda = new SqlDataAdapter(load);
            DataTable sqldat = new DataTable();
            sqlda.Fill(sqldat);
            dgv_account.DataSource = sqldat;
            conn.Close();
        }
        public void ProcessImage(string urlImage)
        {
            PlateImagesList.Clear();
            PlateTextList.Clear();
            panel1.Controls.Clear();
            Bitmap img = new Bitmap(urlImage);
            ptb_.Image = img;
            ptb_.Update();
            //Class được xây dựng sẵn trong thư viện Laptrinhvb để tìm vị trí biến số
            clsBSoft.FindLicensePlate(img, ptb_, imageBox1, PlateImagesList, panel1);
        }

        private bool Check(string doituong,DataGridView src,int col)
        {
            foreach (DataGridViewRow row in src.Rows)
            {
                
                if (row.Cells[col].Value == null)
                    return false;
                if (doituong.Equals(row.Cells[col].Value.ToString(),StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private string GetElement(string doituong, DataGridView src, int col,int Elementcol)
        {
            foreach (DataGridViewRow row in src.Rows)
            {
                string s="";
                if (row.Cells[col].Value == null)
                    return null;
                else
                if (doituong.Equals(row.Cells[col].Value.ToString(), StringComparison.CurrentCultureIgnoreCase))
                {
                    s = row.Cells[Elementcol].Value.ToString();
                    return s ;
                }
            }
            return null;
        }
        private void speak(string text)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = @"D:\Bai_3\" + text+".wav";
            player.Play();
        }
        private void kiemtrano()
        {
            string ten = "SELECT [TT Phi Thang] FROM tb_XeGuiThang WHERE [Bien so DK] LIKE '" + txb_bienso.Text + "'";
            SqlConnection conect = new SqlConnection(s);
            conect.Open();
            SqlCommand scn = new SqlCommand(ten, conect);
            if ((string)scn.ExecuteScalar() == "c")
            {
                txb_phi.Text = "Chua tra phi thang";
            }
            else txb_phi.Text = "Da tra phi thang";
            conect.Close();
        }
        private void btn_nhandien_Click(object sender, EventArgs e)
        {
            #region clear giao diện
            btn_guixe.Text = "Gứi vào|Lấy ra";
            txb_chuxe.Text = "";
            txb_tgra.Text = "";
            txb_tgvao.Text = "";
            txb_phi.Text = "";
            ptb_anhxevao.Image = null;
            ptb_anhxera.Image = null;
            btn_guixe.Enabled = false;
            #endregion
            // Lưu ảnh
            string them = DateTime.Now.ToString("yyyy_MM_dd.HH_mm_ss");
            path = @"D:\Bai_3\camera\" + them + ".jpg";
            capturedImage.Save(path);
            // Hiển thị và nhận diện
            startupPath = path;
            #region nhandien
            //gọi hàm tìm vị trí biển số
            ProcessImage(startupPath);
            //Nếu tìm được- bắt đầu nhận dạng ký tự trên biển số
            if (PlateImagesList.Count != 0)
            {
                Image<Bgr, byte> src = new Image<Bgr, byte>(PlateImagesList[0].ToBitmap());
                Bitmap grayframe;
                Bitmap color;
                int c = clsBSoft.IdentifyContours(src.ToBitmap(), 50, false, out grayframe, out color, out listRect);
                ptb_.Image = color;
                Image<Gray, byte> dst = new Image<Gray, byte>(grayframe);
                grayframe = dst.ToBitmap();
                string zz = "";

                // lọc và sắp xếp số trên biển số xe
                List<Bitmap> bmp = new List<Bitmap>();
                List<int> erode = new List<int>();
                List<Rectangle> up = new List<Rectangle>();
                List<Rectangle> dow = new List<Rectangle>();
                int up_y = 0, dow_y = 0;
                bool flag_up = false;

                int di = 0;

                if (listRect == null) return;

                for (int i = 0; i < listRect.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(listRect[i], grayframe.PixelFormat);
                    int cou = 0;
                    full_tesseract.Clear();
                    full_tesseract.ClearAdaptiveClassifier();
                    string temp = full_tesseract.Apply(ch);
                    while (temp.Length > 3)
                    {
                        Image<Gray, byte> temp2 = new Image<Gray, byte>(ch);
                        temp2 = temp2.Erode(2);
                        ch = temp2.ToBitmap();
                        full_tesseract.Clear();
                        full_tesseract.ClearAdaptiveClassifier();
                        temp = full_tesseract.Apply(ch);
                        cou++;
                        if (cou > 10)
                        {
                            listRect.RemoveAt(i);
                            i--;
                            di = 0;
                            break;
                        }
                        di = cou;
                    }
                }

                for (int i = 0; i < listRect.Count; i++)
                {
                    for (int j = i; j < listRect.Count; j++)
                    {
                        if (listRect[i].Y > listRect[j].Y + 100)
                        {
                            flag_up = true;
                            up_y = listRect[j].Y;
                            dow_y = listRect[i].Y;
                            break;
                        }
                        else if (listRect[j].Y > listRect[i].Y + 100)
                        {
                            flag_up = true;
                            up_y = listRect[i].Y;
                            dow_y = listRect[j].Y;
                            break;
                        }
                        if (flag_up == true) break;
                    }
                }

                for (int i = 0; i < listRect.Count; i++)
                {
                    if (listRect[i].Y < up_y + 50 && listRect[i].Y > up_y - 50)
                    {
                        up.Add(listRect[i]);
                    }
                    else if (listRect[i].Y < dow_y + 50 && listRect[i].Y > dow_y - 50)
                    {
                        dow.Add(listRect[i]);
                    }
                }

                if (flag_up == false) dow = listRect;

                for (int i = 0; i < up.Count; i++)
                {
                    for (int j = i; j < up.Count; j++)
                    {
                        if (up[i].X > up[j].X)
                        {
                            Rectangle w = up[i];
                            up[i] = up[j];
                            up[j] = w;
                        }
                    }
                }
                for (int i = 0; i < dow.Count; i++)
                {
                    for (int j = i; j < dow.Count; j++)
                    {
                        if (dow[i].X > dow[j].X)
                        {
                            Rectangle w = dow[i];
                            dow[i] = dow[j];
                            dow[j] = w;
                        }
                    }
                }

                int x = 0;
                int c_x = 0;

                for (int i = 0; i < up.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(up[i], grayframe.PixelFormat);
                    Bitmap o = ch;
                    string temp;
                    if (i < 2)
                    {
                        temp = clsBSoft.Ocr(ch, false, full_tesseract, num_tesseract, ch_tesseract, true); // nhan dien so
                    }
                    else
                    {
                        temp = clsBSoft.Ocr(ch, false, full_tesseract, num_tesseract, ch_tesseract, false); // nhan dien chu
                    }

                    zz += temp;
                    box[i].Location = new Point(x + i * 50, 0);
                    box[i].Size = new Size(50, 100);
                    box[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    box[i].Image = ch;
                    panel1.Controls.Add(box[i]);
                    c_x++;
                }
                for (int i = 0; i < dow.Count; i++)
                {
                    Bitmap ch = grayframe.Clone(dow[i], grayframe.PixelFormat);
                    string temp = clsBSoft.Ocr(ch, false, full_tesseract, num_tesseract, ch_tesseract, true); // nhan dien so

                    zz += temp;
                    box[i + c_x].Location = new Point(x + i * 50, 100);
                    box[i + c_x].Size = new Size(50, 100);
                    box[i + c_x].SizeMode = PictureBoxSizeMode.StretchImage;
                    box[i + c_x].Image = ch;
                    panel1.Controls.Add(box[i + c_x]);
                    txb_bienso.Text = zz;
                }

            }
            #endregion
            // Đối chiếu csdl
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            string upd = "SELECT COUNT(*) FROM tb_XeTrongBai WHERE [Bien so] LIKE '" + txb_bienso.Text + "'";
            SqlCommand sqlcom = new SqlCommand(upd, conn);
            int trongbai = (int)sqlcom.ExecuteScalar();
            upd = "SELECT COUNT(*) FROM tb_XeGuiThang WHERE [Bien so DK] LIKE '" + txb_bienso.Text + "'";
            sqlcom = new SqlCommand(upd, conn);
            int coguithang = (int)sqlcom.ExecuteScalar();
            conn.Close();
            #region Đối chiếu csdl
            int a = txb_bienso.Text.Length;
            if (txb_bienso.Text.Length <8)
            {
                MessageBox.Show("Xin mời xác nhận lại biển số");
                txb_bienso.Text = "";
                return;
            }
            if (trongbai > 0)
            {
                btn_guixe.Text = "Lấy ra";
                btn_guixe.Enabled = true;
                string layten = "SELECT Ten FROM tb_XeTrongBai WHERE [Bien so] LIKE '" + txb_bienso.Text + "'";
                string laytg = "SELECT [Thoi gian vao] FROM tb_XeTrongBai WHERE [Bien so] LIKE '" + txb_bienso.Text + "'";
                string layanh = "SELECT [Anh chup] FROM tb_XeTrongBai WHERE [Bien so] LIKE '" + txb_bienso.Text + "'";
                SqlConnection c = new SqlConnection(s);
                c.Open();
                SqlCommand sc = new SqlCommand(layten, c);
                txb_chuxe.Text = (string)sc.ExecuteScalar();
                sc = new SqlCommand(laytg, c);
                txb_tgvao.Text = (string)sc.ExecuteScalar();
                txb_tgra.Text = DateTime.Now.ToString("G");
                sc = new SqlCommand(layanh, c);
                ptb_anhxevao.Image = Image.FromFile((string)sc.ExecuteScalar());
                ptb_anhxera.Image = Image.FromFile(path);
                c.Close();
                trangthai = -1;
                if (coguithang > 0)
                {

                    kiemtrano();

                }
                else
                {
                    txb_phi.Text = phivanglai.ToString();
                }
            }
            else
            {
                btn_guixe.Text = "Gửi vào";
                btn_guixe.Enabled = true;
                if (coguithang > 0)
                {
                    string ten = "SELECT [Ho ten] FROM tb_XeGuiThang WHERE [Bien so DK] LIKE '" + txb_bienso.Text + "'";
                    SqlConnection conect = new SqlConnection(s);
                    conect.Open();
                    SqlCommand scn = new SqlCommand(ten, conect);
                    txb_chuxe.Text = (string)scn.ExecuteScalar();
                    conect.Close();
                    txb_tgvao.Text = DateTime.Now.ToString("G");
                    ptb_anhxevao.Image = Image.FromFile(path);
                    trangthai = 1;
                    kiemtrano();
                }
                else
                {
                    txb_chuxe.Text = "Khach vang lai";
                    txb_tgvao.Text = DateTime.Now.ToString("G");
                    ptb_anhxevao.Image = Image.FromFile(path);
                    trangthai = 1;
                    txb_phi.Text = "tra tien khi lay xe";
                }
            }
            #endregion
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            // Get the newest webcam frame
            capturedImage = capture.QueryFrame();
            // Show it in your PictureBox. If you don't want to convert to Bitmap you should use an ImageBox (which is an EmguCV element)
            ptb_camera.Image = capturedImage.ToBitmap();

            // If the button was clicked indicating you want a snapshot, save the image

        }

        private void btn_guixe_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            if (trangthai==-1)
            {
                //Xoa khoi bãi gửi xe
                string xoa = "DELETE FROM tb_XeTrongBai WHERE [Bien so] LIKE'" + txb_biensodk.Text + "';";
                SqlCommand comm = new SqlCommand(xoa, conn);
                comm.ExecuteNonQuery();
                //them vao lich su gui xe
                string xoa1 = "INSERT INTO tb_LichSuGuiXe VALUES('" + txb_chuxe.Text + "','" + txb_biensodk.Text + "','ra','" + txb_tgra.Text + "','" + path + "')";
                comm = new SqlCommand(xoa1, conn);
                comm.ExecuteNonQuery();
                //them vao lich su thu phi
                if (txb_chuxe.Text == "Khach vang lai")
                {
                    string xoa2 = "INSERT INTO tb_LichSuThuPhi VALUES('" + txb_chuxe.Text + "','" + txb_biensodk.Text+ "','" + txb_tgra.Text + "','" + phivanglai.ToString() + "')";
                    comm = new SqlCommand(xoa2, conn);
                    comm.ExecuteNonQuery();
                }    
                speak("ra");
            }
            else if (trangthai == 1)
            {
                //Them xe vao bai
                string them= "INSERT INTO tb_XeTrongBai VALUES('" +txb_biensodk.Text+"','"+ txb_chuxe.Text + "','"+ txb_tgvao.Text + "','" + path + "')";
                SqlCommand cmd = new SqlCommand(them,conn);
                cmd.ExecuteNonQuery();
                //Them vao lich su gui xe
                string them1 = "INSERT INTO tb_LichSuGuiXe VALUES('" + txb_chuxe.Text + "','"  + txb_biensodk.Text + "','vao','" + txb_tgvao.Text + "','" + path + "')";
                cmd = new SqlCommand(them1, conn);
                cmd.ExecuteNonQuery();
                speak("vao");
            }
            #region Cập nhật lại
            string upd = "SELECT * FROM tb_XeTrongBai";
            SqlCommand sqlcom = new SqlCommand(upd, conn);
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcom);
            DataTable sqldat = new DataTable();
            sqlda.Fill(sqldat);
            dgv_xetrongbai.DataSource = sqldat;
            
            upd = "SELECT * FROM tb_LichSuGuiXe";
            sqlcom = new SqlCommand(upd, conn);
            sqlda = new SqlDataAdapter(sqlcom);
            sqldat = new DataTable();
            sqlda.Fill(sqldat);
            dgv_log.DataSource = sqldat;
            
            upd = "SELECT * FROM tb_LichSuThuPhi";
            sqlcom = new SqlCommand(upd, conn);
            sqlda = new SqlDataAdapter(sqlcom);
            sqldat = new DataTable();
            sqlda.Fill(sqldat);
            dgv_philog.DataSource = sqldat;
            #endregion
            #region clear giao diện
            btn_guixe.Text = "Gứi vào|Lấy ra";
            txb_chuxe.Text = "";
            txb_biensodk.Text = "";
            txb_tgra.Text = "";
            txb_tgvao.Text = "";
            txb_phi.Text = "";
            txb_bienso.Text = "";
            ptb_anhxevao.Image = null;
            ptb_anhxera.Image = null;
            btn_guixe.Enabled = false;
            #endregion
        }

        private void giaoDiệnChínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Quản lí bãi giữ xe máy - Giao diện chính";
            panel_giaodienchinh.Visible = true;
            panel_xetrongbai.Visible = false;
            panel_log.Visible = false;
            panel_xeguithang.Visible = false;
            panel_philog.Visible = false;
            panel_quanlitk.Visible = false;
        }

        private void XetrongbaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Quản lí bãi giữ xe máy - Xe trong bãi";
            panel_giaodienchinh.Visible = false;
            panel_xetrongbai.Visible = true;
            panel_log.Visible = false;
            panel_xeguithang.Visible = false;
            panel_philog.Visible = false;
            panel_quanlitk.Visible = false;
        }
        
        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangKyGuiThang newf = new DangKyGuiThang();
            if(newf.ShowDialog()==DialogResult.OK)
            {
                SqlConnection ketnoi = new SqlConnection(s);
                ketnoi.Open();
                string check = "SELECT COUNT(*) FROM tb_XeGuiThang WHERE [Bien so DK] LIKE '" + newf.bienso + "'";
                SqlCommand comm1 = new SqlCommand(check, ketnoi);
                int tontai = (int)comm1.ExecuteScalar();
                if (tontai > 0)
                    MessageBox.Show("Xe đã đăng ký rồi");
                else
                {
                    string quer = "INSERT INTO tb_XeGuiThang VALUES('" + newf.ten + "','" + newf.diachi + "','" + newf.sdt + "','" + newf.bienso + "','" + newf.loaixe + "','" + newf.giayphep + "','" + "c')";
                    SqlCommand comm = new SqlCommand(quer, ketnoi);
                    comm.ExecuteNonQuery();
                    string upd = "SELECT * FROM tb_XeGuiThang";
                    SqlCommand sqlcom = new SqlCommand(upd, ketnoi);
                    SqlDataAdapter sqlda = new SqlDataAdapter(sqlcom);
                    DataTable sqldat = new DataTable();
                    sqlda.Fill(sqldat);
                    dgv_xeguithang.DataSource = sqldat;
                    MessageBox.Show("Thêm thành công!");
                }
                ketnoi.Close();
            }
        }

        private void LichsuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Quản lí bãi giữ xe máy - Log";
            panel_giaodienchinh.Visible = false;
            panel_xetrongbai.Visible = false;
            panel_log.Visible = true;
            panel_xeguithang.Visible = false;
            panel_philog.Visible = false;
            panel_quanlitk.Visible = false;
        }

        private void txb_bienso_TextChanged(object sender, EventArgs e)
        {
            txb_biensodk.Text = txb_bienso.Text;
        }

        private void XeGuiThangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Quản lí bãi giữ xe máy - Xe gửi tháng";
            panel_giaodienchinh.Visible = false;
            panel_xetrongbai.Visible = false;
            panel_log.Visible = false;
            panel_xeguithang.Visible = true;
            panel_philog.Visible = false;
            panel_quanlitk.Visible = false;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_thucong_Click(object sender, EventArgs e)
        {
            #region clear giao diện
            btn_guixe.Text = "Gứi vào|Lấy ra";
            txb_chuxe.Text = "";
            txb_tgra.Text = "";
            txb_tgvao.Text = "";
            txb_phi.Text = "";
            ptb_anhxevao.Image = null;
            ptb_anhxera.Image = null;
            btn_guixe.Enabled = false;
            #endregion
            // Lưu ảnh
            string them = DateTime.Now.ToString("yyyy_MM_dd.HH_mm_ss");
            path = @"D:\Bai_3\camera\" + them + ".jpg";
            capturedImage.Save(path);
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            string upd = "SELECT COUNT(*) FROM tb_XeTrongBai WHERE [Bien so] LIKE '" + txb_bienso.Text + "'";
            SqlCommand sqlcom = new SqlCommand(upd, conn);
            int trongbai = (int)sqlcom.ExecuteScalar();
            upd = "SELECT COUNT(*) FROM tb_XeGuiThang WHERE [Bien so DK] LIKE '" + txb_bienso.Text + "'";
            sqlcom = new SqlCommand(upd, conn);
            int coguithang = (int)sqlcom.ExecuteScalar();
            conn.Close();
            #region Đối chiếu csdl
            if (txb_bienso.Text.Length != 8 && txb_bienso.Text.Length != 9)
            {
                MessageBox.Show("Xin mời xác nhận lại biển số");
                txb_bienso.Text = "";
                return;
            }
            if (trongbai>0)
            {
                btn_guixe.Text = "Lấy ra";
                btn_guixe.Enabled = true;
                string layten = "SELECT Ten FROM tb_XeTrongBai WHERE [Bien so] LIKE '" + txb_bienso.Text + "'";
                string laytg = "SELECT [Thoi gian vao] FROM tb_XeTrongBai WHERE [Bien so] LIKE '" + txb_bienso.Text + "'";
                string layanh = "SELECT [Anh chup] FROM tb_XeTrongBai WHERE [Bien so] LIKE '" + txb_bienso.Text + "'";
                SqlConnection c = new SqlConnection(s);
                c.Open();
                SqlCommand sc = new SqlCommand(layten, c);
                txb_chuxe.Text = (string)sc.ExecuteScalar();
                sc = new SqlCommand(laytg, c);
                txb_tgvao.Text = (string)sc.ExecuteScalar();
                txb_tgra.Text = DateTime.Now.ToString("G");
                sc = new SqlCommand(layanh, c);
                ptb_anhxevao.Image = Image.FromFile((string)sc.ExecuteScalar());
                ptb_anhxera.Image = Image.FromFile(path);
                c.Close();
                trangthai = -1;
                if (coguithang>0)
                {
                    
                    kiemtrano();

                }
                else
                {
                    txb_phi.Text = phivanglai.ToString();
                }
            }
            else
            {
                btn_guixe.Text = "Gửi vào";
                btn_guixe.Enabled = true;
                if (coguithang>0)
                {
                    string ten = "SELECT [Ho ten] FROM tb_XeGuiThang WHERE [Bien so DK] LIKE '" + txb_bienso.Text + "'";
                    SqlConnection conect = new SqlConnection(s);
                    conect.Open();
                    SqlCommand scn = new SqlCommand(ten, conect);
                    txb_chuxe.Text = (string)scn.ExecuteScalar();
                    conect.Close();
                    txb_tgvao.Text = DateTime.Now.ToString("G");
                    ptb_anhxevao.Image = Image.FromFile(path);
                    trangthai = 1;
                    kiemtrano();
                }
                else
                {
                    txb_chuxe.Text = "Khach vang lai";
                    txb_tgvao.Text = DateTime.Now.ToString("G");
                    ptb_anhxevao.Image = Image.FromFile(path);
                    trangthai = 1;
                    txb_phi.Text = "tra tien khi lay xe";
                }
            }
            #endregion
        }

        private void txb_timxetrongbai_TextChanged(object sender, EventArgs e)
        {
            string upd;
            if(txb_timxetrongbai.Text=="")
                upd= "SELECT * FROM tb_XeTrongBai";
            else
                upd = "SELECT * FROM tb_XeTrongBai WHERE [Bien so] LIKE '%" + txb_timxetrongbai.Text + "%'";
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            SqlCommand sqlcom = new SqlCommand(upd, conn);
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcom);
            DataTable sqldat = new DataTable();
            sqlda.Fill(sqldat);
            dgv_xetrongbai.DataSource = sqldat;
            conn.Close();
        }

        private void txb_timkiemlog_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            string upd="";
            if (cmb_timkiemlog.Text=="Bien so")
            {
                #region search
                if (txb_timkiemlog.Text == "")
                    upd = "SELECT * FROM tb_LichSuGuiXe";
                else
                    upd = "SELECT * FROM tb_LichSuGuiXe WHERE [Bien so DK] LIKE '%" + txb_timkiemlog.Text + "%'";
                #endregion
            }
            if (cmb_timkiemlog.Text == "Ten khach")
            {
                #region search
                if (txb_timkiemlog.Text == "")
                    upd = "SELECT * FROM tb_LichSuGuiXe";
                else
                    upd = "SELECT * FROM tb_LichSuGuiXe WHERE [Ten Khach] LIKE '%" + txb_timkiemlog.Text + "%'";
                #endregion
            }
            if (cmb_timkiemlog.Text == "Trang Thai")
            {
                if (txb_timkiemlog.Text == "")
                    upd = "SELECT * FROM tb_LichSuGuiXe";
                else
                    upd = "SELECT * FROM tb_LichSuGuiXe WHERE [Vao ra] LIKE '%" + txb_timkiemlog.Text + "%'";
            }
            if (cmb_timkiemlog.Text == "Thoi gian")
            {
                if (txb_timkiemlog.Text == "")
                    upd = "SELECT * FROM tb_LichSuGuiXe";
                else
                    upd = "SELECT * FROM tb_LichSuGuiXe WHERE [Thoi gian] LIKE '%" + txb_timkiemlog.Text + "%'";
            }
            SqlCommand sqlcom= new SqlCommand(upd, conn);
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcom);
            DataTable sqldat = new DataTable();
            sqlda.Fill(sqldat);
            dgv_log.DataSource = sqldat;
            conn.Close();
        }

        private void txb_timxeguithang_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            string upd = "";
            if (cmb_timxeguithang.Text == "Bien so DK")
            {
                if (txb_timxeguithang.Text == "")
                    upd = "SELECT * FROM tb_XeGuiThang";
                else
                    upd = "SELECT * FROM tb_XeGuiThang WHERE [Bien so DK] LIKE '%" + txb_timxeguithang.Text + "%'";
            }
            if (cmb_timxeguithang.Text == "Ten Chu Xe")
            {
                if (txb_timxeguithang.Text == "")
                    upd = "SELECT * FROM tb_XeGuiThang";
                else
                    upd = "SELECT * FROM tb_XeGuiThang WHERE [Ho ten] LIKE '%" + txb_timxeguithang.Text + "%'";
            }
            if (cmb_timxeguithang.Text == "Loai Xe")
            {
                if (txb_timxeguithang.Text == "")
                    upd = "SELECT * FROM tb_XeGuiThang";
                else
                    upd = "SELECT * FROM tb_XeGuiThang WHERE [Loai xe] LIKE '%" + txb_timxeguithang.Text + "%'";
            }
            if (cmb_timxeguithang.Text == "Trang Thai Thanh Toan")
            {
                if (txb_timxeguithang.Text == "")
                    upd = "SELECT * FROM tb_XeGuiThang";
                else
                    upd = "SELECT * FROM tb_XeGuiThang WHERE [TT Phi Thang] LIKE '%" + txb_timxeguithang.Text + "%'";
            }
            if (cmb_timxeguithang.Text == "So dien thoai")
            {
                if (txb_timxeguithang.Text == "")
                    upd = "SELECT * FROM tb_XeGuiThang";
                else
                    upd = "SELECT * FROM tb_XeGuiThang WHERE [SDT] LIKE '%" + txb_timxeguithang.Text + "%'";
            }
            if (cmb_timxeguithang.Text == "So gpdk xe")
            {
                if (txb_timxeguithang.Text == "")
                    upd = "SELECT * FROM tb_XeGuiThang";
                else
                    upd = "SELECT * FROM tb_XeGuiThang WHERE [So GPDK] LIKE '%" + txb_timxeguithang.Text + "%'";
            }
            SqlCommand sqlcom = new SqlCommand(upd, conn);
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcom);
            DataTable sqldat = new DataTable();
            sqlda.Fill(sqldat);
            dgv_xeguithang.DataSource = sqldat;
            conn.Close();
        }

        private void btn_dongiten_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            string check = "SELECT [Ho ten] FROM tb_XeGuiThang WHERE [Bien so DK] LIKE '" + txb_dongtien.Text + "'";
            SqlCommand sqlcom = new SqlCommand(check, conn);
            string ten = (string)sqlcom.ExecuteScalar();
            if (ten != "")
            {
                string upd = "UPDATE tb_XeGuiThang SET [TT Phi Thang]='r' WHERE [Bien so DK] LIKE '" + txb_dongtien.Text + "'";
                sqlcom = new SqlCommand(upd, conn);
                sqlcom.ExecuteNonQuery();
                string themtien = "INSERT INTO tb_LichSuThuPhi VALUES('" + ten + "','" + txb_dongtien.Text + "','" + DateTime.Now.ToString("G") + "','" + phithang.ToString() + "')";
                sqlcom = new SqlCommand(themtien, conn);
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("Đóng tiền xong");
            }
            else
                MessageBox.Show("Khong tim thay xe");
            string capnhat = "SELECT * FROM tb_XeGuiThang";
            SqlCommand sql = new SqlCommand(capnhat, conn);
            SqlDataAdapter sqlda = new SqlDataAdapter(sql);
            DataTable sqldat = new DataTable();
            sqlda.Fill(sqldat);
            dgv_xeguithang.DataSource = sqldat;
            string capnhat1 = "SELECT * FROM tb_LichSuThuPhi";
            SqlCommand sql1 = new SqlCommand(capnhat1, conn);
            SqlDataAdapter sqlda1 = new SqlDataAdapter(sql1);
            DataTable sqldat1 = new DataTable();
            sqlda1.Fill(sqldat1);
            dgv_philog.DataSource = sqldat1;
            conn.Close();
            txb_dongtien.Text = "";
        }

        private void lịchSửThuTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Quản lí bãi giữ xe máy - Lịch sử thu phí";
            panel_giaodienchinh.Visible = false;
            panel_xetrongbai.Visible = false;
            panel_log.Visible = false;
            panel_xeguithang.Visible = false;
            panel_philog.Visible = true;
            panel_quanlitk.Visible = false;
        }

        private void dgv_xetrongbai_DataSourceChanged(object sender, EventArgs e)
        {
            DemXeTrongBai();
        }
        private void DemXeTrongBai()
        {
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            string upd = "SELECT COUNT(*) FROM tb_XeTrongBai";
            SqlCommand sqlcom = new SqlCommand(upd, conn);
            int trongbai = (int)sqlcom.ExecuteScalar();
            lb_soxe.Text = "Số xe đang trong bãi: " + trongbai;
            conn.Close();
        }

        private void txb_timphilog_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(s);
            conn.Open();
            string upd = "";
            if (cmb_timphilog.Text == "Bien so")
            {
                #region search
                if (txb_timphilog.Text == "")
                    upd = "SELECT * FROM tb_LichSuThuPhi";
                else
                    upd = "SELECT * FROM tb_LichSuThuPhi WHERE [Bien so DK] LIKE '%" + txb_timphilog.Text + "%'";
                #endregion
            }
            if (cmb_timphilog.Text == "Ten Khach")
            {
                #region search
                if (txb_timphilog.Text == "")
                    upd = "SELECT * FROM tb_LichThuPhi";
                else
                    upd = "SELECT * FROM tb_LichSuThuPhi WHERE [Ten Khach] LIKE '%" + txb_timphilog.Text + "%'";
                #endregion
            }
            if (cmb_timphilog.Text == "Thoi gian")
            {
                if (txb_timphilog.Text == "")
                    upd = "SELECT * FROM tb_LichSuThuPhi";
                else
                    upd = "SELECT * FROM tb_LichSuThuPhi WHERE [Thoi gian] LIKE '%" + txb_timphilog.Text + "%'";
            }
            SqlCommand sqlcom = new SqlCommand(upd, conn);
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcom);
            DataTable sqldat = new DataTable();
            sqlda.Fill(sqldat);
            dgv_philog.DataSource = sqldat;
            conn.Close();
        }

        private void btn_xoaxe_Click(object sender, EventArgs e)
        {
            string bienso = dgv_xeguithang.SelectedRows[0].Cells[3].Value.ToString();
            if (bienso != null)
            {
                SqlConnection conn = new SqlConnection(s);
                conn.Open();
                string upd = "DELETE FROM tb_XeGuiThang WHERE [Bien so DK] LIKE '" + bienso + "'";
                SqlCommand sqlcom = new SqlCommand(upd, conn);
                sqlcom.ExecuteNonQuery();
                string capnhat = "SELECT * FROM tb_XeGuiThang";
                sqlcom = new SqlCommand(capnhat, conn);
                SqlDataAdapter sqlda = new SqlDataAdapter(sqlcom);
                DataTable sqldat = new DataTable();
                sqlda.Fill(sqldat);
                dgv_xeguithang.DataSource = sqldat;
                conn.Close();
                MessageBox.Show("Xoa xe thành công");
            }
            else
                MessageBox.Show("Xin chọn một dong để xóa");
        }

        private void dgv_xetrongbai_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_xetrongbai.CurrentCell.ColumnIndex.Equals(3) && e.RowIndex != -1)
                if (dgv_xetrongbai.CurrentCell != null && dgv_xetrongbai.CurrentCell.Value != null)
                {
                    ImageViewer a = new ImageViewer();
                    a.Image =  new Image<Bgr, byte>(dgv_xetrongbai.CurrentCell.Value.ToString());
                    a.Text = dgv_xetrongbai.CurrentCell.Value.ToString();
                    a.Show();
                }
        }

        private void dgv_log_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_xetrongbai.CurrentCell.ColumnIndex.Equals(3) && e.RowIndex != -1)
                if (dgv_log.CurrentCell != null && dgv_log.CurrentCell.Value != null)
                {
                    ImageViewer a = new ImageViewer();
                    a.Image = new Image<Bgr, byte>(dgv_log.CurrentCell.Value.ToString());
                    a.Text = dgv_log.CurrentCell.Value.ToString();
                    a.Show();
                }
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Quản lí bãi giữ xe máy - Quản lí tài khoản";
            panel_giaodienchinh.Visible = false;
            panel_xetrongbai.Visible = false;
            panel_log.Visible = false;
            panel_xeguithang.Visible = false;
            panel_philog.Visible = false;
            panel_quanlitk.Visible = true;
        }

        private void Frm_QuanLiGiuXe_FormClosing(object sender, FormClosingEventArgs e)
        {
            capture.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(s1);
            conn.Open();
            string upd = "";
            if (txb_timtk.Text == "")
                upd = "SELECT Username,[Last Login] FROM account";
            else
                upd = "SELECT Username,[Last Login] FROM account WHERE Username LIKE '%" + txb_timtk.Text + "%'";
            SqlCommand sqlcom = new SqlCommand(upd, conn);
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlcom);
            DataTable sqldat = new DataTable();
            sqlda.Fill(sqldat);
            dgv_account.DataSource = sqldat;
            conn.Close();
        }

        private string Tomd5(string a)
        {
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(a);

            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            mang = my_md5.ComputeHash(mang);

            foreach (byte b in mang)
            {
                str_md5 += b.ToString("X2");
            }
            return str_md5;
        }

        private void btn_captk_Click(object sender, EventArgs e)
        {
            if(txb_tkcap.Text=="" || txb_mkcap.Text==""||txb_xnmkcap.Text=="")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin");
                return;
            }
            string tk = txb_tkcap.Text;
            string mk = Tomd5(txb_mkcap.Text);
            string xnmk = Tomd5(txb_xnmkcap.Text);
            SqlConnection conn = new SqlConnection(s1);
            conn.Open();
            string check = "SELECT COUNT(*) FROM account WHERE Username LIKE '" + tk + "'";
            SqlCommand dangnhap = new SqlCommand(check, conn);
            if ((int)dangnhap.ExecuteScalar() <= 0)
            {
                    if (mk == xnmk)
                    {
                    string changepass = "INSERT INTO account VALUES('" + tk + "','" + mk + "','0',' ')";
                        SqlCommand change = new SqlCommand(changepass, conn);
                        change.ExecuteNonQuery();
                        MessageBox.Show("Cấp tài khoản thành công");
                    }
                    else
                        MessageBox.Show("Xác nhận lại không trùng khớp");
            }
            else
                MessageBox.Show("Tài khoản đã tồn tại");
            string upd = "SELECT Username,[Last Login] FROM account";
            SqlCommand load = new SqlCommand(upd, conn);
            SqlDataAdapter sqlda = new SqlDataAdapter(load);
            DataTable sqldat = new DataTable();
            sqlda.Fill(sqldat);
            dgv_account.DataSource = sqldat;
            conn.Close();
        }

        private void btn_thuhoitk_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(s1);
            conn.Open();
            string username = dgv_account.CurrentRow.Cells[0].Value.ToString();
            if(username=="admin")
            {
                MessageBox.Show("Không thể xóa tài khoản admin");
                return;
            }
            string acess = "DELETE FROM account WHERE Username LIKE '" + username + "'";
            SqlCommand del = new SqlCommand(acess, conn);
            del.ExecuteNonQuery();
            string upd = "SELECT Username,[Last Login] FROM account";
            SqlCommand load = new SqlCommand(upd, conn);
            SqlDataAdapter sqlda = new SqlDataAdapter(load);
            DataTable sqldat = new DataTable();
            sqlda.Fill(sqldat);
            dgv_account.DataSource = sqldat;
            conn.Close();
        }

        private void btn_resetmk_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(s1);
            conn.Open();
            string username = dgv_account.CurrentRow.Cells[0].Value.ToString();
            if (username == "Admin")
            {
                MessageBox.Show("Không thể reset mật khẩu tài khoản admin");
                return;
            }
            string acess = "UPDATE account SET Password='"+Tomd5("1")+"' WHERE Username LIKE '" + username + "'";
            SqlCommand del = new SqlCommand(acess, conn);
            del.ExecuteNonQuery();
            MessageBox.Show("Mật khẩu đã được đặt về 1");
            conn.Close();
        }
    }

}
