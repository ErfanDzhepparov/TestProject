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
                string sqlQuery = "SELECT * FROM Person";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) // если есть данные
                    {
                        // выводим названия столбцов
                        Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                        while (reader.Read()) // построчно считываем данные
                        {
                            object id = reader.GetValue(0);
                            object name = reader.GetValue(1);
                            object age = reader.GetValue(2);

                            Console.WriteLine("{0} \t{1} \t{2}", id, name, age);
                        }
                    }

                    reader.Close();
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
