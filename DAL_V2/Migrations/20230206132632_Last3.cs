using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL_V2.Migrations
{
    public partial class Last3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionField1",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionField2",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionField1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DescriptionField2",
                table: "Product");
        }
    }
}
