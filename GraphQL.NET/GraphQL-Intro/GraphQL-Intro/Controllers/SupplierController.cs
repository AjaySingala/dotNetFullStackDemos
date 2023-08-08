using GraphQL_Intro.Models;
using GraphQL_Intro.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL_Intro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ISupplierRepository _supplierRepository;
        public SupplierController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        [HttpGet("{id}")]
        public async Task<Supplier> GetSupplier(int id)
        {
            return await _supplierRepository.GetSupplier(id);
        }

        //[HttpGet("GetSuppliers")]
        public async Task<List<Supplier>> GetSuppliers()
        {
            return await _supplierRepository.GetSuppliers();
        }
    }
}
