using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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

        public string Cart { get; set; }
        public Cart Carts { get; set; }

    }
}
