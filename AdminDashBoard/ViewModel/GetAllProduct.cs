using System.ComponentModel.DataAnnotations;
namespace AdminDashBoard.ViewModel
{
    public class GetAllProduct
    {

        public long Id { get; set; }
        public int? Discount { get; set; }
        public string  ImagePath { get; set; }


       
        public string Name { get; set; }

        public string NameArabic { set; get; }

        public string Discription { get; set; }

        public string DiscArabic { set; get; }

        public float Price { get; set; }

        
    }
}
