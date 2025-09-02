using ECom.Application.Interfaces;
using ECom.Application.Mapper;
using ECom.Application.Services;
using ECom.Infrastructure.Persistences;
using ECom.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace ECom.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var password = builder.Configuration["SA_PASSWORD"];
        var dbPort = builder.Configuration["MSSQL_PORT"];
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!
            .Replace("{ENV_SA_PASSWORD}", password)
            .Replace("{ENV_MSSQL_PORT}", dbPort);
        builder.Services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(connectionString));
        
        builder.Services.AddScoped<ProductMapper>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();

        builder.Services.AddControllers();
        
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "ECom API",
                Version = "v1",
                Description = "ECom API Documentation",
            });
        });
        
        var app = builder.Build();
        
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();
            db.Database.Migrate();
        }

        app.UseSwagger(); 
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "ECom API V1");
            options.RoutePrefix = string.Empty;
        });

        app.UseHttpsRedirection();
        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}