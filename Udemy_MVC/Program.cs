using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Udemy_MVC.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//�i�D���ε{���ϥ� Entity Framework Core �ӫإߤ@�ӻP SQL Server ��Ʈw�s���� DbContext�]ApplicationDbContext���O�^�A
//�åB�ϥΦbappsettings.json�W�� "DefaultConnection" ���s�u�r��C

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
