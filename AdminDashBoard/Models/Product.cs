using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace AdminDashBoard.Models
{
    public class Product
    {
        public long Id { set; get; }
        [Required]
        public string Name { set; get; }

        [Required]
        public string NameArabic { set; get; }
        [Required]
        public string? ImagePath { set; get; }

        public IFormFile Images { set; get; }
        public int? Discount { set; get; }
        [Required]
        public string Description { set; get; }


        [Required]
        public int AvailUnit { set; get; }
        [Required]
        public string DescriptionArabic { set; get; }
        [Required]

        [Display(Name = "Category")]
        public int CategoryId { set; get; }
        public SelectList category { set; get; }
        [Required]
        public float Price { set; get; }
    }
}
