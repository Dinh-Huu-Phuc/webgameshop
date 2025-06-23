using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebGameShop.Migrations
{
    /// <inheritdoc />
    public partial class image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Detail", "ImageUrl", "IsTrendingProduct", "Name", "Price" },
                values: new object[,]
                {
                    { 13, "Giải Trí", "BowBlitz là một trò chơi hành động bắn súng góc nhìn thứ nhất hấp dẫn, nơi người chơi nhập vai những xạ thủ tài ba trong một thế giới đầy hiểm họa. Trò chơi nổi bật với các chế độ chơi đa dạng như deathmatch, team battle và các chiến dịch PvE. Với đồ họa sắc nét và cơ chế điều khiển mượt mà, BowBlitz đem đến trải nghiệm căng thẳng và kịch tính, đồng thời yêu cầu người chơi phải kết hợp chiến thuật và phản xạ nhanh để chiến thắng các đối thủ cạnh tranh.", "https://play-lh.googleusercontent.com/EoMw7zQE1yOFjeqxq-rVoLpqz7Cp-EmT06hP57dVBBeaWYpKSOa1Guj0KoZKvn40tg=w526-h296-rw", false, "BowBlitz", 5500m },
                    { 14, "Hành Động", "Shatterline là một game bắn súng FPS độc đáo pha trộn yếu tố hành động và khoa học viễn tưởng. Người chơi sẽ khám phá các bản đồ chiến trường đa dạng, từ các căn cứ bị tấn công đến các môi trường ngoài hành tinh. Với hệ thống vũ khí đa dạng và khả năng tùy biến cao, Shatterline mang lại cảm giác thử thách và thú vị, yêu cầu kỹ năng và chiến thuật cao để vượt qua các trận đấu đầy cạnh tranh. Trò chơi còn nổi bật với các chế độ chơi sáng tạo và đồ họa chất lượng cao.", "https://cdn1.epicgames.com/spt-assets/0cbc7c03131b479ab1e5ec67f4da4290/shatterline-1ojh6.jpg", false, "SHATTERLINE", 10000m },
                    { 15, "Sinh Tồn", "Super Mecha Champions là một game battle royale kết hợp phong cách robot khổng lồ và hành động nhanh nhạy. Người chơi điều khiển các siêu robot mạnh mẽ trong các trận đấu đầy kịch tính, chiến đấu tại các bản đồ rộng lớn như thành phố rực rỡ hoặc các vùng đất hoang tàn. Với hệ thống nâng cấp và tùy biến robot đa dạng, game mang đến trải nghiệm vừa chiến đấu vừa khám phá thế giới mở rộng lớn, đồng thời yêu cầu kỹ năng phối hợp và phản xạ nhanh để chiến thắng đối thủ trong các cuộc đua sinh tồn này.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcThYfCAqDGhtJKWGf2sBAzrVah4mkWwddOXaA&s", false, "Supper Mecha Champions", 3333m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
