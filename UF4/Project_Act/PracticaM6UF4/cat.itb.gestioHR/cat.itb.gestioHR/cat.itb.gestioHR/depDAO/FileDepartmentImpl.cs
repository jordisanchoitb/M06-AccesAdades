using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.gestioHR.depDAO
{
    public class FileEmployeeImpl : DepartmentDAO
    {
        public void InsertAll(List<Department> deps)
        {
            string path = @"..\..\..\departments.json";
            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = System.Text.Json.JsonSerializer.Serialize(deps, options);
            System.IO.File.WriteAllText(path, json);
        }
        public List<Department> SelectAll()
        {
            string path = @"..\..\..\departments.json";
            string json = System.IO.File.ReadAllText(path);
            List<Department> deps = System.Text.Json.JsonSerializer.Deserialize<List<Department>>(json);
            return deps;
        }

        public bool Delete(int depId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Department dep)
        {
            throw new NotImplementedException();
        }


        public Department Select(int depId)
        {
            throw new NotImplementedException();
        }


        public bool Update(Department dep)
        {
            throw new NotImplementedException();
        }
    }
}
