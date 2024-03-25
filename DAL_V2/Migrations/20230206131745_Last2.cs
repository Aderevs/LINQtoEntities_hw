using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL_V2.Migrations
{
    public partial class Last2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ActionPrice",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionPrice",
                table: "Product");
        }
    }
}
