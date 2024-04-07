using System;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;

namespace cat.itb.M6UF2EA3
{
    public class SessionFactoryCloud
    {
        private static string ConnectionString = "Server=raja.db.elephantsql.com;Port=5432;Database=abpedugl;User Id=abpedugl;Password=6Xak1hamaZsNrBltNOIbGtT1uxP4NdRb;";
        private static ISessionFactory session;

        public static ISessionFactory CreateSession()
        {
            if (session != null)
                return session;

            IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);
            var configMap =
                Fluently.Configure().Database(configDB)
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Departamento>())
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Empleado>());

            session = configMap.BuildSessionFactory();

            return session;
        }

        public static ISession Open()
        {
            return CreateSession().OpenSession();
        }
    }
}
