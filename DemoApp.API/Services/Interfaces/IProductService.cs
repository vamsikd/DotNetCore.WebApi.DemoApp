using DemoApp.API.Dto;

namespace DemoApp.API.Services.Interfaces
{
    public interface IProductService
    {
        int Add(AddProductRequestDto product);
    }
}
