using AppSettingsResfreshTest.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AppSettingsResfreshTest
{
    /// <summary>
    /// Add seed data interface to the db context to allow it to seed with data defaults
    /// </summary>

    public class DbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory, IWebHostEnvironment webHost)
        {
            this._scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            
        }
    }
}
