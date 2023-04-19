using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDto.CategoryDto
{
    public class MinimalCategoryDto
    {
        
        public int Id { get; set; }
        [MinLength(3), MaxLength(10)]
        public string Name { get; set; }
    
        public int? ParentCategory { set; get; }
        public string nameArabic { set; get; }
        public string ImagePath { get; set; }

    }
}
 