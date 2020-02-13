using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string RoleID { get; set; }
        [Required(ErrorMessage = "Du måste ge ett namn till Rollen")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
