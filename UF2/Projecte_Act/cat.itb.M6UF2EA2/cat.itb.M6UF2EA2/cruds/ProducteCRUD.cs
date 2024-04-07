using Npgsql;
using System;

namespace cat.itb.M6UF2EA2
{
    public class ProducteCRUD
    {
        public List<Producte> SelectAll()
        {
            List<Producte> productes = new List<Producte>();
            string sql = "SELECT * FROM producte";
            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    // Executo la consulta i guardo el resultat a un reader
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Mentre hi hagi registres els llegeixo i els mostro
                        while (reader.Read())
                        {
                            Producte producte = new Producte(reader.GetInt32(0), reader.GetString(1));
                            productes.Add(producte);
                        }
                    }
                }
            }
            return productes;
        }
        public Producte SelectOneId(int prod_num)
        {
            string sql = "SELECT * FROM producte WHERE prod_num = @prodnum";
            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("prodnum", prod_num);
                    // Executo la consulta i guardo el resultat a un reader
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Mentre hi hagi registres els llegeixo i els mostro
                        while (reader.Read())
                        {
                            return new Producte(reader.GetInt32(0), reader.GetString(1));
                        }
                    }
                }
            }
            return null;
        }
        public void Insert(Producte producte)
        {
            string sql = "INSERT INTO producte (prod_num, descripcio) VALUES (@prodnum, @description)";
            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("prodnum", producte.Prod_num);
                    cmd.Parameters.AddWithValue("description", producte.Descripcio);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine($"El producte amb el codi {producte.Prod_num} s'ha insertat correctament");
                    }
                    else
                    {
                        Console.WriteLine($"El producte amb el codi {producte.Prod_num} no s'ha insertat");
                    }
                    cmd.Parameters.Clear();
                }
            }
        }
        public void Insert(List<Producte> productes)
        {
            foreach (Producte producte in productes)
            {
                Insert(producte);
            }
        }
        public void Delete(Producte producte) 
        { 
            string sql = "DELETE FROM producte WHERE prod_num = @prodnum";
            
            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("prodnum", producte.Prod_num);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine($"El producte amb el codi {producte.Prod_num} s'ha eliminat correctament");
                    }
                    else
                    {
                        Console.WriteLine($"El producte amb el codi {producte.Prod_num} no s'ha eliminat");
                    }
                    cmd.Parameters.Clear();
                }
            }
        }
        public void Delete(List<Producte> productes)
        {
            foreach (Producte producte in productes)
            {
                Delete(producte);
            }
        }
        public void Delete(int prod_num)
        {
            string sql = "DELETE FROM producte WHERE prod_num = @prodnum";
            
            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("prodnum", prod_num);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine($"El producte amb el codi {prod_num} s'ha eliminat correctament");
                    }
                    else
                    {
                        Console.WriteLine($"El producte amb el codi {prod_num} no s'ha eliminat");
                    }
                    cmd.Parameters.Clear();
                }
            }
        }
        public void Delete(List<int> prod_nums)
        {
            foreach (int prod_num in prod_nums)
            {
                Delete(prod_num);
            }
        }
    }
}
