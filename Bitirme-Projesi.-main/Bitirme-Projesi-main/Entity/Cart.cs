    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Entity
    {
        public class Cart
        {
            public int Id { get; set; }

            public string UserId { get; set; }
            public ApplicationUser User { get; set; }


           public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
        }
    }
