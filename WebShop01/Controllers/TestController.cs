using Microsoft.AspNetCore.Mvc;

namespace WebShop01.Controllers
{
    public class TestController : Controller
    {
        DAL_V2.Interfaces.IKeyParamsRepository _test;
        public TestController(DAL_V2.Interfaces.IKeyParamsRepository test)
        {
            _test = test;
        }
        public async Task< IActionResult> Index()
        {
            
            var result = await _test.SelectIncludeWords();
            return Json(result);
        }
    }
}
