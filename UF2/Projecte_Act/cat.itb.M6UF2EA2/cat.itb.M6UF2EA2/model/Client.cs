using System;

namespace cat.itb.M6UF2EA2
{
    public class Client
    {
        public int Client_Cod { get; set; }
        public string Nom { get; set; }
        public string Adreca { get; set; }
        public string Ciutat { get; set; }
        public string Estat { get; set; }
        public string Codi_Postal { get; set; }
        public int Area { get; set; }
        public string Telefon { get; set; }
        public int Repr_Cod { get; set; }
        public double Limit_Credit { get; set; }
        public string Observacions { get; set; }

        public Client(int Client_Cod, string Nom, string Adreca, string Ciutat, string Estat, string Codi_Postal, int Area, string Telefon, int Repr_Cod, double Limit_Credit, string Observacions)
        {
            this.Client_Cod = Client_Cod;
            this.Nom = Nom;
            this.Adreca = Adreca;
            this.Ciutat = Ciutat;
            this.Estat = Estat;
            this.Codi_Postal = Codi_Postal;
            this.Area = Area;
            this.Telefon = Telefon;
            this.Repr_Cod = Repr_Cod;
            this.Limit_Credit = Limit_Credit;
            this.Observacions = Observacions;
        }

        public override string ToString()
        {
            return $"Client_Cod: {this.Client_Cod}" +
                $"\nNom: {this.Nom}" +
                $"\nAdreca: {this.Adreca}" +
                $"\nCiutat: {this.Ciutat}" +
                $"\nEstat: {this.Estat}" +
                $"\nCodi_Postal: {this.Codi_Postal}" +
                $"\nArea: {this.Area}" +
                $"\nTelefon: {this.Telefon}" +
                $"\nRepr_Cod: {this.Repr_Cod}" +
                $"\nLimit_Credit: {this.Limit_Credit}" +
                $"\nObservacions: {this.Observacions}";
        }
    }
}
