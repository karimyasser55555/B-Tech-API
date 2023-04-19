using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDto.CategoryDto;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCaommand:IRequest<bool>
    {

        public string Name { set; get; }

        public string NameArabic { set; get; }
        

        public int? Discount { set; get; }
        public   string Description { set; get; }
       
        public int AvailUnit { set; get; }
        public string DescriptionArabic { set; get; }
        public  int CategoryId { set; get; }
        public IFormFile file { set; get; }
        public float Price { set; get; }
       public CreateProductCaommand(string Name,string NameArabic, string DescriptionArabic,
           int? Discount, string Description, int CategoryId, IFormFile file, int AvailUnit,float Price)
        {
           this.Name = Name;
            this.NameArabic = NameArabic;
            this.DescriptionArabic = DescriptionArabic;
            this.Discount = Discount;
            this.Description = Description;
            this.CategoryId = CategoryId;
            this.file = file;
            this.Price = Price;
        }

         public CreateProductCaommand() { }

        
    }
}
