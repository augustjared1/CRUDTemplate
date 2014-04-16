using SportsDB.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsDB.Models
{
    public class HomeIndexVM
    {
        public List<Athlete> Athletes { get; set; }
        public List<Sport> Sports { get; set; }
    }
}