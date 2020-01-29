using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Classes
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Firstname { get; set; }
        [Required(ErrorMessage = "Ange förnamn")]

        public string Lastname { get; set; }
        [Required(ErrorMessage = "Ange efternamn")]


        public string Username { get; set; }
        [Required(ErrorMessage = "Ange användarnamn")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Ange Email-adress")]


        public string Password { get; set; }
        [Required(ErrorMessage = "Ange ett lösenord")]

        public string Phone { get; set; }

    }
}
