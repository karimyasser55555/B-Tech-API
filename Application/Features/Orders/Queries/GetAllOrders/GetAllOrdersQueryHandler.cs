using Application.Contracts;
using Application.Features.Products.Queries.GetAllQuery;
using MediatR;
using ModelDto.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderMinimalDto>>
    {
        private readonly IOrderRepository _OrderRepository;

        public GetAllOrdersQueryHandler(IOrderRepository order)
        {
            _OrderRepository = order;
        }
        

        public async Task<IEnumerable<OrderMinimalDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var Orders = await _OrderRepository.GetAllByUserID(request.UserID);

            return Orders.Select(a => new OrderMinimalDto { Id = a.Id, OrderStatus = a.OrderStatus,
            orderItems=(a.OrderItems.ToList())
            });;
        }
    }
}
