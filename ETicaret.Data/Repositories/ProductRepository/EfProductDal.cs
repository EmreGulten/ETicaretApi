using ETicaret.Core.DataAccess.EntityFramework;
using ETicaret.Data.Concrete.EntityFramework;
using ETicaret.Entities.Concrete;
using ETicaret.Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Repositories.ProductRepository
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ContextDb>, IProductDal
    {
        public async Task<List<ProductDto>> GetList()
        {
            using (var context = new ContextDb())
            {
                var result = from product in context.Products
                             select new ProductDto
                             {
                                 Id = product.Id,
                                 Name = product.Name,
                                 MainImageUrl = (context.ProductImages.Where(x => x.ProductId == product.Id && x.IsMainImage == true).Count() > 0
                                                ? context.ProductImages.Where(x => x.ProductId == product.Id && x.IsMainImage == true).Select(p => p.ImageUrl).FirstOrDefault()
                                                : "")
                             };
                return await result.OrderBy(p => p.Name).ToListAsync();
            }
        }

        public async Task<List<ProductDto>> GetProductList(int id)
        {
            using (var context = new ContextDb() )
            {
                if (id != 0)
                {
                    var customerRelationship = context.CustomerRelationships.Where(x => x.CustomerId == id).SingleOrDefault();

                    var result = from product in context.Products
                                 select new ProductDto
                                 {
                                     Id = product.Id,
                                     Name = product.Name,
                                     Discount = customerRelationship.Discount,
                                     Price = context.PriceListDetails.Where(x => x.PriceListId == customerRelationship.PriceListId && x.ProductId == product.Id).Count() > 0
                                             ? context.PriceListDetails.Where(x => x.PriceListId == customerRelationship.PriceListId && x.ProductId == product.Id).Select(c => c.Price).FirstOrDefault() : 0,
                                     MainImageUrl = (context.ProductImages.Where(p => p.ProductId == product.Id && p.IsMainImage == true).Count() > 0
                                                    ? context.ProductImages.Where(p => p.ProductId == product.Id && p.IsMainImage == true).Select(s => s.ImageUrl).FirstOrDefault()
                                                    : ""),
                                     Images = context.ProductImages.Where(x => x.ProductId == product.Id).Select(s => s.ImageUrl).ToList()
                                 };
                    return await result.OrderBy(p => p.Name).ToListAsync();
                }
                else
                {
                    var result = from product in context.Products
                                 select new ProductDto
                                 {
                                     Id = product.Id,
                                     Name = product.Name,
                                     Discount = 0,
                                     Price = 0,
                                     MainImageUrl = (context.ProductImages.Where(x => x.ProductId == product.Id && x.IsMainImage == true).Count() > 0
                                                    ? context.ProductImages.Where(x => x.ProductId == product.Id && x.IsMainImage == true).Select(s => s.ImageUrl).FirstOrDefault()
                                                    : ""),
                                     Images = context.ProductImages.Where(x => x.ProductId == product.Id).Select(s => s.ImageUrl).ToList()
                                 };
                    return await result.OrderBy(p => p.Name).ToListAsync();
                }
            }
        }
    }
}
