using System;
using cat.itb.gestioHR.empDAO;

namespace cat.itb.testEmpDAO
{
    public class Program
    {
        public static void Main()
        {
            // Act 5
            EmployeeDAO empDAOSQL = new SQLEmployeeImpl();
            EmployeeDAO fileempDAO = new FileEmployeeImpl();
            fileempDAO.InsertAll(empDAOSQL.SelectAll());

            // Act 6
            List<Employee> employees = fileempDAO.SelectAll();
            EmployeeDAO empDAOMONGO = new MongoEmployeeImpl();
            empDAOMONGO.InsertAll(employees);

            // Act 7
            Employee employee = empDAOMONGO.Select(7654);
            employee.Salary = 2000;
            // Modificat salari en el mongodb
            empDAOMONGO.Update(employee);
            // Modificat salari en el postgresql
            empDAOSQL.Update(employee);
            // Modificat salari en el fitxer
            fileempDAO.InsertAll(empDAOSQL.SelectAll());


        }
    }
}
