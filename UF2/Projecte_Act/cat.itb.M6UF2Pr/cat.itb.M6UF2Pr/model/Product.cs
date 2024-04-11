﻿using System;

namespace cat.itb.M6UF2Pr
{
    public class Product
    {
        public virtual int? Id { get; set; }
        public virtual int? Code { get; set; }
        public virtual string? Description { get; set; }
        public virtual int? CurrentStock { get; set; }
        public virtual int? MinStock { get; set; }
        public virtual double? Price { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Supplier? Supplier { get; set; }

        public override string ToString()
        {
            return $"Product: {Id}, {Code}, {Description}, {CurrentStock}, {MinStock}, {Price}";
        }

    }
}
