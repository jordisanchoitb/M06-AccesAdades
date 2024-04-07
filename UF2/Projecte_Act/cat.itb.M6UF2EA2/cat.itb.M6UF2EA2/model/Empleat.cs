using System;

namespace cat.itb.M6UF2EA2
{
    public class Empleat
    {
        public int Emp_no { get; set; }
        public string Cognom { get; set; }
        public string Ofici { get; set; }
        public int Cap { get; set; }
        public DateTime Data_Alt { get; set; }
        public int Salari { get; set; }
        public int Comissio { get; set; }
        public int Dept_no { get; set; }

        public Empleat(int Emp_no, string Cognom, string Ofici, int Cap, DateTime Data_Alt, int Salari, int Comissio, int Dept_no)
        {
            this.Emp_no = Emp_no;
            this.Cognom = Cognom;
            this.Ofici = Ofici;
            this.Cap = Cap;
            this.Data_Alt = Data_Alt;
            this.Salari = Salari;
            this.Comissio = Comissio;
            this.Dept_no = Dept_no;
        }

        public override string ToString()
        {
            return $"Emp_no: {this.Emp_no}" +
                $"\nCognom: {this.Cognom}" +
                $"\nOfici: {this.Ofici}" +
                $"\nCap: {this.Cap}" +
                $"\nData_Alt: {this.Data_Alt}" +
                $"\nSalari: {this.Salari}" +
                $"\nComissio: {this.Comissio}" +
                $"\nDept_no: {this.Dept_no}";
        }
    }
}
