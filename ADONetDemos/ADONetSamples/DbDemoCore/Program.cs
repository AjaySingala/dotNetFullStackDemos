using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DbDemoCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is DbDemoCore...");
            //CreateCustomer();
            //GetCustomers();
            GetOrders();
        }

        static void GetCustomers()
        {
            string connStr = @"Server=.\SQLEXPRESS;Initial Catalog=northwind;Integrated Security=true;";

            //var connStr = ConfigurationManager.ConnectionStrings["northwind"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            string qry = "SELECT CustomerID, ContactName, City, CompanyName FROM Customers";
            //SqlCommand cmd = sqlConnection.CreateCommand();
            //cmd.CommandText = qry;
            SqlCommand cmd = new SqlCommand(qry, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Customer> customers = new List<Customer>();

            while (reader.Read())
            {
                //Console.WriteLine($" {reader.GetString(0)}" +
                //    $" {reader.GetValue(1)}" +
                //    $" {reader.GetValue(2)}"
                //    );
                Customer cust = new Customer();
                //cust.CustomerId = reader.GetString(0);
                //cust.CompanyName = reader.GetString(1);
                //cust.ContactName = reader.GetValue(2).ToString();
                //cust.City = reader.GetString(3);
                //cust.someint = reader.GetInt32(3);
                //cust.someint = Convert.ToInt32(reader.GetValue(3));

                cust.CustomerId = reader["CustomerId"].ToString();
                cust.CompanyName = reader["CompanyName"].ToString();
                cust.ContactName = reader["ContactName"].ToString();
                cust.City = reader["City"].ToString();

                customers.Add(cust);
            }
            reader.Close();
            //SqlCommand cmd2 = new SqlCommand("SELECT * FROM Employees", sqlConnection);
            //SqlDataReader reader2 = cmd.ExecuteReader();

            sqlConnection.Close();

            foreach (Customer customer in customers)
            {
                Console.WriteLine($" {customer.CustomerId}," +
                    $" {customer.CompanyName}," +
                    $" {customer.ContactName}," +
                    $" {customer.City}"
                    );
            }
        }

        static void GetOrders()
        {
            string connStr = @"Server=.\SQLEXPRESS;Initial Catalog=northwind;Integrated Security=true;";

            //var connStr = ConfigurationManager.ConnectionStrings["northwind"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            string qry = "SELECT TOP 10 * FROM Orders";
            //SqlCommand cmd = sqlConnection.CreateCommand();
            //cmd.CommandText = qry;
            SqlCommand cmd = new SqlCommand(qry, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var dtStr = reader["OrderDate"].ToString();
                var dt = DateTime.Parse(dtStr);
                var freight = Convert.ToDecimal(reader["Freight"]);
                Console.WriteLine($" {Convert.ToInt32(reader["OrderId"])}" +
                    $", {dt}" +
                    $", {freight}"
                    );
            }
            reader.Close();
        }

        static void CreateCustomer()
        {
            string connStr = @"Server=.\SQLEXPRESS;Initial Catalog=northwind;Integrated Security=true;";

            //var connStr = ConfigurationManager.ConnectionStrings["northwind"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            //string qry = "INSERT INTO Customers";
            //qry += " (CustomerID, CompanyName, ContactName, City)";
            //qry += " VALUES('JHNSM', 'Acme Corp.', 'John Smith', 'Dallas')";

            string qry = "INSERT INTO Employees(Lastname, Firstname)";
            qry += " VALUES('Smith', 'John');";
            qry += " SELECT @@IDENTITY;";

            //string qry = "SELECT EmployeeID, Lastname, Firstname FROM Employees";
            //qry += " WHERE EmployeeId = 8;";

            //SqlCommand cmd = sqlConnection.CreateCommand();
            //cmd.CommandText = qry;
            SqlCommand cmd = new SqlCommand(qry, sqlConnection);
            //int rowsAffected = cmd.ExecuteNonQuery();
            //Console.WriteLine($"Created {rowsAffected} records...");

            int idOfNewRecord = Convert.ToInt32(cmd.ExecuteScalar());
            Console.WriteLine($"Id of the new record is {idOfNewRecord}...");

            sqlConnection.Close();
        }

    }
}