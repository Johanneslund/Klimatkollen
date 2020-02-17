using Grupp7.Classes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    public class ObservationViewModel
    {
        public string SearchTerm { get; set; }
        public string ObservationType { get; set; }
        public string Cities { get; set; }
        public string Names { get; set; }
        public string FirstNames { get; set; }
        public List<Observation> ObservationsList { get; set; }
        public List<Weather> WeatherList { get; set; }
        public List<Animal> AnimalList { get; set; }
        public string CentralLatitude { get; set; }
        public string CentralLongitude { get; set; }
        public Statistics Statistics { get; set; }

    }
}
