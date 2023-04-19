using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll();
        Task<List<Order>> GetAllByUserID(int UserID);
        Task<Order> Get(int Id);
        void Create(Order Order_Details);
        void Update(int Id, Order Order_Details);
        Task Delete(int Id);

    }
}
