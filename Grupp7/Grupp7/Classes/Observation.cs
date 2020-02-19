using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Classes
{
    public class Observation
    {
        public DateTime Datetime { get; set; }
        public string ObservationTypes { get; set; }
        public string Cities { get; set; }
        public string Names { get; set; }
        public string FirstNames { get; set; } 
        public Animal Animal { get; set; }
        public Weather Weather { get; set; }
    }
}
