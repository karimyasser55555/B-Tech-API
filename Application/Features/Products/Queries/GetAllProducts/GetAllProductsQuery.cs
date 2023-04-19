using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ModelDto.ProductDto;

namespace Application.Features.Products.Queries.GetAllQuery
{
    public class GetAllProductsQuery:IRequest<IEnumerable<MinimalProductDto>>
    {
      public  string ? Name { set; get; }
        public string? ArabicName { set; get; }
       
        public int? Discount { set; get; }
        public float? Morethan { set; get; }
        public float? Lessthan { set; get; }
      
        public string? Lang { set; get; }
        public int? CategoryId { set; get; }
 
    }
}
