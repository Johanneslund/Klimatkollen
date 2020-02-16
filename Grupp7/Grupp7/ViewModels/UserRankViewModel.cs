using Grupp7.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    public class UserRankViewModel
    {
        public User User { get; set; }
        public int observationNum { get; set; }
        public int position { get; set; }

        public UserRankViewModel()
        {
            User = new User();
        }
    }
}
