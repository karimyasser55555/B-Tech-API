using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Features.Categories.Queries.GetCategoryById;
using Application.Features.Products.Queries.GetProductById;
using MediatR;
using ModelDto.Review;

namespace Application.Features.Reviews.Queries.GetReviewById
{
    public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdQuery, ReviewDetailsDTO>
    {
        private readonly IReviewRepository _reviewRepository;
       
        public GetReviewByIdHandler(IReviewRepository reviewRepository )
        {

            _reviewRepository= reviewRepository;
            
        }

        async Task<ReviewDetailsDTO> IRequestHandler<GetReviewByIdQuery, ReviewDetailsDTO>.Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var r = await _reviewRepository.GetByIdAsyc(request.Id);

            return new ReviewDetailsDTO
            {
                Id = request.Id,
                Comment = r.Comment,
                Rate = r.Rate,
                Date = r.Date,
                userId = r.UserId,
                productId = r.ProductId,


            };
        }



    }
}
