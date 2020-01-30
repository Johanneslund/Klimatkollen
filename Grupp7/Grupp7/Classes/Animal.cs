using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Classes
{
    public class Animal
    {
        public int AnimalId { get; set; }

        public DateTime Datetime { get; set; }

        public string Name { get; set; }

        public string Coat { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        [ForeignKey("SpeciesId")]
        public int SpeciesId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public User User { get; set; }

        public Species Species { get; set; }
    }
}
