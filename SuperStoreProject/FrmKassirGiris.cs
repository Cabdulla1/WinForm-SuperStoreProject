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
using System.Net.Mail;
using System.Resources;
using System.Reflection;

namespace SuperStoreProject
{
    public partial class FrmKassirGiris : Form
    {
        public FrmKassirGiris()
        {
            InitializeComponent();
        }

        SqlServerConnection con = new SqlServerConnection();
        bool move;
        int mouse_x, mouse_y;
        private void FrmKassir_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void FrmKassir_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == true)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           // this.Close();
            Environment.Exit(0);
        }

        private void btn_daxilol_Click(object sender, EventArgs e)
        {
            Cashier cashier = new Cashier();
            cashier.CashierNumber = tb_kassirno.Text;
            cashier.Password = tb_sifre.Text;

            
            SqlCommand sorgu = new SqlCommand("Select * From Kassir where KassirNo=@p1 and Sifre=@p2",con.Connect());
            sorgu.Parameters.AddWithValue("@p1",cashier.CashierNumber);
            sorgu.Parameters.AddWithValue("@p2",cashier.Password);
            
            
            SqlDataReader dr = sorgu.ExecuteReader();

            if (dr.Read())
            {
                cashier.Id = int.Parse(dr[0].ToString());
                cashier.FirstName = dr[1].ToString();
                cashier.LastName = dr[2].ToString();
                cashier.PhoneNumber = dr[3].ToString();
                cashier.Salary = decimal.Parse(dr[6].ToString());

                
                FrmKassirSatis frmKassirSatis = new FrmKassirSatis();
                frmKassirSatis.cashier = cashier;
                frmKassirSatis.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kassir Nomresi ve yas sifre yanlisdir");
            }

            con.Connect().Close();
        }

        

        private void lnk_lbl_sifreberpa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSifreBerpa frm = new FrmSifreBerpa();
            this.Hide();
            frm.ShowDialog();

        }

        private void pb_az_Click(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager("SuperStoreProject." + "az", Assembly.GetExecutingAssembly());
            tb_kassirno.Text = rm.GetString("tb_kassirno");
            btn_daxilol.Text = rm.GetString("btn_daxilol");
            lnk_lbl_sifreberpa.Text = rm.GetString("lnk_lbl_sifreberpa");
        }

        private void pb_eng_Click(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager("SuperStoreProject." + "en", Assembly.GetExecutingAssembly());
            tb_kassirno.Text = rm.GetString("tb_kassirno");
            btn_daxilol.Text = rm.GetString("btn_daxilol");
            lnk_lbl_sifreberpa.Text = rm.GetString("lnk_lbl_sifreberpa");
        }

        private void FrmKassir_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
    }
}
