using FoodTrack.Web.Models;
using FoodTrack.Web.Services;
using FoodTrack.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        /// <summary>
        /// ProductCreate
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ProductCreate()
		{
			return View();
		}
        /// <summary>
        /// ProductCreate
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
	}

}




