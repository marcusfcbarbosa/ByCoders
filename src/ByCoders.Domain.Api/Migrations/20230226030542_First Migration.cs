using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ByCoders.Domain.Api.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Titulos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Cpf = table.Column<string>(type: "varchar(50)", nullable: true),
                    Cartao = table.Column<string>(type: "varchar(50)", nullable: true),
                    Hora = table.Column<TimeSpan>(nullable: false),
                    DonoLoja = table.Column<string>(type: "varchar(50)", nullable: true),
                    NomeLoja = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titulos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Titulos");
        }
    }
}
