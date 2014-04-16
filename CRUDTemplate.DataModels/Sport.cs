using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsDB.DataModels
{
    public class Sport
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public int Teams { get; set; }

        //Foreign Key
        public int Athleteid { get; set; }
    }
}
