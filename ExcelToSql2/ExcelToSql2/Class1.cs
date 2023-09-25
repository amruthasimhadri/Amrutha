﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace ExcelToSql2
{
    class Program
    {
        static void Main(string[] args)
        {
            //the datetime and Log folder will be used for error log file in case error occured
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string LogFolder = @"C:\Log\";
            try
            {

                //Provide the Database Name 
                
                //Provide the SQL Server Name 
                
                //Provide the table name in which you want to load excel sheet's data
                String TableName = @"tblCustomer";
                //Provide the schema of table
                String SchemaName = @"dbo";
                //Provide Excel file path
                string fileFullPath = @"C:\GitExample\Amrutha\postwork\sheet1.xlsx";
                //Provide Sheet Name you like to read
                string SheetName ="sheet1";


                //Create Connection to SQL Server Database 
                SqlConnection SQLConnection = new SqlConnection();
                SQLConnection.ConnectionString = "Data Source=ASIMHADR-L-5515\\SQLEXPRESS;Initial Catalog=PostWork;User ID=sa;Password=Welcome2evoke@1234";
                    


                //Create Excel Connection
                string ConStr;
                string HDR;
                HDR = "YES";
                ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
                    + fileFullPath + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
                OleDbConnection cnn = new OleDbConnection(ConStr);


                //Get data from Excel Sheet to DataTable
                OleDbConnection Conn = new OleDbConnection(ConStr);
                Conn.Open();
                OleDbCommand oconn = new OleDbCommand("select * from [" + SheetName + "$]", Conn);
                OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                Conn.Close();

                SQLConnection.Open();
                //Load Data from DataTable to SQL Server Table.
                using (SqlBulkCopy BC = new SqlBulkCopy(SQLConnection))
                {
                    BC.DestinationTableName = SchemaName + "." + TableName;
                    foreach (var column in dt.Columns)
                        BC.ColumnMappings.Add(column.ToString(), column.ToString());
                    BC.WriteToServer(dt);
                }
                SQLConnection.Close();

            }
            catch (Exception exception)
            {
                // Create Log File for Errors
                using (StreamWriter sw = File.CreateText(LogFolder
                    + "\\" + "ErrorLog_" + datetime + ".log"))
                {
                    sw.WriteLine(exception.ToString());

                }

            }

        }
    }
}
