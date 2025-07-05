using Microsoft.Data.SqlClient;
using System.Data;

namespace SqlInjectionSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Search in producs : ");
            string ?input = Console.ReadLine();


            // Simulate a SQL injection vulnerability
            string connectionString = """
            Data Source = .; Initial Catalog = ShopTestDB ; User ID = sa ; Password = amin5123;
            Encrypt=False;
            """;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand searchCommand = new SqlCommand($"""
                SELECT * FROM Products WHERE ProductName LIKE '%{input}%'       
                """, connection);                                         //Search Command with risk of injection


            SqlCommand safeSearchCommand = new SqlCommand("""
                SELECT * FROM Products WHERE ProductName LIKE @input       
                """, connection);

            safeSearchCommand.CommandType = CommandType.Text;
            safeSearchCommand.Parameters.AddWithValue("@input", $"%{input}%"); // Safe parameterized query

            connection.Open();

            //SqlDataReader reader = searchCommand.ExecuteReader();
            SqlDataReader SafeReader = safeSearchCommand.ExecuteReader();
            while (SafeReader.Read())
            {
                Console.WriteLine($"Product: {SafeReader["ProductName"]}, Category: {SafeReader["ProductCategory"]}");
            }
            connection.Close();


            // Note: This code is intentionally vulnerable to SQL injection for educational purposes.
            // In a real application, you should use parameterized queries to prevent SQL injection attacks.
            // what if user input is : sam'; DELETE FROM Users ; --'
            // The above input would result in a SQL command that deletes all users from the Users table.
        }
    }
}
