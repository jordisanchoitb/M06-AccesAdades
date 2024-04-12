using System;
using NHibernate.Criterion;
using Npgsql;

namespace cat.itb.M6UF2Pr
{
    public class SupplierCRUD
    {
        public List<Supplier> SelectCreditHigherThanADO(double credit)
        {
            string sql = "SELECT * FROM SUPPLIER WHERE CREDIT > @CREDIT";
            List<Supplier> suppliers = new List<Supplier>();
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("CREDIT", credit);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Supplier supplier = new Supplier();
                            supplier.Id = reader.GetInt32(0);
                            supplier.Name = reader.GetString(1);
                            supplier.Address = reader.GetString(2);
                            supplier.City = reader.GetString(3);
                            supplier.StCode = reader.GetString(4);
                            supplier.ZipCode = reader.GetString(5);
                            supplier.Area = reader.GetDouble(6);
                            supplier.Phone = reader.GetString(7);
                            supplier.Amount = reader.GetDouble(9);
                            supplier.Credit = reader.GetDouble(10);
                            supplier.Remark = reader.GetString(11);
                            suppliers.Add(supplier);
                        }
                    }
                }
            }
            return suppliers;
        }

        public void Insert(Supplier supplier)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(supplier);
                    transaction.Commit();
                    Console.WriteLine($"Supplier {supplier.Name} inserted");
                }
            }
         }

        public List<Supplier> SelectByCity(string nomciutat)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                var query = session.CreateQuery("FROM Supplier WHERE City = :nomciutat");
                query.SetParameter("nomciutat", nomciutat);
                return query.List<Supplier>().ToList();
            }
        }

        public void Update(Supplier supplier)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(supplier);
                    transaction.Commit();
                    Console.WriteLine($"Supplier {supplier.Name} updated");
                }
            }
        }

        public void Update(List<Supplier> suppliers)
        {
            foreach (var supplier in suppliers)
            {
                Update(supplier);
            }
        }

        public Supplier SelectLowestAmount()
        {
            // utilitzan queryOver  y las subqueries del queryOver
            using var session = SessionFactoryCloud.Open();
            QueryOver<Supplier> minAmount = QueryOver.Of<Supplier>()
                .SelectList(p => p.SelectMin(s => s.Amount));
            Supplier supplier = session.QueryOver<Supplier>()
                .WithSubquery.WhereProperty(p => p.Amount).Eq(minAmount)
                .SingleOrDefault();
            return supplier;
        }
    }
}
