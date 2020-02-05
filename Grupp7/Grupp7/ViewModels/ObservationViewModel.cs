using Grupp7.Classes;
using Grupp7.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    public class ObservationViewModel
    {
        //  public List<Animal> AnimalList { get; set; }
        // public List<Weather> WeatherList { get; set; }
        //public List<User> UserList { get; set; }

        private readonly IRepository repository;

        public List<Observation> ObservationsList { get; set; }
        public List<Specie> Species { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ObservationViewModel(IRepository repository)
        {
            this.repository = repository;
        }

        public ObservationViewModel()
        {
        }

        public void OnGet()
        {
            Species = repository.Search(SearchTerm).ToList();
        }
    }
}
