using Microsoft.Office.Interop.Excel;
using Microsoft.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Class1
    {
        public void SaveFileToDatabase(string filePath)
        {
            String strConnection = "Data Source=ASIMHADR-L-5515\\SQLEXPRESS;Initial Catalog=PostWork;User ID=sa;Password=Welcome2evoke@1234";

            String excelConnString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0\"", filePath);
            //Create Connection to Excel work book 
            using (OleDbConnection excelConnection = new OleDbConnection(excelConnString))
            { 

            //Create OleDbCommand to fetch data from Excel 
            using (OleDbCommand cmd = new OleDbCommand("Select [student],[rollno],[course] from [sheet1$]", excelConnection))
            {
                    qexcelConnection.Open();
                using (OleDbDataReader dReader = cmd.ExecuteReader())
                {
                    using (SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection))
                    {
                        //Give your Destination table name 
                        sqlBulk.DestinationTableName = "Table1";
                        sqlBulk.WriteToServer(dReader);
                    }
                }
            }
            }
        }


        
    }
}
