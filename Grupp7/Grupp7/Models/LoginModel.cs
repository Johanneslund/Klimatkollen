using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Models
{
    public class LoginModel
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "Ange en korrekt E-post adress")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ange korrekt lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Kom ihåg mig")]
        public bool RememberMe { get; set; }
    }
}
