using Application.Contracts;
using MediatR;
using ModelDto.CategoryDto;
using System;
using Application.Features.Categories.Queries.GetAllCategories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Domain;
namespace Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<MinimalCategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetAllCategoriesHandler(ICategoryRepository categoryRepository)
        {
            
            _categoryRepository = categoryRepository;
        }
       

       public async Task<IEnumerable<MinimalCategoryDto>> Handle (GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var r = await _categoryRepository.FilterAsync(request.Name,request.NameArabic);
          


            return  r.Select(e=>new MinimalCategoryDto
           {Name=e.Name ,nameArabic=e.NameArabic,ImagePath=e.ImagePath,Id=e.Id,ParentCategory=e.parentId}).ToList();
             

        }
    }
}
