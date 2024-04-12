using System;
using Npgsql;

namespace cat.itb.M6UF2Pr
{
    public class EmployeeCRUD
    {
        public void InsertADO(List<Employee> employees)
        {
            string sql = "INSERT INTO EMPLOYEE (SURNAME, JOB, MANAGERNO, STARTDATE, SALARY, COMMISSION, DEPTNO) VALUES (@SURNAME, @JOB, @MANAGERNO, @STARTDATE, @SALARY, @COMMISSION, @DEPTNO)";
            using (NpgsqlConnection connection = new CloudConnection().GetConnection())
            {
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    foreach (Employee employee in employees)
                    {
                        command.Parameters.AddWithValue("SURNAME", employee.Surname);
                        command.Parameters.AddWithValue("JOB", employee.Job);
                        command.Parameters.AddWithValue("MANAGERNO", employee.ManagerNo);
                        command.Parameters.AddWithValue("STARTDATE", employee.StartDate);
                        command.Parameters.AddWithValue("SALARY", employee.Salary);
                        command.Parameters.AddWithValue("COMMISSION", employee.Commission == null ? 0 : employee.Commission);
                        command.Parameters.AddWithValue("DEPTNO", employee.DeptNo);
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }
                    Console.WriteLine("Empleats inserits correctament.");
                }
            }
        }

        public Employee SelectByNameADO(string name)
        {
            Employee employee = new Employee();
            string sql = "SELECT * FROM EMPLOYEE WHERE SURNAME = @SURNAME";
            using (NpgsqlConnection connection = new CloudConnection().GetConnection())
            {
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("SURNAME", name.ToUpper());
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employee.Id = reader.GetInt32(0);
                            employee.Surname = reader.GetString(1);
                            employee.Job = reader.GetString(2);
                            employee.ManagerNo = reader.GetInt32(3);
                            employee.StartDate = reader.GetDateTime(4);
                            employee.Salary = reader.GetDouble(5);
                            try
                            {
                                employee.Commission = reader.GetDouble(6);
                            }
                            catch (InvalidCastException)
                            {
                                employee.Commission = null;
                            }
                            employee.DeptNo = reader.GetInt32(7);
                        }
                    }
                }
            }
            return employee;
        }

        public void DeleteADO(Employee employee)
        {
            string sql = "DELETE FROM EMPLOYEE WHERE ID = @ID";
            using (NpgsqlConnection connection = new CloudConnection().GetConnection())
            {
                using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("ID", employee.Id);
                    if(command.ExecuteNonQuery() != 0)
                    {
                        Console.WriteLine($"Empleat {employee.Surname} eliminat correctament.");
                    } else
                    {
                        Console.WriteLine($"No s'ha pogut eliminar l'empleat {employee.Surname}.");
                    }
                }
            }
        }

        public Employee SelectBySurname(string surname)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                var query = session.CreateQuery("FROM Employee WHERE Surname = :surname");
                query.SetParameter("surname", surname);
                return query.List<Employee>().ToList().FirstOrDefault();
            }
        }

    }
}
