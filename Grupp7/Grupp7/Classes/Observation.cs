using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Classes
{
    public class Observation
    {
        public DateTime Datetime { get; set; }
        public Animal Animal { get; set; }
        public Weather Weather { get; set; }
    }
}
