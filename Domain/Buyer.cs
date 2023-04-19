using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
   public class Buyer:User
    {

         
        public IEnumerable<Card> cards { get; set; }

        public IEnumerable<Order> orders { get; set; }

        public IEnumerable<Review> reviews { set; get; } //?????????????????????????
         
    }
}
