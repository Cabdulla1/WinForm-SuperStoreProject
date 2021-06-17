using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net;
using System.Resources;
using System.Reflection;

namespace SuperStoreProject
{
    public partial class FrmSifreBerpa : Form
    {
        public FrmSifreBerpa()
        {
            InitializeComponent();
        }

        SqlServerConnection con = new SqlServerConnection();

        private bool IsEmail(string email)
        {
            try
            {
                MailAddress ma = new MailAddress(email);
                return true;
            }
            catch 
            {

                return false;
            }
        }

        int userId=0;
        int kod=0;

        private int RandomCode()
        {
            Random rnd = new Random();
            return rnd.Next(100000,999999);
        }

        private bool CheckUser(string email)
        {
            
            SqlCommand com = new SqlCommand("Select * From Kassir where Email = @p1",con.Connect());
            com.Parameters.AddWithValue("@p1",email);
            
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                userId = int.Parse(dr[0].ToString());
                return true;
            }

            con.Connect().Close();
            return false;

            
        }

        private void SaveToDb()
        {
            try
            {
                SqlCommand com = new SqlCommand("insert into Berpa (KassirId,Kod,Tarix) values(@p1,@p2,@p3)", con.Connect());
                com.Parameters.AddWithValue("@p1", userId);
                com.Parameters.AddWithValue("@p2", kod);
                com.Parameters.AddWithValue("@p3", DateTime.Now.AddMinutes(15));
                com.ExecuteNonQuery();

                
            }
            catch 
            {
                MessageBox.Show("Naməlum Xəta");
                
            }
            

        }

        private void btn_berpa_kodu_Click(object sender, EventArgs e)
        {
            if (!IsEmail(tb_email.Text))
            {
                MessageBox.Show("Email Duzgun Deyil");
            }
            else
            {
                if (!CheckUser(tb_email.Text))
                {
                    MessageBox.Show("Istifadeci Tapilmadi");
                }

                else
                {
                    try
                    {
                        MailSender();
                        SaveToDb();
                        MessageBox.Show("Bərpa emaili göndərildi");
                        panel_check_code.Visible = true;
                    }
                    catch
                    {

                        MessageBox.Show("Xəta");
                    }
                }
            }

        }

        private void MailSender()
        {
            kod = RandomCode();
            
            string from = "";
            string pass = "";
            string to = tb_email.Text;


            MailMessage mm = new MailMessage();
            mm.From = new MailAddress(from, "Super Store System");
            mm.Subject = "Şifrə Bərpası";
            mm.To.Add(new MailAddress(to));
            mm.IsBodyHtml = true;
            mm.Body = "<h3> Sizin Bərpa Kodunuz : "+kod+"</h3>";

            NetworkCredential nc = new NetworkCredential();
            nc.UserName = from;
            nc.Password = pass;


            SmtpClient sc = new SmtpClient();
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;
            sc.Port = 587;
            sc.UseDefaultCredentials = false;
            sc.Credentials = nc;
            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            sc.Send(mm);
        }

        private void btn_daxil_et_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("Select Tarix From Berpa Where KassirId=@p1 and Kod = @p2",con.Connect());
            com.Parameters.AddWithValue("@p1",userId);
            com.Parameters.AddWithValue("@p2",tb_kod.Text);

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                if (DateTime.Compare(Convert.ToDateTime(dr[0].ToString()),DateTime.Now) < 0)
                {
                    MessageBox.Show("Kod Yanlisdir","Xeta");
                }
                else
                {
                    panel_berpa.Visible = true;
                }

            }
            else
            {
                MessageBox.Show("Kod Yanlisdir","Xeta");
            }

        }

        private void btn_sifirla_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_yeni_sifre.Text) || String.IsNullOrEmpty(tb_tekrar.Text))
            {
                MessageBox.Show("Sifre Bos Buraxila Bilmez");
            }
            else
            {
                if (tb_yeni_sifre.Text == tb_tekrar.Text)
                {
                    SqlCommand com = new SqlCommand("Update Kassir Set Sifre = @p1 Where Id =@p2",con.Connect());
                    com.Parameters.AddWithValue("@p1",tb_tekrar.Text);
                    com.Parameters.AddWithValue("@p2",userId);
                    com.ExecuteNonQuery();
                    con.Connect().Close();
                    MessageBox.Show("Şifrə Dəyişdirildi");
                }
                else
                {
                    MessageBox.Show("Şifrələr Eyni deyil","Xeta");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        int mouse_x, mouse_y;
        bool move;

        private void panel_top_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void panel_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (move==true)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void pb_az_Click(object sender, EventArgs e)
        {
            
            ResourceManager rm = new ResourceManager("SuperStoreProject." + "az", Assembly.GetExecutingAssembly());
            btn_berpa_kodu.Text = rm.GetString("btn_berpa_kodu");
            btn_daxil_et.Text = rm.GetString("btn_daxil_et");
            lbl_yeni_sifre.Text = rm.GetString("lbl_yeni_sifre");
            lbl_tekrar.Text = rm.GetString("lbl_tekrar");
            btn_sifirla.Text = rm.GetString("btn_sifirla");
        }

        private void pb_eng_Click(object sender, EventArgs e)
        {
            
            ResourceManager rm = new ResourceManager("SuperStoreProject." + "en", Assembly.GetExecutingAssembly());
            btn_berpa_kodu.Text = rm.GetString("btn_berpa_kodu");
            btn_daxil_et.Text = rm.GetString("btn_daxil_et");
            lbl_yeni_sifre.Text = rm.GetString("lbl_yeni_sifre");
            lbl_tekrar.Text = rm.GetString("lbl_tekrar");
            btn_sifirla.Text = rm.GetString("btn_sifirla");
        }

        private void panel_top_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
    }
}
