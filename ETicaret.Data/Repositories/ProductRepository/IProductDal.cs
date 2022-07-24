using ETicaret.Core.DataAccess;
using ETicaret.Entities.Concrete;
using ETicaret.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Repositories.ProductRepository
{
    public interface IProductDal : IEntityRepository<Product>
    {
        Task<List<ProductDto>> GetList();
        Task<List<ProductDto>> GetProductList(int id);
    }
}
