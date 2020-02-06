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

        public string Firstname { get; set; }
        [Required(ErrorMessage = "Ange förnamn")]

        public string Lastname { get; set; }
        [Required(ErrorMessage = "Ange efternamn")]

        public string Username { get; set; }

        [ForeignKey("Id")]
        public string Id { get; set; }

        





    }
}
