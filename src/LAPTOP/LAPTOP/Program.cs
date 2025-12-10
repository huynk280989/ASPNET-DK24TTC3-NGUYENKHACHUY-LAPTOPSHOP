using LAPTOP.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Enable MVC
builder.Services.AddControllersWithViews();

// Register DbContext
builder.Services.AddDbContext<LaptopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LaptopDb"));
});

// Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

//  Route dành riêng cho ADMIN
app.MapControllerRoute(
    name: "admin",
    pattern: "Admin/{controller=Product}/{action=Index}/{id?}");

//  Route mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



