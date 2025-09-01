using ECom.Application.Interfaces;
using ECom.Application.Mapper;
using ECom.Application.Services;
using ECom.Infrastructure.Persistences;
using ECom.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECom.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(connectionString));
        
        builder.Services.AddScoped<ProductMapper>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductService, ProductService>();

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        var app = builder.Build();
        
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();
            db.Database.Migrate();
        }

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}