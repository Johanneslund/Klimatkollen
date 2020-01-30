using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Classes
{
    public class Weather
    {
        public int WeatherId { get; set; }

        public DateTime Datetime { get; set; }

        public string Type { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string Temperature { get; set; }

        public string PH { get; set; }

        public string Humidity { get; set; }

        public string Carbon { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
