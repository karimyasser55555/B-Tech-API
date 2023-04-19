using Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AdminDashBoard.Models
{
    public class Review
    {
        
        public int Id { get; set; }
        public string? Comment { get; set; }
        [Required]
        public int Rate { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public long ProductId { get; set; }
    }
}
