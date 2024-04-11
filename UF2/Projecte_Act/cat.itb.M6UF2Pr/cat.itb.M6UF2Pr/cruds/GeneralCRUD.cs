using System;
using Npgsql;

namespace cat.itb.M6UF2Pr
{
    public class GeneralCRUD
    {
        public void RunScriptShop()
        {
            List<string> tables = ["ORDERP", "SUPPLIER", "PRODUCT", "EMPLOYEE"];
            DropTables(tables);
            string path = @"..\..\..\files\shop.sql";

            using (StreamReader sr = File.OpenText(path))
            {
                string sql = sr.ReadToEnd();
                using (NpgsqlConnection conn = new CloudConnection().GetConnection())
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        if (cmd.ExecuteNonQuery() != 0)
                        {
                            Console.WriteLine("Base de dades netejada");
                        }
                        else
                        {
                            Console.WriteLine("Error netejan base de dades");
                        }
                    }
                }
            }
        }

        public void DropTables(List<string> tables)
        {
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                foreach (string table in tables)
                {
                    using (NpgsqlCommand cmd = new NpgsqlCommand($"DROP TABLE IF EXISTS {table}", conn))
                    {
                        if (cmd.ExecuteNonQuery() != 0)
                        {
                            Console.WriteLine($"Taula {table} eliminada");
                        }
                        else
                        {
                            Console.WriteLine($"Error eliminant taula {table}");
                        }
                    }
                }
            }
        }
    }
}
