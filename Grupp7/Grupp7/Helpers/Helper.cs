using Grupp7.Classes;
using Grupp7.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Grupp7.Helpers
{
    public static class Helper
    {
        public static ObservationViewModel getCentralPosition(ObservationViewModel model)
        {

            double latSum = 0;
            double longSum = 0;
            foreach (var item in model.ObservationsList)
            {
                if (item.Animal?.Latitude != null && item.Animal?.Longitude != null)
                {
                    latSum += Convert.ToDouble(item.Animal.Latitude.Replace('.', ','));
                    longSum += Convert.ToDouble(item.Animal.Longitude.Replace('.', ','));
                }
                if (item.Weather?.Latitude != null && item.Weather?.Longitude != null)
                {
                    latSum += Convert.ToDouble(item.Weather.Latitude.Replace('.', ','));
                    longSum += Convert.ToDouble(item.Weather.Longitude.Replace('.', ','));
                }
            }
            model.CentralLatitude = (latSum / model.ObservationsList.Count).ToString().Replace(',', '.');
            model.CentralLongitude = (longSum / model.ObservationsList.Count).ToString().Replace(',', '.');
            return model;
        }

        public static Animal setCurrentTimeAnimal(Animal animal)
        {
            Animal _animal = animal;
            _animal.Datetime = DateTime.Now;
            return _animal;
        }
        public static Weather setCurrentTimeWeather(Weather weather)
        {
            Weather _weather = weather;
            _weather.Datetime = DateTime.Now;
            return _weather;
        }
        public static List<SelectListItem> getCoats()
        {
            List<SelectListItem> coatList = new List<SelectListItem>();
            coatList.Add(new SelectListItem { Value = "Sommar", Text = "Sommar" });
            coatList.Add(new SelectListItem { Value = "Vinter", Text = "Vinter" });
            coatList.Add(new SelectListItem { Value = "Spräcklig", Text = "Spräcklig" });

            return coatList;
        }
        public static List<Animal> filterByDate(ObservationViewModel model, DateTime startDate, DateTime endDate, int aSpecie)// Specie
        {

            List<Animal> sortedList = new List<Animal>();
            foreach (var item in model.AnimalList.Where(x => x.SpecieId == aSpecie))
            {
                if (item.Datetime > startDate && endDate > item.Datetime)
                {
                    sortedList.Add(item);
                }

            }
            return sortedList;
        }
        public static List<Observation> filterByDateUserHome(List<Observation> observations, DateTime startDate, DateTime endDate)
        {

            List<Observation> sortedList = new List<Observation>();
            foreach (var item in observations)
            {
                if (item.Datetime > startDate && endDate > item.Datetime)
                {
                    sortedList.Add(item);
                }

            }
            return sortedList;
        }
        public static List<Observation> PopulateObservationList(List<Animal> Animals, List<Weather> Weathers)
        {
            List<Observation> nearbyObservations = new List<Observation>();
            foreach (var item in Animals)
            {
                nearbyObservations.Add(new Observation() { Animal = item, Datetime = item.Datetime });
            }
            foreach (var item in Weathers)
            {
                nearbyObservations.Add(new Observation() { Weather = item, Datetime = item.Datetime });
            }
            return nearbyObservations;
        }
        /* before the changes 
         * public static List<Animal> filterByDate(ObservationViewModel model, Animal specie, DateTime startdate, DateTime Enddate)
        {
            DateTime startDate = new DateTime(2010, 1, 1);
            DateTime endDate = new DateTime(2019, 12, 31);
            List<Animal> sortedList = new List<Animal>();
            foreach (var item in model.AnimalList)
            {
                if(item.Datetime > startDate && endDate > item.Datetime)
                {
                    sortedList.Add(item);
                }
                
            }
            return sortedList;
        }
         */

        public static int[] GetAnimalsByYear(ObservationViewModel model, int specieId)
        {
            int[] animalsByYear = new int[] {0,0,0,0,0,0,0,0,0,0,0};
            DateTime year = new DateTime(2010, 01, 01);
            int count = 0;
            int arrPosition = 0;

            while (arrPosition < 11)
            {
                foreach (var item in model.AnimalList.Where(x => x.SpecieId == specieId))
                {
                    if (item.Datetime.Year == year.Year)
                    {
                        count++;
                    }
                }
                animalsByYear[arrPosition] = count;
                arrPosition++;
                count = 0;
                year = year.AddYears(1);
            }
            return animalsByYear;
        }

        public static void getCoatColors(ObservationViewModel model, List<Animal> sortedList, int period)
        {

            List<string> coatColor = new List<string>();
            foreach (var item in sortedList)
            {
                if (item.Coat == "Sommar")
                {
                    if (period == 1)
                    {
                        model.Statistics.FirstSummer++;
                    }
                    else if (period == 2)
                    {
                        model.Statistics.SecondSummer++;
                    }
                }

                if (item.Coat == "Vinter")
                {
                    if (period == 1)
                    {
                        model.Statistics.FirstWinter++;
                    }
                    else if (period == 2)
                    {
                        model.Statistics.SecondWinter++;
                    }

                }
                if (item.Coat == "Spräcklig")
                {
                    if (period == 1)
                    {
                        model.Statistics.FirstMixed++;
                    }
                    else if (period == 2)
                    {
                        model.Statistics.SecondMixed++;
                    }

                }
            }
        }
    }
}