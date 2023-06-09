using AppSettingsResfreshTest.Models;
using AppSettingsResfreshTest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AppSettingsResfreshTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SampleDB>(options => options.UseSqlServer(Configuration.GetConnectionString("SampleDB")));

            services.Configure<WebConfig>(Configuration.GetSection("WebConfig"));
            services.AddAuthentication();
            services.AddSession();
            services.AddHealthChecks();//.AddCheck().AddDbContextCheck<SampleDB>();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new GlobalSettingsFilter()
                {
                    Url = Configuration.GetSection("WebConfig")["StaticProperty"],
                });
                options.AllowEmptyInputInBodyModelBinding = true;
            });

            services.AddScoped<IConstructorSetupSerivce, ConstructorSetupSerivce>(_ =>
            new ConstructorSetupSerivce()
            {
                Url = Configuration.GetSection("WebConfig")["StaticProperty"]
            });

            services.AddScoped<IEmailService, EmailService>(_ =>
            {
                ResourceTemplatePath templatePath = new ResourceTemplatePath();
                SMTPServer server = new SMTPServer();
                EmailSettings settings = new EmailSettings() 
                {
                    Url = Configuration.GetSection("WebConfig")["StaticProperty"]
                };

                return new EmailService(templatePath, settings, server);
            });

            services.AddSingleton(_ =>
            {
                LogServerAgent log = new LogServerAgent();
                log.InitializeLogServerAgent(Configuration.GetSection("WebConfig")["StaticProperty"]);
                return log;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseMiddleware(typeof(ClientMiddleware));//beign used to set dynamic properties from HttpContext i.e UserEmail, UserToken, PD Access Token

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.UseHealthChecks("/HealthCheck");

            IServiceScopeFactory scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using IServiceScope scope = scopeFactory.CreateScope();
            using SampleDB context = scope.ServiceProvider.GetService<SampleDB>();
            context.Database.Migrate();// migrate any database changes on startup (includes initial db creation)
        }
    }
}
