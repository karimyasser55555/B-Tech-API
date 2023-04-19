using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDto.ProductDto
{
    public class MinimalProductDto
    {

        public long Id { get; set; }
        public int? Discount { get; set; }
 

        public string ImagePath { set; get; }

        [MinLength(3), MaxLength(10)]
        public string Name { get; set; }

        public string NameArabic { set; get; }

        public string Discription { get; set; }

        public string DiscArabic { set; get; }

        public float Price { get; set; }
    }
}
 