using MediatR;
using ModelDto.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reviews.Queries.GetReviewById
{
    public class GetReviewByIdQuery : IRequest<ReviewDetailsDTO>
    {
        public int Id { set; get; }
    }
}
