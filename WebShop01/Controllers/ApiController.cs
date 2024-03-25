using BLL.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShop01.Enum;
using WebShop01.Interfaces;
using WebShop01.Models;

namespace WebShop01.Controllers
{
    public class ApiController : Controller
    {
        IProductServices _productService;
        ICategoryServices _categoryService;
        public ApiController(IProductServices productService, ICategoryServices categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Products()
        {
            var response = await _productService.AllProducts();
            return Json(response);
        }
        
        public async Task<IActionResult> Search(string word)
        {
            var response = await _productService.ProductsByWord(word);
            return Json(response);
        }

        public async Task<IActionResult> Category(string category, string[] keywords, int max, int min)
        {
            if (keywords.Length > 0)
            {
                var response = await _productService.GetProductsByCategoryAndKeyWordsWithPrice(category, keywords, max, min);
                return Json(response);
            }
            else
            {
                var response = await _productService.GetProductsByCategoryAndPrice(category, max, min);
                return Json(response);
            }
        } 
    }
}
