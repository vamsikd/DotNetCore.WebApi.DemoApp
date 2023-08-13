using DemoApp.API.Dto;
using DemoApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categorySvc;
        private readonly IExcelFileProcessor _excelReader;

        public CategoriesController(ICategoryService categoryService, IExcelFileProcessor excelReader)
        {
            _categorySvc = categoryService;
            _excelReader = excelReader;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryResponseDto>> GetAll()
        {
            var categories = _categorySvc.GetAll();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddCategoryRequestDto category)
        {
            var categoryId = _categorySvc.Add(category);
            return Ok(categoryId);
        }

        [HttpPost]
        [Route("upload")]
        public IActionResult Add(IFormFile categoryFile)
        {
            if (categoryFile is null || categoryFile.Length == 0)
                return BadRequest("Invalid File");
                    
            var categories = _excelReader.GetCategories(categoryFile);
            var isSuccess = _categorySvc.UpdateOrAddRange(categories);
            return Ok(isSuccess);
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
