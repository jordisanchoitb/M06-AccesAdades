using System;

namespace cat.itb.M6UF1EA2
{
    public class Products1
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string Picture { get; set; }
        public string[] Categories { get; set; } = new string[10];
    }
}
