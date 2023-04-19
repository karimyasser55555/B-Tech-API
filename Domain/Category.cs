using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{

    public class Category
    {

        public int Id { get; set; }

        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }
        public string NameArabic { get; set; }
        [ForeignKey("ParentCategory")]
        public int? parentId { get; set; }
        public Category? ParentCategory { get; set; }
        private IList<Category> ?subcategories;
        public IEnumerable<Category> ?Subcategories { get; set; }

        private IList<Product> products;
        public IEnumerable<Product> Products { get { return products; } }
        [Required]
        
       
        public string ImagePath{set; get;}

        public Category() { }


        public bool AddProduct(Product product)
        {
            var prod = products.FirstOrDefault(e => (e.Name == product.Name) ||
            (e.NameArabic == product.NameArabic));
            if (prod == null)
            {
                products.Add(product);
                return true;
            }
            else
            {
                return false;

            }

        }

        public bool AddSubCategory(Category category)
        {
            var sub = subcategories.FirstOrDefault(e => (e.Name == category.Name)
            ||(e.NameArabic==category.NameArabic));
            if (sub == null)
            {
                subcategories.Add(category);
                return true;
            }
            else
            {
                return false;

            }

        }

         
    }
}
