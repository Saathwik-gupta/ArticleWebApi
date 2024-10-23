using Microsoft.EntityFrameworkCore;
using ArticleWebApi.Data;
using ArticleWebApi.Services;
using ArticleWebApi.Models;
using ArticleWebApi.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ArticleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register DAL services using interfaces
builder.Services.AddScoped<IArticleServiceDAL, ArticleServiceDAL>();
builder.Services.AddScoped<IArticleGroupServiceDAL, ArticleGroupServiceDAL>();
builder.Services.AddScoped<IPackageServiceDAL, PackageServiceDAL>();
builder.Services.AddScoped<ICountryServiceDAL, CountryServiceDAL>();
builder.Services.AddScoped<IStateServiceDAL, StateServiceDAL>();
builder.Services.AddScoped<ICityServiceDAL, CityServiceDAL>();

// Register BL services using interfaces
builder.Services.AddScoped<IArticleServiceBL, ArticleServiceBL>();
builder.Services.AddScoped<IArticleGroupServiceBL, ArticleGroupServiceBL>();
builder.Services.AddScoped<IPackageServiceBL, PackageServiceBL>();
builder.Services.AddScoped<ICountryServiceBL, CountryServiceBL>();
builder.Services.AddScoped<IStateServiceBL, StateServiceBL>();
builder.Services.AddScoped<ICityServiceBL, CityServiceBL>();

// Configure controllers and handle circular references
builder.Services.AddControllers();
    // .AddJsonOptions(options =>
    // {
    //     // Handle cyclic references if necessary
    //     options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    //     options.JsonSerializerOptions.WriteIndented = true; // Optional: for readable JSON
    // });

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Optional: Add health checks
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Article API V1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
    });
}

// Use HTTPS redirection
app.UseHttpsRedirection();

// Optional: Use global error handling middleware
app.UseExceptionHandler("/error"); // You can create an error handling endpoint

app.UseAuthorization();

// Map your Article API routes
app.MapControllers(); // Ensure your controllers are mapped

// Health checks endpoint
app.MapHealthChecks("/health"); // You can access health checks at /health

// Example Weather Forecast endpoint
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
