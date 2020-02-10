using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Classes
{
    public class Specie
    {
        public int SpecieId { get; set; }
        [DisplayName("Djur")]
        public string Speciename { get; set; }
    }
}
