using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SuperStoreProject
{
    class CashBoxManager
    {
        SqlServerConnection con = new SqlServerConnection();

        public decimal EnterMoney { get; set; }
        public decimal ExitMoney { get; set; }

        public DateTime Date { get; set; }

        public void UpdateCashBox()
        {
            SqlCommand command = new SqlCommand("Insert Into Kassa (Giris,Cixis,Tarix) values(@p1,@p2,@p3)",con.Connect());
            command.Parameters.AddWithValue("@p1",EnterMoney);
            command.Parameters.AddWithValue("@p2",ExitMoney);
            command.Parameters.AddWithValue("@p3",Date);
            command.ExecuteNonQuery();
            con.Connect().Close();
        }
    }
}
