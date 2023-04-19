using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDto.OrderDto
{
    public class OrderDetailsDto
    {
       

        public int Id { get; set; }
       
        public string OrderStatus { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
       
        public DateTime? DateOrder { get; set; }
    
        public float? Total { set; get; }
        public DateTime? DeliveryDate { get; set; }
        public float? ShippingPrice { get; set; }
       public float? Tax { get; set; }

        public int Quantity { set; get; }
        public OrderDetailsDto() { }
        //public OrderDetailsDto
        //    (int Id, string orderStatus, IEnumerable<OrderItem> orderItems,
        //    DateTime? dateOrder = null, DateTime? deliveryDate = null,
        //    float? shippingPrice = null, float? Tax = null)
        //{
        //    this.Id = Id;
           
        //    OrderStatus = orderStatus;
        //    OrderItems = orderItems   ;
        //    this.ShippingPrice = shippingPrice;
        //    this.Tax = Tax;
           

        //}




    }
}
