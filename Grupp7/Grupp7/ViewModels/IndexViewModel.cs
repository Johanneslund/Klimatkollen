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
        public List<User> UserList { get; set; }
        public List<Weather> WeatherList { get; set; }
        public List<Animal> AnimalList { get; set; }
        public List<User> UsersRankList { get; set; }

        public IndexViewModel()
        {
            UserList = new List<User>();
            WeatherList = new List<Weather>();
            AnimalList = new List<Animal>();
            UsersRankList = new List<User>();
        }
    }
}
