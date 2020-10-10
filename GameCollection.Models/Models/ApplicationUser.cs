using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GameCollection.Models
{
    // extend the intendify user table and add these fields to the class and db
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped] // don't map to field in db
        public string FullName { get { return FirstName + " " + LastName; } }
    }

}
