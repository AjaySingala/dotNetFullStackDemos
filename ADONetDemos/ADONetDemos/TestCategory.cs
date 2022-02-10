using ADONetDemos.BL;
using ADONetDemos.Entities;
using ADONetDemos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Simulate a Test.
namespace ADONetDemos
{
    public class TestCategory
    {
        CategoryBL _categoryBL;

        public void TestGetById(int id)
        {
            Console.WriteLine("Entering TestCategory.TestGetById...");

            _categoryBL = new CategoryBL(new CategoryRepositoryTest());
            Category category = _categoryBL.Get(id);
            if (category == null)
            {
                Console.WriteLine($"{id} is not a category");
            }
            else
            {
                Console.WriteLine($"Category Id: {category.Categoryid}, Name: {category.CategoryName}");
            }

            Console.WriteLine("Exiting TestCategory.TestGetById...");

        }
    }
}
