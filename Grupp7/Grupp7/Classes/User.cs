using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Classes
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Ange förnamn")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Ange efternamn")]
        public string Lastname { get; set; }
        public string City { get; set; }
        [Required(ErrorMessage = "Välj punkt på kartan")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "Välj punkt på kartan")]
        public string Longitude { get; set; }
        //public string Email { get; set; }
        public string Username { get; set; }

        [ForeignKey("Id")]
        public string Id { get; set; }
    }
}
