using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace Application.Contracts
{
    public interface IOrderItemRepository
    {
        List<OrderItem> GetAll();
        OrderItem Get(int Id);
        void Create(OrderItem Order_Items);
        void Update(int Id, OrderItem Order_Items);
        void Delete(int Id);
    }
}
