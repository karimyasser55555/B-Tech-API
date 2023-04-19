using Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiContext;
using Domain;
namespace Infrastructure
{
    public class OrderItemRepository:IOrderItemRepository
    {
        private readonly DBContext context;

        public OrderItemRepository(DBContext _context)
        {
            context = _context;
        }

        public List<OrderItem> GetAll()
        {
            return context.orderItems.ToList();
        }
        public OrderItem Get(int Id)
        {
            return context.orderItems.Where(o => o.DeletedAt == null).FirstOrDefault(o => o.ID == Id);
        }

        public void Create(OrderItem Order_Items)
        {
            Order_Items.CreatedAt = DateTime.Now;
            context.orderItems.Add(Order_Items);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.orderItems.Remove(Get(Id));
            context.SaveChanges();
        }

        public void Update(int Id, OrderItem Order_Items)
        {
            OrderItem OldOrder_Items = Get(Id);
            OldOrder_Items.Quantity = Order_Items.Quantity;
            OldOrder_Items.OrderID = Order_Items.OrderID;
            OldOrder_Items.ProductID = Order_Items.ProductID;

            OldOrder_Items.UpdatedAt = DateTime.Now;

            context.SaveChanges();
        }
    }
}
