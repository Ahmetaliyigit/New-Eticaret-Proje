using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Gender
    {
        public int Id { get; set; }
        public string GenderName { get; set; }

        List<Product> Products { get; set; }

    }
}
