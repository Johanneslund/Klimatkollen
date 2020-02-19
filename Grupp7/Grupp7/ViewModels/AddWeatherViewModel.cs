using Grupp7.Classes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    public class AddWeatherViewModel
    {
        public Weather Weather { get; set; }
        public User User { get; set; }
        public List<SelectListItem> WeatherTypes {get; set;}
    }
}
