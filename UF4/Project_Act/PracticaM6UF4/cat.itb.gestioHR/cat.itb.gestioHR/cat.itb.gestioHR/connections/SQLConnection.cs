using System;
using Npgsql;

namespace cat.itb.gestioHR.connections
{
    public class SQLConnection
    {
        private String HOST = "fanny.db.elephantsql.com:5432"; // Ubicació de la BD.
        private String DB = "pykpkbbo"; // Nom de la BD.
        private String USER = "pykpkbbo";
        private String PASSWORD = "FFIgGZmlJVzaG8kRGtZHs4i3wisuwJ6O";

        public NpgsqlConnection GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(
                "Host=" + HOST + ";" + "Username=" + USER + ";" +
                "Password=" + PASSWORD + ";" + "Database=" + DB + ";"
            );
            conn.Open();
            return conn;
        }
    }
}