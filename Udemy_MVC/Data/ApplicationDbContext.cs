using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Udemy_MVC.Models;

//它是一個 DbContext 的子類別，用於定義應用程式的資料庫模型和資料存取操作
namespace Udemy_MVC.Data
{
    // 類別是 ApplicationDbContext，它繼承自 EF Core  中的 DbContext 類別
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //ApplicationDbContext 的建構函式。它接受一個 DbContextOptions<ApplicationDbContext> 類型的參數，
            //會將接收到的 options 參數傳遞給base類別的建構函式，以便 EF Core 正確配置 DbContext
        }

        public DbSet<Category> Categories { get; set; }
        //Categories 是一個 DbSet 屬性，代表了資料庫中的 Category 實體的集合
        //能透過 ApplicationDbContext 類別來存取和操作 Category 實體對應的資料表

        //使用 EF Core 中的 Fluent API 來配置資料庫中的初始資料（稱為種子資料
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(    //指定了三個 Category 實體的初始值
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
            //目的: 在資料庫模型初始化時，向 Category 表格中加入三筆初始資料
        }

    }
}
