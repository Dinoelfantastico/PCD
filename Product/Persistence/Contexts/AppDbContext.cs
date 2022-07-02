using Microsoft.EntityFrameworkCore;
using Product.Domain.Models;
using Product.Extension;

namespace Product.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product_> Product_s { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Entidad Product_

            builder.Entity<Product_>().ToTable("Product_s");
            builder.Entity<Product_>().HasKey(p => p.Id);
            builder.Entity<Product_>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product_>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Product_>().Property(p => p.Ferlizante)
                .IsRequired().HasMaxLength(50);
            builder.Entity<Product_>();

            builder.Entity<Product_>().HasData
              (
                  new Product_ { Id = 1, Name = "Papa", Ferlizante = "Fertilizante 1" },
                  new Product_ { Id = 2, Name = "Zanahoria", Ferlizante = "Fertilizante 2" },
                  new Product_ { Id = 3, Name = "Palta", Ferlizante = "Fertilizante 3" },
                  new Product_ { Id = 4, Name = "Pepino", Ferlizante = "Fertilizante 4" }
            );

            builder.UseSnakeCaseNamingConvention();


        }


    }
}
