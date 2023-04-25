using Microsoft.AspNetCore.Mvc.Filters;

namespace AppSettingsResfreshTest
{
    public class AuthAttribute : ActionFilterAttribute, IExceptionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnException(ExceptionContext context)
        {
        }
    }
}
