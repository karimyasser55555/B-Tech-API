using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.UpdateOrder
{
   public class UpdateOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public IEnumerable<OrderItem> orderItems { get; set; }
    }
}
