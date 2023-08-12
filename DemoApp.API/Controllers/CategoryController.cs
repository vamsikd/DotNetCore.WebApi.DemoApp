using DemoApp.API.Dto;
using DemoApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categorySvc;
        public CategoryController(ICategoryService categoryService)
        {
            this._categorySvc = categoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryResponseDto>> GetAll()
        {
            var categories = _categorySvc.GetAll();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddCategoryRequestDto category)
        {
            var categoryId = _categorySvc.Add(category);
            return Ok(categoryId);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateCategoryRequestDto category)
        {
            bool Updated = _categorySvc.Update(category);
            return Ok($"Successfully Updated {category.Name}");
        }

        [HttpDelete]
        [Route("{categoryId}")]
        public IActionResult Delete([FromRoute] int categoryId)
        {
            bool deleted = _categorySvc.Delete(categoryId);
            return Ok($"Successfully Deleted {categoryId}");
        }

        [HttpGet]
        [Route("{categoryId}")]
        public ActionResult<CategoryResponseDto> Get([FromRoute] int categoryId)
        {
            CategoryResponseDto responseDto = _categorySvc.Get(categoryId);
            return Ok(responseDto);

        }

    }
}
