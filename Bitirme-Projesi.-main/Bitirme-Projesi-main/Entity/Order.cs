using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string UserNo { get; set; }

        [Required]      // otomatik İngilizce mesaj
        public string Mobile { get; set; }

        [Required]
        public string AdressLine { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ZipCode { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
