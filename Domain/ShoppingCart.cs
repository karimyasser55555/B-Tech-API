using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
   public class ShoppingCart
    {
        public int Id { get; set; }

        public DateTime DataAdded { get; set; }//?????????//

 
        public Buyer buyer { get; set; }

        public IEnumerable<Product> products { get; set; }

    }
}
