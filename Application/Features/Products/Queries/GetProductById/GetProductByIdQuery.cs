using MediatR;
using ModelDto.CategoryDto;
using ModelDto.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<MinimalProductDetails>
    {
        public long Id { set; get; }
    }
}
