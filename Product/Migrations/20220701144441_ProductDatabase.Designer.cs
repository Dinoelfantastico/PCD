// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.Persistence.Contexts;

#nullable disable

namespace Product.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220701144441_ProductDatabase")]
    partial class ProductDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Product.Domain.Models.Product_", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ferlizante")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ferlizante");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("p_k_product_s");

                    b.ToTable("product_s", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ferlizante = "Fertilizante 1",
                            Name = "Papa"
                        },
                        new
                        {
                            Id = 2,
                            Ferlizante = "Fertilizante 2",
                            Name = "Zanahoria"
                        },
                        new
                        {
                            Id = 3,
                            Ferlizante = "Fertilizante 3",
                            Name = "Palta"
                        },
                        new
                        {
                            Id = 4,
                            Ferlizante = "Fertilizante 4",
                            Name = "Pepino"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
