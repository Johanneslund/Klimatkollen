using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role namn")]
        public string RoleName { get; set; }
    }
}
