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
    public partial class FrmKassirSatis : Form
    {
        public FrmKassirSatis()
        {
            InitializeComponent();
        }

        SqlServerConnection con = new SqlServerConnection();

        public Cashier cashier = new Cashier();
        
        private void FrmKassirSatis_Load(object sender, EventArgs e)
        {
            lbl_adsoyad.Text = cashier.FirstName + " " + cashier.LastName;
            lbl_kassirnovalue.Text = cashier.CashierNumber;
            btn_next.Enabled = false;


        }

        List<Product> products = new List<Product>();

        decimal toplam, qiymet, pul, qaliq, yekun;
        int say;

        Product product;
        private void btn_search_Click(object sender, EventArgs e)
        {


            product = new Product();
            if (tb_mehsulid.Text != "")
            {
                product.Id = int.Parse(tb_mehsulid.Text);


                SqlCommand command = new SqlCommand("Select * From Mehsullar Where Id=@p1", con.Connect());
                command.Parameters.AddWithValue("@p1", product.Id);
                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    product.ProductName = dr[1].ToString();
                    product.TopCategory = int.Parse(dr[2].ToString());
                    product.SubCategory = int.Parse(dr[3].ToString());
                    product.Stock = int.Parse(dr[4].ToString());
                    product.PurchasePrice = decimal.Parse(dr[5].ToString());
                    product.SalePrice = decimal.Parse(dr[6].ToString());
                    product.Manufacturer = dr[7].ToString();
                    product.ExpirationDate = Convert.ToDateTime(dr[8].ToString());


                    if (DateTime.Compare(product.ExpirationDate, DateTime.Now) < 0)
                    {
                        MessageBox.Show("Mehsulun son istifade tarixi bitmisdir.Yeni Mehsulu Daxil edin", "Xeta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        lbl_qiymet_value.Text = product.SalePrice.ToString();
                        qiymet = product.SalePrice;
                        if (product.Stock < 100)
                        {
                            lbl_stok_value.ForeColor = Color.Red;
                        }
                        lbl_stok_value.Text = product.Stock.ToString();

                        products.Add(product);

                    }
                }
                else
                {
                    MessageBox.Show("Mehsul Id-si yanlisdir.");
                }

                
            }
            else
            {
                MessageBox.Show("Mehsul Id si bos buraxila bilmez");
            }

            tb_mehsulid.Text = "";
        }

        private void btn_menecer_sehife_Click(object sender, EventArgs e)
        {
            FrmMenecerGiris frm = new FrmMenecerGiris();
            frm.ShowDialog();
        }

        private void FrmKassirSatis_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void pb_az_Click(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager("SuperStoreProject." + "az", Assembly.GetExecutingAssembly());
            lbl_kassirno.Text = rm.GetString("lbl_kassirno");
            lbl_kassir.Text = rm.GetString("lbl_kassir");
            lbl_menecer_sehifesi.Text = rm.GetString("lbl_menecer_sehifesi");
            lbl_mehsulid.Text = rm.GetString("lbl_mehsulid");
            lbl_qiymet.Text = rm.GetString("lbl_qiymet");
            lbl_stok.Text = rm.GetString("lbl_stok");
            lbl_say.Text = rm.GetString("lbl_say");
            lbl_toplam.Text = rm.GetString("lbl_toplam");
            lbl_yekun.Text = rm.GetString("lbl_yekun");
            lbl_pul.Text = rm.GetString("lbl_pul");
            lbl_qaliq.Text = rm.GetString("lbl_qaliq");
            btn_satis.Text = rm.GetString("btn_satis");
            gb_satis.Text = rm.GetString("gb_satis");
            lv_mehsullar.Columns[0].Text = rm.GetString("lv_mehsul_ad");
            lv_mehsullar.Columns[1].Text = rm.GetString("lv_mehsul_qiymet");
            lv_mehsullar.Columns[2].Text = rm.GetString("lv_mehsul_say");
            lv_mehsullar.Columns[3].Text = rm.GetString("lv_mehsul_toplam");

        }

        private void pb_eng_Click(object sender, EventArgs e)
        {
            
            ResourceManager rm = new ResourceManager("SuperStoreProject." + "en", Assembly.GetExecutingAssembly());
            lbl_kassirno.Text = rm.GetString("lbl_kassirno");
            lbl_kassir.Text = rm.GetString("lbl_kassir");
            lbl_menecer_sehifesi.Text = rm.GetString("lbl_menecer_sehifesi");
            lbl_mehsulid.Text = rm.GetString("lbl_mehsulid");
            lbl_qiymet.Text = rm.GetString("lbl_qiymet");
            lbl_stok.Text = rm.GetString("lbl_stok");
            lbl_say.Text = rm.GetString("lbl_say");
            lbl_toplam.Text = rm.GetString("lbl_toplam");
            lbl_yekun.Text = rm.GetString("lbl_yekun");
            lbl_pul.Text = rm.GetString("lbl_pul");
            lbl_qaliq.Text = rm.GetString("lbl_qaliq");
            btn_satis.Text = rm.GetString("btn_satis");
            gb_satis.Text = rm.GetString("gb_satis");
            lv_mehsullar.Columns[0].Text = rm.GetString("lv_mehsul_ad");
            lv_mehsullar.Columns[1].Text = rm.GetString("lv_mehsul_qiymet");
            lv_mehsullar.Columns[2].Text = rm.GetString("lv_mehsul_say");
            lv_mehsullar.Columns[3].Text = rm.GetString("lv_mehsul_toplam");

        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (tb_say.Text != "")
            {


                ListViewItem lvi = new ListViewItem();
                //foreach (var product in products)
                //{

                //}
                lvi.Text = product.ProductName;
                lvi.SubItems.Add(product.SalePrice.ToString());
                lvi.SubItems.Add(say.ToString());
                lvi.SubItems.Add(toplam.ToString());
                lv_mehsullar.Items.Add(lvi);


                yekun += toplam;
                lbl_yekun_value.Text = yekun.ToString();

                product.Stock -= say;
                product.NumberOfSales = say;
                product.TotalPrice = toplam;

                

            }
            else
            {
                MessageBox.Show("Say daxil edin");
            }

            tb_say.Text = "";
            lbl_qiymet_value.Text = "00";
            lbl_toplam_value.Text = "00";
            lbl_stok_value.Text = "00";

            btn_next.Enabled = false;
        }

        private void tb_say_TextChanged(object sender, EventArgs e)
        {
            if (tb_say.Text != "")
            {
                try
                {
                    say = int.Parse(tb_say.Text);
                    toplam = qiymet * say;
                    lbl_toplam_value.Text = toplam.ToString();
                    btn_next.Enabled = true;
                }
                catch (Exception)
                {

                    tb_say.Text = "";
                }
                
            }

        }

        private void tb_pul_TextChanged(object sender, EventArgs e)
        {
            if (tb_pul.Text != "")
            {
                pul = decimal.Parse(tb_pul.Text);
                qaliq = pul - yekun;
                lbl_qaliq_value.Text = qaliq.ToString();

            }
            else
            {
                lbl_qaliq_value.Text = "00";
            }


        }

        private void btn_satis_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale();
            sale.Seller = cashier.Id;
            sale.DateOfSale = DateTime.Now;

            SqlCommand command = new SqlCommand("Select MAX(SatisNomresi) From Satis ", con.Connect());
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                sale.SaleNumber = int.Parse(dr[0].ToString()) + 1;
            }

            ProductOperationManager productOperationManager = new ProductOperationManager();
            SaleManager saleManager = new SaleManager();

            //dongu o productlari bir bir gezir ,hansi satisdirsa hemen seatis ucun butun mehsullari elave edir
            foreach (var product in products)
            {
                productOperationManager.SaleUpdate(product);
                saleManager.Add(sale,product);
            }

            lv_mehsullar.Items.Clear();
            products.Clear();

            CashBoxManager cashBoxManager = new CashBoxManager();
            cashBoxManager.EnterMoney = yekun;
            cashBoxManager.ExitMoney = 0;
            cashBoxManager.Date = DateTime.Now.Date;
            cashBoxManager.UpdateCashBox();

            MessageBox.Show("Satis edildi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

    }
}
