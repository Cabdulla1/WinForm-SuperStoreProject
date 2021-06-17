using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SuperStoreProject
{
    
    class SaleManager
    {
        SqlServerConnection con = new SqlServerConnection();
        public void Add(Sale sale,Product product)
        {
            SqlCommand command = new SqlCommand("Insert into Satis (SatisNomresi,UstKateQoriya,AltKateqoriya,Mehsul,Qiymet,Say,ToplamQiymet,Satici,Tarix)" +
                "values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)",con.Connect());
            command.Parameters.AddWithValue("@p1",sale.SaleNumber);
            command.Parameters.AddWithValue("@p2",product.TopCategory);
            command.Parameters.AddWithValue("@p3",product.SubCategory);
            command.Parameters.AddWithValue("@p4",product.Id);
            command.Parameters.AddWithValue("@p5",product.SalePrice);
            command.Parameters.AddWithValue("@p6",product.NumberOfSales);
            command.Parameters.AddWithValue("@p7",product.TotalPrice);
            command.Parameters.AddWithValue("@p8",sale.Seller);
            command.Parameters.AddWithValue("@p9",sale.DateOfSale);
            command.ExecuteNonQuery();
            con.Connect().Close();
        }

        public void Delete(Sale sale)
        {
            SqlCommand command = new SqlCommand("Delete From Satis Where Id=@p1",con.Connect());
            command.Parameters.AddWithValue("@p1",sale.Id);
            command.ExecuteNonQuery();
            con.Connect().Close();
        }
    }
}
