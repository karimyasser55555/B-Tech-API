using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class Images
    {
        public int Id { get; set; }
        public string ImageFileName { get; set; }


        [ForeignKey("Product")]
        public int ProductID { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Product? Product { get; set; }
    }
}
