using AppSettingsResfreshTest.Models;
using AppSettingsResfreshTest.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AppSettingsResfreshTest.Controllers
{
    //[Route("[controller]/[action]")]
    //[ApiController]
    [Auth]
    public class HomeController : Controller, IAuthUrl
    {
        public readonly WebConfig webConfigContext;
        public readonly IConstructorSetupSerivce constructorSetup;
        public readonly IEmailService emailService;
        public readonly LogServerAgent log;

        public string AuthUrl { get; set; }

        public HomeController(IOptionsMonitor<WebConfig> webConfig, IConstructorSetupSerivce serivce, IEmailService email, LogServerAgent agent)
        {
            webConfigContext = webConfig.CurrentValue;
            constructorSetup = serivce;
            emailService = email;
            log = agent;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult AppSettingsAction()
        {
            //dynamic ConstantsList = webConfigContext;
            //ConstantsList.UserToken = "new Value";

            return Json(new 
            { 
                appsettingValue = webConfigContext.StaticProperty, 
                serviceValue = constructorSetup.Url,
                emailUrlValue = emailService.getUrlValue(),
                authFilterValue = AuthUrl,
                logServerValue = log.GetUrl
            });
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
        public IActionResult SaveChanges([FromBody] Entity entity)
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
