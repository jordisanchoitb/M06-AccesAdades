using System;

namespace cat.itb.M6UF2EA3
{
    public static class Program
    {
        public static void Main()
        {
            //Act1();
            //Act2();
            //Act3();
            //Act4();
            //Act5();
            //Act6();
            //Act7();
            //Act8();

            //DbReset();

        }
        public static void Act1()
        {
            List<Departamento> list = new List<Departamento>
            {
                new Departamento("TECNOLOGIA","BARCELONA"),
                new Departamento("INFORMATICA","SEVILLA")
            };
            DepartamentosCRUD departamentoscrud = new DepartamentosCRUD();
            departamentoscrud.Insert(list);
        }

        public static void Act2()
        {
            DepartamentosCRUD departamentoscrud = new DepartamentosCRUD();
            EmpleadosCRUD empleadoscrud = new EmpleadosCRUD();
            Departamento departamentoBNC = departamentoscrud.SelectById(5);
            Departamento departamentoSV = departamentoscrud.SelectById(6);

            Empleado empleado1 = new Empleado(100, "Garcia", "Program", 1, new DateTime(2018, 12, 31, 5, 10, 20, DateTimeKind.Utc), 1000, 0, departamentoBNC);
            Empleado empleado2 = new Empleado(200, "Perez", "Analista", 2, new DateTime(2018, 12, 31, 5, 10, 20, DateTimeKind.Utc), 2000, 0, departamentoSV);

            empleadoscrud.Insert(empleado1);
            empleadoscrud.Insert(empleado2);              
        }

        public static void Act3()
        {
            DepartamentosCRUD departamentoscrud = new DepartamentosCRUD();
            Departamento departamento = departamentoscrud.SelectById(2);
            departamento.Dnombre = "RECERCA";
            departamentoscrud.Update(departamento);
        }

        public static void Act4()
        {
            EmpleadosCRUD empleadoscrud = new EmpleadosCRUD();
            Empleado empleado = empleadoscrud.SelectByEmpno(7499);
            empleado.Salario = 2100;
            empleadoscrud.Update(empleado);
        }

        public static void Act5()
        {
            EmpleadosCRUD empleadoscrud = new EmpleadosCRUD();
            Empleado empleado = empleadoscrud.SelectByApellido("SALA");
            empleadoscrud.Delete(empleado);
        }

        public static void Act6()
        {
            EmpleadosCRUD empleadoscrud = new EmpleadosCRUD();
            List<Empleado> empleados = empleadoscrud.SelectAll();
            foreach (var empleado in empleados)
            {
                if (empleado.Salario > 2000)
                {
                    Console.WriteLine($"Cognom: {empleado.Apellido} Salari: {empleado.Salario}");
                }
            }
        }

        public static void Act7()
        {
            EmpleadosCRUD empleadoscrud = new EmpleadosCRUD();
            Empleado empleado = empleadoscrud.SelectById(6);
            Console.WriteLine($"Nom del departament: {empleado.Departamento.Dnombre}");
        }

        public static void Act8()
        {
            EmpleadosCRUD empleadoscrud = new EmpleadosCRUD();
            List<Empleado> empleados = empleadoscrud.SelectAll();
            foreach (var empleado in empleados)
            {
                if (empleado.Departamento.Id == 2)
                {
                    Console.WriteLine($"Cognom: {empleado.Apellido} Ofici: {empleado.Oficio} Salari: {empleado.Salario}");
                }
            }
        }

        public static void DbReset()
        {
            string path = @"..\..\..\files\hr2.sql";
            string sql = File.ReadAllText(path);

            using (var session = SessionFactoryCloud.Open())
            {
                session.CreateSQLQuery(sql).ExecuteUpdate();
                Console.WriteLine("Base de dades estaurada");
            }
        }
    }
}