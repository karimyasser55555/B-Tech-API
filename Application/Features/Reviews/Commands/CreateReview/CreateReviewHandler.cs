using Application.Contracts;
using MediatR;
using System;
using ModelDto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDto.CategoryDto;
using Domain;

namespace Application.Features.Reviews.Commands.CreateProduct
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCaommand, bool>
    {
        private readonly IReviewRepository _reviewRepository;
        public CreateReviewHandler(IReviewRepository reviewRepository)
        {

            _reviewRepository = reviewRepository;
        }

        public async Task<bool> Handle(CreateReviewCaommand request, CancellationToken cancellationToken)
        {
            //Review review = await _reviewRepository.GetByIdAsyc(request.Id);
            var min = new Review()
            {
                Comment = request.Comment,
                Rate = request.Rate,
                Date = request.Date,
                UserId = request.userId,
                ProductId = request.productId


            };
            if (min != null)
            {
                await _reviewRepository.CreateAsync(min);
                return true;
            }
            else
                return false;

        }

    }
    }

