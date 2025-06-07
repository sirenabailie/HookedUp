// File: HookedUp/Program.cs

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using HookedUp.APIs;

namespace HookedUp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1) Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // 2) CORS
            builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
                p.WithOrigins("http://localhost:3000")
                 .AllowAnyMethod()
                 .AllowAnyHeader()
            ));

            // 3) Database: InMemory for Testing, else PostgreSQL
            if (builder.Environment.IsEnvironment("Testing"))
            {
                builder.Services.AddDbContext<HookedUpDbContext>(o =>
                    o.UseInMemoryDatabase("TestDb"));
            }
            else
            {
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                builder.Services.AddDbContext<HookedUpDbContext>(o =>
                    o.UseNpgsql(builder.Configuration["HookedUpDbConnectionString"]));
            }

            // 4) JSON cycles
            builder.Services.Configure<JsonOptions>(opts =>
                opts.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            var app = builder.Build();

            // 5) Middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseCors();

            // 6) Map your APIs
            ProjectRequestAPI.Map(app);
            ArtistProfileAPI.Map(app);
            UserAPI.Map(app);
            ReviewRatingAPI.Map(app);
            DirectMessageAPI.Map(app);

            app.Run();
        }
    }
}
