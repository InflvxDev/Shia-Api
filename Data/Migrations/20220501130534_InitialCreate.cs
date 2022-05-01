using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adopter",
                columns: table => new
                {
                    IdentificationCard = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adopter", x => x.IdentificationCard);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    AnimalID = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.AnimalID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    IdentificationCard = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(35)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.IdentificationCard);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adopter");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
