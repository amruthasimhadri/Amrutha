using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExcelToSql
{
    public class Class1
    {
      
        public void ImportDataFromExcel()
        {
            string excelFilePath = "\"C:\\tempp\\sheet1.xlsx\"";
            //declare variables - edit these based on your particular situation
            //string ssqltable = "Table1";
            // make sure your sheet name is correct, here sheet name is sheet1,
            //so you can change your sheet name if have    different
            string myexceldataquery = "select student,rollno,course from [sheet1$]";
            //try
            //{

            //create our connection strings
            //string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + excelFilePath +
            //";extended properties=" + "\"excel 8.0;hdr=yes;\"";
            string sexcelconnectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilePath + ";Extended Properties=\"Excel 8.0;HDR=YES\";";
                string ssqlconnectionstring = "Data Source=ASIMHADR-L-5515\\SQLEXPRESS;Initial Catalog=PostWork;User ID=sa;Password=Welcome2evoke@1234";
                //execute a query to erase any previous data from our destination table
                string sclearsql = "delete from Table1";
                SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring);
                sqlconn.Open();
                SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);
                //sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                
                //series of commands to bulk copy data from the excel file into our sql table
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
                bulkcopy.DestinationTableName = "Table1";
                while (dr.Read())
                {
                    bulkcopy.WriteToServer(dr);
                }
                dr.Close();
                oledbconn.Close();
                sqlconn.Close();
                //Label1.Text = "File imported into sql server successfully.";
            }
            //catch (Exception ex)
            //{
                //handle exception
              //  Console.WriteLine(ex.Message);
            //}
            

        }
        
    }
//}
