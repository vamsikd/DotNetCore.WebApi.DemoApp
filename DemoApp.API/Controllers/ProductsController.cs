using DemoApp.API.Dto;
using DemoApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productSvc;
        public ProductsController(IProductService productService)
        {
            this._productSvc = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductResponseDto>> GetAll()
        {
            var products = _productSvc.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddProductRequestDto product)
        {
            var productId = _productSvc.Add(product);
            return Ok(productId);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateProductRequestDto product)
        {
            bool Updated = _productSvc.Update(product);
            return Ok($"Successfully Updated {product.Name}");
        }

        [HttpDelete]
        [Route("{productId}")]
        public IActionResult Delete([FromRoute] int productId)
        {
            bool deleted = _productSvc.Delete(productId);
            return Ok($"Successfully Deleted {productId}");
        }

        [HttpGet]
        [Route("{productId}")]
        public ActionResult<ProductResponseDto> Get([FromRoute] int productId)
        {
            ProductResponseDto responseDto = _productSvc.Get(productId);
            return Ok(responseDto);

        }

    }
}
