using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Classes
{
    public class Weather
    {
        public int WeatherId { get; set; }

        public DateTime Datetime { get; set; }

        public string Type { get; set; }

        public int Longitude { get; set; }

        public int Latitude { get; set; }

        public int Temperature { get; set; }

        public int PH { get; set; }

        public int Humidity { get; set; }

        public int Carbon { get; set; }

        public User User { get; set; }
    }
}
