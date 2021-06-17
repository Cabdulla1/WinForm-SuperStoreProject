using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperStoreProject
{
    public partial class FrmMenecerGiris : Form
    {
        public FrmMenecerGiris()
        {
            InitializeComponent();
        }

        SqlServerConnection con = new SqlServerConnection();
        
        bool move;
        int mouse_x,mouse_y;

        private void FrmMenecer_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.SetDesktopLocation(MousePosition.X-mouse_x,MousePosition.Y-mouse_y);
            }
        }

        private void FrmMenecer_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_daxilol_Click(object sender, EventArgs e)
        {
            Manager manager = new Manager();
            manager.ManagerNumber = tb_menecerno.Text;
            manager.Password = tb_sifre.Text;

            
            SqlCommand sorgu = new SqlCommand("Select * From Menecer where MenecerNo=@p1 and Sifre = @p2",con.Connect());
            sorgu.Parameters.AddWithValue("@p1",manager.ManagerNumber);
            sorgu.Parameters.AddWithValue("@p2",manager.Password);
            SqlDataReader dr = sorgu.ExecuteReader();

            if (dr.Read())
            {
                manager.Id = int.Parse(dr[0].ToString());
                manager.FirstName = dr[1].ToString();
                manager.LastName = dr[2].ToString();
                manager.PhoneNumber = dr[3].ToString();
                manager.Salary = decimal.Parse(dr[6].ToString());

                FrmMenecerOperations menecerOperations = new FrmMenecerOperations();
                menecerOperations.manager = manager;
                menecerOperations.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Menecer nomresi ve ya sifre yanlisdir.","Xeta");
            }

            con.Connect().Close();
            
        }

        private void pb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pb_az_Click(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager("SuperStoreProject." + "az", Assembly.GetExecutingAssembly());
            tb_menecerno.Text = rm.GetString("tb_kassirno");
            btn_daxilol.Text = rm.GetString("btn_daxilol");
            
        }

        private void pb_eng_Click(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager("SuperStoreProject." + "en", Assembly.GetExecutingAssembly());
            tb_menecerno.Text = rm.GetString("tb_kassirno");
            btn_daxilol.Text = rm.GetString("btn_daxilol");

        }

        private void FrmMenecer_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
    }
}
