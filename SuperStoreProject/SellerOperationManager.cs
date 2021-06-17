using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SuperStoreProject
{
    class SellerOperationManager
    {
        SqlServerConnection con = new SqlServerConnection();
        public void Add(Seller seller)
        {
            SqlCommand command = new SqlCommand("Insert into Satici (Ad,Soyad,Telefon,Bolme,Maas) Values(@p1,@p2,@p3,@p4,@p5)", con.Connect());
            command.Parameters.AddWithValue("@p1",seller.FirstName);
            command.Parameters.AddWithValue("@p2",seller.LastName);
            command.Parameters.AddWithValue("@p3",seller.PhoneNumber);
            command.Parameters.AddWithValue("@p4",seller.Category);
            command.Parameters.AddWithValue("@p5",seller.Salary);
            
            command.ExecuteNonQuery();
            con.Connect().Close();
        }

        public void Update(Seller seller)
        {
            SqlCommand command = new SqlCommand("Update Satici Set Maas=@p1,Telefon=@p2 Where Id=@p3",con.Connect());
            command.Parameters.AddWithValue("@p1",seller.Salary);
            command.Parameters.AddWithValue("@p2",seller.PhoneNumber);
            command.Parameters.AddWithValue("@p3",seller.Id);
            command.ExecuteNonQuery();
            con.Connect().Close();
        }

         
        public void Delete(Seller seller)
        {
            SqlCommand command = new SqlCommand("Delete From Satici Where Id=@p1",con.Connect());
            command.Parameters.AddWithValue("@p1",seller.Id);
            command.ExecuteNonQuery();
            con.Connect().Close();
        }
    }
}
