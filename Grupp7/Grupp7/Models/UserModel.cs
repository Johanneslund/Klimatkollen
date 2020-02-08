using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Models
{
    public class UserModel
    {
        public string Id { get; set; }

        //[Required]
        public string Firstname { get; set; }

        //[Required]
        public string Lastname { get; set; }

        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        //[Compare("Password", ErrorMessage = "Password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        public int Phone { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        public string Message { get; set; }
    }
}
