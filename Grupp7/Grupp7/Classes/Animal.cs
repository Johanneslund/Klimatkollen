using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Classes
{
    public class Animal 
    {
        public int AnimalId { get; set; }
        [DisplayName("Datum")]
        public DateTime Datetime { get; set; }
        [DisplayName("Päls")]
        
        public string Coat { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        [ForeignKey("SpecieId")]
        public int SpecieId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public User User { get; set; }

        public Specie Specie { get; set; }
    }
}
