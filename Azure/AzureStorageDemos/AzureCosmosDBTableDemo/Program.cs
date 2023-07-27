// install-package Azure.Data.Tables

// Authenticate the client.
using Azure;
using Azure.Data.Tables;
using AzureCosmosDBTableDemo;

// Get the connection string.
Console.WriteLine();
Console.WriteLine("Getting connection string...");
var connectionString = Environment.GetEnvironmentVariable("COSMOS_CONNECTION_STRING");

// New instance of the TableClient class.
Console.WriteLine();
Console.WriteLine("Creating new instance of Table Service Client...");
TableServiceClient tableServiceClient = 
    new TableServiceClient(connectionString);

// Create a table.
Console.WriteLine();
Console.WriteLine("Creating table 'adventureworks'...");
// New instance of TableClient class referencing the server-side table
TableClient tableClient = tableServiceClient.GetTableClient(
    tableName: "adventureworks"
);

await tableClient.CreateIfNotExistsAsync();

// Create an item.
Console.WriteLine();
Console.WriteLine("Creating an item 'Ocean Surfboard'...");
// Create new item using composite key constructor.
var prod1 = new Product()
{
    RowKey = "68719518388",
    PartitionKey = "gear-surf-surfboards",
    Name = "Ocean Surfboard",
    Quantity = 8,
    Sale = true
};

// Add new item to server-side table.
await tableClient.AddEntityAsync<Product>(prod1);

// Get an item.
Console.WriteLine();
Console.WriteLine("Getting an item...");
// Read a single item from container.
var product = await tableClient.GetEntityAsync<Product>(
    rowKey: "68719518388",
    partitionKey: "gear-surf-surfboards"
);
Console.WriteLine();
Console.WriteLine("Single product:");
Console.WriteLine(product.Value.Name);

// Query items.
Console.WriteLine();
Console.WriteLine("Creating another item 'Sand Surfboard'...");
// Read multiple items from container.
var prod2 = new Product()
{
    RowKey = "68719518390",
    PartitionKey = "gear-surf-surfboards",
    Name = "Sand Surfboard",
    Quantity = 5,
    Sale = false
};

await tableClient.AddEntityAsync<Product>(prod2);

Console.WriteLine();
Console.WriteLine("Read/Query multiple items...");
Console.WriteLine("Multiple products:");
var products = tableClient.Query<Product>(x => x.PartitionKey == "gear-surf-surfboards");

foreach (var item in products)
{
    Console.WriteLine(item.Name);
}
