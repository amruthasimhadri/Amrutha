using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ado.net
{
    public class Class1
    {
        public void getcus()
        {
            SqlConnection _con = new SqlConnection("Data Source=ASIMHADR-L-5515\\SQLEXPRESS;Initial Catalog=Ammu;User ID=sa;Password=Welcome2evoke@1234");
            _con.Open();
            SqlCommand cmd = new SqlCommand("select * from cus", _con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("\t{0}\t{0}",reader.GetInt32(0),reader.GetString(1)); 
            }
        }
    }
}
