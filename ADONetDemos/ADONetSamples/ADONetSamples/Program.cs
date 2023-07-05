using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DbDemo();
            //InjectionDemo();
            //PreventInjectionDemo();
            //CreateCustomerSP();
            //MultipleResultSets();
            DataSetDemo();
        }

        static void DbDemo()
        {
            //string connStr = @"Server=.\SQLEXPRESS;Initial Catalog=northwind;Integrated Security=true;";

            var connStr = ConfigurationManager.ConnectionStrings["northwind"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            string qry = "SELECT * FROM Customers";

            //SqlCommand cmd = sqlConnection.CreateCommand();
            //cmd.CommandText = qry;
            SqlCommand cmd = new SqlCommand(qry, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($" {reader.GetString(0)}" +
                    $" {reader.GetString(1)}" +
                    $" {reader.GetString(2)}"
                    );
            }
            reader.Close();
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM Employees", sqlConnection);
            SqlDataReader reader2 = cmd.ExecuteReader();

            sqlConnection.Close();
        }

        static void InjectionDemo()
        {
            Console.WriteLine();
            Console.WriteLine("InjectionDemo()...");

            Console.Write("Enter a city: ");
            string city = Console.ReadLine();

            var connStr = ConfigurationManager.ConnectionStrings["northwind"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connStr);
            string qry = " SELECT CustomerId, CompanyName, ContactName, City";
            qry += $" FROM Customers";
            qry += $" WHERE City = '{city}'";

            SqlCommand cmd = new SqlCommand(qry, sqlConnection);
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

        static void PreventInjectionDemo()
        {
            Console.WriteLine();
            Console.WriteLine("PreventInjectionDemo()...");

            var connStr = ConfigurationManager.ConnectionStrings["northwind"].ConnectionString;

            Console.Write("Enter a city: ");
            string city = Console.ReadLine();

            SqlConnection sqlConnection = new SqlConnection(connStr);
            //string qry = " SELECT CustomerId, CompanyName, ContactName, City";
            //qry += $" FROM Customers";
            //qry += $" WHERE City = @City";
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

            var connStr = ConfigurationManager.ConnectionStrings["northwind"].ConnectionString;

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

        static void MultipleResultSets()
        {
            Console.WriteLine();
            Console.WriteLine("MultipleResultSets()...");

            var connStr = ConfigurationManager.ConnectionStrings["northwind"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connStr);
            StringBuilder qry = new StringBuilder();
            //qry.Append(" INSERT INTO Customers (CustomerId, CompanyName)");
            //qry.Append(" VALUES('ABCDF', 'ABCDF');");
            qry.Append(" SELECT * FROM Customers");
            qry.Append(" SELECT * FROM Employees");

            SqlCommand cmd = new SqlCommand(qry.ToString(), sqlConnection);
            sqlConnection.Open();

            Console.WriteLine("Customers....");
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]}");
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

        static void DataSetDemo()
        {
            Console.WriteLine();
            Console.WriteLine("DataSetDemo()...");

            var connStr = ConfigurationManager.ConnectionStrings["northwind"].ConnectionString;
            var qry = "SELECT * FROM Customers";
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlDataAdapter adapter = new SqlDataAdapter(qry, sqlConnection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Customers");

            string qry2 = "SELECT * FROM Employees";
            SqlDataAdapter adapter2 = new SqlDataAdapter(qry2, sqlConnection);
            adapter2.Fill(ds, "Employees");

            foreach(var table in ds.Tables)
            {
                Console.WriteLine($"{table.ToString()}");
            }

            //DataTable tbl = ds.Tables[0];
            DataTable tbl = ds.Tables["Customers"];
            foreach(DataRow row in tbl.Rows)
            {
                Console.WriteLine($" {row["CustomerId"]}" +
                    $" | {row["CompanyName"]}" +
                    $" | {row["ContactName"]}");
            }

            DataTable tbl2 = ds.Tables["Employees"];
            foreach (DataRow row in tbl2.Rows)
            {
                Console.WriteLine($" {row["EmployeeId"]}" +
                    $" | {row["FirstName"]}" +
                    $" | {row["LastName"]}");
            }
        }
    }
}
