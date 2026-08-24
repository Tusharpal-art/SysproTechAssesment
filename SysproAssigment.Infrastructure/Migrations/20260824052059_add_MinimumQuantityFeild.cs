using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysproAssigment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_MinimumQuantityFeild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinimumQuantity",
                table: "Products",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinimumQuantity",
                table: "Products");
        }
    }
}
