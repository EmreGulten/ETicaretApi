using ETicaret.Core.Utilities.Abstract;
using ETicaret.Entities.Concrete;
using ETicaret.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Business.Repositories.ProductRepository
{
    public interface IProductService
    {
        Task<IResult> Add(Product product);
        Task<IResult> Update(Product product);
        Task<IResult> Delete(Product product);
        Task<IDataResult<List<ProductDto>>> GetList();
        Task<IDataResult<List<ProductDto>>> GetProductList(int id);
        Task<IDataResult<Product>> GetById(int id);
    }
}
