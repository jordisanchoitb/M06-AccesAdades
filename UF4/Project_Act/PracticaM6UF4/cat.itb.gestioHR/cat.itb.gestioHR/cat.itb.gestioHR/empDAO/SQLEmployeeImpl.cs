using System;
using System.Collections.Generic;
using cat.itb.gestioHR.connections;
using cat.itb.gestioHR.depDAO;
using Npgsql;

namespace cat.itb.gestioHR.empDAO
{
    public class SQLEmployeeImpl : EmployeeDAO
    {
        
        private NpgsqlConnection conn;

        public void DeleteAll()
        {
            SQLConnection db = new SQLConnection();
            conn = db.GetConnection();
            
            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM employee", conn);

            try
            {
                cmd.ExecuteNonQuery();
              
                Console.WriteLine("Employees deleted");
            }
            catch
            {
                Console.WriteLine("Couldn't delete Employees");
                
            }

            conn.Close();
         
        }
        
        public void InsertAll(List<Employee> emps)
        {
            DeleteAll();
            SQLConnection db = new SQLConnection();
            conn = db.GetConnection();
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO employee VALUES (@empid, @surname, @job, @mgrid, @startdate, @salari, @comissio, @depid)", conn);
            
            foreach (var emp in emps)
            {
                cmd.Parameters.AddWithValue("empid", emp._id);
                cmd.Parameters.AddWithValue("surname", emp.Surname);
                cmd.Parameters.AddWithValue("job", emp.Job);
                cmd.Parameters.AddWithValue("mgrid", emp.Managerid);
                cmd.Parameters.AddWithValue("startdate", emp.StartDate);
                cmd.Parameters.AddWithValue("salari", emp.Salary);
                cmd.Parameters.AddWithValue("comissio", emp.Commission);
                cmd.Parameters.AddWithValue("depid", emp.DepId._id);
                cmd.Prepare();
                try
                {
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Employee with Id {0} and Name {1} added",
                        emp._id, emp.Surname);
                }
                catch
                {
                    Console.WriteLine("Couldn't add Employee with Id {0}", emp._id);
                }
                
                cmd.Parameters.Clear();
            }
            
            conn.Close();
        }
        
        public List<Employee> SelectAll()
        {
            SQLConnection db = new SQLConnection();
            conn = db.GetConnection();
            DepartmentDAO departmentDAO = new SQLDepartmentImpl();

            var cmd = new NpgsqlCommand("SELECT * FROM employee", conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            List<Employee> emps = new List<Employee>(); 
            
            while (dr.Read())
            {
                Employee dep = new Employee();
                dep._id = dr.GetInt32(0);
                dep.Surname = dr.GetString(1);
                dep.Job = dr.GetString(2);
                try
                {
                    dep.Managerid = dr.GetInt32(3);
                }
                catch (Exception e)
                {
                    dep.Managerid = 0;
                }
                dep.StartDate = dr.GetDateTime(4);
                dep.Salary = dr.GetDouble(5);
                try
                {
                    dep.Commission = dr.GetDouble(6);
                } catch (Exception e)
                {
                    dep.Commission = 0;
                }
                dep.DepId = departmentDAO.Select(dr.GetInt32(7));
                emps.Add(dep);
            }

            conn.Close();
            return emps;
        }
        
        public Employee Select(int empId)
        {
       
           SQLConnection db = new SQLConnection();
           conn = db.GetConnection();
           DepartmentDAO departmentDAO = new SQLDepartmentImpl();
           
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM employee WHERE _id =" + empId, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            Employee dep = new Employee();
            
            if (dr.Read())
            {
                dep._id = dr.GetInt32(0);
                dep.Surname = dr.GetString(1);
                dep.Job = dr.GetString(2);
                dep.Managerid = dr.GetInt32(3);
                dep.StartDate = dr.GetDateTime(4);
                dep.Salary = dr.GetDouble(5);
                try
                {
                    dep.Commission = dr.GetDouble(6);
                }
                catch (Exception e)
                {
                    dep.Commission = 0;
                }
                dep.DepId = departmentDAO.Select(dr.GetInt32(7));
            }
            else
            {
                dep = null;
            }
            conn.Close();
            return dep;
            
        }

        public Boolean Insert(Employee emp)
        {
   
           SQLConnection db = new SQLConnection();
           conn = db.GetConnection();
           
           NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO employee VALUES (@empid, @surname, @job, @mgrid, @startdate, @salari, @comissio, @depid)", conn);

            Boolean bol; 
            cmd.Parameters.AddWithValue("empid", emp._id);
            cmd.Parameters.AddWithValue("surname", emp.Surname);
            cmd.Parameters.AddWithValue("job", emp.Job);
            cmd.Parameters.AddWithValue("mgrid", emp.Managerid);
            cmd.Parameters.AddWithValue("startdate", emp.StartDate);
            cmd.Parameters.AddWithValue("salari", emp.Salary);
            cmd.Parameters.AddWithValue("comissio", emp.Commission);
            cmd.Parameters.AddWithValue("depid", emp.DepId._id);
            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
                bol = true;
                Console.WriteLine("Employee with Id {0} and Name {1} added",
                    emp._id, emp.Surname);
            }
            catch
            {
                bol = false;
                Console.WriteLine("Couldn't add Employee with Id {0}", emp._id);
            }
           
            conn.Close();
            return bol;

        }

        public Boolean Delete(int empId)
        {
          
           SQLConnection db = new SQLConnection();
           conn = db.GetConnection();
            Boolean bol; 
            
            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM employee WHERE _id =" + empId, conn);

            try
            {
                 cmd.ExecuteNonQuery();
                 bol = true;
                 Console.WriteLine("Employee with Id {0} deleted",
                    empId);
            }
            catch
            {
                Console.WriteLine("Couldn't delete Employee with Id {0}", empId);
                bol = false;
            }

            conn.Close();
            return bol;
        }

        public Boolean Update(Employee emp)
        {
            SQLConnection db = new SQLConnection();
            conn = db.GetConnection();
            NpgsqlCommand cmd = new NpgsqlCommand("UPDATE employee SET surname = @surname, job = @job, managerid = @mgrid, startdate = @startdate, salary = @salari, commission = @comissio, depid = @depid WHERE _id = @empId", conn);
            
            Boolean bol; 
            cmd.Parameters.AddWithValue("empId", emp._id);
            cmd.Parameters.AddWithValue("surname", emp.Surname);
            cmd.Parameters.AddWithValue("job", emp.Job);
            cmd.Parameters.AddWithValue("mgrid", emp.Managerid);
            cmd.Parameters.AddWithValue("startdate", emp.StartDate);
            cmd.Parameters.AddWithValue("salari", emp.Salary);
            cmd.Parameters.AddWithValue("comissio", emp.Commission);
            cmd.Parameters.AddWithValue("depid", emp.DepId._id);            
            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
                bol = true;
                Console.WriteLine("Employee with ID {0} updated", emp._id);
            }
            catch
            {
                bol = false;
                Console.WriteLine("Couldn't update Employee {0}", emp.Surname);
            }
            
            
            conn.Close();
            return bol;
        }
        
    }
}