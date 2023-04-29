using AppSettingsResfreshTest.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppSettingsResfreshTest
{
    public class AuthAttribute : ActionFilterAttribute, IExceptionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IAuthUrl controller = context.Controller as IAuthUrl;
            controller.AuthUrl = context.RouteData.Values["TestUrl"].ToString();
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnException(ExceptionContext context)
        {
        }
    }
}
