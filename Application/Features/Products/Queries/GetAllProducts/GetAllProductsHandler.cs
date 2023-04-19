using Application.Contracts;

using MediatR;
using ModelDto.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetAllQuery
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<MinimalProductDto>>
    {
        private readonly IProductRepository _productRepository;
        public GetAllProductsHandler(IProductRepository productRepository)
        {

            _productRepository = productRepository;
        }
       

       public async Task<IEnumerable<MinimalProductDto>> Handle (GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var r = await _productRepository.FilterAsync(request.CategoryId,request.Name,request.ArabicName,request.Discount,
                request.Lessthan,request.Morethan);
             
           return  r.Select(e => new MinimalProductDto
           {
               Id= (int)e.Id,
               
               NameArabic=e.NameArabic,
               DiscArabic=e.DiscriptionArabic,
               Discount=e.Discount,
               Name = e.Name,
               ImagePath =e.ImagePath,
               Price=e.Price,
                    Discription = e.Discription,
               
           });
             
            

        }
    }
}
