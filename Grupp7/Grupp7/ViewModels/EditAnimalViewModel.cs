﻿using Grupp7.Classes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    public class EditAnimalViewModel
    {
        public Animal Animal { get; set; }
        public List<SelectListItem> Species {get; set;}
        public List<SelectListItem> Coats { get; set; }
    }
}
