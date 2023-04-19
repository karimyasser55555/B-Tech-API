using Application.Contracts;
using MediatR;
using ModelDto.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsDto>
    {
        private readonly IOrderRepository _OrderRepository;

        public GetOrderDetailsQueryHandler(IOrderRepository order)
        {
            _OrderRepository = order;
        }
        public async Task<OrderDetailsDto> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var item = await _OrderRepository.Get(request.Id);
           if(item.DeliveryDate==DateTime.Now)
            {
                item.OrderStatus = "Delevired";

            }
            return new OrderDetailsDto
            {
                Id = item.Id,
               ShippingPrice=item.ShippingPrice,
               Tax=item.Tax,
               DateOrder=item.DateOrder,
             Total=item.Total,
             OrderStatus=item.OrderStatus,
             DeliveryDate=item.DeliveryDate,
             Quantity=item.OrderItems.Select(q=>q.Quantity).Sum()
            } ;
        }
    }
}
