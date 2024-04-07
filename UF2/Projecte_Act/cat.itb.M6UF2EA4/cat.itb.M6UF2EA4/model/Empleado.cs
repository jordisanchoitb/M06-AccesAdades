using System;

namespace cat.itb.M6UF2EA4
{
    public class Empleado
    {
        public virtual int Id { get; set; }
        public virtual int EmpNo { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Oficio { get; set; }
        public virtual int Dir { get; set; }
        public virtual DateTime FechaAlt { get; set; }
        public virtual double Salario { get; set; }
        public virtual double Comision { get; set; }
        public virtual Departamento Departamento { get; set; }

        public Empleado(int empNo, string apellido, string oficio, int dir, DateTime fechaAlt, double salario, double comision, Departamento departamento)
        {
            EmpNo = empNo;
            Apellido = apellido;
            Oficio = oficio;
            Dir = dir;
            FechaAlt = fechaAlt;
            Salario = salario;
            Comision = comision;
            Departamento = departamento;
        }

        public Empleado()
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}, EmpNo: {EmpNo}, Apellido: {Apellido}, Oficio: {Oficio}, Dir: {Dir}, FechaAlt: {FechaAlt}, Salario: {Salario}, Comision: {Comision}, Departamento: {Departamento}";
        }

    }
}
