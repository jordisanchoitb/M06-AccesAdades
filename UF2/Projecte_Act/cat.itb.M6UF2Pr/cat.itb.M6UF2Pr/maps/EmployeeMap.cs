using System;
using FluentNHibernate.Mapping;

namespace cat.itb.M6UF2Pr
{
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Table("employee");
            Id(x => x.Id);
            Map(x => x.Surname).Column("surname");
            Map(x => x.Job).Column("job");
            Map(x => x.ManagerNo).Column("managerno");
            Map(x => x.StartDate).Column("startdate");
            Map(x => x.Salary).Column("salary");
            Map(x => x.Commission).Column("commission");
            Map(x => x.DeptNo).Column("deptno");
            HasMany(x => x.Products)
                .KeyColumn("empno")
                .Not.LazyLoad()
                .Fetch.Join();

        }
    }
}
