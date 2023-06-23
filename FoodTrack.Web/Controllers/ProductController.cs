using FoodTrack.Web.Models;
using FoodTrack.Web.Services;
using FoodTrack.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace FoodTrack.Web.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductServices _services;

		public ProductController(IProductServices productServices)
		{
			_services = productServices;
		}
		public async Task<IActionResult> ProductIndex()
		{
			List<ProductDto> list = new();
			var response = await _services.GetAllProductAsync<ResponseDto>();
			if (response != null && response.Success)
			{
				list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
			}
			return View(list);
		}
		public async Task<IActionResult> ProductCreate()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ProductCreate(ProductDto model)
		{
			if (ModelState.IsValid)
			{
				var response = await _services.CreateProductTAsync<ResponseDto>(model);
				if (response != null && response.Success)
				{
					return RedirectToAction(nameof(ProductIndex));
				}
			}
			return View(model);
		}

		public async Task<IActionResult> ProductEdit(int ProductID)
		{
			var response = await _services.GetProductByIdAsync<ResponseDto>(ProductID);
			if (response != null && response.Success)
			{
				ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ProductEdit(ProductDto model)
		{
			if (ModelState.IsValid)
			{
				var response = await _services.UpdateProductTAsync<ResponseDto>(model);
				if (response != null && response.Success)
				{
					return RedirectToAction(nameof(ProductIndex));
				}
			}
			return View(model);
		}

		public async Task<IActionResult> ProductDelete(int productId)
		{
			var response = await _services.GetProductByIdAsync<ResponseDto>(productId);
			if (response != null && response.Success)
			{
				ProductDto model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ProductDelete(ProductDto model)
		{
			if (ModelState.IsValid)
			{
				var response = await _services.DeleteProductTAsync<ResponseDto>(model.ProductID);
				if (response.Success)
				{
					return RedirectToAction(nameof(ProductIndex));
				}
			}
			return View(model);
		}
		public Task<IActionResult> Search(string search)
		{
			try
			{
				return null;

			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}

}






