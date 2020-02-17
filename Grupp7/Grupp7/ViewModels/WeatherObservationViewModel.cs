using Grupp7.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    public class WeatherObservationViewModel
    {
        public Weather Weather { get; set; }
        public User User { get; set; }
        public string Email { get; set; }
    }
}
