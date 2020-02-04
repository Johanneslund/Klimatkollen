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
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public Animal Animal { get; set; }
        public Weather Weather { get; set; }

        [ForeignKey ("AnimalId")]
        public int AnimalId { get; set; }

        [ForeignKey("WeatherId")]
        public int WeatherId { get; set; }

    }
}
