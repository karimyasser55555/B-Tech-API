using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { set; get; }

        public string NameArabic { set; get; }

        
        public IFormFile file { set; get; }
        public int? ParentCategory { set; get; }
        public UpdateCategoryCommand(int Id, string Name,string NameArabic, IFormFile file,
            int? ParentCategory = null)
        {
            this.Id = Id;
            this.NameArabic = NameArabic;
            this.Name = Name;
            this.file = file;
            this.ParentCategory = ParentCategory;
        }
        public UpdateCategoryCommand() { }
        

       

        
    }
}
