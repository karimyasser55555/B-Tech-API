using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class User : IdentityUser<int>

    {

        //public long Id { get; set; }

        [MaxLength(100), MinLength(3)]
        public string Fname { get; set; }
        [MaxLength(100), MinLength(3)]
        public string Lname { get; set; }
        //relation with user
        public virtual IEnumerable<Role> Roles { get; set; }
        //relation with UserPaymetMethods

        
        public User(string fname, string lname)
        {

            Fname = fname;
            Lname = lname;
            Roles = new List<Role>();
         
        }



        public User() : this(null!, null!)
        {


        }
    }
}
