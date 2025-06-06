using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using HookedUp;
using HookedUp.APIs;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Enable Swagger/OpenAPI for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Set up CORS for cross-origin requests (example for localhost:3000)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")  // Frontend URL
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Allows passing DateTimes without timezone data (PostgreSQL setup)
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Connect to PostgreSQL using Entity Framework Core
builder.Services.AddDbContext<HookedUpDbContext>(options =>
    options.UseNpgsql(builder.Configuration["HookedUpDbConnectionString"]));

// Set up JSON serialization options (avoiding circular references in the response)
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();  // Enable CORS

ProjectRequestAPI.Map(app);

app.Run();
