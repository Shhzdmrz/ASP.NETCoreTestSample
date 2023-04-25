using Microsoft.AspNetCore.Mvc;

namespace AppSettingsResfreshTest.Controllers
{
    //[ApiController]
    public class OfficeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RouteAction(int? a)
        {
            return Json(a);
        }
    }
}
