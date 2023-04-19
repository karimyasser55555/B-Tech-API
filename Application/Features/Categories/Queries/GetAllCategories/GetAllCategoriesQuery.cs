using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ModelDto.CategoryDto;

namespace Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<MinimalCategoryDto>>
    {
      public  string ? Name { set; get; }
        public string? NameArabic { set; get; }
    }
}
