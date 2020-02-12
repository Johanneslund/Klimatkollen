﻿using Grupp7.Classes;
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

        public static Animal setCurrentTime(Animal animal)
        {
            Animal _animal = animal;
            _animal.Datetime = DateTime.Now;
            return _animal;
        }
        public static List<SelectListItem> getCoats()
        {
            List<SelectListItem> coatList = new List<SelectListItem>();
            coatList.Add(new SelectListItem { Value = "Sommar", Text = "Sommar"});
            coatList.Add(new SelectListItem { Value = "Vinter", Text = "Vinter"});
            coatList.Add(new SelectListItem { Value = "Spräcklig", Text = "Spräcklig"});

            return coatList;
        }
        public static List<Animal> filterByDate(ObservationViewModel model)
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
        public static void getCoatColors(ObservationViewModel model)
        {
            List<string> coatColor = new List<string>();
            foreach (var item in model.AnimalList)
            {
                if(item.Coat == "Sommar") 
                {
                    model.Summer++;
                }
                if(item.Coat == "Vinter")
                {
                    model.Winter++;
                }
                if(item.Coat == "Spräcklig")
                { 
                model.Mixed++;
                }
            }
        }
    }
}
