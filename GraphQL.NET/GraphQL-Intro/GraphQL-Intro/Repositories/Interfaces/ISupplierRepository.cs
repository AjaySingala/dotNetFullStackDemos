using GraphQL_Intro.Models;

namespace GraphQL_Intro.Repositories.Interfaces
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetSuppliers();
        Task<Supplier> GetSupplier(int Id);
    }
}
