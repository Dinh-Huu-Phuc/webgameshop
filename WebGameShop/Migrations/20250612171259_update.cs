using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebGameShop.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Detail", "ImageUrl", "IsTrendingProduct", "Name", "Price" },
                values: new object[,]
                {
                    { 10, "NARAKA BLADEPOINT: Đắm chìm vào những huyền thoại của Viễn Đông trong NARAKA: BLADEPOINT; hợp tác với bạn bè của bạn trong những trận chiến cận chiến nhịp độ nhanh để có trải nghiệm Battle Royale không giống bất kỳ trải nghiệm nào khác. Những anh hùng từ khắp nơi trên thế giới đã tụ họp trên Đảo Morus, nơi hai vị thần cổ đại đã va chạm nhau từ hàng triệu năm trước — tạo ra Mặt nạ bất tử: một hiện vật có sức mạnh huyền thoại. Bạn là một anh hùng như vậy, sẵn sàng đối mặt với nhiều người khác trên con đường giành lấy nó.\r\n", "https://i.pinimg.com/736x/d4/b7/93/d4b7932df8ddf3cb913e08e53177b107.jpg", false, "NARAKA", 1000m },
                    { 11, "Cận cảnh Mecha | Lumina Đôi cánh rực rỡ sẽ xuất hiện trên bầu trời và đáp xuống chiến trường đang bên bờ vực sụp đổ, cứu vãn tình hình khỏi cái chết chắc chắn.", "https://i.pinimg.com/736x/87/31/b7/8731b76ef8f1ceb0fe99f54615294b15.jpg", false, "Mechabreak", 1550m },
                    { 12, "Đánh giá PlayerUnknown’s Battlegrounds (dành cho PC), Tôi đã trải qua nỗi kinh hoàng thầm lặng trong trận đấu PlayerUnknown BattleGrounds (PUBG) đầu tiên của mình. Trận đấu thứ 2 cũng mang lại cảm giác tương tự. Độ vừa vặn 1/3 cao hơn nhiều so với những trận trước, vì tôi đã thận trọng lái xe đạp cho đến khi chỉ còn lại chưa đến 10 game thủ. Lần tiếp theo, Đọc thêm https://smartgamer.website/playerunknowns-battlegrounds-for-pc-review", "https://i.pinimg.com/736x/9e/01/b5/9e01b5a0679af689d02213a5c95a5737.jpg", false, "Pubg", 2200m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
