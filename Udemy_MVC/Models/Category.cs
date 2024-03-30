using System.ComponentModel.DataAnnotations;

namespace Udemy_MVC.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }
		//[Key]可加可不加，或是用CategoryId，會默認是Key

		[Required]
		public string Name { get; set; }
		public int DisplayOrder { get; set; }
	}
}
