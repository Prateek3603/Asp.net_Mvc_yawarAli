﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Team8amRockingStars
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default1",
                url: "pistahouse/burger",
                defaults: new { controller = "New", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default2",
                url: "tajmahal/sweets",
                defaults: new { controller = "New", action = "Index", id = UrlParameter.Optional }
            );



            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
         );

            

        }
    }
}
