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
    public partial class FrmSaticiYenile : Form
    {
        public FrmSaticiYenile()
        {
            InitializeComponent();
        }

        SqlServerConnection con = new SqlServerConnection();

        Seller seller;
        private void dgv_satici_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seller  = new Seller();

            int secilen = dgv_satici.SelectedCells[0].RowIndex;

            seller.Id = int.Parse(dgv_satici.Rows[secilen].Cells[0].Value.ToString());
            seller.FirstName = dgv_satici.Rows[secilen].Cells[1].Value.ToString();
            seller.LastName = dgv_satici.Rows[secilen].Cells[2].Value.ToString();
            seller.Salary = decimal.Parse(dgv_satici.Rows[secilen].Cells[5].Value.ToString());
            seller.PhoneNumber = dgv_satici.Rows[secilen].Cells[3].Value.ToString();

            lbl_adsoyad_value.Text = seller.FirstName + " " + seller.LastName;
            tb_id.Text = seller.Id.ToString();
            tb_maas.Text = seller.Salary.ToString();
            mskd_telefon.Text = seller.PhoneNumber;
        }

        private void FrmSaticiYenile_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Satici",con.Connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_satici.DataSource = dt;

        }


        SellerOperationManager operationManager = new SellerOperationManager();

        private void btn_yenile_Click(object sender, EventArgs e)
        {
            seller.PhoneNumber = mskd_telefon.Text;
            seller.Salary = decimal.Parse(tb_maas.Text);

            DialogResult dr = MessageBox.Show("Melumatlar Yenilensinmi?","Diqqet",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if(dr == DialogResult.OK)
            {
                operationManager.Update(seller);
                MessageBox.Show("Melumatlar Yenilendi");
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Melumatlar Silinsinmi?","Diqqet",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                operationManager.Delete(seller);
                MessageBox.Show("Melumatlar Silindi");
            }
        }

        private void pb_az_Click(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager("SuperStoreProject." + "az", Assembly.GetExecutingAssembly());
            lbl_id.Text = rm.GetString("lbl_id");
            lbl_telefon.Text = rm.GetString("lbl_telefon");
            lbl_adsoyad.Text = rm.GetString("lbl_adsoyad");
            lbl_maas.Text = rm.GetString("lbl_maas");
            btn_yenile.Text = rm.GetString("btn_yenile");
            btn_sil.Text = rm.GetString("btn_sil");
            gb_saticilar.Text = rm.GetString("gb_kassirler");
        }

        private void pb_eng_Click(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager("SuperStoreProject." + "en", Assembly.GetExecutingAssembly());
            lbl_id.Text = rm.GetString("lbl_id");
            lbl_telefon.Text = rm.GetString("lbl_telefon");
            lbl_adsoyad.Text = rm.GetString("lbl_adsoyad");
            lbl_maas.Text = rm.GetString("lbl_maas");
            btn_yenile.Text = rm.GetString("btn_yenile");
            btn_sil.Text = rm.GetString("btn_sil");
            gb_saticilar.Text = rm.GetString("gb_kassirler");
        }
    }
}
