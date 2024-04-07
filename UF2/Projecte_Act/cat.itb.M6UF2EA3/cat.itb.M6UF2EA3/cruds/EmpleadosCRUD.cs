using System;
using NHibernate;
namespace cat.itb.M6UF2EA3
{
    public class EmpleadosCRUD
    {
        public Empleado SelectById(int id)
        {
            Empleado empleado;
            using (var session = SessionFactoryCloud.Open())
            {
                empleado = session.Get<Empleado>(id);
                NHibernateUtil.Initialize(empleado.Departamento);
            }
            return empleado;
        }

        public Empleado SelectByEmpno(int empno)
        {
            Empleado empleado;
            using (var session = SessionFactoryCloud.Open())
            {
                empleado = session.Query<Empleado>().FirstOrDefault(e => e.EmpNo == empno);
                NHibernateUtil.Initialize(empleado.Departamento);
            }
            return empleado;
        }

        public Empleado SelectByApellido(string apellido)
        {
            Empleado empleado;
            using (var session = SessionFactoryCloud.Open())
            {
                empleado = session.Query<Empleado>().FirstOrDefault(e => e.Apellido == apellido);
                NHibernateUtil.Initialize(empleado.Departamento);
            }
            return empleado;
        }

        public List<Empleado> SelectAll()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                return session.Query<Empleado>().ToList();
            }
        }

        public void Insert(Empleado empleado)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(empleado);
                    transaction.Commit();
                    Console.WriteLine($"Empleado {empleado.Apellido} inserted");
                }
            }
        }

        public void Insert(List<Empleado> empleados)
        {
            foreach (var empleado in empleados)
            {
                Insert(empleado);
            }
        }


        public void Delete(Empleado empleado)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(empleado);
                    transaction.Commit();
                    Console.WriteLine($"Empleado {empleado.Apellido} deleted");
                }
            }
        }

        public void Delete(List<Empleado> empleados)
        {
            foreach (var empleado in empleados)
            {
                Delete(empleado);
            }
        }

        public void Update(Empleado empleado)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(empleado);
                    transaction.Commit();
                    Console.WriteLine($"Empleado {empleado.Apellido} updated");
                }
            }
        }



    }
}
