using Microsoft.EntityFrameworkCore;
using WebGameShop.Data;
using WebGameShop.Models.Interface;
using WebGameShop.Models.Services;
using Microsoft.AspNetCore.Identity; // Đảm bảo namespace này có sẵn

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Cấu hình DbContext với tên kết nối bạn đã đặt
builder.Services.AddDbContext<WebGameShopDBContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("WebGameShopDBContextConnection")));

// Cấu hình Identity với hỗ trợ Roles và sử dụng DbContext của bạn
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>() // --- ĐÃ THÊM DÒNG NÀY ĐỂ HỖ TRỢ ROLES ---
    .AddEntityFrameworkStores<WebGameShopDBContext>();

// Đăng ký các repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Session
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages(); // Cần thiết cho Identity UI

var app = builder.Build();

// Sử dụng Session trước các middleware khác cần nó
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Đảm bảo thứ tự middleware đúng: Routing -> Authentication -> Authorization
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


// Bắt đầu phần Khởi tạo Role và Admin User (Data Seeding)

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        // 1. Tạo vai trò "Admin" nếu chưa tồn tại
        const string adminRoleName = "Admin";
        var adminRoleExists = await roleManager.RoleExistsAsync(adminRoleName);
        if (!adminRoleExists)
        {
            await roleManager.CreateAsync(new IdentityRole(adminRoleName));
            Console.WriteLine($"Role '{adminRoleName}' created successfully.");
        }

        // 2. Tạo người dùng admin nếu chưa tồn tại và gán vai trò "Admin"
        const string adminEmail = "TanThuyHoang@webgameshop.com"; // <-- THAY THẾ EMAIL NÀY VỚI EMAIL BẠN MUỐN
        const string adminPassword = "Admin@123"; // <-- THAY THẾ MẬT KHẨU NÀY BẰNG MẬT KHẨU MẠNH CỦA BẠN

        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true 
            };

            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                // Gán vai trò "Admin" cho người dùng vừa tạo
                await userManager.AddToRoleAsync(adminUser, adminRoleName);
                Console.WriteLine($"Admin user '{adminEmail}' created and assigned to role '{adminRoleName}'.");
            }
            else
            {
                Console.WriteLine($"Error creating admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
        else
        {
            // Nếu người dùng admin đã tồn tại, kiểm tra và gán lại vai trò nếu cần
            if (!await userManager.IsInRoleAsync(adminUser, adminRoleName))
            {
                await userManager.AddToRoleAsync(adminUser, adminRoleName);
                Console.WriteLine($"Admin user '{adminEmail}' already exists, assigned to role '{adminRoleName}'.");
            }
            else
            {
                Console.WriteLine($"Admin user '{adminEmail}' already exists and has role '{adminRoleName}'.");
            }
        }
    }
    catch (Exception ex)
    {
        // Ghi log lỗi nếu có vấn đề trong quá trình khởi tạo
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database with roles and admin user.");
    }
}
// =======================================================
// Kết thúc phần Khởi tạo Role và Admin User
// =======================================================

// Map Razor Pages (cho Identity UI) và Controller Routes
app.MapRazorPages(); // Đặt sau UseAuthorization()
app.MapControllerRoute(
    name: "default", // Đổi tên route để tránh trùng lặp nếu có route "product"
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();