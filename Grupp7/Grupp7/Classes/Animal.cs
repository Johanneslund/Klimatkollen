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
        [Required(ErrorMessage = "Vänligen ange ett datum")]
        public DateTime Datetime { get; set; }
        [DisplayName("Päls")]
        [Required(ErrorMessage = "Vänligen ange djurets päls")]
        [MaxLength(64)]
        public string Coat { get; set; }
        [Required(ErrorMessage = "Använd kartan för att ange Longitude")]
        [MaxLength(128)]
        public string Longitude { get; set; }
        [Required(ErrorMessage = "Använd kartan för att ange Latitude")]
        [MaxLength(128)]
        public string Latitude { get; set; }
        [MaxLength(128)]

        [DisplayName("Stad")]
        [Required(ErrorMessage = "Välj punkt på kartan")]
        public string City { get; set; }
        [ForeignKey("SpecieId")]

        public int SpecieId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public User User { get; set; }

        public Specie Specie { get; set; }
    }
}
