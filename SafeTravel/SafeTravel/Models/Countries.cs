using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafeTravel.Models
{
    public class Countries
    {
        public int id { get; set; }
        public string name{ get; set; }

        public DateTime checkin { get; set; }

        public DateTime checkout { get; set; }
    }
}