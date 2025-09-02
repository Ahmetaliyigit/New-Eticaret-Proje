using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price  { get; set; }
        public int Stock { get; set; }
        public string Url { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string Size { get; set; }

        public int GenderId { get; set; }
        public Gender Gender { get; set; }


        // For Cart

        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

    }
}
