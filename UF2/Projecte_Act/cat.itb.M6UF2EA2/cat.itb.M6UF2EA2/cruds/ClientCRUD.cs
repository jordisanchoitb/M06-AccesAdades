using System;
using Npgsql;

namespace cat.itb.M6UF2EA2
{
    public class ClientCRUD
    {
        public List<Client> SelectAll()
        {
            List<Client> clients = new List<Client>();
            string sql = "SELECT * FROM client";
            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    // Executo la consulta i guardo el resultat en un reader
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Mentre hi hagi registres els llegeixo i els mostro
                        while (reader.Read())
                        {
                            int repr_cod = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                            clients.Add(new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetString(7), repr_cod, reader.GetDouble(9), reader.GetString(10)));
                        }
                    }
                }
            }
            return clients;
        }
        public Client SelectOneId(int Client_Cod)
        {
            string sql = "SELECT * FROM client WHERE client_cod = @clientcod";
            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("clientcod", Client_Cod);
                    // Executo la consulta i guardo el resultat en un reader
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Mentre hi hagi registres els llegeixo i els mostro
                        while (reader.Read())
                        {
                            int repr_cod = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                            return new Client(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetString(7), repr_cod, reader.GetDouble(9), reader.GetString(10));
                        }
                    }
                }
            }
            return null;
        }
        public void Insert(Client client)
        {
            string sql = "INSERT INTO client (client_cod, nom, adreca, ciutat, estat, codi_postal, area, telefon, repr_cod, limit_credit, observacions) VALUES (@clientcod, @nom, @adreca, @ciutat, @estat, @codipostal, @area, @telefon, @reprcod, @limitcredit, @observacions)";
            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("clientcod", client.Client_Cod);
                    cmd.Parameters.AddWithValue("nom", client.Nom);
                    cmd.Parameters.AddWithValue("adreca", client.Adreca);
                    cmd.Parameters.AddWithValue("ciutat", client.Ciutat);
                    cmd.Parameters.AddWithValue("estat", client.Estat);
                    cmd.Parameters.AddWithValue("codipostal", client.Codi_Postal);
                    cmd.Parameters.AddWithValue("area", client.Area);
                    cmd.Parameters.AddWithValue("telefon", client.Telefon);
                    cmd.Parameters.AddWithValue("reprcod", client.Repr_Cod);
                    cmd.Parameters.AddWithValue("limitcredit", client.Limit_Credit);
                    cmd.Parameters.AddWithValue("observacions", client.Observacions);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine($"El client amb el codi {client.Client_Cod} s'ha insertat correctament");
                    }
                    else
                    {
                        Console.WriteLine($"El client amb el codi {client.Client_Cod} no s'ha insertat");
                    }
                    cmd.Parameters.Clear();
                }
            }
        }
        public void Insert(List<Client> clients)
        {
            foreach (Client client in clients)
            {
                Insert(client);
            }
        }
        public void Delete(Client client)
        {
            string sql = "DELETE FROM client WHERE client_cod = @clientcod";

            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("clientcod", client.Client_Cod);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine($"El client amb el codi {client.Client_Cod} s'ha eliminat correctament");
                    }
                    else
                    {
                        Console.WriteLine($"El client amb el codi {client.Client_Cod} no s'ha eliminat");
                    }
                    cmd.Parameters.Clear();
                }
            }
        }
        public void Delete(List<Client> clients)
        {
            foreach (Client client in clients)
            {
                Delete(client);
            }
        }
        public void Delete(int clientcod)
        {
            string sql = "DELETE FROM client WHERE client_cod = @clientcod";

            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("clientcod", clientcod);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine($"El client amb el codi {clientcod} s'ha eliminat correctament");
                    }
                    else
                    {
                        Console.WriteLine($"El client amb el codi {clientcod} no s'ha eliminat");
                    }
                    cmd.Parameters.Clear();
                }
            }
        }
        public void Delete(List<int> clientcods)
        {
            foreach (int clientcod in clientcods)
            {
                Delete(clientcod);
            }
        }
        public void UpdateLimitCredit(int clientcod, int nuevovalor)
        {
            string sql = "UPDATE client SET limit_credit = @nuevovalor WHERE client_cod = @clientcod";
            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("clientcod", clientcod);
                    cmd.Parameters.AddWithValue("nuevovalor", nuevovalor);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine($"El limit_credit del client amb el codi {clientcod} s'ha actualitzat correctament");
                    }
                    else
                    {
                        Console.WriteLine($"El limit_credit del client amb el codi {clientcod} no s'ha actualitzat");
                    }
                    cmd.Parameters.Clear();
                }
            }
        }

    }
}
