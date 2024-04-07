using System;
using Npgsql;

namespace cat.itb.M6UF2EA2
{
    public class EmpleatCRUD
    {
        public List<Empleat> SelectAll()
        {
            List<Empleat> empleats = new List<Empleat>();
            string sql = "SELECT * FROM EMP";
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
                            int cap = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                            int comissio = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                            Empleat empleat = new Empleat(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), cap, reader.GetDateTime(4), reader.GetInt32(5), comissio, reader.GetInt32(7));
                            empleats.Add(empleat);
                        }
                    }
                }
            }
            return empleats;
        }
        public Empleat SelectOneId(int emp_no)
        {
            string sql = "SELECT * FROM EMP WHERE EMP_NO = @empno";
            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("empno", emp_no);
                    // Executo la consulta i guardo el resultat a un reader
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Mentre hi hagi registres els llegeixo i els mostro
                        while (reader.Read())
                        {
                            int cap = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                            int comissio = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                            return new Empleat(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), cap, reader.GetDateTime(4), reader.GetInt32(5), comissio, reader.GetInt32(7));
                        }
                    }
                }
            }
            return null;
        }
        public void Insert(Empleat empleat)
        {
            string sql = "INSERT INTO EMP (EMP_NO, COGNOM, OFICI, CAP, DATA_ALTA, SALARI, COMISSIO, DEPT_NO) VALUES (@empno, @cognom, @ofici, @cap, @dataalta, @salari, @comissio, @deptno);";
            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("empno", empleat.Emp_no);
                    cmd.Parameters.AddWithValue("cognom", empleat.Cognom);
                    cmd.Parameters.AddWithValue("ofici", empleat.Ofici);
                    cmd.Parameters.AddWithValue("cap", empleat.Cap);
                    cmd.Parameters.AddWithValue("dataalta", empleat.Data_Alt);
                    cmd.Parameters.AddWithValue("salari", empleat.Salari);
                    cmd.Parameters.AddWithValue("comissio", empleat.Comissio);
                    cmd.Parameters.AddWithValue("deptno", empleat.Dept_no);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine($"L'empleat amb el codi {empleat.Emp_no} s'ha insertat correctament");
                    }
                    else
                    {
                        Console.WriteLine($"L'empleat amb el codi {empleat.Emp_no} no s'ha insertat");
                    }
                    cmd.Parameters.Clear();
                }
            }
        }
        public void Insert(List<Empleat> empleats)
        {
            foreach (Empleat empleat in empleats)
            {
                Insert(empleat);
            }
        }
        public void Delete(Empleat empleat)
        {
            string sql = "DELETE FROM EMP WHERE EMP_NO = @empno";

            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("empno", empleat.Emp_no);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine($"L'empleat amb el codi {empleat.Emp_no} s'ha eliminat correctament");
                    }
                    else
                    {
                        Console.WriteLine($"L'empleat amb el codi {empleat.Emp_no} no s'ha eliminat");
                    }
                    cmd.Parameters.Clear();
                }
            }
        }
        public void Delete(List<Empleat> empleats)
        {
            foreach (Empleat empleat in empleats)
            {
                Delete(empleat);
            }
        }
        public void Delete(int empno)
        {
            string sql = "DELETE FROM EMP WHERE EMP_NO = @empno";

            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new CloudConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("empno", empno);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine($"L'empleat amb el codi {empno} s'ha eliminat correctament");
                    }
                    else
                    {
                        Console.WriteLine($"L'empleat amb el codi {empno} no s'ha eliminat");
                    }
                    cmd.Parameters.Clear();
                }
            }
        }
        public void Delete(List<int> empnos)
        {
            foreach (int empno in empnos)
            {
                Delete(empno);
            }
        }
    }
}
