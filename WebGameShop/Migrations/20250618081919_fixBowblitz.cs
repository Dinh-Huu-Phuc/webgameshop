using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebGameShop.Migrations
{
    /// <inheritdoc />
    public partial class fixBowblitz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://modhello.com/uploads/2025/4/bowblitz-thumbnail.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://play-lh.googleusercontent.com/EoMw7zQE1yOFjeqxq-rVoLpqz7Cp-EmT06hP57dVBBeaWYpKSOa1Guj0KoZKvn40tg=w526-h296-rw");
        }
    }
}
