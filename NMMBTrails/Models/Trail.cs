using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NMMBTrails.Models
{
    public class Trail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string County { get; set; }
        public string URL { get; set; }
    }
}