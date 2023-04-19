using MediatR;
using ModelDto.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetAllOrders
{
   
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderMinimalDto>>
    {
      public int UserID{ set; get; }
    }
}