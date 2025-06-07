// File: HookedUp.Tests/CustomWebApplicationFactory.cs

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HookedUp;

namespace HookedUp.Tests
{
    public class CustomWebApplicationFactory
      : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            // Force the app to run under "Testing"
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                // Ensure a fresh in-memory database per test run
                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<HookedUpDbContext>();

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            });
        }
    }
}
