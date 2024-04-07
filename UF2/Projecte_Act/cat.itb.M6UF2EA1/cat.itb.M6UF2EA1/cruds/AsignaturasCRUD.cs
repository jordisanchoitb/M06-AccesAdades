using System;
using Npgsql;

namespace cat.itb.M6UF2EA1
{
    public class AsignaturasCRUD
    {
        public void ClearDb()
        {
            string path = @"..\..\..\school.sql";

            using (StreamReader sr = File.OpenText(path))
            {
                string sql = sr.ReadToEnd();
                using (NpgsqlConnection conn = new SchoolConnection().GetConnection())
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

        public void Act1()
        {
            string sql = "SELECT * FROM alumnos";

            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new SchoolConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    // Executo la consulta i recullo el resultat
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Faig un bucle per recorrer totes les files de la consulta
                        while (reader.Read())
                        {
                            // mostra la informacio de la consulta
                            Console.WriteLine($"Dni: {reader[0]}, Nom Complet: {reader[1]}, Direccio: {reader[2]}, Poblacio: {reader[3]}, Telefon: {reader[4]}");
                        }
                    }
                }
            }

        }

        public void Act2()
        {
            string sql = "SELECT * FROM notas";

            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new SchoolConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    // Executo la consulta i recullo el resultat
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Faig un bucle per recorrer totes les files de la consulta
                        while (reader.Read())
                        {
                            // mostra la informacio de la consulta
                            Console.WriteLine($"Dni: {reader[0]}, Cod: {reader[1]}, Nota: {reader[2]}");
                        }
                    }
                }
            }

        }
        
        public void Act3()
        {
            string sql = "SELECT * FROM notas WHERE dni = @dni";

            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new SchoolConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    // Li paso el parametre del dni
                    cmd.Parameters.AddWithValue("dni", "4448242");

                    // Executo la consulta i recullo el resultat
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Faig un bucle per recorrer totes les files de la consulta
                        while (reader.Read())
                        {
                            // mostra la informacio de la consulta
                            Console.WriteLine($"Dni: {reader[0]}, Cod: {reader[1]}, Nota: {reader[2]}");
                        }
                    }
                }
            }

        }

        public void Act4()
        {
            string sql = "INSERT INTO alumnos (DNI,APENOM,DIREC,POBLA,TELEF) VALUES (@dni,@apenom,@direc,@pobla,@telef)";

            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new SchoolConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    // Li paso el parametre del dni
                    cmd.Parameters.AddWithValue("dni", "4428242");
                    cmd.Parameters.AddWithValue("apenom", "Pepe Garcia");
                    cmd.Parameters.AddWithValue("direc", "Calle Principal 123");
                    cmd.Parameters.AddWithValue("pobla", "Sevilla");
                    cmd.Parameters.AddWithValue("telef", "789987456");
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine("El insert s'ha fet correctement");
                    }
                    else
                    {
                        Console.WriteLine("El insert a fallat");
                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("dni", "4428243");
                    cmd.Parameters.AddWithValue("apenom", "Juan Lopez");
                    cmd.Parameters.AddWithValue("direc", "Calle Secundaria 456");
                    cmd.Parameters.AddWithValue("pobla", "Madrid");
                    cmd.Parameters.AddWithValue("telef", "789987457");
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine("El insert s'ha fet correctement");
                    }
                    else
                    {
                        Console.WriteLine("El insert a fallat");
                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("dni", "4428244");
                    cmd.Parameters.AddWithValue("apenom", "Maria Perez");
                    cmd.Parameters.AddWithValue("direc", "Calle Terciaria 789");
                    cmd.Parameters.AddWithValue("pobla", "Barcelona");
                    cmd.Parameters.AddWithValue("telef", "789987458");
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine("El insert s'ha fet correctement");
                    }
                    else
                    {
                        Console.WriteLine("El insert a fallat");
                    }
                }
            }
        }

        public void Act5()
        {
            string sql = "INSERT INTO notas (DNI,COD,NOTA) VALUES (@dni,@cod,@nota)";

            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new SchoolConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    // Primer alumne
                    cmd.Parameters.AddWithValue("dni", "4428242");
                    cmd.Parameters.AddWithValue("cod", 4);
                    cmd.Parameters.AddWithValue("nota", 8);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine("El insert s'ha fet correctement");
                    }
                    else
                    {
                        Console.WriteLine("El insert a fallat");
                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("dni", "4428242");
                    cmd.Parameters.AddWithValue("cod", 5);
                    cmd.Parameters.AddWithValue("nota", 8);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine("El insert s'ha fet correctement");
                    }
                    else
                    {
                        Console.WriteLine("El insert a fallat");
                    }
                    cmd.Parameters.Clear();

                    // Segon alumne
                    cmd.Parameters.AddWithValue("dni", "4428243");
                    cmd.Parameters.AddWithValue("cod", 4);
                    cmd.Parameters.AddWithValue("nota", 8);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine("El insert s'ha fet correctement");
                    }
                    else
                    {
                        Console.WriteLine("El insert a fallat");
                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("dni", "4428243");
                    cmd.Parameters.AddWithValue("cod", 5);
                    cmd.Parameters.AddWithValue("nota", 8);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine("El insert s'ha fet correctement");
                    }
                    else
                    {
                        Console.WriteLine("El insert a fallat");
                    }
                    cmd.Parameters.Clear();

                    // Tercer alumne
                    cmd.Parameters.AddWithValue("dni", "4428244");
                    cmd.Parameters.AddWithValue("cod", 4);
                    cmd.Parameters.AddWithValue("nota", 8);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine("El insert s'ha fet correctement");
                    }
                    else
                    {
                        Console.WriteLine("El insert a fallat");
                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("dni", "4428244");
                    cmd.Parameters.AddWithValue("cod", 5);
                    cmd.Parameters.AddWithValue("nota", 8);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine("El insert s'ha fet correctement");
                    }
                    else
                    {
                        Console.WriteLine("El insert a fallat");
                    }
                }
            }
        }

        public void Act6()
        {
            string sql = "UPDATE notas SET NOTA = @nota WHERE DNI = @dni AND COD = @cod";

            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new SchoolConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    // Li paso el parametre del dni
                    cmd.Parameters.AddWithValue("dni", "4448242");
                    cmd.Parameters.AddWithValue("cod", 4);
                    cmd.Parameters.AddWithValue("nota", 9);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine("El update s'ha fet correctement");
                    }
                    else
                    {
                        Console.WriteLine("El update a fallat");
                    }
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("dni", "4448242");
                    cmd.Parameters.AddWithValue("cod", 5);
                    cmd.Parameters.AddWithValue("nota", 9);
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine("El update s'ha fet correctement");
                    }
                    else
                    {
                        Console.WriteLine("El update a fallat");
                    }
                }
            }
        }

        public void Act7()
        {
            string sql = "UPDATE alumnos SET TELEF = @telef WHERE DNI = @dni";

            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new SchoolConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    // Li paso el parametre del dni
                    cmd.Parameters.AddWithValue("dni", "12344345");
                    cmd.Parameters.AddWithValue("telef", "934885237");
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine("El update s'ha fet correctement");
                    }
                    else
                    {
                        Console.WriteLine("El update a fallat");
                    }
                }
            }
        }

        public void Act8()
        {
            string sql = "DELETE FROM alumnos WHERE POBLA = @pobla";

            //Preparo la connexió al cloud ElephantSQL
            using (NpgsqlConnection conn = new SchoolConnection().GetConnection())
            {
                // Defineixo el sql a executar i paso la connexió on s'executarà
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    // Li paso el parametre del dni
                    cmd.Parameters.AddWithValue("pobla", "Mostoles");
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine("El delete s'ha fet correctement");
                    }
                    else
                    {
                        Console.WriteLine("El delete a fallat");
                    }
                }
            }
        }
    }
}
