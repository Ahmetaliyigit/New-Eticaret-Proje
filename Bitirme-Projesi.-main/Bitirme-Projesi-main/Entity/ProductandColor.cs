using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ProductandColor
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Color> Colors { get; set; } = new List<Color>();

        public List<Gender> Genders { get; set; } = new List<Gender>();
    }
}
