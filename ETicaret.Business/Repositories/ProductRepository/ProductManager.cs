using ETicaret.Business.Repositories.ProductRepository.Constants;
using ETicaret.Core.Utilities.Abstract;
using ETicaret.Core.Utilities.Concrete;
using ETicaret.Data.Repositories.ProductRepository;
using ETicaret.Entities.Concrete;
using ETicaret.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Business.Repositories.ProductRepository
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public async Task<IResult> Add(Product product)
        {
            await _productDal.Add(product);
            return new SuccessResult(ProductMessages.Added);
        }

        public async Task<IResult> Delete(Product product)
        {
            await _productDal.Delete(product);
            return new SuccessResult(ProductMessages.Deleted);
        }

        public async Task<IDataResult<Product>> GetById(int id)
        {
            return new SuccessDataResult<Product>(await _productDal.Get(x => x.Id == id));
        }

        public async Task<IDataResult<List<ProductDto>>> GetList()
        {
            return new SuccessDataResult<List<ProductDto>>(await _productDal.GetList());
        }

        public async Task<IDataResult<List<ProductDto>>> GetProductList(int id)
        {
            return new SuccessDataResult<List<ProductDto>>(await _productDal.GetProductList(id));
        }

        public async Task<IResult> Update(Product product)
        {
            await _productDal.Update(product);
            return new SuccessResult(ProductMessages.Updated);
        }
    }
}
