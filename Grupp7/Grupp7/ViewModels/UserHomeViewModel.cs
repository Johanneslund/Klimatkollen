﻿using Grupp7.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.ViewModels
{
    public class UserHomeViewModel
    {
        public User User { get; set; }
        public List<Observation> NearbyObservation {get; set;}
        public double radius { get; set; }
        public int daysBeforeToday { get; set; }
        public bool IsUserObservation { get; set; }

    }
}
