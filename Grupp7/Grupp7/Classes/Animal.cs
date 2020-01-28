using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Classes
{
    public class Animal
    {
        public int AnimalId { get; set; }

        public DateTime Datetime { get; set; }

        public string Name { get; set; }

        public int Longitude { get; set; }

        public int Latitude { get; set; }

        public User User { get; set; }
    }
}
