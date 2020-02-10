using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Models
{
    public class UserModel
    {
        public string Id { get; set; }

        
        [DisplayName("Förnamn")]
        public string Firstname { get; set; }

       
        [DisplayName("Efternamn")]

        public string Lastname { get; set; }
        [DisplayName("Användarnamn")]

        public string Username { get; set; }

        [Required(ErrorMessage = "Ange en korrekt E-post adress")]
        [EmailAddress]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ange ett säkert lösenord, Det krävs minst 1: Stor bokstav, liten bokstav, siffra, tecken, längden måste vara minst 6")]
        [DataType(DataType.Password)]
        [DisplayName("Lösenord")]

        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Konfirmera lösenord")]
        //[Compare("Password", ErrorMessage = "Password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Ange ett korrekt telefonnummer")]
        [DisplayName("Telefonnummer")]
        public int Phone { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        public string Message { get; set; }
        public string Subject { get; set; }
    }
}
