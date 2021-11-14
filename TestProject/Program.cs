using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectDataBase
{
    class Program
    {
        private static string connectionString = @"DATA SOURCE = ERFAN\SQLEXPRESSS; INITIAL CATALOG = MyDataBase;
            INTEGRATED SECURITY = TRUE";
        static void Main(string[] args)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT ФИО FROM Person";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection))
                    {
                        adapter.Fill(dataTable);
                        Console.WriteLine(dataTable.DefaultView.ToString());
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка соединения с БД!");
            }

            Console.ReadLine();
        }
    }
}
