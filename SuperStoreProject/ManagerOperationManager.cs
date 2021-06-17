using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SuperStoreProject
{
    class ManagerOperationManager
    {
        SqlServerConnection con = new SqlServerConnection();
        public void Add(Manager manager)
        {
            SqlCommand command = new SqlCommand("Insert into Menecer (Ad,Soyad,MenecerNo,Sifre,Maas,Telefon) " +
                "values(@p1,@p2,@p3,@p4,@p5,@p6)",con.Connect());
            command.Parameters.AddWithValue("@p1",manager.FirstName);
            command.Parameters.AddWithValue("@p2",manager.LastName);
            command.Parameters.AddWithValue("@p3",manager.ManagerNumber);
            command.Parameters.AddWithValue("@p4",manager.Password);
            command.Parameters.AddWithValue("@p5",manager.Salary);
            command.Parameters.AddWithValue("@p6",manager.PhoneNumber);
            command.ExecuteNonQuery();
            con.Connect().Close();
        }

        public void Update(Manager manager)
        {
            SqlCommand command = new SqlCommand("Update Menecer Set Sifre=@p1,Maas=@p2,Telefon=@p3 Where Id=@p4",con.Connect());
            command.Parameters.AddWithValue("@p1",manager.Password);
            command.Parameters.AddWithValue("@p2",manager.Password);
            command.Parameters.AddWithValue("@p3",manager.PhoneNumber);
            command.Parameters.AddWithValue("@p4",manager.Id);
            command.ExecuteNonQuery();
            con.Connect().Close();
        }

        public void Delete(Manager manager)
        {
            SqlCommand command = new SqlCommand("delete from Menecer Where Id=@p1",con.Connect());
            command.Parameters.AddWithValue("@p1",manager.Id);
            command.ExecuteNonQuery();
            con.Connect().Close();
        }
    }
}
