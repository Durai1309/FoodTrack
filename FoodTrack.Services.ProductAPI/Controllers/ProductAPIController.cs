using FoodTrack.Services.ProductAPI.Models.Dto;
using FoodTrack.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FoodTrack.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _responseDto;
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._responseDto = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _responseDto.Result = productDtos;
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
            }
            return _responseDto;
        }


        [HttpGet]
        public async Task<object> GetAll()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _responseDto.Result = productDtos;
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
            }
            return _responseDto;
        }
    }
}
