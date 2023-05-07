using FoodTrack.Services.ProductAPI.Models.Dto;

namespace FoodTrack.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductsById(int ProductId);
        Task<ProductDto> CreateUpdate(ProductDto productDto);
        Task<bool> DeleteProduct(int ProductId);
    }
}

