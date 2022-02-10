using ADONetDemos;
using ADONetDemos.BL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.WriteLine(CultureInfo.CurrentCulture);
        CultureInfo.CurrentCulture = new CultureInfo("en-US"); ;
        Console.WriteLine(CultureInfo.CurrentCulture);

        string connectionString =
            @"Data Source=(local)\SQLEXPRESS;Initial Catalog=Northwind;"
            + "Integrated Security=true";

        //GetProductForPricePoint(connectionString);

        //Console.WriteLine();
        //GetSalesByCategory(connectionString, "Beverages");
        //Console.WriteLine();

        //InsertProductCategory(connectionString, "New Category");
        //Console.WriteLine();

        //var id = AddProductCategory(connectionString, "Blah");
        //Console.WriteLine($"ID of the new Product Category record is {id}");
        //Console.WriteLine();

        //GetCustomerUsingDataSet(connectionString);
        //Console.WriteLine();

        //GetDataFromMultipleDataAdapters(connectionString);
        //Console.WriteLine();

        //TxnManagement(connectionString);
        //Console.WriteLine();

        //InsertCategoryUsingStoredProc(connectionString);
        //Console.WriteLine();

        // Repository and Unit of Work Design Pattern Examples.
        GetCategoryById(1);
        GetCategoryById(999);
        Console.WriteLine();

        TestGetCategoryById();
        Console.WriteLine();

        Console.Write("Press <ENTER> to continue...");
        Console.ReadLine();
    }

    #region Repository and Unit of Work Design Pattern Examples.

    static void TestGetCategoryById()
    {
        Console.WriteLine("Getting Category by Id (Repo Pattern)...");

        var test = new TestCategory();
        test.TestGetById(1);
        Console.WriteLine();

        test.TestGetById(999);
        Console.WriteLine();

        Console.WriteLine("Done getting Category by Id (Repo Pattern)...");
    }

    static void GetCategoryById(int id)
    {
        Console.WriteLine("Getting Category by Id using BL...");
        var bl = new CategoryBL();
        var category = bl.Get(id);
        if (category == null)
        {
            Console.WriteLine($"{id} is not a category");
        }
        else
        {
            Console.WriteLine($"Category Id: {category.Categoryid}, Name: {category.CategoryName}");
        }
        Console.WriteLine("Done getting Category by Id using BL...");
    }

    #endregion


    static void GetProductForPricePoint(string connectionString)
    {
        Console.WriteLine("Getting Products for price point...");

        // Provide the query string with a parameter placeholder.
        string queryString =
            "SELECT ProductID, UnitPrice, ProductName from dbo.products "
                + "WHERE UnitPrice > @pricePoint "
                + "ORDER BY UnitPrice DESC;";

        // Specify the parameter value.
        int paramValue = 5;

        // Create and open the connection in a using block. This
        // ensures that all resources will be closed and disposed
        // when the code exits.
        using (SqlConnection connection =
            new SqlConnection(connectionString))
        {
            // Create the Command and Parameter objects.
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("@pricePoint", paramValue);

            // Open the connection in a try/catch block.
            // Create and execute the DataReader, writing the result
            // set to the console window.
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}",
                        reader[0], reader[1], reader[2]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Done getting Products for price point...");
        }
    }

    static void GetSalesByCategory(string connectionString, string categoryName)
    {
        Console.WriteLine("Getting Sales By Category via Stored Proc...");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Create the command and set its properties.
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SalesByCategory";
            command.CommandType = CommandType.StoredProcedure;

            // Add the input parameter and set its properties.
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@CategoryName";
            parameter.SqlDbType = SqlDbType.NVarChar;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = categoryName;

            // Add the parameter to the Parameters collection.
            command.Parameters.Add(parameter);

            // Open the connection and execute the reader.
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}: {1:C}", reader[0], reader[1]);
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
        }
        Console.WriteLine("Done getting Sales By Category via Stored Proc...");
    }

    static int AddProductCategory(string connString, string newName)
    {
        Console.WriteLine("Getting ID of the new record just created...");

        Int32 newProdID = 0;
        string sql =
            "INSERT INTO Categories(CategoryName, Description) VALUES (@Name, @Desc); "
            + "SELECT CAST(scope_identity() AS int)";
        using (SqlConnection conn = new SqlConnection(connString))
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            cmd.Parameters.Add("@Desc", SqlDbType.VarChar);
            cmd.Parameters["@name"].Value = newName;
            cmd.Parameters["@desc"].Value = newName;
            try
            {
                conn.Open();
                newProdID = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine("Done getting ID of the new record just created...");
        return (int)newProdID;
    }

    static void InsertProductCategory(string connString, string newName)
    {
        Console.WriteLine("Inserting a new Product Category...");

        string sql =
            "INSERT INTO Categories(CategoryName, Description) VALUES (@Name, @Desc)";
        using (SqlConnection conn = new SqlConnection(connString))
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            cmd.Parameters.Add("@Desc", SqlDbType.VarChar);
            cmd.Parameters["@name"].Value = newName;
            cmd.Parameters["@desc"].Value = newName;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        Console.WriteLine("Done Inserting a new Product Category...");
    }

    static void GetCustomerUsingDataSet(string connString)
    {
        Console.WriteLine("Getting Customer data...");

        string queryString =
            "SELECT CustomerID, CompanyName FROM dbo.Customers";
        SqlDataAdapter adapter = new SqlDataAdapter(queryString, connString);

        //// OR use this approach:
        //SqlConnection conn = new SqlConnection(connString);
        //SqlDataAdapter adapter = new SqlDataAdapter(queryString, conn);

        DataSet customers = new DataSet();
        adapter.Fill(customers, "Customers");
        foreach (DataRow row in customers.Tables["Customers"].Rows)
        {
            string id = (string)row["CustomerId"];
            string company = (string)row["CompanyName"];
            Console.WriteLine($"{id} : {company}");
        }
        Console.WriteLine("Done getting Customer data...");
    }

    static void GetDataFromMultipleDataAdapters(string connString)
    {
        Console.WriteLine("Getting data from Customers and Orders...");

        SqlConnection conn = new SqlConnection(connString);

        string customerQueryString = "SELECT * FROM dbo.Customers";
        string orderQueryString = "SELECT * FROM dbo.Orders";

        SqlDataAdapter custAdapter = new SqlDataAdapter(customerQueryString, conn);
        SqlDataAdapter ordAdapter = new SqlDataAdapter(orderQueryString, conn);

        DataSet customerOrders = new DataSet();

        custAdapter.Fill(customerOrders, "Customers");
        ordAdapter.Fill(customerOrders, "Orders");

        DataRelation relation = customerOrders.Relations.Add("CustOrders",
          customerOrders.Tables["Customers"].Columns["CustomerID"],
          customerOrders.Tables["Orders"].Columns["CustomerID"]);

        foreach (DataRow pRow in customerOrders.Tables["Customers"].Rows)
        {
            Console.WriteLine(pRow["CustomerID"]);
            foreach (DataRow cRow in pRow.GetChildRows(relation))
                Console.WriteLine("\t" + cRow["OrderID"]);
        }
        Console.WriteLine("Done getting data from Customers and Orders...");
    }

    static void TxnManagement(string connString)
    {
        using (SqlConnection connection = new SqlConnection(connString))
        {
            connection.Open();

            // Start a local transaction.
            SqlTransaction sqlTran = connection.BeginTransaction();

            // Enlist a command in the current transaction.
            SqlCommand command = connection.CreateCommand();
            command.Transaction = sqlTran;

            try
            {
                // Execute two separate commands.
                command.CommandText =
                  "INSERT INTO Customers(CustomerId, CompanyName) VALUES('TEST1', 'Test Txn Company')";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO Orders(OrderId, CustomerId) VALUES(999, 'ABCDZ')";
                //command.CommandText = "INSERT INTO Orders(CustomerId) VALUES('ABCDZ')";
                command.ExecuteNonQuery();

                // Commit the transaction.
                sqlTran.Commit();
                Console.WriteLine("Both records were written to database.");
            }
            catch (Exception ex)
            {
                // Handle the exception if the transaction fails to commit.
                Console.WriteLine(ex.Message);

                try
                {
                    // Attempt to roll back the transaction.
                    sqlTran.Rollback();
                }
                catch (Exception exRollback)
                {
                    // Throws an InvalidOperationException if the connection
                    // is closed or the transaction has already been rolled
                    // back on the server.
                    Console.WriteLine(exRollback.Message);
                }
            }
        }

    }

    static void InsertCategoryUsingStoredProc(string connString)
    {
        using (SqlConnection connection = new SqlConnection(connString))
        {
            // Create a SqlDataAdapter based on a SELECT query.
            SqlDataAdapter adapter = 
                new SqlDataAdapter("SELECT CategoryID, CategoryName FROM dbo.Categories", 
                connection);

            // Create a SqlCommand to execute the stored procedure.
            adapter.InsertCommand = new SqlCommand("InsertCategory", connection);
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

            // Create a parameter for the ReturnValue.
            SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@RowCount", SqlDbType.Int);
            parameter.Direction = ParameterDirection.ReturnValue;

            // Create an input parameter for the CategoryName.
            // You do not need to specify direction for input parameters.
            adapter.InsertCommand.Parameters.Add("@CategoryName", SqlDbType.NChar, 15, "CategoryName");

            // Create an output parameter for the new identity value.
            parameter = adapter.InsertCommand.Parameters.Add("@Identity", SqlDbType.Int, 0, "CategoryID");
            parameter.Direction = ParameterDirection.Output;

            // Create a DataTable and fill it.
            DataTable categories = new DataTable();
            adapter.Fill(categories);

            // Add a new row.
            DataRow categoryRow = categories.NewRow();
            categoryRow["CategoryName"] = "New Beverages";
            categories.Rows.Add(categoryRow);

            // Update the database.
            adapter.Update(categories);

            // Retrieve the ReturnValue.
            Int32 rowCount = (Int32)adapter.InsertCommand.Parameters["@RowCount"].Value;
            Int32 id= (Int32)adapter.InsertCommand.Parameters["@Identity"].Value;

            Console.WriteLine("ReturnValue (RowCount): {0}", rowCount.ToString());
            Console.WriteLine("Id: {0}", id.ToString());
            Console.WriteLine("All Rows:");
            foreach (DataRow row in categories.Rows)
            {
                Console.WriteLine("  {0}: {1}", row[0], row[1]);
            }
        }
    }
}