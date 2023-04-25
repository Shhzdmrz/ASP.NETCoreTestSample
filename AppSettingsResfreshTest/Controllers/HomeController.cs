using AppSettingsResfreshTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AppSettingsResfreshTest.Controllers
{
    //[Route("[controller]/[action]")]
    //[ApiController]
    //[Auth]
    public class HomeController : Controller
    {
        public readonly WebConfig webConfigContext;
        public HomeController(IOptionsMonitor<WebConfig> webConfig)
        {
            webConfigContext = webConfig.CurrentValue;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult AppSettingsAction()
        {
            //dynamic ConstantsList = webConfigContext;
            //ConstantsList.UserToken = "new Value";

            return Json(webConfigContext);
        }

        public JsonResult TestAction()
        {
            //dynamic ConstantsList = webConfigContext;
            //ConstantsList.UserToken = "new Value";

            return Json(new { webConfigContext, token = HttpContext.Items["authToken"] });
        }

        public IActionResult RouteAction(int? a)
        {
            return Json(a);
        }

        [HttpPost]
        public IActionResult SaveChanges([FromBody]Entity entity)
        {
            return Json(entity);
        }

        [HttpPost]
        public IActionResult SecondSaveChanges([FromBody] Entity entity)
        {
            return Json(entity);
        }

        
    }
}
