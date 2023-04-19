using AdminDashBoard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace AdminDashBoard.ViewModel
{
    public class GetAllCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameArabic { get; set;}
        public string ImagePath { set; get; }
    }
}
