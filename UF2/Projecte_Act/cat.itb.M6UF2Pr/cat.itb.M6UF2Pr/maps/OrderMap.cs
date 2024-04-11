using System;
using FluentNHibernate.Mapping;

namespace cat.itb.M6UF2Pr
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("orderp");
            Id(x => x.Id);
            References(x => x.Supplier).Column("supplierno");
            Map(x => x.OrderDate).Column("orderdate");
            Map(x => x.Amount).Column("amount");
            Map(x => x.DeliveryDate).Column("deliverydate");
            Map(x => x.Cost).Column("cost");
        }
    }
}
