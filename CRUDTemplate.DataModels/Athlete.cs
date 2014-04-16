using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsDB.DataModels
{
    public class Athlete
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }

        //Reverse Lookup
        public virtual List<Sport> Sports { get; set; }
    }
}
