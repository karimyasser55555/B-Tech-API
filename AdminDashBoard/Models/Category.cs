using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDashBoard.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        public string NameArabic { get; set; }

        [Display(Name = "Category")]
        public int ParentCategory { set; get; }
        public SelectList category { set; get; }
        [Required]
        public IFormFile? Images { get; set; }
        [Required]
        public string? ImagePath { set; get; }


    }
}