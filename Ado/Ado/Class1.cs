
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ado
{
    public class Class1
    {
        public void getdata()
        {
            using (SqlConnection con = new SqlConnection("Data Source=ASIMHADR-L-5515\\SQLEXPRESS;Initial Catalog=Ammu;User ID=sa;Password=Welcome2evoke@1234"))
            {
               con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("retrieve",con);
                
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                
                DataTable dt = new DataTable();
                sda.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    Console.WriteLine(dr[0]+" " + dr[1]);
                }
                
            }
        }
    }
}
