using System;
using FluentNHibernate.Mapping;

namespace cat.itb.M6UF2EA4
{
    public class DepartamentoMap : ClassMap<Departamento>
    {
        public DepartamentoMap()
        {
            Table("departamentos");
            Id(x => x.Id).Column("id");
            Map(x => x.Dnombre).Column("dnombre");
            Map(x => x.Loc).Column("loc");
            HasMany(x => x.Empleados)
                .KeyColumn("deptno")
                .Cascade.AllDeleteOrphan()
                .Not.LazyLoad();
        }
    }
}
