using Application.Contracts;
using Domain;
using MediatR;
using ModelDto.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        public CreateOrderCommandHandler(IOrderRepository order, IOrderItemRepository orderItem)
        {
            _OrderRepository = order;
            _orderItemRepository = orderItem;
        }

       

         async Task<bool> IRequestHandler<CreateOrderCommand, bool>.Handle(CreateOrderCommand request,
             CancellationToken cancellationToken)
        {
          
            Order order = new Order();
            for (int i = 0; i < request.orderItem.Count(); i++)
            {
                _orderItemRepository.Create(request.orderItem[i]);


                order.AddOrderItem(request.orderItem[i]);
                
                
            } ;
            order.DeliveryDate = request.DeliveryDate;
            order.DateOrder = request.DateOrder;
            order.Tax = request.Tax;
            order.ShippingPrice = request.ShippingPrice;
            order.CardId = request.CardId;
            order.UserID = request.UserID;
            order.Total = request.Total;
            order.OrderStatus = request.OrderStatus;    
           
            if (order != null)
            {
                 _OrderRepository.Create(order);
                return true;
            }
            else
                return false;
        }
    }

}

