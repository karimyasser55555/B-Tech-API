using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
   public class ContactDetails
    {
        public int Id { get; set; }
        public int AddressId { get; set; }

        public string Street { get; set; }

        public string state  { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public long MobileNumber { get; set; }

 
        public User user { get; set; }

        public IEnumerable<Order> orders { get; set; }
    }
}
