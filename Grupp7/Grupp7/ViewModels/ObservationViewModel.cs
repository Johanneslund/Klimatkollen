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

        public List<object> ObservationsList { get; set; } // test
        public string CentralLatitude { get; set; }
        public string CentralLongitude { get; set; }
        public int Winter { get; set; }
        public int Summer { get; set; }
        public int Mixed { get; set; }
    }
}
