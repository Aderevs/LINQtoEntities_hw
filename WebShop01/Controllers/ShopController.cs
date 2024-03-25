using BLL.Interfaces.Services;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShop01.Enum;
using WebShop01.Interfaces;
using WebShop01.Models;

namespace WebShop01.Controllers
{
    public class ShopController : Controller
    {
        private readonly ILogger<ShopController> _logger;
        ICategoryServices _categoryServices;
        IProductServices _productService;

        public ShopController(ILogger<ShopController> logger, ICategoryServices categoryServices, IProductServices productService)
        {
            _logger = logger;
            _categoryServices = categoryServices;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _categoryServices.AllCategories();
            return View(response);
        }

        public async Task<IActionResult> Category(string category)
        {
            
            var response = await _categoryServices.GetCategoryInfoByName(category);
            return View(response);
        }
        
        public async Task<IActionResult> ProductPage(string category)
        {
            var response = await _productService.GetProductByName(category);
            return View(response);
        }
        
        public IActionResult Search()
        {
            return View();
        }
    }
}