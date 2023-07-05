using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DbDemoCoreConfig
{
    internal class Program
    {
        static IConfigurationRoot config;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // Build a config object, using env vars and JSON providers.
            config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            //ReadConfig();
            MultipleResultSets();
            //InjectionDemo();
            //PreventInjectionDemo();
            //CreateCustomerSP();
            //fCreateEmployeeSP();
            //GetEmployeesSP();
        }

        static void ReadConfig()
        {
            Console.WriteLine();
            Console.WriteLine("ReadConfig()...");

            Settings settings = config.GetRequiredSection("Settings").Get<Settings>();
            // Write the values to the console.
            Console.WriteLine($"KeyOne = {settings?.KeyOne}");
            Console.WriteLine($"KeyTwo = {settings?.KeyTwo}");
            Console.WriteLine($"KeyThree:Message = {settings?.KeyThree?.Message}");

            var connStrN = config.GetConnectionString("northwind");
            var connStrP = config.GetConnectionString("pubs");
            Console.WriteLine($"Northwind Connection String: {connStrN}");
            Console.WriteLine($"Pubs Connection String: {connStrP}");

            var ipOne = config["IPAddressRange:0"];
            Console.WriteLine($"{ipOne}");
            Console.WriteLine($"{config["IPAddressRange:1"]}");
            Console.WriteLine($"{config["IPAddressRange:2"]}");
        }

        static void MultipleResultSets()
        {
            Console.WriteLine();
            Console.WriteLine("MultipleResultSets()...");

            var connStr = config.GetConnectionString("northwind");

            SqlConnection sqlConnection = new SqlConnection(connStr);
            StringBuilder qry = new StringBuilder();
            qry.Append(" SELECT * FROM Customers;");
            qry.Append(" SELECT * FROM Employees");

            SqlCommand cmd = new SqlCommand(qry.ToString(), sqlConnection);
            sqlConnection.Open();

            Console.WriteLine("Customers....");
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["CustomerId"]}" +
                    $" | {reader["CompanyName"]}" +
                    $" | {reader["ContactName"]}");
            }

            reader.NextResult();
            Console.WriteLine();
            Console.WriteLine("Employees....");
            while (reader.Read())
            {
                Console.WriteLine($"{reader["EmployeeId"]}" +
                    $" | {reader["LastName"]}" +
                    $" | {reader["FirstName"]}");
            }

            reader.Close();
            sqlConnection.Close();
        }

        // ENTER THIS: London’; DELETE FROM Dummy --
        static void InjectionDemo()
        {
            Console.WriteLine();
            Console.WriteLine("InjectionDemo()...");

            var connStr = config.GetConnectionString("northwind");

            Console.Write("Enter a city: ");
            string city = Console.ReadLine();

            SqlConnection sqlConnection = new SqlConnection(connStr);
            StringBuilder qry = new StringBuilder();
            qry.Append(" SELECT CustomerId, CompanyName, ContactName, City");
            qry.Append($" FROM Customers");
            qry.Append($" WHERE City = '{city}'");

            SqlCommand cmd = new SqlCommand(qry.ToString(), sqlConnection);
            sqlConnection.Open();

            var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine($"{reader["CustomerId"]}" +
                    $" | {reader["CompanyName"]}" +
                    $" | {reader["ContactName"]}");
            }
            reader.Close();
            sqlConnection.Close();
        }

        static void PreventInjectionDemo()
        {
            Console.WriteLine();
            Console.WriteLine("PreventInjectionDemo()...");

            var connStr = config.GetConnectionString("northwind");

            Console.Write("Enter a city: ");
            string city = Console.ReadLine();

            SqlConnection sqlConnection = new SqlConnection(connStr);
            StringBuilder qry = new StringBuilder();
            qry.Append(" SELECT CustomerId, CompanyName, ContactName, City");
            qry.Append($" FROM Customers");
            qry.Append($" WHERE City = @City");

            SqlCommand cmd = new SqlCommand(qry.ToString(), sqlConnection);
            cmd.Parameters.AddWithValue("@City", city);
            cmd.CommandType = System.Data.CommandType.Text;

            sqlConnection.Open();

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["CustomerId"]}" +
                    $" | {reader["CompanyName"]}" +
                    $" | {reader["ContactName"]}");
            }
            reader.Close();
            sqlConnection.Close();
        }

        static void CreateCustomerSP()
        {
            Console.WriteLine();
            Console.WriteLine("CreateCustomerSP()...");

            var connStr = config.GetConnectionString("northwind");

            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandText = "spCreateCustomer";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            
            cmd.Parameters.Clear();

            cmd.Parameters.Add(new SqlParameter("@customerId", System.Data.SqlDbType.NChar));
            cmd.Parameters["@customerId"].Value = "ABCRP";

            cmd.Parameters.Add(new SqlParameter("@companyName", System.Data.SqlDbType.NVarChar));
            cmd.Parameters["@companyName"].Value = "ABC Corp.";

            cmd.Parameters.Add(new SqlParameter("@contactName", System.Data.SqlDbType.NVarChar));
            cmd.Parameters["@contactName"].Value = "James Sully";

            sqlConnection.Open();
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

        static void CreateEmployeeSP()
        {
            Console.WriteLine();
            Console.WriteLine("CreateEmplolyeeSP()...");

            var connStr = config.GetConnectionString("northwind");

            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandText = "spCreateEmployee";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Clear();

            cmd.Parameters.Add(new SqlParameter("@fname", System.Data.SqlDbType.NVarChar));
            cmd.Parameters["@fname"].Value = "Mary";

            cmd.Parameters.Add(new SqlParameter("@lname", System.Data.SqlDbType.NVarChar));
            cmd.Parameters["@lname"].Value = "Jane";

            sqlConnection.Open();
            var id = cmd.ExecuteScalar();
            Console.WriteLine($"Employee with ID {id} created...");

            sqlConnection.Close();
        }

        static void GetEmployeesSP()
        {
            Console.WriteLine();
            Console.WriteLine("GetEmployeesSP()...");

            var connStr = config.GetConnectionString("northwind");

            using (SqlConnection sqlConnection = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployees", sqlConnection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                sqlConnection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["EmployeeID"]}" +
                        $"| {reader["LastName"]}" +
                        $", {reader["FirstName"]}");
                }
                reader.Close();
            }

        }

    }
}