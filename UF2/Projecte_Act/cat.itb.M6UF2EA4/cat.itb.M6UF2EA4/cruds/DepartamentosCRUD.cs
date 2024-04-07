using System;
using NHibernate;
using NHibernate.Criterion;
namespace cat.itb.M6UF2EA4
{
    public class DepartamentosCRUD
    {
        public static List<Departamento> SelectAllHQl()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                var query = session.CreateQuery("from Departamento");
                return query.List<Departamento>().ToList();
            }
        }

        public static string SelectLocalizacionHQL(string dnombre)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                var query = session.CreateQuery("select d.Loc from Departamento d where d.Dnombre = :dnombre");
                query.SetParameter("dnombre", dnombre);
                return query.UniqueResult<string>();
            }
        }

        public static List<Departamento> SelectLocalizacionSevillaBarcelonaQueryOver()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                Departamento departamento = null;
                var query = session.QueryOver<Departamento>(() => departamento)
                                   .Where(Restrictions.Or(Restrictions.Eq(Projections.Property(() => departamento.Loc), "SEVILLA"), Restrictions.Eq(Projections.Property(() => departamento.Loc), "BARCELONA")))
                                   .List();
                return query.ToList();
            }
        }


    }
}
