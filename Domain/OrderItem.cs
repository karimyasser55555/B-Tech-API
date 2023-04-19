using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain
{
    public class OrderItem
    {

        public int ID { get; set; }
        public int Quantity { get; set; }


        [ForeignKey("Order")]
        public int? OrderID { get; set; }
        [ForeignKey("Product")]
        public long? ProductID { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }

    }
}
