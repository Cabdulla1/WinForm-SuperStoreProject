using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Resources;
using System.Reflection;

namespace SuperStoreProject
{
    public partial class FrmGiris : Form
    {
        public string appName= " ";
        
        string appVersion;
        SqlServerConnection con = new SqlServerConnection();
        public FrmGiris()
        {
            InitializeComponent();
        }
        

        bool move;
        int mouse_x, mouse_y;

        
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pb_menecer_Click(object sender, EventArgs e)
        {
            FrmMenecerGiris frmMenecer = new FrmMenecerGiris();
            frmMenecer.Show();
            this.Hide();
        }

        private void pb_satici_Click(object sender, EventArgs e)
        {
            FrmKassirGiris frmKassir = new FrmKassirGiris();
            frmKassir.Show();
            this.Hide();
        }

        WebClient client = new WebClient();
        string downUrl = "http://192.168.0.105/home/SuperStore.exe";
        string fileName;
        private void FrmGiris_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * From ProqramVersiya", con.Connect());
            SqlDataReader dr = command.ExecuteReader();

            if (dr.Read() == true)
            {
                appName = dr[0].ToString();
                fileName = @"C:\Users\cavid" + @"\Desktop\" + appName + "_setup.exe";
                appVersion = dr[1].ToString();
            }

            
            lbl_program_version.Text = appName + " " + appVersion;

            

            
            
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string url = "http://192.168.0.105/home/update.php";
            string data = String.Format("appName={0}&appVersion={1}",appName,appVersion);

            string result = client.UploadString(url,data);

            int currentVersion = Int32.Parse(appVersion.Replace(".",""));
            int newVersion = Int32.Parse(result.Replace(".",""));

            if(currentVersion < newVersion)
            {
                if(MessageBox.Show("Yeni Versiya Mövcuddur.Proqram Yenilənsinmi?","Yeni Versiya",
                    MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    UpdateApplication();
                    UpdateDatabase(result);
                    Environment.Exit(0);
                }
            }
            else
            {

            }
        }

        private void UpdateApplication()
        {
            client.DownloadFileAsync(new Uri(downUrl), fileName);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
        }

        private void UpdateDatabase(string version)
        {
            SqlCommand command = new SqlCommand("Update ProqramVersiya set Versiya = @p1",con.Connect());
            command.Parameters.AddWithValue("@p1",version);
            command.ExecuteNonQuery();
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Yükləmə tamamlandı");
        }

        
        private void pb_az_Click(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager("SuperStoreProject." + "az", Assembly.GetExecutingAssembly());
            lbl_menecer.Text = rm.GetString("lbl_menecer");
            lbl_kassir.Text = rm.GetString("lbl_kassir");
        }

        private void pb_eng_Click(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager("SuperStoreProject." + "en", Assembly.GetExecutingAssembly());
            lbl_menecer.Text = rm.GetString("lbl_menecer");
            lbl_kassir.Text = rm.GetString("lbl_kassir");
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }
    }
}
