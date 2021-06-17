using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SuperStoreProject
{
    class ProductOperationManager
    {
        SqlServerConnection con = new SqlServerConnection();
        public void Add(Product product)
        {
            
            SqlCommand command = new SqlCommand("insert into Mehsullar " +
                "(Ad,UstKateqoriya,AltKateqoriya,StokSay,AlisQiymet,SatisQiymet,Istehsalci,SonIstifadetarixi) " +
                "values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",con.Connect());
            command.Parameters.AddWithValue("@p1",product.ProductName);
            command.Parameters.AddWithValue("@p2",product.TopCategory);
            command.Parameters.AddWithValue("@p3",product.SubCategory);
            command.Parameters.AddWithValue("@p4",product.Stock);
            command.Parameters.AddWithValue("@p5",product.PurchasePrice);
            command.Parameters.AddWithValue("@p6",product.SalePrice);
            command.Parameters.AddWithValue("@p7",product.Manufacturer);
            command.Parameters.AddWithValue("@p8",product.ExpirationDate);
            command.ExecuteNonQuery();
            con.Connect().Close();
            
        }

        public void Delete(Product product)
        {
            
            SqlCommand command = new SqlCommand("Delete From Mehsullar Where Id=@p1",con.Connect());
            command.Parameters.AddWithValue("@p1",product.Id);
            command.ExecuteNonQuery();
            con.Connect().Close();
        }

        public void SaleUpdate(Product product)
        {
            
            SqlCommand command = new SqlCommand("Update Mehsullar Set Stoksay=@p1,AlisQiymet=@p2,SatisQiymet=@p3 Where Id=@p4",con.Connect());
            command.Parameters.AddWithValue("@p1",product.Stock);
            command.Parameters.AddWithValue("@p2",product.PurchasePrice);
            command.Parameters.AddWithValue("@p3",product.SalePrice);
            command.Parameters.AddWithValue("@p4",product.Id);
            command.ExecuteNonQuery();
            con.Connect().Close();
        }

        public void Update(Product product)
        {
            SqlCommand command = new SqlCommand("Update Mehsullar Set Stoksay +=@p1,AlisQiymet=@p2,SatisQiymet=@p3 Where Id=@p4", con.Connect());
            command.Parameters.AddWithValue("@p1", product.Stock);
            command.Parameters.AddWithValue("@p2", product.PurchasePrice);
            command.Parameters.AddWithValue("@p3", product.SalePrice);
            command.Parameters.AddWithValue("@p4", product.Id);
            command.ExecuteNonQuery();
            con.Connect().Close();
        }
    }
}
