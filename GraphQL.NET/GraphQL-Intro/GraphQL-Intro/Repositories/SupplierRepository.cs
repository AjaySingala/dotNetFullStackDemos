using GraphQL_Intro.Models;
using GraphQL_Intro.Repositories.Interfaces;

namespace GraphQL_Intro.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly List<Supplier> suppliers = new List<Supplier>
        {
            new Supplier
            {
                Id = 1,
                FirstName = "Steve",
                LastName = "Smith",
                Address = "USA",
                Phone = "1111111111",
                Email = "test@xyz.com"
            },
            new Supplier
            {
                Id = 2,
                FirstName = "Michael",
                LastName = "Foster",
                Address = "USA",
                Phone = "2222222222",
                Email = "abc@test.com"
            },
            new Supplier
            {
                Id = 3,
                FirstName = "Anand",
                LastName = "Shah",
                Address = "India",
                Phone = "9999999999",
                Email = "xyz@abc.com"
            }
        };

        public async Task<List<Supplier>> GetSuppliers()
        {
            return await Task.FromResult(suppliers);
        }

        public async Task<Supplier> GetSupplier(int Id)
        {
            return await Task.FromResult(suppliers.FirstOrDefault(x => x.Id == Id));
        }
    }
}
