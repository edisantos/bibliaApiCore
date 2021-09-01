using Microsoft.EntityFrameworkCore.Migrations;

namespace lemosinfotec.biblia.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biblia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Versiculo = table.Column<int>(type: "int", nullable: false),
                    Capitulo = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Conteudo = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biblia", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biblia");
        }
    }
}
