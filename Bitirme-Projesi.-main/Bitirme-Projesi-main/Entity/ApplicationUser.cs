using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }



        // For Cart


        public Cart Cart { get; set; }

    }
}
