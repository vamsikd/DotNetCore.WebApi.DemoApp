using DemoApp.API.Data;
using DemoApp.API.Dto;
using DemoApp.API.Models;
using DemoApp.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.API.Services
{
    public class ProductService : IProductService
    {
        private DemoAppDbContext _dbContext;
        public ProductService(DemoAppDbContext context)
        {
            _dbContext = context;
        }

      public int Add(AddProductRequestDto productDto)
        {
            // map Dto to Model
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            var productDetail = new ProductDetail
            {
                AvailableQuantity = productDto.AvailableQuantity,
                Discount = productDto.Discount,
                InStock = productDto.InStock,
                IsActive = productDto.IsActive,
                ProductId = product.Id,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };
            _dbContext.ProductDetails.Add(productDetail);
            _dbContext.SaveChanges();
            return product.Id;
        }
    }
}
