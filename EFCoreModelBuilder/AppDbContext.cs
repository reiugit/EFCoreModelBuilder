using EFCoreModelBuilder.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreModelBuilder;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<AProduct> AProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // * Class AProduct is configured mostly via annotations.
        // * Class BProduct is configured only via DbContext.ModelBuilder.

        modelBuilder.Entity<AProduct>(eb =>
        {
            eb.ToTable("AProducts", tb =>
            {
                tb.HasCheckConstraint("CK_Price_not_negative", $"Price > 0");
            });

            eb.HasData(new AProduct { Id = 1, Name = "Class AProduct is configured mostly via annotations.", Description = "Description", Price = 5.5m });
        });

        modelBuilder.Entity<BProduct>(eb =>
        {
            eb.ToTable("BProducts", tb =>
            {
                tb.HasCheckConstraint("CK_Price_not_negative", $"Price > 0");
            });

            eb.Property(p => p.Name).HasMaxLength(100);
            eb.Property(p => p.Description).HasMaxLength(200);
            eb.Property(p => p.Price).HasPrecision(10, 2);
            eb.HasIndex(p => p.Name).IsUnique();
            eb.HasData(new BProduct { Id = 1, Name = "Class BProduct is configured only via DbContext.ModelBuilder.", Description = "Description", Price = 5.5m });
        });

    }
}

