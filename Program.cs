using Microsoft.Data.SqlClient;

namespace SqlInjectionSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Search in producs : ");
            string input = Console.ReadLine();


            // Simulate a SQL injection vulnerability
            string connectionString = """
            Data Source = .; Initial Catalog = ShopTestDB ; User ID = sa ; Password = amin5123;
            Encrypt=False;
            """;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand searchCommand = new SqlCommand($"""
                SELECT * FROM Products WHERE ProductName LIKE '%{input}%'
                """, connection);


            connection.Open();

            SqlDataReader reader = searchCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Product: {reader["ProductName"]}, Category: {reader["ProductCategory"]}");
            }
            connection.Close();
        }
    }
}
