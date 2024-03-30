using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Udemy_MVC.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//告訴應用程式使用 Entity Framework Core 來建立一個與 SQL Server 資料庫連接的 DbContext（ApplicationDbContext類別），
//並且使用在appsettings.json名為 "DefaultConnection" 的連線字串。

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
