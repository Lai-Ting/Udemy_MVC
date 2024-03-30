using Microsoft.AspNetCore.Mvc;
using Udemy_MVC.Data;
using Udemy_MVC.Models;

namespace Udemy_MVC.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;
        //這是一個私有的、只能在類別內部存取的欄位。使用_db 存儲對DbContext的連線。
        public CategoryController(ApplicationDbContext db) //它接受一個 ApplicationDbContext 的參數並將其存儲在私有欄位 _db 中
        {
            _db = db;
        }
        public IActionResult Index()
		{
            //檢索DbContext中Categories(所有的 Category 物件)轉成List，存儲在名為 objCategoryList 的 List 集合中
            List<Category> objCategoryList = _db.Categories.ToList();
            return View();
		}
	}
}
