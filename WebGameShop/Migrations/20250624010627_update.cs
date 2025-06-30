using System;
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
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsTrendingProduct = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Orders = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrdersDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdersDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Detail", "ImageUrl", "IsTrendingProduct", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "AAA", "Black Myth Wukong là một game Triple A với đồ họa cực khủng. Có raysing với đồ họa đẹp nhất từ trước đến nay , nhưng từ đó cũng cần 1 cấu hình PC mạnh mẽ như chip mạnh Ram cao, và đặc biết là GPU: thấp nhất thì 2070supper cho tới 5 seri", "https://i.pinimg.com/736x/97/3e/16/973e16ab9a05c0d1c1c9c1788cca1e93.jpg", false, "Black Myth Wukong", 55m },
                    { 2, "FPS", "Apex legends là một game bắn súng góc nhìn thứ nhất , trò chơi fps này là người chơi sẽ chạy bo ", "https://i.pinimg.com/736x/84/eb/20/84eb2061bf0a96bec901c5c31f760891.jpg", false, "Apex legends", 70m },
                    { 3, "FPS", "Valorant là game bắn súng với góc nhìn thứ 1, 1 bên sẽ bảo vệ khu đặt C4 và 1 bên còn lại đi lừa và đặt c4", "https://i.pinimg.com/736x/39/dd/4d/39dd4da08ecccc0159d79598365e995e.jpg", false, "Valorant", 25m },
                    { 4, "Giải Trí", "Chicken Invaders là trò chơi chiến thuật đi du hành các vì sao bắn các con gà", "https://i.pinimg.com/736x/e8/2e/b3/e82eb3a089c1b790aeb07ece0addba90.jpg", false, "Chickend Invaders", 15m },
                    { 5, "Chiến Thuật", "3Q Củ hành là game moba chiến thuật giao tranh giữa 2 bên là Ngụy và Ngô...", "https://i.pinimg.com/736x/e4/f9/66/e4f966f2e7eeebceaf14f1f81f912621.jpg", false, "3Q Củ Hành", 55m },
                    { 6, "Hành Động", "Game DC spuer man đánh nhau với quái vật.", "https://i.pinimg.com/736x/6b/57/3a/6b573a7bd2abf31aa5544ef019869cb2.jpg", false, "DC UNIVERSE", 95m },
                    { 7, "Hành Động", "Halo là game hành động mặc lên bộ giáp chiến cực ngầu đi bắn quái vật.", "https://i.pinimg.com/736x/bb/5b/20/bb5b20c42ed71a4f3434b66374e6ecc2.jpg", false, "Hallo", 105m },
                    { 8, "Chiến Thuật", "Chicken Invaders là trò chơi chiến thuật đi du hành các vì sao bắn các con gà", "https://i.pinimg.com/736x/c9/e8/e2/c9e8e2de1334ef26ab9f22bea8f7a853.jpg", false, "God Of War", 600m },
                    { 9, "Chiến Thuật", "Liên Minh huyền thoại là game chia phe ra đánh nhau và đẩy nhà ... bên nào đẩy nhà xong trước bên đây thắng", "https://i.pinimg.com/736x/c8/3a/f2/c83af2fe3d2b7ed26d605224958d1f28.jpg", false, "LOL", 900m },
                    { 10, "Cốt Truyện", "NARAKA BLADEPOINT: Đắm chìm vào những huyền thoại của Viễn Đông trong NARAKA: BLADEPOINT; hợp tác với bạn bè của bạn trong những trận chiến cận chiến nhịp độ nhanh để có trải nghiệm Battle Royale không giống bất kỳ trải nghiệm nào khác. Những anh hùng từ khắp nơi trên thế giới đã tụ họp trên Đảo Morus, nơi hai vị thần cổ đại đã va chạm nhau từ hàng triệu năm trước — tạo ra Mặt nạ bất tử: một hiện vật có sức mạnh huyền thoại. Bạn là một anh hùng như vậy, sẵn sàng đối mặt với nhiều người khác trên con đường giành lấy nó.\r\n", "https://i.pinimg.com/736x/d4/b7/93/d4b7932df8ddf3cb913e08e53177b107.jpg", false, "NARAKA", 1000m },
                    { 11, "Hành Động", "Cận cảnh Mecha | Lumina Đôi cánh rực rỡ sẽ xuất hiện trên bầu trời và đáp xuống chiến trường đang bên bờ vực sụp đổ, cứu vãn tình hình khỏi cái chết chắc chắn.", "https://i.pinimg.com/736x/87/31/b7/8731b76ef8f1ceb0fe99f54615294b15.jpg", false, "Mechabreak", 1550m },
                    { 12, "Sinh Tồn", "Đánh giá PlayerUnknown’s Battlegrounds (dành cho PC), Tôi đã trải qua nỗi kinh hoàng thầm lặng trong trận đấu PlayerUnknown BattleGrounds (PUBG) đầu tiên của mình. Trận đấu thứ 2 cũng mang lại cảm giác tương tự. Độ vừa vặn 1/3 cao hơn nhiều so với những trận trước, vì tôi đã thận trọng lái xe đạp cho đến khi chỉ còn lại chưa đến 10 game thủ. Lần tiếp theo, Đọc thêm https://smartgamer.website/playerunknowns-battlegrounds-for-pc-review", "https://i.pinimg.com/736x/9e/01/b5/9e01b5a0679af689d02213a5c95a5737.jpg", false, "Pubg", 2200m },
                    { 13, "Giải Trí", "BowBlitz là một trò chơi hành động bắn súng góc nhìn thứ nhất hấp dẫn, nơi người chơi nhập vai những xạ thủ tài ba trong một thế giới đầy hiểm họa. Trò chơi nổi bật với các chế độ chơi đa dạng như deathmatch, team battle và các chiến dịch PvE. Với đồ họa sắc nét và cơ chế điều khiển mượt mà, BowBlitz đem đến trải nghiệm căng thẳng và kịch tính, đồng thời yêu cầu người chơi phải kết hợp chiến thuật và phản xạ nhanh để chiến thắng các đối thủ cạnh tranh.", "https://modhello.com/uploads/2025/4/bowblitz-thumbnail.jpg", false, "BowBlitz", 5500m },
                    { 14, "Hành Động", "Shatterline là một game bắn súng FPS độc đáo pha trộn yếu tố hành động và khoa học viễn tưởng. Người chơi sẽ khám phá các bản đồ chiến trường đa dạng, từ các căn cứ bị tấn công đến các môi trường ngoài hành tinh. Với hệ thống vũ khí đa dạng và khả năng tùy biến cao, Shatterline mang lại cảm giác thử thách và thú vị, yêu cầu kỹ năng và chiến thuật cao để vượt qua các trận đấu đầy cạnh tranh. Trò chơi còn nổi bật với các chế độ chơi sáng tạo và đồ họa chất lượng cao.", "https://cdn1.epicgames.com/spt-assets/0cbc7c03131b479ab1e5ec67f4da4290/shatterline-1ojh6.jpg", false, "SHATTERLINE", 10000m },
                    { 15, "Sinh Tồn", "Super Mecha Champions là một game battle royale kết hợp phong cách robot khổng lồ và hành động nhanh nhạy. Người chơi điều khiển các siêu robot mạnh mẽ trong các trận đấu đầy kịch tính, chiến đấu tại các bản đồ rộng lớn như thành phố rực rỡ hoặc các vùng đất hoang tàn. Với hệ thống nâng cấp và tùy biến robot đa dạng, game mang đến trải nghiệm vừa chiến đấu vừa khám phá thế giới mở rộng lớn, đồng thời yêu cầu kỹ năng phối hợp và phản xạ nhanh để chiến thắng đối thủ trong các cuộc đua sinh tồn này.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcThYfCAqDGhtJKWGf2sBAzrVah4mkWwddOXaA&s", false, "Supper Mecha Champions", 3333m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDetails_OrderId",
                table: "OrdersDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersDetails_ProductId",
                table: "OrdersDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ContactMessages");

            migrationBuilder.DropTable(
                name: "OrdersDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
