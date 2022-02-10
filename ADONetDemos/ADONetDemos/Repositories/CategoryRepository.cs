using ADONetDemos.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetDemos.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly string _connString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=Northwind;"
            + "Integrated Security=true";

        public void Create(Category category)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                StringBuilder qry = new StringBuilder();
                qry.Append(" SELECT CategoryID, CategoryName, Description FROM Categories");
                qry.Append($" WHERE CategoryID = {id}");

                SqlCommand cmd = new SqlCommand(qry.ToString(), connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Category category = new Category();
                    category.Categoryid = reader.GetInt32(0);
                    category.CategoryName = reader["CategoryName"].ToString();
                    category.Descriptipon = reader["Description"].ToString();

                    return category;
                }
                reader.Close();
                cmd.Dispose();
            }
            return null;
        }
    }
}
