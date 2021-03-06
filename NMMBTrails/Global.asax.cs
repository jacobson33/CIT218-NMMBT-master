﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NMMBTrails.DAL;

namespace NMMBTrails
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["dataFilePath"] = new DataConfig().xmlPath;
        }

        protected void Session_Start()
        {
            XMLDataService xml = new XMLDataService();
            Session["Trails"] = xml.Read();
            Session["Permission"] = "User";
        }
    }
}
