using FoodTrack.Web.Models;
using FoodTrack.Web.Services.IServices;
using Newtonsoft.Json.Linq;
using static FoodTrack.Web.StaticData;
using System;

namespace FoodTrack.Web.Services
{
    public class ProductService : BaseServices, IProductServices
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<T> CreateProductTAsync<T>(ProductDto productDto)
        {
            return await this.SentAsync<T>(new ApiRequestcs()
            {
                ApiType = StaticData.ApiType.POST,
                Data = productDto,
                ApiUrl = StaticData.ProductAPIBase + "/api/products",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteProductTAsync<T>(int id)
        {
            return await this.SentAsync<T>(new ApiRequestcs()
            {
                ApiType = StaticData.ApiType.DELETE,
                ApiUrl = StaticData.ProductAPIBase + "/api/products" + id,
                AccessToken = ""

            });
        }
        public async Task<T> GetAllProductAsync<T>()
        {
            return await this.SentAsync<T>(new ApiRequestcs()
            {
                ApiType = StaticData.ApiType.GET,
                ApiUrl = StaticData.ProductAPIBase + "/api/products",
                AccessToken = ""
            
        });
        }
        public async Task<T> GetProductByIdAsync<T>(int id)
        {
            return await this.SentAsync<T>(new ApiRequestcs()
            {
                ApiType = StaticData.ApiType.GET,
                ApiUrl = StaticData.ProductAPIBase + "/api/products" + id,
                AccessToken = ""

            });
        }
        public async Task<T> UpdateProductTAsync<T>(ProductDto ProductDto)
        {
            return await this.SentAsync<T>(new ApiRequestcs()
            {
                ApiType = StaticData.ApiType.PUT,
                Data = ProductDto,
                ApiUrl = StaticData.ProductAPIBase + "/api/products",
                AccessToken = ""
            });
        }
    }
}

