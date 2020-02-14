using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupp7.Classes
{
    public class Equipment
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public bool IsAvaliable { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
