using System;

namespace cat.itb.M6UF2EA2
{
    public class Producte
    {
        public int Prod_num { get; set; }
        public string Descripcio { get; set; }

        public Producte(int Prod_num, string Descripcio)
        {
            this.Prod_num = Prod_num;
            this.Descripcio = Descripcio;
        }

        public override string ToString()
        {
            return $"Prod_num: {this.Prod_num}" +
                $"\nDescripcio: {this.Descripcio}";
        }
    }
}
