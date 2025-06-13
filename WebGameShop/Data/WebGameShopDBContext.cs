using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebGameShop.Models;

namespace WebGameShop.Data
{
    public class WebGameShopDBContext : IdentityDbContext
    {
        public WebGameShopDBContext(DbContextOptions<WebGameShopDBContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingcartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrdersDetails { get; set; }
        public DbSet<Contact> ContactMessages { get; set; }

        //seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
            .Property(o => o.OrderTotal)
            .HasColumnType("decimal(18, 2)"); // Ví dụ: 18 tổng số chữ số, 2 chữ số sau dấu thập phân

            // Cấu hình cho Price trong OrderDetail
            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.Price)
                .HasColumnType("decimal(18, 2)");

            // Cấu hình cho Price trong Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Black Myth Wukong",
                Price = 55,
                Detail = "Black Myth Wukong là một game Triple A với đồ họa cực khủng. Có raysing với đồ họa đẹp nhất từ trước đến nay , nhưng từ đó cũng cần 1 cấu hình PC mạnh mẽ như chip mạnh Ram cao, và đặc biết là GPU: thấp nhất thì 2070supper cho tới 5 seri",
                ImageUrl = "https://i.pinimg.com/736x/97/3e/16/973e16ab9a05c0d1c1c9c1788cca1e93.jpg",
                Category = "AAA"
            },
            new Product
            {
                Id = 2,
                Name = "Apex legends",
                Price = 70,
                Detail = "Apex legends là một game bắn súng góc nhìn thứ nhất , trò chơi fps này là người chơi sẽ chạy bo ",
                ImageUrl = "https://i.pinimg.com/736x/84/eb/20/84eb2061bf0a96bec901c5c31f760891.jpg",
                Category = "FPS"
            },
            new Product
            {
                Id = 3,
                Name = "Valorant",
                Price = 25,
                Detail = "Valorant là game bắn súng với góc nhìn thứ 1, 1 bên sẽ bảo vệ khu đặt C4 và 1 bên còn lại đi lừa và đặt c4",
                ImageUrl = "https://i.pinimg.com/736x/39/dd/4d/39dd4da08ecccc0159d79598365e995e.jpg",
                Category = "FPS"
            },
            new Product
            {
                Id = 4,
                Name = "Chickend Invaders",
                Price = 15,
                Detail = "Chicken Invaders là trò chơi chiến thuật đi du hành các vì sao bắn các con gà",
                ImageUrl = "https://i.pinimg.com/736x/e8/2e/b3/e82eb3a089c1b790aeb07ece0addba90.jpg",
                Category = "Giải Trí"
            },
            new Product
            {
                Id = 5,
                Name = "3Q Củ Hành",
                Price = 55,
                Detail = "3Q Củ hành là game moba chiến thuật giao tranh giữa 2 bên là Ngụy và Ngô...",
                ImageUrl = "https://i.pinimg.com/736x/e4/f9/66/e4f966f2e7eeebceaf14f1f81f912621.jpg",
                Category = "Chiến Thuật"
            },
            new Product
            {
                Id = 6,
                Name = "DC UNIVERSE",
                Price = 95,
                Detail = "Game DC spuer man đánh nhau với quái vật.",
                ImageUrl = "https://i.pinimg.com/736x/6b/57/3a/6b573a7bd2abf31aa5544ef019869cb2.jpg",
                Category = "Hành Động"
            },
            new Product
            {
                Id = 7,
                Name = "Hallo",
                Price = 105,
                Detail = "Halo là game hành động mặc lên bộ giáp chiến cực ngầu đi bắn quái vật.",
                ImageUrl = "https://i.pinimg.com/736x/bb/5b/20/bb5b20c42ed71a4f3434b66374e6ecc2.jpg",
                Category = "Hành Động"
            },
            new Product
            {
                Id = 8,
                Name = "God Of War",
                Price = 600,
                Detail = "Chicken Invaders là trò chơi chiến thuật đi du hành các vì sao bắn các con gà",
                ImageUrl = "https://i.pinimg.com/736x/c9/e8/e2/c9e8e2de1334ef26ab9f22bea8f7a853.jpg",
                Category = "Chiến Thuật",
            },
            new Product
            {
                Id = 9,
                Name = "LOL",
                Price = 900,
                Detail = "Liên Minh huyền thoại là game chia phe ra đánh nhau và đẩy nhà ... bên nào đẩy nhà xong trước bên đây thắng",
                ImageUrl = "https://i.pinimg.com/736x/c8/3a/f2/c83af2fe3d2b7ed26d605224958d1f28.jpg",
                Category = "Chiến Thuật"
            },
            new Product
            {
                Id = 10,
                Name = "NARAKA",
                Price = 1000,
                Detail = "NARAKA BLADEPOINT: Đắm chìm vào những huyền thoại của Viễn Đông trong NARAKA: BLADEPOINT; hợp tác với bạn bè của bạn trong những trận chiến cận chiến nhịp độ nhanh để có trải nghiệm Battle Royale không giống bất kỳ trải nghiệm nào khác. Những anh hùng từ khắp nơi trên thế giới đã tụ họp trên Đảo Morus, nơi hai vị thần cổ đại đã va chạm nhau từ hàng triệu năm trước — tạo ra Mặt nạ bất tử: một hiện vật có sức mạnh huyền thoại. Bạn là một anh hùng như vậy, sẵn sàng đối mặt với nhiều người khác trên con đường giành lấy nó.\r\n",
                ImageUrl = "https://i.pinimg.com/736x/d4/b7/93/d4b7932df8ddf3cb913e08e53177b107.jpg",
                Category = "Cốt Truyện"
            },
            new Product
            {
                Id = 11,
                Name = "Mechabreak",
                Price = 1550,
                Detail = "Cận cảnh Mecha | Lumina Đôi cánh rực rỡ sẽ xuất hiện trên bầu trời và đáp xuống chiến trường đang bên bờ vực sụp đổ, cứu vãn tình hình khỏi cái chết chắc chắn.",
                ImageUrl = "https://i.pinimg.com/736x/87/31/b7/8731b76ef8f1ceb0fe99f54615294b15.jpg",
                Category = "Hành Động",
            },
            new Product
            {
                Id = 12,
                Name = "Pubg",
                Price = 2200,
                Detail = "Đánh giá PlayerUnknown’s Battlegrounds (dành cho PC), Tôi đã trải qua nỗi kinh hoàng thầm lặng trong trận đấu PlayerUnknown BattleGrounds (PUBG) đầu tiên của mình. Trận đấu thứ 2 cũng mang lại cảm giác tương tự. Độ vừa vặn 1/3 cao hơn nhiều so với những trận trước, vì tôi đã thận trọng lái xe đạp cho đến khi chỉ còn lại chưa đến 10 game thủ. Lần tiếp theo, Đọc thêm https://smartgamer.website/playerunknowns-battlegrounds-for-pc-review",
                ImageUrl = "https://i.pinimg.com/736x/9e/01/b5/9e01b5a0679af689d02213a5c95a5737.jpg",
                Category = "Sinh Tồn"
            }
            );
        }
    }
}
