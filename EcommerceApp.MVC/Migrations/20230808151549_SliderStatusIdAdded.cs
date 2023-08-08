using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.MVC.Migrations
{
    /// <inheritdoc />
    public partial class SliderStatusIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SliderStatusId",
                table: "Sliders",
                type: "int",
                nullable: false,
                defaultValue: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderStatusId",
                table: "Sliders");
        }
    }
}
