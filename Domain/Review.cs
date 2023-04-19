using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
  public  class Review
    {

        [Key]
        public int Id { get; set; }
        public string? Comment { get; set; }
        [Required]
        public int Rate { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("user")]
        public int UserId { get; set; }
        public User? user { get; set; }
        //Relation between Product and Review ??????

        [ForeignKey("product")]
        public long ProductId { get; set; }
        public Product? product { get; set; }



    }
}
