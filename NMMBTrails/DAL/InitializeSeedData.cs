using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NMMBTrails.Models;

namespace NMMBTrails.DAL
{
    public class InitializeSeedData
    {
        public static IEnumerable<Trail> GetAllTrails()
        {
            IList<Trail> trails = new List<Trail>();

            trails.Add(new Trail { Id = 1, Name = "Trail 1", Longitude = 45.0000, Latitude = 85.0000, County = "Grand Traverse", URL = "#" });
            trails.Add(new Trail { Id = 2, Name = "Big Trail", Longitude = 45.0000, Latitude = 85.0000, County = "Leelanau", URL = "#" });
            trails.Add(new Trail { Id = 3, Name = "Little Trail", Longitude = 45.0000, Latitude = 85.0000, County = "Otsego", URL = "#" });
            trails.Add(new Trail { Id = 4, Name = "Wooded Trail", Longitude = 45.0000, Latitude = 85.0000, County = "Grand Traverse", URL = "#" });
            trails.Add(new Trail { Id = 5, Name = "Easy Riding", Longitude = 45.0000, Latitude = 85.0000, County = "Kalkaska", URL = "#" });
            trails.Add(new Trail { Id = 6, Name = "Trail 17", Longitude = 45.0000, Latitude = 85.0000, County = "Leelanau", URL = "#" });
            trails.Add(new Trail { Id = 7, Name = "Trail 2", Longitude = 45.0000, Latitude = 85.0000, County = "Grand Traverse", URL = "#" });
            trails.Add(new Trail { Id = 8, Name = "Mountain Top", Longitude = 45.0000, Latitude = 85.0000, County = "Mackinaw", URL = "#" });

            return trails;
        }
    }
}