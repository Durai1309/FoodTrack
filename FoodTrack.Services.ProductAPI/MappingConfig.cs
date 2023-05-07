using AutoMapper;
using FoodTrack.Services.ProductAPI.Models;
using FoodTrack.Services.ProductAPI.Models.Dto;

namespace FoodTrack.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var MappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });
            return MappingConfig;
        }
    }
}

