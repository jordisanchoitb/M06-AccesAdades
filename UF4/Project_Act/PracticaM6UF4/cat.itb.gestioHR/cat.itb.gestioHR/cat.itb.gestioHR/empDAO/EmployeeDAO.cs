using System;
using System.Collections.Generic;

namespace cat.itb.gestioHR.empDAO
{
    public interface EmployeeDAO
    {

        void DeleteAll();
        void InsertAll(List<Employee> emps);
        List<Employee> SelectAll();
        Employee Select(int empId);
        Boolean Insert(Employee emp);

        Boolean Delete(int empId);

        Boolean Update(Employee emp);

    }
}