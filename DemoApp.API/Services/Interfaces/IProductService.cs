using DemoApp.API.Dto;

namespace DemoApp.API.Services.Interfaces
{
    public interface IProductService
    {
        int Add(AddProductRequestDto product);
        bool Update(UpdateProductRequestDto product);
        bool Delete(int productId);
        ProductResponseDto Get(int productId);
        IEnumerable<ProductResponseDto> GetAll();
        int ArchiveInActiveProducts();
        IEnumerable<ArchivedProductResponseDto> GetArchivedProducts();

    }
}
