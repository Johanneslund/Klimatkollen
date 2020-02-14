using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    // This class is referencing the SQL database table for AspNetUserRoles
    public class UserRoleViewModel
    {
        public string UserID { get; set; }
        public string Email { get; set; }
        public bool IsSelected { get; set; }
    }
}
