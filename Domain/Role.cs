using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("Role")]
    public class Role : IdentityRole<int>
    {

        
        public virtual IEnumerable<User>? Users { get; set; }


    }
}
