using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Migrations
{
    public partial class ProductDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product_s",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ferlizante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_product_s", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "product_s",
                columns: new[] { "id", "ferlizante", "name" },
                values: new object[,]
                {
                    { 1, "Fertilizante 1", "Papa" },
                    { 2, "Fertilizante 2", "Zanahoria" },
                    { 3, "Fertilizante 3", "Palta" },
                    { 4, "Fertilizante 4", "Pepino" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_s");
        }
    }
}
