using DemoApp.API.Dto;

namespace DemoApp.API.Services.Interfaces
{
    public interface IExcelFileProcessor
    {
        IEnumerable<AddCategoryRequestDto> GetCategories(IFormFile file);
}



}
