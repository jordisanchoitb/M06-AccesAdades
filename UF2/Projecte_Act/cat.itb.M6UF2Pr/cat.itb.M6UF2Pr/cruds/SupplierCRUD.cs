using System;
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
    }
}
