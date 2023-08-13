using DemoApp.API.Dto;

namespace DemoApp.API.Services.Interfaces
{
    public interface ICategoryService
    {
        int Add(AddCategoryRequestDto category);
        bool UpdateOrAddRange(IEnumerable<AddCategoryRequestDto> categories);
        bool Update(UpdateCategoryRequestDto category);
        bool Delete(int categoryId);
        CategoryResponseDto Get(int categoryId);
        IEnumerable<CategoryResponseDto> GetAll();
    }
}
