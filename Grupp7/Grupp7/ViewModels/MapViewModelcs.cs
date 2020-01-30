using Grupp7.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    public class MapViewModel
    {
        public List<Animal> Animals { get; set; }
        public string CenterLongitude { get; set; }
        public string CenterLatitude { get; set; }
    }
}
