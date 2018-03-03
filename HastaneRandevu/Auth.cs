using HastaneRandevu.Models;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HastaneRandevu
{
    public static class Auth
    {
        public static Hastalar Hastalar
        {
            get
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                    return null;

                var hasta = HttpContext.Current.Items["HastalarKey"] as Hastalar;
                if (hasta == null)
                {
                    hasta = Database.Session.Query<Hastalar>().FirstOrDefault(u => u.TcKimlik == HttpContext.Current.User.Identity.Name);
                }

                if (hasta == null)
                    return null;

                HttpContext.Current.Items["HastalarKey"] = hasta;

                return hasta;
            }
        }
    }
}