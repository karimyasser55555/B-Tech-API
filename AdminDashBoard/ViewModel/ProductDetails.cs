using System.ComponentModel.DataAnnotations;
namespace AdminDashBoard.ViewModel
{
    public class ProductDetails
    {
        public long Id { get; set; }
        public int? Discount { get; set; }

        public int AvailUnit { set; get; }

        public string ImagePath { get; set; }

        [MinLength(3), MaxLength(10)]
        public string Name { get; set; }

        public string NameArabic { set; get; }

        public string Discription { get; set; }

        public string DiscArabic { set; get; }

        public int? CategoryId { set; get; }
        public float Price { get; set; }
    }
}
