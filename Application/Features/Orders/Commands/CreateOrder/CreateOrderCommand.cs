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
    public class CreateOrderCommand : IRequest<bool>
    {
  
             public  List<OrderItem> orderItem { get; set; }

             public int? CardId { set; get; }

             public int? UserID { set; get; }
          
             public float? ShippingPrice { get; set; }
             public float? Tax { get; set; }

             public DateTime? DateOrder { get; set; }

             public string? OrderStatus { get; set; }

             public DateTime? DeliveryDate { get; set; }

             public int? Total { set; get; }

        

        public CreateOrderCommand() { }

        public CreateOrderCommand(List<OrderItem> orderItem, int? CardId, int? UserID, 
          float? ShippingPrice, float? Tax, int? Total
            )
        {
            this.orderItem = orderItem;
            this.CardId = CardId;
            this.UserID = UserID;
            this.ShippingPrice = ShippingPrice;
            this.Tax = Tax;
            this.DeliveryDate = DateTime.Now.AddDays(3);
            DateOrder = DateTime.Now;
            this.OrderStatus = "Pending";
           
            this.Total = Total;
        }
    }
}
