using System;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;

namespace cat.itb.M6UF2Pr
{
    public class SessionFactoryCloud
    {
        private static string ConnectionString = "Server=salt.db.elephantsql.com;Port=5432;Database=ckxphvzj;User Id=ckxphvzj;Password=JU8zz0bCN-dkuBPEATZTTTp9vy3RI-gY;";
        private static ISessionFactory session;

        public static ISessionFactory CreateSession()
        {
            if (session != null)
                return session;

            IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);
            var configMap =
                Fluently.Configure().Database(configDB)
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Employee>())
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Order>())
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Supplier>())
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Product>());

            session = configMap.BuildSessionFactory();

            return session;
        }

        public static ISession Open()
        {
            return CreateSession().OpenSession();
        }
    }
}
