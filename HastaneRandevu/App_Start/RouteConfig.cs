using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HastaneRandevu
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Home", "", new { controller = "Hasta", action = "Index" });
            routes.MapRoute("KayitForm", "kayitform", new { controller = "Hasta", action = "KayitForm" });
            routes.MapRoute("Randevu", "randevu", new { controller = "Hasta", action = "Randevu" });
            routes.MapRoute("Ilceler", "ilceler", new { controller = "Hasta", action = "Ilceler" });
            routes.MapRoute("Hastaneler", "hastaneler", new { controller = "Hasta", action = "Hastaneler" });
            routes.MapRoute("Hekimler", "hekimler", new { controller = "Hasta", action = "Hekimler" });
            routes.MapRoute("Saatler", "saatler", new { controller = "Hasta", action = "Saatler" });
            routes.MapRoute("Logout", "logout", new { controller = "Hasta", action = "Logout" });


        }
    }
}
