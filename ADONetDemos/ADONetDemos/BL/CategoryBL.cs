using ADONetDemos.Entities;
using ADONetDemos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetDemos.BL
{
    public class CategoryBL
    {
        readonly ICategoryRepository _repo; 
        public CategoryBL()
        {
            _repo = new CategoryRepository();
        }

        public CategoryBL(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public Category Get(int id)
        {
            var category = _repo.GetById(id);
            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            var categories = _repo.GetAll();
            return categories;
        }
    }
}
