using System;

namespace cat.itb.M6UF2EA3
{
    public class Departamento
    {
        public virtual int Id { get; set; }
        public virtual string Dnombre { get; set; }
        public virtual string Loc { get; set; }
        public virtual IList<Empleado> Empleados { get; set; }

        public Departamento(string dnombre, string loc)
        {
            Dnombre = dnombre;
            Loc = loc;
        }

        public Departamento()
        {
        }

        public override string ToString()
        {
            return $"Departamento:{Id} - {Dnombre} - {Loc}";
        }
    }
}
