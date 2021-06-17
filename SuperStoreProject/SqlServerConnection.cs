using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SuperStoreProject
{
    class SqlServerConnection
    {

        //Bazaya qosulmaq ucun baglanti adresi
        public SqlConnection Connect()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6JDPHQ7\SQLEXPRESS;Initial Catalog=DbSuperStore;Integrated Security=True;MultipleActiveResultSets=True");
            con.Open();
            return con;
        }
    }
}
