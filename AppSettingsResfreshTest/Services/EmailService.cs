using Microsoft.AspNetCore.Mvc.Filters;

namespace AppSettingsResfreshTest.Services
{
    public interface IEmailService
    {
        string getUrlValue();
    }
    public class EmailService : IEmailService
    {
        private readonly ITemplatePath _templatePath;
        private readonly ISettings _settings;
        private readonly IMessageServer _messageServer;

        public string getUrlValue() => _settings.Url;
        public EmailService(ITemplatePath templatePath, ISettings settings, IMessageServer messageServer)
        {
            _templatePath = templatePath;
            _settings = settings;
            _messageServer = messageServer;
        }
    }

    public interface ITemplatePath
    {
        string TemplatePath { get; }
    }
    public class ResourceTemplatePath : ITemplatePath
    {
        public string TemplatePath { get; set; }
    }

    public interface ISettings
    {
        string Url { get; }
    }
    public class EmailSettings : ISettings
    {
        public string Url { get; set; }
    }

    public interface IMessageServer
    {
    }

    public class SMTPServer : IMessageServer
    {
    }


    public class GlobalSettingsFilter : IActionFilter
    {
        public string Url { get; set; }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.RouteData.Values.Add("TestUrl", Url);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }

    public class LogServerAgent
    {
        private string _Url;
        public string GetUrl => _Url;
        public void InitializeLogServerAgent(string Url)
        {
            _Url = Url;
        }
    }

    public interface IAuthUrl
    {
        string AuthUrl { get; set; }
    }
}
