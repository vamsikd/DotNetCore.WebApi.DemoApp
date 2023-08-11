using DemoApp.API.Dto;

namespace DemoApp.API.Services.Interfaces
{
    public interface IProductService
    {
        string Add(AddProductRequestDto product);
    }
}
