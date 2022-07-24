using ETicaret.Data.Concrete.EntityFramework;
using ETicaret.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ContextDb _contextDb;

        public ProductsController(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var result = await _contextDb.Products.ToListAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            return await _contextDb.Products.FindAsync(id);
        }
    }
}
