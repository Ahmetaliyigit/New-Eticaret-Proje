using System.ComponentModel.DataAnnotations;

namespace E_Ticaret_Prjesi_AHMT.Models
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
