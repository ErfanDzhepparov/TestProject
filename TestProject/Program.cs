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
                    string sqlQuery = "SELECT * FROM Person";
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


            //try
            //{
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();
            //        string sqlQuery = "INSERT INTO Person(ФИО, Возраст) VALUES('Петров И З', 25)";
            //        using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            //        {
            //            command.ExecuteNonQuery();
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Ошибка соединения с БД!");
            //}

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "UPDATE Person SET ФИО = 'ААААА', Возраст = 100 WHERE ID = 1";
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.ExecuteNonQuery();
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
