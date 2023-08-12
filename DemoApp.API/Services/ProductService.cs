using DemoApp.API.Data;
using DemoApp.API.Dto;
using DemoApp.API.Models;
using DemoApp.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;

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

        public bool Update(UpdateProductRequestDto productDto)
        {
            var product = _dbContext.Products
                .Include(p => p.ProductDetail)
                .FirstOrDefault(p => p.Id == productDto.Id);

            if (product == null)
                throw new Exception($"Product not found for Id {productDto.Id}");

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.UpdatedOn = DateTime.Now;
            product.ProductDetail.AvailableQuantity = productDto.AvailableQuantity;
            product.ProductDetail.Discount = productDto.Discount;
            product.ProductDetail.InStock = productDto.InStock;
            product.ProductDetail.IsActive = productDto.IsActive;
            product.ProductDetail.UpdatedOn = DateTime.Now;

            _dbContext.SaveChanges();

            return true;
        }

        bool IProductService.Delete(int productId)
        {
            var product = _dbContext.Products
               .Include(p => p.ProductDetail)
               .FirstOrDefault(p => p.Id == productId);

            if (product == null)
                throw new Exception($"Product not found for Id {productId}");

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return true;
        }

        ProductResponseDto IProductService.Get(int productId)
        {
            var product = _dbContext.Products
                .Include(p => p.ProductDetail)
                .FirstOrDefault(p => p.Id == productId);

            if (product == null)
                throw new Exception($"Product not found for Id {productId}");

            var productResponseDto = new ProductResponseDto();
            {
                productResponseDto.Id = productId;
                productResponseDto.Name = product.Name;
                productResponseDto.Description = product.Description;
                productResponseDto.Price = product.Price;
                productResponseDto.AvailableQuantity = product.ProductDetail.AvailableQuantity;
                productResponseDto.Discount = product.ProductDetail.Discount;
                productResponseDto.InStock = product.ProductDetail.InStock;
                productResponseDto.IsActive = product.ProductDetail.IsActive;
                productResponseDto.CreatedOn = product.CreatedOn;
                productResponseDto.UpdatedOn = product.UpdatedOn;

            };
            return productResponseDto;
        }

        List<ProductResponseDto> IProductService.GetAll()
        {
            var products = _dbContext.Products
                .Include(p => p.ProductDetail)
                .ToList();
            var productResponseDtoList = products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                AvailableQuantity = p.ProductDetail.AvailableQuantity,
                Discount = p.ProductDetail.Discount,
                InStock = p.ProductDetail.InStock,
                IsActive = p.ProductDetail.IsActive,
                CreatedOn = p.CreatedOn,
                UpdatedOn = p.UpdatedOn

            })
                .ToList();
            return productResponseDtoList;
        }
    }
}
