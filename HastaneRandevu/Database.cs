using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using HastaneRandevu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HastaneRandevu
{
    public class Database
    {
        private const string SessionKey = "HastaneRandevu.Database.SessionKey";
        private static ISessionFactory _sessionFactory;

        public static ISession Session
        {
            get { return (ISession)HttpContext.Current.Items[SessionKey]; }
        }

        public static void Configure()
        {
            var config = new Configuration();
            config.Configure();

            var mapper = new ModelMapper();
            mapper.AddMapping<HastalarMap>();
            mapper.AddMapping<YoneticilerMap>();
            mapper.AddMapping<HastanelerMap>();
            mapper.AddMapping<HekimlerMap>();
            mapper.AddMapping<IllerMap>();
            mapper.AddMapping<IlcelerMap>();
            mapper.AddMapping<RandevularMap>();
            mapper.AddMapping<KliniklerMap>();
            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            _sessionFactory = config.BuildSessionFactory();

        }

        public static void OpenSession()
        {
            HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession();
        }

        public static void CloseSession()
        {
            var session = HttpContext.Current.Items[SessionKey] as ISession;
            if (session != null)
                session.Close();
            HttpContext.Current.Items.Remove(SessionKey);
        }
    }
}