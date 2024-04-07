using System;
using NHibernate;
using NHibernate.Criterion;
namespace cat.itb.M6UF2EA4
{
    public class EmpleadosCRUD
    {
        public static List<Empleado> SelectAllCriteria()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                var criteria = session.CreateCriteria<Empleado>();
                return criteria.List<Empleado>().ToList();
            }
        }

        public static List<Empleado> SelectSalariGreater2000Criteria()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                double salari = 2000;
                var criteria = session.CreateCriteria<Empleado>();
                criteria.Add(Restrictions.Gt("Salario", salari));
                criteria.SetProjection(Projections.ProjectionList()
                                       .Add(Projections.Property("Apellido"))
                                                          .Add(Projections.Property("Salario")));
                var result = criteria.List<object[]>();

                var empleados = result.Select(row => new Empleado
                {
                    Apellido = (string)row[0],
                    Salario = (double)row[1]
                }).ToList();
                return empleados;
            }
        }

        public static List<Empleado> SelectVendedorOrderBySalarioDescQueryOver()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                Empleado empleado = null;
                var query = session.QueryOver<Empleado>(() => empleado)
                                   .Where(() => empleado.Oficio == "VENDEDOR")
                                   .OrderBy(() => empleado.Salario).Desc
                                   .List();
                return query.ToList();
            }
        }

        public static List<Empleado> SelectApellidoOficiStartSApellidoHQL()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                var query = session.CreateQuery("select e.Apellido, e.Oficio, e.Salario from Empleado e where e.Apellido like 'S%'");
                var result = query.List<object[]>();

                var empleadosInfo = result.Select(row => new Empleado
                {
                    Apellido = (string)row[0],
                    Oficio = (string)row[1],
                    Salario = (double)row[2]
                }).ToList();
                return empleadosInfo;
            }
        }

        public static List<string> SelectCognomSalariBetween2000_3500QueryOver()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                Empleado empleado = null;
                var query = session.QueryOver<Empleado>(() => empleado)
                                   .Where(Restrictions.Between(Projections.Property(() => empleado.Salario), 2000, 3500))
                                   .OrderBy(() => empleado.Apellido).Asc
                                   .Select(Projections.Property(() => empleado.Apellido))
                                   .List<string>();
                return query.ToList();
            }
        }

        public static List<Empleado> SelectOficioEmpleadoSalariGreater1400QueryOver()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                Empleado empleado = null;
                var query = session.QueryOver<Empleado>(() => empleado)
                                   .Where(Restrictions.And(Restrictions.Eq(Projections.Property(() => empleado.Oficio), "EMPLEADO"), Restrictions.Gt(Projections.Property(() => empleado.Salario), 1400)))
                                   .List();
                return query.ToList();
            }
        }

        public static Empleado SelectSalariMaxQueryOver()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                Empleado empleado = null;
                var query = session.QueryOver<Empleado>(() => empleado)
                                   .OrderBy(() => empleado.Salario).Desc
                                   .Take(1)
                                   .SingleOrDefault();
                return query;
            }
        }
    }
}
