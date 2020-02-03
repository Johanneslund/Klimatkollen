using Grupp7.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    public class UserHomeViewModel
    {
        public User User { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Weather> Weathers { get; set; }
    }
}
