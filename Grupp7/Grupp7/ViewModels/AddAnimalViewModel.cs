using Grupp7.Classes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    public class AddAnimalViewModel
    {
        [Required]
        public Animal Animal { get; set; }
        public List<SelectListItem> Species { get; set; }
        public User User { get; set; }
        public List<SelectListItem> Coat { get; set; }
    }
}
