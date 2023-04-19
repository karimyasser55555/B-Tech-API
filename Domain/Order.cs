using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    
    public class Order
    {
        public int Id { get; private set; }

        public DateTime? DateOrder { get; set; }

        public string? OrderStatus { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [ForeignKey("User")]
        public int? UserID { get; set; }

        [ForeignKey("Card")]
        public int? CardId { set; get; }
        public float? ShippingPrice { get; set; }

        public float? Tax { get; set; }
        public virtual User? User { get; set; }

        public virtual Card? Card { set; get; }
      
        public int? Total { set; get; }
        private List<OrderItem> OrderItem { set; get; }

        public IEnumerable<OrderItem> OrderItems
        {
            set
            {
                OrderItem = value.ToList();
            }

            get
            {
                return OrderItem;
            }
        }
        public Order() {

            OrderItem = new List<OrderItem>();
        }
        public Order(IEnumerable<Product> products, string orderStatus,
            DateTime? dateOrder = null, DateTime? deliveryDate = null, float? shippingPrice = null, float? tax = null)
        {
            OrderItems = OrderItem;


        }

        public Order(IEnumerable<OrderItem> orderItem)
        {
            OrderItems = orderItem;


        }


        public bool AddOrderItem(OrderItem orderItem)
        {
            //var availableproduct = products.FirstOrDefault(a => a.Id == product.Id);
            //if (availableproduct == null)
            //{
            

            
                 OrderItem.Add(orderItem);
                return true;
            //}
            //else { return false; }
        }
 
        public bool Removefromproducts(OrderItem orderItem)
        {
            
                OrderItem.Remove(orderItem);
                return true;
 
        }
    }
}
