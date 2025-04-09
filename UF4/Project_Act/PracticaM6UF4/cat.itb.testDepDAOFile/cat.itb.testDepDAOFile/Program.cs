using System;
using cat.itb.gestioHR.depDAO;

namespace cat.itb.testDepDAOFile
{
    public class Program
    {
        public static void Main()
        {
            // Act2
            DepartmentDAO depDAOSQL = new SQLDepartmentImpl();
            DepartmentDAO filedepDAO = new FileDepartmentImpl();
            filedepDAO.InsertAll(depDAOSQL.SelectAll());


            // Act3
            List<Department> listdep = filedepDAO.SelectAll();
            DepartmentDAO depDAOMongo = new MongoDepartmentImpl();
            depDAOMongo.InsertAll(listdep);

        }
    }
}

