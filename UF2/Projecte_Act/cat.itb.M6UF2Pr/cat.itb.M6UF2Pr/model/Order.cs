using System;

namespace cat.itb.M6UF2Pr
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual double Amount { get; set; }
        public virtual DateTime DeliveryDate { get; set; }
        public virtual double Cost { get; set; }
        public virtual Supplier Supplier { get; set; }

        public override string ToString()
        {
            return $"Order: {Id}, {OrderDate}, {Amount}, {DeliveryDate}, {Cost}";
        }


    }
}
