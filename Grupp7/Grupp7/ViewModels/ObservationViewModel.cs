using Grupp7.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    public class ObservationViewModel
    {
        public List<Animal> AnimalList { get; set; }
        public List<Weather> WeatherList { get; set; }
        public List<User> UserList { get; set; }
        public string SearchTerm { get; set; }
        public List<ObservationViewModel> ObservationsList { get; set; } // test
    }
}
