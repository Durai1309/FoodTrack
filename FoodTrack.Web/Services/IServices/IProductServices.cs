using FoodTrack.Web.Models;

namespace FoodTrack.Web.Services.IServices
{
    public interface IProductServices : IBaseSevices
    {
        Task<T> GetAllProductAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductTAsync<T>(ProductDto productDto);
        Task<T> UpdateProductTAsync<T>(ProductDto ProductDto);
        Task<T> DeleteProductTAsync<T>(int id);
    }
}
