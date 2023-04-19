using ApiContext;
using Application.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
  
    public class OrderRepository : IOrderRepository
    {
        private readonly DBContext context;

        public OrderRepository(DBContext _context)
        {
            context = _context;
        }
        public async Task<List<Order>> GetAll()
        {
            return await context.Orders.Include(d => d.OrderItems)
                .ThenInclude(i => i.Product).ToListAsync();
        }
        public async Task<List<Order>> GetAllByUserID(int UserID)
        {
            return await context.Orders.Include(d => d.OrderItems).ThenInclude(i => i.Product)
                .Where(o => o.UserID == UserID).ToListAsync();
        }
        public async Task<Order> Get(int Id)
        {
            return await context.Orders.Include(d => d.OrderItems).
                FirstOrDefaultAsync(or => or.Id == Id);
        }

        public void Create(Order Order_Details)
        {
           
            context.Orders.Add(Order_Details);
            context.SaveChanges();
        }

        public async Task Delete(int Id)
        {
            Order order =await Get(Id);
             context.Orders.Remove(order);
            await context.SaveChangesAsync();
        }

        public async void Update(int Id, Order Order_Details)
        {
            Order OldOrder_Details =await Get(Id);
            OldOrder_Details.Total = Order_Details.Total;
           
            OldOrder_Details.UserID = Order_Details.UserID;

            await context.SaveChangesAsync();
        }
    }




}

