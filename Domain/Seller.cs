using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
   public class Seller:User
    {
 

        public string CompanyName { get; set; }

        public float Rating { get; set; }//????????????????????/

        public string Description { get; set; }

        public IEnumerable<Product> products { get; set; }

    }
}
