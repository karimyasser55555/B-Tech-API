using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace AdminDashBoard.Models
{
    public class test
    {


        public int Id { get; set; }

        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        public string NameArabic { get; set; }

        [Display(Name = "Category")]
        public int ParentCategory { set; get; }
        public SelectList category { set; get; }
        [Required]
        public IFormFile? file { get; set; }
    }
}
