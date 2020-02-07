using Grupp7.Classes;
using Grupp7.ViewModels;
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
            foreach (var item in model.AnimalList)
            {
                if (item.Latitude != null && item.Longitude != null)
                {
                    latSum += Convert.ToDouble(item.Latitude.Replace('.', ','));
                    longSum += Convert.ToDouble(item.Longitude.Replace('.', ','));
                }
            }
            model.CentralLatitude = (latSum / model.AnimalList.Count).ToString().Replace(',', '.');
            model.CentralLongitude = (longSum / model.AnimalList.Count).ToString().Replace(',', '.');
            return model;
        }

        public static Animal setCurrentTime(Animal animal)
        {
            Animal _animal = animal;
            _animal.Datetime = DateTime.Now;
            return _animal;
        }
    }
}
