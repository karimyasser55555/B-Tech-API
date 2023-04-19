using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace ModelDto.OrderDto
{
    public class OrderMinimalDto
    {
        public int Id { get; set; }
        
        public string? OrderStatus { get; set; }
        public List<int> odersItem { get; set; }

        public List<OrderItem> orderItems { set; get; }
    }
}
