﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Classes
{
    public class Statistics
    {
        public int FirstWinter { get; set; }
        public int FirstSummer { get; set; }
        public int FirstMixed { get; set; }
        public int SecondSummer { get; set; }
        public int SecondWinter { get; set; }
        public int SecondMixed { get; set; }

        public int [] GrouseByYear { get; set; }
        public int[] FrogByYear { get; set; }
        public int[] FoxByYear { get; set; }
        public int[] SwineByYear { get; set; }
        public int[] HareByYear { get; set; }


    }
}