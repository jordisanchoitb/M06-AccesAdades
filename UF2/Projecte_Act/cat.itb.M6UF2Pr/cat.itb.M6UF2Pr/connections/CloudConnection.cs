using System;
using Npgsql;

namespace cat.itb.M6UF2Pr
{
    public class CloudConnection
    {
        public string host = "salt.db.elephantsql.com:5432";
        public string user = "ckxphvzj";
        public string database = "ckxphvzj";
        public string password = "JU8zz0bCN-dkuBPEATZTTTp9vy3RI-gY";

        public NpgsqlConnection conn = null;

        public NpgsqlConnection GetConnection()
        {
            NpgsqlConnection connection = new NpgsqlConnection(
                $"Host={host};Username={user};" +
                $"Password={password};Database={database};"
            );

            connection.Open();
            return connection;
        }
    }
}
