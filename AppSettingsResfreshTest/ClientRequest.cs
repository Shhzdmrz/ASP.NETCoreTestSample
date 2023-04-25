using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace AppSettingsResfreshTest
{
    public class ClientMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public ClientMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            Random rnd = new Random();
            string DynamicProperty = rnd.Next(52).ToString();
            context.Items["authToken"] = DynamicProperty;
            await _requestDelegate(context);
        }
    }
}
