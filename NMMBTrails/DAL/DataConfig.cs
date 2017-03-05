using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NMMBTrails.DAL
{
    public class DataConfig
    {
        //configuration settings for data storage
        public string jsonPath = HttpContext.Current.Server.MapPath("~/App_Data/Trails.txt");
        public string xmlPath = HttpContext.Current.Server.MapPath("~/App_Data/Trails.xml");
    }
}