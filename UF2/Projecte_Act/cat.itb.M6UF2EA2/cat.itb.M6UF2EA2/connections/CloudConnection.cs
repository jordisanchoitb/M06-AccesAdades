using System;
using Npgsql;

namespace cat.itb.M6UF2EA2
{
    public class CloudConnection
    {
        public string host = "raja.db.elephantsql.com:5432";
        public string user = "sfvhtwkr";
        public string database = "sfvhtwkr";
        public string password = "DQKMNS2liKgAelG3XyArtNoDKSVPxOjl";

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
