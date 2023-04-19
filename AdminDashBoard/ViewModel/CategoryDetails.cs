using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AdminDashBoard.ViewModel
{
    public class CategoryDetails
    {
        public string Name { get; set; }
        public string NameArabic { get; set; }
        public string? ImagePath { set; get; }
    }
}
