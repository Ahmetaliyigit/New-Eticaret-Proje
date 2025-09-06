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

        [Required]     
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

        public List<OrderProducts> OrderProducts { get; set; } = new List<OrderProducts>();
    }
}
