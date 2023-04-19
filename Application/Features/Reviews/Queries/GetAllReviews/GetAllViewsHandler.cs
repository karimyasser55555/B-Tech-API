using Application.Contracts;

using MediatR;
using ModelDto.ProductDto;
using ModelDto.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reviews.Queries.GetAllQuery
{
    public class GetAllViewsHandler : IRequestHandler<GetAllViewsQuery, IEnumerable<ReviewMinimalDTO>>
    {
        private readonly IReviewRepository _reviewRepository;
        public GetAllViewsHandler(IReviewRepository reviewRepository)
        {

            _reviewRepository = reviewRepository;
        }
       

       public async Task<IEnumerable<ReviewMinimalDTO>> Handle (GetAllViewsQuery request, CancellationToken cancellationToken)
        {
            var r = await _reviewRepository.FilterAsync();
               
                
           return  r.Select(e => new ReviewMinimalDTO
           {
               Id= e.Id,
               Comment= e.Comment,
               Rate= e.Rate,
               Date= e.Date,
               userId=e.UserId,
               productId=e.ProductId,


           });


  
    }

       
    }
}
