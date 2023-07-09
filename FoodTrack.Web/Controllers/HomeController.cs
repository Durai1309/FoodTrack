using FoodTrack.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FoodTrack.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		/// <summary>
		/// HomeController
		/// </summary>
		/// <param name="logger"></param>
		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
		/// <summary>
		/// Index
		/// </summary>
		/// <returns></returns>
		public IActionResult Index()
        {
            return View();
        }
		/// <summary>
		/// Privacy
		/// </summary>
		/// <returns></returns>
		public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// Error
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
       
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
	
	}
}