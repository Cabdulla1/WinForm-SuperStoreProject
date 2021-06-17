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
using System.Resources;
using System.Reflection;

namespace SuperStoreProject
{
    public partial class FrmKassirYenile : Form
    {
        public FrmKassirYenile()
        {
            InitializeComponent();
        }

        SqlServerConnection con = new SqlServerConnection();
        Cashier cashier;
        private void FrmKassirYenile_Load(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter("Select * From Kassir",con.Connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_kassir.DataSource = dt;
 
        }

        private void dgv_kassir_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cashier = new Cashier();

            int secilen = dgv_kassir.SelectedCells[0].RowIndex;

            cashier.Id = int.Parse(dgv_kassir.Rows[secilen].Cells[0].Value.ToString());
            cashier.FirstName = dgv_kassir.Rows[secilen].Cells[1].Value.ToString();
            cashier.LastName = dgv_kassir.Rows[secilen].Cells[2].Value.ToString();
            cashier.PhoneNumber = dgv_kassir.Rows[secilen].Cells[3].Value.ToString();
            cashier.Password = dgv_kassir.Rows[secilen].Cells[5].Value.ToString();
            cashier.Salary = decimal.Parse(dgv_kassir.Rows[secilen].Cells[6].Value.ToString());


            lbl_adsoyad_value.Text = cashier.FirstName + " " + cashier.LastName;
            tb_id.Text = cashier.Id.ToString();
            tb_sifre.Text = cashier.Password;
            mskd_telefon.Text = cashier.PhoneNumber;
            tb_maas.Text = cashier.Salary.ToString();

        }

        CashierOperationManager cashierOperation = new CashierOperationManager();
        private void btn_yenile_Click(object sender, EventArgs e)
        {
            cashier.Password = tb_sifre.Text;
            cashier.Salary = decimal.Parse(tb_maas.Text);
            cashier.PhoneNumber = mskd_telefon.Text;

            DialogResult dr = MessageBox.Show("Melumatlar Yenilensinmi?","Diqqet",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                
                cashierOperation.Update(cashier);

                MessageBox.Show("Melumatlar Yenilendi");
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Melumatlar silinsinmi?","Diqqet",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                cashierOperation.Delete(cashier);
                MessageBox.Show("Melumatlar Silindi");
            }
        }

        private void pb_az_Click(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager("SuperStoreProject." + "az", Assembly.GetExecutingAssembly());
            lbl_id.Text = rm.GetString("lbl_id");
            lbl_sifre.Text = rm.GetString("lbl_sifre");
            lbl_telefon.Text = rm.GetString("lbl_telefon");
            lbl_adsoyad.Text = rm.GetString("lbl_adsoyad");
            lbl_maas.Text = rm.GetString("lbl_maas");
            btn_yenile.Text = rm.GetString("btn_yenile");
            btn_sil.Text = rm.GetString("btn_sil");
            gb_kassirler.Text = rm.GetString("gb_kassirler");
        }

        private void pb_eng_Click(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager("SuperStoreProject." + "en", Assembly.GetExecutingAssembly());
            lbl_id.Text = rm.GetString("lbl_id");
            lbl_sifre.Text = rm.GetString("lbl_sifre");
            lbl_telefon.Text = rm.GetString("lbl_telefon");
            lbl_adsoyad.Text = rm.GetString("lbl_adsoyad");
            lbl_maas.Text = rm.GetString("lbl_maas");
            btn_yenile.Text = rm.GetString("btn_yenile");
            btn_sil.Text = rm.GetString("btn_sil");
            gb_kassirler.Text = rm.GetString("gb_kassirler");
        }
    }
}
