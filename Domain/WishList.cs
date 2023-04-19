using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
   public class WishList
    {
        
        public int Id { get; set; }

        public DateTime DataAdded { get; set; } //?????????
       

        [ForeignKey("User")]
        public int UserID { set; get; }
        public User User { set; get; }

       
        private List<Product> _products;

        public IEnumerable<Product> products 
        { get { return _products; }
            
            set { _products = value.ToList(); } }


        public WishList()
        {
            _products = new List<Product>();
        }


        public bool AddProduct(Product product)
        {
           
                _products.Add(product);
                return true;
            

        }

        public bool RemoveProduct(Product product)
        {

            _products.Remove(product);
            return true;


        }
    }
}
