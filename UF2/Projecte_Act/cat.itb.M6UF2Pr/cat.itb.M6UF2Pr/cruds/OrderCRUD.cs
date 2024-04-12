using System;
using Npgsql;


namespace cat.itb.M6UF2Pr
{
    public class OrderCRUD
    {
        public List<Order> SelectOrdersSupplierADO(int supplierno)
        {
            List<Order> orders = new List<Order>();
            string sql = "SELECT * FROM ORDERP WHERE supplierno = @supplierno";
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("supplierno", supplierno);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order();
                            order.Id = reader.GetInt32(0);
                            order.OrderDate = reader.GetDateTime(2);
                            order.Amount = reader.GetDouble(3);
                            order.DeliveryDate = reader.GetDateTime(4);
                            order.Cost = reader.GetDouble(5);
                            orders.Add(order);
                        }
                    }
                }
            }
            return orders;
        }

        public List<Order> SelectByCostHigherThan(double cost, double amount)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                var query = session.CreateQuery("FROM Order WHERE Cost > :cost AND Amount = :amount");
                query.SetParameter("cost", cost);
                query.SetParameter("amount", amount);
                return query.List<Order>().ToList();
            }
        }
    }
}
