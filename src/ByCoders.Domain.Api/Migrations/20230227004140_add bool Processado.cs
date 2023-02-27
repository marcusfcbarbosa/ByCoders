using Microsoft.EntityFrameworkCore.Migrations;

namespace ByCoders.Domain.Api.Migrations
{
    public partial class addboolProcessado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Processado",
                table: "Titulos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Processado",
                table: "Titulos");
        }
    }
}
