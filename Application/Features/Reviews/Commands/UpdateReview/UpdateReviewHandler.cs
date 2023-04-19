using Application.Contracts;
using Application.Features.Categories.Commands.UpdateCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reviews.Commands.UpdateProduct
{
    public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand, bool>
    {


        private readonly IReviewRepository _reviewRepository;
        public UpdateReviewHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        

        public async Task<bool> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review=await _reviewRepository.GetByIdAsyc(request.Id);
            if (review != null)
            {
                review.Comment = request.Comment;
                review.Rate = request.Rate;
                review.Date = request.Date;
                review.ProductId = request.productId;
                review.UserId = request.userId;
                await _reviewRepository.UpdateAsync(review);
                return true;
                
               
            }
            return false;

        }
    }
}
