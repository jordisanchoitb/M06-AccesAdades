using NHibernate;
using NHibernate.Linq;
using Npgsql;
using System;

namespace cat.itb.M6UF2Pr
{
    public class ProductCRUD
    {
        public Product SelectByCodeADO(int code)
        {
            string sql = $"SELECT * FROM Product WHERE Code = @code";
            Product product = null;
            using (NpgsqlConnection connection = new CloudConnection().GetConnection())
            {
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("code", code);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        product = new Product
                        {
                            Id = reader.GetInt32(0),
                            Code = reader.GetInt32(1),
                            Description = reader.GetString(2),
                            CurrentStock = reader.GetInt32(3),
                            MinStock = reader.GetInt32(4),
                            Price = reader.GetDouble(5),
                        };
                    }
                }
            }
            return product;
        }

        public void UpdateADO(Product product)
        {
            string sql = "UPDATE Product SET Description = @description, CurrentStock = @currentstock, MinStock = @minstock, Price = @price, EmpNo = @empno WHERE Code = @code";
            using (NpgsqlConnection connection = new CloudConnection().GetConnection())
            {
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("description", product.Description);
                    command.Parameters.AddWithValue("currentstock", product.CurrentStock);
                    command.Parameters.AddWithValue("minstock", product.MinStock);
                    command.Parameters.AddWithValue("price", product.Price);
                    command.Parameters.AddWithValue("code", product.Code);
                    if (command.ExecuteNonQuery() != 0) 
                    {
                        Console.WriteLine($"Product {product.Code} updated");
                    } else
                    {
                        Console.WriteLine($"Product {product.Code} no updated");
                    }
                    command.Parameters.Clear();
                }
            }
        }

        public void UpdateADO(List<Product> products)
        {
            foreach (var product in products)
            {
                UpdateADO(product);
            }
        }

        public void DeleteADO(Product product)
        {
            string sql = "DELETE FROM Product WHERE Code = @code";
            using (NpgsqlConnection connection = new CloudConnection().GetConnection())
            {
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("code", product.Code);
                    if (command.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine($"Product {product.Code} deleted");
                    }
                    else
                    {
                        Console.WriteLine($"Product {product.Code} no deleted");
                    }
                    command.Parameters.Clear();
                }
            }
        }

        public void InsertADO(Product product)
        {
            string sql = "INSERT INTO Product (Code, Description, CurrentStock, MinStock, Price, EmpNo) VALUES (@code, @description, @currentstock, @minstock, @price, @empno)";
            using (NpgsqlConnection connection = new CloudConnection().GetConnection())
            {
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("code", product.Code);
                    command.Parameters.AddWithValue("description", product.Description);
                    command.Parameters.AddWithValue("currentstock", product.CurrentStock);
                    command.Parameters.AddWithValue("minstock", product.MinStock);
                    command.Parameters.AddWithValue("price", product.Price);
                    if (command.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine($"Product {product.Code} inserted");
                    }
                    else
                    {
                        Console.WriteLine($"Product {product.Code} no inserted");
                    }
                    command.Parameters.Clear();
                }
            }
        }
        public Product SelectById(int id)
        {
            Product product;
            using (var session = SessionFactoryCloud.Open())
            {
                product = session.Get<Product>(id);
            }
            return product;
        }

        public List<Product> SelectAll()
        {
            using (var session = SessionFactoryCloud.Open())
            {
                return session.Query<Product>().ToList();
            }
        }

        public void Insert(Product product)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(product);
                    transaction.Commit();
                    Console.WriteLine($"Product {product.Code} inserted");
                }
            }
        }

        public void Insert(List<Product> products)
        {
            foreach (var product in products)
            {
                Insert(product);
            }
        }

        public void Delete(Product product)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(product);
                    transaction.Commit();
                    Console.WriteLine($"Product {product.Code} deleted");
                }
            }
        }

        public void Delete(List<Product> products)
        {
            foreach (var product in products)
            {
                Delete(product);
            }
        }

        public void Update(Product product)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(product);
                    transaction.Commit();
                    Console.WriteLine($"Product {product.Code} updated");
                }
            }
        }
    }
}
