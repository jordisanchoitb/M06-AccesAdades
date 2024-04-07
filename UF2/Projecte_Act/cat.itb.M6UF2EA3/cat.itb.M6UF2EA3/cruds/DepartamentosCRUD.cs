using System;
using NHibernate;
namespace cat.itb.M6UF2EA3
{
    public class DepartamentosCRUD
    {
        public Departamento SelectById(int id)
        {
            Departamento departamento;
            using (var session = SessionFactoryCloud.Open())
            {
                departamento = session.Get<Departamento>(id);
                NHibernateUtil.Initialize(departamento.Empleados);
            }
            return departamento;
        }

        public List<Departamento> SelectAll()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                return session.Query<Departamento>().ToList();
            }
        }

        public void Insert(Departamento departamento)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(departamento);
                    transaction.Commit();
                    Console.WriteLine($"Departamento {departamento.Dnombre} inserted");
                }
            }
        }

        public void Insert(List<Departamento> departamentos)
        {
            foreach (var departamento in departamentos)
            {
                Insert(departamento);
            }
        }

        public void Delete(Departamento departamento)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(departamento);
                    transaction.Commit();
                    Console.WriteLine($"Departamento {departamento.Dnombre} deleted");
                }
            }
        }

        public void Delete(List<Departamento> departamentos)
        {
            foreach (var departamento in departamentos)
            {
                Delete(departamento);
            }
        }

        public void Update(Departamento departamento)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(departamento);
                    transaction.Commit();
                    Console.WriteLine($"Departamento {departamento.Dnombre} updated");
                }
            }
        }

    }
}
