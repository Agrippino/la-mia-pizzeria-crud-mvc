using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzeriaAgrippino.Migrations
{
    public partial class SettimaCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePizza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamePizza = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DescriptionPizza = table.Column<string>(type: "Text", maxLength: 250, nullable: false),
                    PricePizza = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}
