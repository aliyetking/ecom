using ECom.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECom.Infrastructure.Persistences;

public class ECommerceDbContext : DbContext
{
    public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>(entity =>
        {
            entity.ToTable("Products");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                  .ValueGeneratedOnAdd()
                  .UseIdentityColumn(1, 1); 
            entity.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entity.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(x => x.Stock).IsRequired();
            entity.Property(x => x.CategoryId).IsRequired();
        });
        
        builder.Entity<Category>(entity =>
        {
            entity.ToTable("Categories");
            entity.HasKey(x => x.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1); 
            entity.Property(x => x.Name).IsRequired().HasMaxLength(100);
            
            entity.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        base.OnModelCreating(builder);
    }
}