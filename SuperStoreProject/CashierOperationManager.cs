using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SuperStoreProject
{

    class CashierOperationManager
    {
        SqlServerConnection con = new SqlServerConnection();

        public void Add(Cashier cashier)
        {
            
            SqlCommand command = new SqlCommand("insert insto Kassir (Ad,Soyad,KassirNo,Isfre,Maas,Telefon,Email)" +
                "values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", con.Connect());
            command.Parameters.AddWithValue("@p1", cashier.FirstName);
            command.Parameters.AddWithValue("@p2", cashier.LastName);
            command.Parameters.AddWithValue("@p3", cashier.CashierNumber);
            command.Parameters.AddWithValue("@p4", cashier.Password);
            command.Parameters.AddWithValue("@p5", cashier.Salary);
            command.Parameters.AddWithValue("@p6",cashier.PhoneNumber);
            command.Parameters.AddWithValue("@p7",cashier.Email);
            command.ExecuteNonQuery();
            con.Connect().Close();
        }

        public void Update(Cashier cashier)
        {
            
            SqlCommand command = new SqlCommand("update Kassir Set Sifre=@p1,Maas=@p2,Telefon=@p3 Where Id=@p4", con.Connect());
            command.Parameters.AddWithValue("@p1", cashier.Password);
            command.Parameters.AddWithValue("@p2", cashier.Salary);
            command.Parameters.AddWithValue("@p3",cashier.PhoneNumber);
            command.Parameters.AddWithValue("@p4", cashier.Id);
            command.ExecuteNonQuery();
            con.Connect().Close();
        }

        public void Delete(Cashier cashier)
        {

            SqlCommand command = new SqlCommand("Delete From Kassir Where Id=@p1", con.Connect());
            command.Parameters.AddWithValue("@p1", cashier.Id);
            command.ExecuteNonQuery();
            con.Connect().Close();
        }

    }
}
