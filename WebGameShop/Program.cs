using Microsoft.EntityFrameworkCore;
using WebGameShop.Data;
using WebGameShop.Models.Interface;
using WebGameShop.Models.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WebGameShopDBContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("WebGameShopDBContextConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<WebGameShopDBContext>();

// Đăng ký các repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>(); // Bỏ comment hoặc thêm nếu cần
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Session
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();

var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapRazorPages();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "product",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();