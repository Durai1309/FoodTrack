using FoodTrack.Services.ProductAPI.Models.Dto;
using FoodTrack.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
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
		public async Task<object> GetProducts()
		{
			try
			{
				IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
				_responseDto.Result = productDtos;
			}
			catch (Exception)
			{
				_responseDto.Success = false;
			}
			return _responseDto;
		}
		[HttpGet]
		[Route("{id}")]
		public async Task<object> GetProductsById(int id)
		{
			try
			{
				ProductDto productDtos = await _productRepository.GetProductsById(id);
				_responseDto.Result = productDtos;
			}
			catch (Exception)
			{
				_responseDto.Success = false;
			}
			return _responseDto;
		}

		[HttpPost]
		public async Task<object> CreateProduct([FromBody] ProductDto productDto)
		{
			try
			{
				ProductDto model = await _productRepository.CreateUpdate(productDto);
				_responseDto.Result = model;
			}
			catch (Exception)
			{
				_responseDto.Success = false;
			}
			return _responseDto;
		}
		[HttpPut]
		public async Task<object> UpdateProduct([FromBody] ProductDto productDto)
		{
			try
			{
				ProductDto model = await _productRepository.CreateUpdate(productDto);
				_responseDto.Result = model;
			}
			catch (Exception)
			{
				_responseDto.Success = false;
			}
			return _responseDto;
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<object> DeleteProduct(int id)
		{
			try
			{
				bool model = await _productRepository.DeleteProduct(id);
				_responseDto.Result = model;
			}
			catch (Exception)
			{
				_responseDto.Success = false;
			}
			return _responseDto;
		}
	}
}
