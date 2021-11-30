using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioNessHealth.Migrations
{
    public partial class Personagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personagens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filme = table.Column<string>(type: "nvarchar(max", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Personagens", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personagens");
        }
    }
}
