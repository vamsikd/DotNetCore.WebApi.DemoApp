using DemoApp.API.Dto;
using DemoApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace DemoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productSvc;
        public ProductsController(IProductService productService)
        {
            _productSvc = productService;
        }

        public IProductService ProductService { get; }

        [HttpGet]
        public ActionResult<List<ProductResponseDto>> GetAll() 
        {
            var products = new List<ProductResponseDto>
            {
                new ProductResponseDto
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Test",
                    Description = "Test",
                    Quantity = 1,
                    IsActive = true,
                    InStock = true
                }
            };

            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddProductRequestDto product) 
        {
            
            var productId = _productSvc.Add(product);

            return Ok();
        }
    }
}
