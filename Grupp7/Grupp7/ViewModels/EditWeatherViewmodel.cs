using Grupp7.Classes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    public class EditWeatherViewModel
    {
        public Weather Weather { get; set; }
        public List<SelectListItem> WeatherTypes { get; set; }
    }
}
