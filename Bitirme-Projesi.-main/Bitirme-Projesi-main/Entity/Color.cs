using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Color
    {
        public int Id { get; set; }
        public string ColorName  { get; set; }

        List<Product> Products { get; set; }

    }
}
