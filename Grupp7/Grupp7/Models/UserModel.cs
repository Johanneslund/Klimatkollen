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

        [Required(ErrorMessage = "Ange ett förnamn")]
        [DisplayName("Förnamn")] 
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Ange ett efternamn")]
        [DisplayName("Efternamn")]

        public string Lastname { get; set; }
        [DisplayName("Användarnamn")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Ange en korrekt e-post adress")]
        [EmailAddress]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ange ett säkert lösenord, Det krävs minst 1: Stor bokstav, liten bokstav, siffra, tecken, längden måste vara minst 6")]
        [DataType(DataType.Password)]
        [DisplayName("Lösenord")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Välj punkt på kartan")]
        public string City { get; set; }
        
        public string Latitude { get; set; }
        
        public string Longitude { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Konfirmera lösenord")]
        [Compare("Password", ErrorMessage = "Lösenorden matchar inte")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Ange ett korrekt telefonnummer")]
        [DisplayName("Telefonnummer")]
        public int Phone { get; set; }

        [Display(Name = "Kom ihåg mig")]
        public bool RememberMe { get; set; }

        public string Message { get; set; } 
        public string Subject { get; set; }
        public int ObservationNum { get; set; }
    }
}
