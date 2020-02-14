using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Roles = new List<string>();
        }

        public IList<string> Roles { get; set; }
        public string ID { get; set; }
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
