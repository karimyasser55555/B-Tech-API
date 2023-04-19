using Application.Contracts;
using Application.Features.Orders.Commands.DeleteOrder;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IOrderRepository _OrderRepository;

        public UpdateOrderCommandHandler(IOrderRepository order)
        {
            _OrderRepository = order;
        }
        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var item = await _OrderRepository.Get(request.Id);
            if (item != null && request.orderItems != null)
            {
                item.OrderItems = request.orderItems;

                 _OrderRepository.Update(request.Id,item);
                 
                return true;
            }
            else
                return false;
        }
    }
}
