using System;
using Npgsql;

namespace cat.itb.M6UF2EA1
{
    public class SchoolConnection
    {
        public string host = "castor.db.elephantsql.com:5432";
        public string user = "zohrkiyv";
        public string database = "zohrkiyv";
        public string password = "ZcLbV05u5WwrarOiyXC3gj59nDoKQMFc";

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
