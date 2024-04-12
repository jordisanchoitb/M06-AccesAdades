using System;
using FluentNHibernate.Mapping;

namespace cat.itb.M6UF2Pr
{
    public class SupplierMap : ClassMap<Supplier>
    {
        public SupplierMap()
        {
            Table("supplier");
            Id(x => x.Id);
            Map(x => x.Name).Column("name");
            Map(x => x.Address).Column("address");
            Map(x => x.City).Column("city");
            Map(x => x.StCode).Column("stcode");
            Map(x => x.ZipCode).Column("zipcode");
            Map(x => x.Area).Column("area");
            Map(x => x.Phone).Column("phone");
            References(x => x.Product).Column("productno").Not.LazyLoad();
            Map(x => x.Amount).Column("amount");
            Map(x => x.Credit).Column("credit");
            Map(x => x.Remark).Column("remark");
            HasMany(x => x.Orders)
                .KeyColumn("supplierno")
                .Not.LazyLoad()
                .Fetch.Join()
                .AsSet();
            ;
        }
    }
}
