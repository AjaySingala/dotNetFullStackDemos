using ADONetDemos.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetDemos.Repositories
{
    public class CategoryRepositoryTest : ICategoryRepository
    {
        private IList<Category> _categories = new List<Category>();

        public CategoryRepositoryTest()
        {
            _categories.Add(new Category()
            {
                Categoryid = 1,
                CategoryName = "Category 1",
                Descriptipon = "Category Desc 1"
            });
            _categories.Add(new Category()
            {
                Categoryid = 2,
                CategoryName = "Category 2",
                Descriptipon = "Category Desc 3"
            });
            _categories.Add(new Category()
            {
                Categoryid = 3,
                CategoryName = "Category 3",
                Descriptipon = "Category Desc 3"
            });
        }

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
            Console.WriteLine("Entering CategoryRepositoryTest.GetById...");

            var category = _categories.FirstOrDefault(c => c.Categoryid == id);

            Console.WriteLine("Exiting CategoryRepositoryTest.GetById...");
            return category;
        }
    }
}
