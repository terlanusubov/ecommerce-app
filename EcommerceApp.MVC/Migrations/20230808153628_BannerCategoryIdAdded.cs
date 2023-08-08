using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApp.MVC.Migrations
{
    /// <inheritdoc />
    public partial class BannerCategoryIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "BannerAds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BannerAds_CategoryId",
                table: "BannerAds",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BannerAds_Categories_CategoryId",
                table: "BannerAds",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BannerAds_Categories_CategoryId",
                table: "BannerAds");

            migrationBuilder.DropIndex(
                name: "IX_BannerAds_CategoryId",
                table: "BannerAds");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "BannerAds");
        }
    }
}
