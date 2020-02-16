using Grupp7.Classes;
using Grupp7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    public class IndexViewModel
    {
        public List<UserRankViewModel> UserRankList { get; set; }

        public IndexViewModel()
        {
            UserRankList = new List<UserRankViewModel>();
        }
    }
}
