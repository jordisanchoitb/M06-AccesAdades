using System;
using FluentNHibernate.Mapping;

namespace cat.itb.M6UF2EA3
{
    public class EmpleadoMap : ClassMap<Empleado>
    {
        public EmpleadoMap()
        {
            Table("empleados");
            Id(x => x.Id);
            Map(x => x.EmpNo).Column("empno");
            Map(x => x.Apellido).Column("apellido");
            Map(x => x.Oficio).Column("oficio");
            Map(x => x.Dir).Column("dir");
            Map(x => x.FechaAlt).Column("fechaalt");
            Map(x => x.Salario).Column("salario");
            Map(x => x.Comision).Column("comision");
            References(x => x.Departamento).Column("deptno");

        }
    }
}
