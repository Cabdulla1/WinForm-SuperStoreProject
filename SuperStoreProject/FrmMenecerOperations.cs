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
    public partial class FrmMenecerOperations : Form
    {
        public FrmMenecerOperations()
        {
            InitializeComponent();
        }

        SqlServerConnection con = new SqlServerConnection();
        public Manager manager = new Manager();

        public void MehsulList()
        {
            SqlDataAdapter da = new SqlDataAdapter("Execute MehsulList", con.Connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_mehsullar.DataSource = dt;
        }

        public void SatisList()
        {
            SqlDataAdapter da = new SqlDataAdapter("Execute SatisList", con.Connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_satislar.DataSource = dt;
        }

        public void KassaList()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Kassa", con.Connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_kassa.DataSource = dt;
        }
        private void FrmMenecerOperations_Load(object sender, EventArgs e)
        {
            lbl_menecerno_value.Text = manager.ManagerNumber;
            lbl_adsoyadvalue.Text = manager.FirstName + " " + manager.LastName;

            MehsulList();
            SatisList();
            KassaList();

            SqlDataAdapter da = new SqlDataAdapter("Select KateqoriyaId,KateqoriyaAd From UstKateqoriya", con.Connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmb_ustkat.ValueMember = "KateqoriyaId";
            cmb_ustkat.DisplayMember = "KateqoriyaAd";
            cmb_ustkat.DataSource = dt;

            cmb_kat_ust.ValueMember = "KateqoriyaId";
            cmb_kat_ust.DisplayMember = "KateqoriyaAd";
            cmb_kat_ust.DataSource = dt;

            cmb_kateqoriya.ValueMember = "KateqoriyaId";
            cmb_kateqoriya.DisplayMember = "KateqoriyaAd";
            cmb_kateqoriya.DataSource = dt;

            rb_100.Checked = true;

            btn_artir.Enabled = false;
            btn_yeni_kassir.Enabled = false;

        }
        private void cmb_ustkat_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select KateqoriyaId,KateqoriyaAd From AltKateqoriya Where UstKateqoriya=@p1", con.Connect());
            da.SelectCommand.Parameters.AddWithValue("@p1", cmb_ustkat.SelectedValue);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmb_alt_kat.ValueMember = "KateqoriyaId";
            cmb_alt_kat.DisplayMember = "KateqoriyaAd";
            cmb_alt_kat.DataSource = dt;
        }

        private void btn_axtar_kateqoriya_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Mehsullar Where UstKateqoriya=@p1 and AltKateqoriya=@p2", con.Connect());
            da.SelectCommand.Parameters.AddWithValue("@p1", cmb_ustkat.SelectedValue);
            da.SelectCommand.Parameters.AddWithValue("@p2", cmb_alt_kat.SelectedValue);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_mehsullar.DataSource = dt;
        }

        private void btn_axtar_stok_Click(object sender, EventArgs e)
        {
            if (rb_100.Checked == true)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From Mehsullar Where StokSay<100", con.Connect());
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv_mehsullar.DataSource = dt;
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From Mehsullar Where StokSay<200", con.Connect());
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv_mehsullar.DataSource = dt;
            }
        }

        private void btn_axtar_ad_Click(object sender, EventArgs e)
        {
            
            SqlDataAdapter da = new SqlDataAdapter("Select * From Mehsullar Where Ad like '%'+@p1+'%'", con.Connect());
            da.SelectCommand.Parameters.AddWithValue("@p1", tb_mehsul_adi.Text);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_mehsullar.DataSource = dt;
        }

        private void btn_butun_mehsullar_Click(object sender, EventArgs e)
        {
            MehsulList();
        }

        private void btn_axtar_tarix_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From Satis Where Tarix=@p1", con.Connect());
                da.SelectCommand.Parameters.AddWithValue("@p1", mskd_tarix.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv_satislar.DataSource = dt;
            }
            catch (Exception)
            {

            }
            

        }

        private void btn_axtar_2tarix_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From Satis Where Tarix between @p1 and @p2", con.Connect());
                da.SelectCommand.Parameters.AddWithValue("@p1", mskd_tarix1.Text);
                da.SelectCommand.Parameters.AddWithValue("@p2", mskd_tarix2.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv_satislar.DataSource = dt;
            }
            catch (Exception)
            {

                
            }
            
        }

        private void btn_butun_satislar_Click(object sender, EventArgs e)
        {
            
            SatisList();
        }

        Sale sale1 = new Sale();
        Product product1 = new Product();
        CashBoxManager boxManager1 = new CashBoxManager();
        private void dgv_satislar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dgv_satislar.SelectedCells[0].RowIndex;

            sale1.Id = int.Parse(dgv_satislar.Rows[secilen].Cells[0].Value.ToString());
            tb_satis_id.Text = sale1.Id.ToString();


            product1.ProductName = dgv_satislar.Rows[secilen].Cells[4].Value.ToString();

            SqlCommand command = new SqlCommand("Select Id,StokSay,AlisQiymet From Mehsullar Where Ad=@p1", con.Connect());
            command.Parameters.AddWithValue("@p1", product1.ProductName);
            SqlDataReader dr = command.ExecuteReader();

            if (dr.Read())
            {
                product1.Id = int.Parse(dr[0].ToString());
                product1.Stock = int.Parse(dr[1].ToString());
                product1.PurchasePrice = decimal.Parse(dr[2].ToString());
            }

            product1.Stock = product1.Stock + int.Parse(dgv_satislar.Rows[secilen].Cells[6].Value.ToString());
            product1.SalePrice = decimal.Parse(dgv_satislar.Rows[secilen].Cells[5].Value.ToString());

            dr.Close();
            con.Connect().Close();


            boxManager1.EnterMoney = 0;
            boxManager1.ExitMoney = decimal.Parse(dgv_satislar.Rows[secilen].Cells[7].Value.ToString());
            boxManager1.Date = DateTime.Now.Date;
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Satis Qeydleri silinsinmi", "Diqqet", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                SaleManager saleManager = new SaleManager();
                saleManager.Delete(sale1);

                boxManager1.UpdateCashBox();

                ProductOperationManager productOperationManager = new ProductOperationManager();
                productOperationManager.SaleUpdate(product1);

                tb_satis_id.Text = "";
            }


            product1 = new Product();
            sale1 = new Sale();
            boxManager1 = new CashBoxManager();
        }

        private void btn_satici_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Satici", con.Connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_isciler.DataSource = dt;
        }

        private void btn_kassir_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Kassir", con.Connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_isciler.DataSource = dt;
        }

        private void btn_kassir_melumat_Click(object sender, EventArgs e)
        {
            FrmKassirYenile frm = new FrmKassirYenile();
            frm.ShowDialog();

        }

        private void btn_bax_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From Kassa Where Tarix =@p1", con.Connect());
                da.SelectCommand.Parameters.AddWithValue("@p1", mskd_tb_tarix.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv_kassa.DataSource = dt;
            }
            catch (Exception)
            {

                
            }
            
        }

        private void btn_bax_2_tarix_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * From Kassa Where Tarix between @p1 and @p2", con.Connect());
                da.SelectCommand.Parameters.AddWithValue("@p1", mskd_tb_tarix1.Text);
                da.SelectCommand.Parameters.AddWithValue("@p2", mskd_tb_tarix2.Text);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv_kassa.DataSource = dt;
            }
            catch (Exception)
            {

                
            }
            
        }

        private void cmb_kat_ust_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select KateqoriyaId,KateqoriyaAd From AltKateqoriya Where UstKateqoriya=@p1", con.Connect());
            da.SelectCommand.Parameters.AddWithValue("@p1", cmb_kat_ust.SelectedValue);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmb_kat_alt.ValueMember = "KateqoriyaId";
            cmb_kat_alt.DisplayMember = "KateqoriyaAd";
            cmb_kat_alt.DataSource = dt;
        }


        ProductOperationManager operationManager = new ProductOperationManager();

        private void btn_elave_et_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_ad.Text) == false && String.IsNullOrEmpty(tb_stok.Text) == false 
                && String.IsNullOrEmpty(tb_alis.Text) == false && String.IsNullOrEmpty(tb_satis.Text) == false 
                && String.IsNullOrEmpty(tb_istehsalci.Text)==false && mskd_son_ist.Text != "    -  -")
            {
                Product product = new Product();
                product.ProductName = tb_ad.Text;
                product.TopCategory = int.Parse(cmb_kat_ust.SelectedValue.ToString());
                product.SubCategory = int.Parse(cmb_kat_alt.SelectedValue.ToString());
                product.Stock = int.Parse(tb_stok.Text);
                product.PurchasePrice = decimal.Parse(tb_alis.Text);
                product.SalePrice = decimal.Parse(tb_satis.Text);
                product.Manufacturer = tb_istehsalci.Text;
                product.ExpirationDate = Convert.ToDateTime(mskd_son_ist.Text).Date;


                operationManager.Add(product);

                say = int.Parse(tb_stok.Text);
                toplam = say * product.PurchasePrice;

                CashBoxManager cashBoxManager = new CashBoxManager();
                cashBoxManager.EnterMoney = 0;
                cashBoxManager.ExitMoney = toplam;
                cashBoxManager.Date = DateTime.Now.Date;

                cashBoxManager.UpdateCashBox();

                MessageBox.Show("Mehsul Elave Olundu..");

                tb_ad.Text = "";
                tb_stok.Text = "";
                tb_satis.Text = "";
                tb_alis.Text = "";
                tb_istehsalci.Text = "";
                mskd_son_ist.Text = "";
            }
            else
            {
                MessageBox.Show("Melumatlar Tam Doldurulmalidir", "Xeta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        Product product;
        decimal toplam;
        int say;
        private void btn_search_Click(object sender, EventArgs e)
        {
            product = new Product();

            if (tb_id.Text != "")
            {
                product.Id = int.Parse(tb_id.Text);


                SqlCommand command = new SqlCommand("Select Ad,StokSay,AlisQiymet,SatisQiymet From Mehsullar Where Id=@p1", con.Connect());
                command.Parameters.AddWithValue("@p1", product.Id);
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    product.ProductName = dr[0].ToString();
                    product.Stock = int.Parse(dr[1].ToString());
                    product.PurchasePrice = decimal.Parse(dr[2].ToString());
                    product.SalePrice = decimal.Parse(dr[3].ToString());
                }

                ListViewItem lvi = new ListViewItem();
                lvi.Text = product.ProductName;
                lvi.SubItems.Add(product.Stock.ToString());
                lvi.SubItems.Add(product.PurchasePrice.ToString());
                lvi.SubItems.Add(product.SalePrice.ToString());

                lv_mehsullar.Items.Add(lvi);

                tb_alis_qiymet.Text = product.PurchasePrice.ToString();
                tb_satis_qiymet.Text = product.SalePrice.ToString();

                toplam = product.PurchasePrice;
                lbl_toplam_value.Text = toplam.ToString();

                btn_artir.Enabled = true;

                con.Connect().Close();
            }
            else
            {
                MessageBox.Show("Mehsu Id-si Daxil edin");
            }
        }

        private void tb_say_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_say.Text) == false)
            {
                say = int.Parse(tb_say.Text);
                toplam = say * product.PurchasePrice;
                lbl_toplam_value.Text = toplam.ToString();
            }
            else
            {
                say = 1;
            }
        }

        private void tb_alis_qiymet_TextChanged(object sender, EventArgs e)
        {
            if (tb_alis_qiymet.Text != "")
            {
                product.PurchasePrice = decimal.Parse(tb_alis_qiymet.Text);
                toplam = say * product.PurchasePrice;
                lbl_toplam_value.Text = toplam.ToString();
            }
            else
            {
                toplam = product.PurchasePrice * say;
                lbl_toplam_value.Text = toplam.ToString();
            }

        }

        private void btn_artir_Click(object sender, EventArgs e)
        {
            product.PurchasePrice = decimal.Parse(tb_alis_qiymet.Text);
            product.SalePrice = decimal.Parse(tb_satis_qiymet.Text);
            product.Stock = int.Parse(tb_say.Text);

            operationManager.Update(product);

            CashBoxManager cashBoxManager = new CashBoxManager();
            cashBoxManager.EnterMoney = 0;
            cashBoxManager.ExitMoney = toplam;
            cashBoxManager.Date = DateTime.Now.Date;

            cashBoxManager.UpdateCashBox();


            MessageBox.Show("Mehsul melumatlari ve Stok sayi yenilendi");

            tb_id.Text = "";
            tb_say.Text = "";
            tb_alis_qiymet.Text = "";
            tb_satis_qiymet.Text = "";

            btn_artir.Enabled = false;
        }

        private void btn_yeni_satici_Click(object sender, EventArgs e)
        {
            Seller seller = new Seller();
            if (String.IsNullOrEmpty(tb_satici_ad.Text)==false 
                && String.IsNullOrEmpty(tb_soyad.Text) == false 
                && mskd_telefon.Text != "(   )   -   -  -" && String.IsNullOrEmpty(tb_maas.Text) == false)
            {
                seller.FirstName = tb_satici_ad.Text;
                seller.LastName = tb_soyad.Text;
                seller.PhoneNumber = mskd_telefon.Text;
                seller.Category = int.Parse(cmb_kateqoriya.SelectedValue.ToString());
                seller.Salary = decimal.Parse(tb_maas.Text);


                SellerOperationManager sellerOperation = new SellerOperationManager();
                sellerOperation.Add(seller);

                MessageBox.Show("Yeni Satici Elave Olundu");

                tb_satici_ad.Text = "";
                tb_soyad.Text = "";
                mskd_telefon.Text = "(   )   -   -  -";
                tb_maas.Text = "";
            }
            else
            {
                MessageBox.Show("Melumatlar Tam Doldurulmalidir", "Xeta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        Cashier cashier;

        private void btn_sec_Click(object sender, EventArgs e)
        {
            cashier = new Cashier();

            Random rnd = new Random();
            int cashierNumber;

            cashierNumber = rnd.Next(100000, 1000000);

            SqlCommand command = new SqlCommand("Select * From Kassir Where KassirNo=@p1", con.Connect());
            command.Parameters.AddWithValue("@p1", cashierNumber.ToString());
            SqlDataReader dr = command.ExecuteReader();


            if (dr.Read() == false)
            {
                cashier.CashierNumber = cashierNumber.ToString();
                btn_yeni_kassir.Enabled = true;
                tb_kassir_no.Text = cashierNumber.ToString();
            }
            else
            {
                MessageBox.Show("Bu Kassir Nomresi sistemde movcuddur,Yeni kassir nomresi ucun yeniden duymeni basin");
            }

        }

        private void btn_yeni_kassir_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_kassir_ad.Text)==false && String.IsNullOrEmpty(tb_kassir_soyad.Text)==false
                && String.IsNullOrEmpty(tb_kassir_no.Text)==false && String.IsNullOrEmpty(tb_maas_kassir.Text)==false
                && String.IsNullOrEmpty(tb_sifre.Text)==false && mskd_kassir_telefon.Text!= "(   )   -   -  -")
            {
                cashier.FirstName = tb_kassir_ad.Text;
                cashier.LastName = tb_kassir_soyad.Text;
                cashier.Password = tb_sifre.Text;
                cashier.Salary = decimal.Parse(tb_maas_kassir.Text);
                cashier.PhoneNumber = mskd_kassir_telefon.Text;
                cashier.Email = tb_email.Text;


                CashierOperationManager cashierOperation = new CashierOperationManager();

                cashierOperation.Add(cashier);

                MessageBox.Show("Yeni Kassir Elave Olundu");
                btn_yeni_kassir.Enabled = false;

                tb_kassir_ad.Text = "";
                tb_kassir_soyad.Text = "";
                tb_kassir_no.Text = "";
                mskd_kassir_telefon.Text = "(   )   -   -  -";
                tb_sifre.Text = "";
                tb_maas_kassir.Text = "";
            }

            else
            {
                MessageBox.Show("Melumatlar Tam Doldurumalidir","Xeta",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btn_satici_melumat_Click(object sender, EventArgs e)
        {
            FrmSaticiYenile frm = new FrmSaticiYenile();
            frm.ShowDialog();
        }

        private void FrmMenecerOperations_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btn_menecer_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Menecer", con.Connect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv_isciler.DataSource = dt;
        }

        private void pb_az_Click(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager("SuperStoreProject." + "az", Assembly.GetExecutingAssembly());
            SetLanguage(rm);

        }

        private void pb_eng_Click(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager("SuperStoreProject." + "en", Assembly.GetExecutingAssembly());
            SetLanguage(rm);


        }

        private void SetLanguage(ResourceManager rm)
        {
            lbl_menecerno.Text = rm.GetString("lbl_menecerno");
            lbl_adsoyad.Text = rm.GetString("lbl_adsoyad") + ":";
            gb_axtar.Text = rm.GetString("gb_axtar");
            gb_kateqoriya.Text = rm.GetString("gb_kateqoriya");
            btn_axtar_ad.Text = rm.GetString("btn_axtar_ad");
            btn_axtar_kateqoriya.Text = rm.GetString("btn_axtar_kateqoriya");
            btn_butun_mehsullar.Text = rm.GetString("btn_butun_mehsullar");
            lbl_ust_kat.Text = rm.GetString("lbl_ust_kat");
            lbl_alt_kat.Text = rm.GetString("lbl_alt_kat");
            gb_mehsullar.Text = rm.GetString("gb_mehsullar");
            rb_100.Text = rm.GetString("rb_100");
            rb_200.Text = rm.GetString("rb_200");
            btn_axtar_stok.Text = rm.GetString("btn_axtar_stok");
            Mehsullar.Text = rm.GetString("tbc_mehsullar");
            Satislar.Text = rm.GetString("tbc_satislar");
            Isciler.Text = rm.GetString("tbc_isciler");
            ElaveEtMehsul.Text = rm.GetString("tbc_elave_et_mehsul");
            IsciElave.Text = rm.GetString("tbc_isci_elave_et");
            Kassa.Text = rm.GetString("tbc_kassa");
            btn_axtar_tarix.Text = rm.GetString("btn_axtar");
            btn_axtar_2tarix.Text = rm.GetString("btn_axtar");
            lbl_tarix.Text = rm.GetString("lbl_tarix");
            lbl_tarix1.Text = rm.GetString("lbl_tarix1");
            lbl_tarix2.Text = rm.GetString("lbl_tarix2");
            btn_butun_satislar.Text = rm.GetString("btn_butun_satislar");
            btn_sil.Text = rm.GetString("btn_sil");
            gb_satislar.Text = rm.GetString("gb_satislar");
            gb_satis_sil.Text = rm.GetString("gb_satis_sil");
            gb_tarix.Text = rm.GetString("gb_tarix");
            gb_2_tarix.Text = rm.GetString("gb_2_tarix");
            gb_isciler.Text = rm.GetString("gb_isciler");
            gb_isciler_2.Text = rm.GetString("gb_isciler");
            btn_satici.Text = rm.GetString("btn_satici");
            btn_kassir.Text = rm.GetString("btn_kassir");
            btn_menecer.Text = rm.GetString("btn_menecer");
            btn_satici_melumat.Text = rm.GetString("btn_satici_melumatlari");
            btn_kassir_melumat.Text = rm.GetString("btn_kassir_melumatlari");
            gb_isci_melumat.Text = rm.GetString("gb_isci_melumatlari");
            gb_tarixe_gore.Text = rm.GetString("gb_tarix");
            gb_2tarix.Text = rm.GetString("gb_2_tarix");
            lbl_tarix_kassa.Text = rm.GetString("lbl_tarix");
            lbl_tarix1_kassa.Text = rm.GetString("lbl_tarix1");
            lbl_tarix2_kassa.Text = rm.GetString("lbl_tarix2");
            btn_bax.Text = rm.GetString("btn_bax");
            btn_butun.Text = rm.GetString("btn_butun");
            gb_yeni_mehsul.Text = rm.GetString("gb_yeni_mehsul");
            gb_stok_artir.Text = rm.GetString("gb_stok_artir");
            lbl_ad.Text = rm.GetString("lbl_ad");
            lbl_kat_ust.Text = rm.GetString("lbl_kat_ust");
            lbl_kat_alt.Text = rm.GetString("lbl_kat_alt");
            lbl_stok.Text = rm.GetString("lbl_stok");
            lbl_alis.Text = rm.GetString("lbl_alis");
            lbl_satis.Text = rm.GetString("lbl_satis");
            lbl_istehsalci.Text = rm.GetString("lbl_istehsalci");
            lbl_son_ist.Text = rm.GetString("lbl_son_ist");
            btn_elave_et.Text = rm.GetString("btn_elave_et");
            lbl_id.Text = rm.GetString("lbl_id");
            lbl_say.Text = rm.GetString("lbl_say");
            lbl_alis_qiymet.Text = rm.GetString("lbl_alis");
            lbl_satis_qiymet.Text = rm.GetString("lbl_satis");
            lbl_toplam.Text = rm.GetString("lbl_toplam");
            btn_artir.Text = rm.GetString("btn_artir");
            lbl_satici_ad.Text = rm.GetString("lbl_satici_ad");
            lbl_satici_soyad.Text = rm.GetString("lbl_satici_soyad");
            lbl_telefon_satici.Text = rm.GetString("lbl_telefon");
            lbl_maas.Text = rm.GetString("lbl_maas");
            btn_yeni_satici.Text = rm.GetString("btn_yeni_satici");
            lbl_kassir_ad.Text = rm.GetString("lbl_satici_ad");
            lbl_kassir_soyad.Text = rm.GetString("lbl_satici_soyad");
            lbl_telefon_kassir.Text = rm.GetString("lbl_telefon");
            lbl_kassirno.Text = rm.GetString("lbl_kassirno");
            lbl_sifre.Text = rm.GetString("lbl_sifre");
            lbl_maas_kassir.Text = rm.GetString("lbl_maas");
            lbl_email.Text = rm.GetString("lbl_email");
            btn_yeni_kassir.Text = rm.GetString("btn_yeni_kassir");
            gb_kassir.Text = rm.GetString("gb_kassir");
            gb_satici.Text = rm.GetString("gb_satici");
            btn_bax_2_tarix.Text = rm.GetString("btn_bax");
            gb_stok.Text = rm.GetString("gb_stok");
            lbl_satis_id.Text = rm.GetString("lbl_satis_id");
        }
    }
}
