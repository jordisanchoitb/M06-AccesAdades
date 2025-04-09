using System;
using cat.itb.gestioHR.depDAO;

namespace cat.itb.gestioHR.empDAO
{
    public class Employee
    {
        public virtual int _id { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Job { get; set; }
        public virtual int Managerid { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual double Salary { get; set; }
        public virtual double Commission { get; set; }
        public virtual Department DepId { get; set; }
    }
}

