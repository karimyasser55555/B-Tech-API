using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using MediatR;
using ModelDto.CategoryDto;
using ModelDto;
using Domain;

namespace Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, MinimalCategoryDetails>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryByIdHandler(ICategoryRepository categoryRepository)
        {

            _categoryRepository = categoryRepository;
        }


        async Task<MinimalCategoryDetails> IRequestHandler<GetCategoryByIdQuery, MinimalCategoryDetails>.Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            
          var  cat = await _categoryRepository.GetByIdAsyc(request.Id);

           

            return new MinimalCategoryDetails
            {
                Name = cat.Name,
                nameArabic = cat.NameArabic,
                ImagePath = cat.ImagePath,
                Id = cat.Id,
                Subcategories=cat.Subcategories

            };
                  
                

            
        

             
        }
    }
}
