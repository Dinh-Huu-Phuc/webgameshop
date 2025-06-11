using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebGameShop.Migrations
{
    /// <inheritdoc />
    public partial class addgame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    IsTrendingProduct = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
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
                columns: new[] { "Id", "Detail", "ImageUrl", "IsTrendingProduct", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Black Myth Wukong là một game Triple A với đồ họa cực khủng. Có raysing với đồ họa đẹp nhất từ trước đến nay , nhưng từ đó cũng cần 1 cấu hình PC mạnh mẽ như chip mạnh Ram cao, và đặc biết là GPU: thấp nhất thì 2070supper cho tới 5 seri", "https://i.pinimg.com/736x/97/3e/16/973e16ab9a05c0d1c1c9c1788cca1e93.jpg", false, "Black Myth Wukong", 55m },
                    { 2, "Apex legends là một game bắn súng góc nhìn thứ nhất , trò chơi fps này là người chơi sẽ chạy bo ", "https://i.pinimg.com/736x/84/eb/20/84eb2061bf0a96bec901c5c31f760891.jpg", false, "Apex legends", 70m },
                    { 3, "Valorant là game bắn súng với góc nhìn thứ 1, 1 bên sẽ bảo vệ khu đặt C4 và 1 bên còn lại đi lừa và đặt c4", "https://i.pinimg.com/736x/39/dd/4d/39dd4da08ecccc0159d79598365e995e.jpg", false, "Valorant", 25m },
                    { 4, "Chicken Invaders là trò chơi chiến thuật đi du hành các vì sao bắn các con gà", "https://i.pinimg.com/736x/e8/2e/b3/e82eb3a089c1b790aeb07ece0addba90.jpg", false, "Chickend Invaders", 15m },
                    { 5, "3Q Củ hành là game moba chiến thuật giao tranh giữa 2 bên là Ngụy và Ngô...", "https://i.pinimg.com/736x/e4/f9/66/e4f966f2e7eeebceaf14f1f81f912621.jpg", false, "3Q Củ Hành", 55m },
                    { 6, "Game DC spuer man đánh nhau với quái vật.", "https://i.pinimg.com/736x/6b/57/3a/6b573a7bd2abf31aa5544ef019869cb2.jpg", false, "DC UNIVERSE", 95m },
                    { 7, "Halo là game hành động mặc lên bộ giáp chiến cực ngầu đi bắn quái vật.", "https://i.pinimg.com/736x/bb/5b/20/bb5b20c42ed71a4f3434b66374e6ecc2.jpg", false, "Hallo", 105m },
                    { 8, "Chicken Invaders là trò chơi chiến thuật đi du hành các vì sao bắn các con gà", "https://i.pinimg.com/736x/c9/e8/e2/c9e8e2de1334ef26ab9f22bea8f7a853.jpg", false, "God Of War", 600m },
                    { 9, "Liên Minh huyền thoại là game chia phe ra đánh nhau và đẩy nhà ... bên nào đẩy nhà xong trước bên đây thắng", "https://i.pinimg.com/736x/c8/3a/f2/c83af2fe3d2b7ed26d605224958d1f28.jpg", false, "LOL", 900m }
                });

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
                name: "ContactMessages");

            migrationBuilder.DropTable(
                name: "OrdersDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
