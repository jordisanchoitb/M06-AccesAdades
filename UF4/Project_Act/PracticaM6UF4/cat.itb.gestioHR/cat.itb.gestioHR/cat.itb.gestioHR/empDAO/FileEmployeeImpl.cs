using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.gestioHR.empDAO
{
    public class FileEmployeeImpl : EmployeeDAO
    {
        public void InsertAll(List<Employee> emps)
        {
            string path = @"..\..\..\employee.json";
            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = System.Text.Json.JsonSerializer.Serialize(emps, options);
            System.IO.File.WriteAllText(path, json);
        }
        public List<Employee> SelectAll()
        {
            string path = @"..\..\..\employee.json";
            string json = System.IO.File.ReadAllText(path);
            List<Employee> emps = System.Text.Json.JsonSerializer.Deserialize<List<Employee>>(json);
            return emps;
        }

        public bool Delete(int empId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Employee emp)
        {
            throw new NotImplementedException();
        }


        public Employee Select(int empId)
        {
            throw new NotImplementedException();
        }


        public bool Update(Employee emp)
        {
            throw new NotImplementedException();
        }
    }
}
