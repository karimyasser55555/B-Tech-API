using Application.Contracts;
using Application.Features.Reviews.Commands.DeleteReview;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reviews.Commands.DeleteProduct
{
    public class DeleteReviewHandler : IRequestHandler<DeleteReviewCommand, bool>
    {
        private readonly IReviewRepository _reviewRepository;
        public DeleteReviewHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

       

        public async Task<bool> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var IsExist =await _reviewRepository.GetByIdAsyc(request.Id);
            if(IsExist!=null)
            {
                await _reviewRepository.DeleteAsync(request.Id);

                return true;
            }
            return false;
        }
    }
}
