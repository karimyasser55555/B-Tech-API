using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Application.Features.Reviews.Commands.DeleteReview
{
    public class DeleteReviewCommand:IRequest<bool>
    {
        public int Id { set; get; }

    }
}
