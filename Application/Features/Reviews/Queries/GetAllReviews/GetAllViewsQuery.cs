using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

using ModelDto.ProductDto;
using ModelDto.Review;

namespace Application.Features.Reviews.Queries.GetAllQuery
{
    public class GetAllViewsQuery:IRequest<IEnumerable<ReviewMinimalDTO>>
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public int? Rate { get; set; }
        public DateTime? Date { get; set; }
        public int? userId { get; set; }
        public long? productId { get; set; }


    }
}
