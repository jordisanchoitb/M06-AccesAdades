using System;
using NHibernate.Criterion;


namespace cat.itb.M6UF2EA4
{
    public static class Program
    {
        public static void Main()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                PrintMenu();
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        Console.Clear();
                        Act1();
                        Console.WriteLine("Prem una tecla per continua");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Act2();
                        Console.WriteLine("Prem una tecla per continua");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Act3();
                        Console.WriteLine("Prem una tecla per continua");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Act4();
                        Console.WriteLine("Prem una tecla per continua");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Act5();
                        Console.WriteLine("Prem una tecla per continua");
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        Act6();
                        Console.WriteLine("Prem una tecla per continua");
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        Act7();
                        Console.WriteLine("Prem una tecla per continua");
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.Clear();
                        Act8();
                        Console.WriteLine("Prem una tecla per continua");
                        Console.ReadKey();
                        break;
                    case 9:
                        Console.Clear();
                        Act9();
                        Console.WriteLine("Prem una tecla per continua");
                        Console.ReadKey();
                        break;
                    case 10:
                        Console.Clear();
                        Act10();
                        Console.WriteLine("Prem una tecla per continua");
                        Console.ReadKey();
                        break;
                    case 11:
                        Console.Clear();
                        DbReset();
                        Console.WriteLine("Prem una tecla per continua");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opció no vàlida");
                        Console.WriteLine("Prem una tecla per continua");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("0. Sortir");
            Console.WriteLine("1. Act1");
            Console.WriteLine("2. Act2");
            Console.WriteLine("3. Act3");
            Console.WriteLine("4. Act4");
            Console.WriteLine("5. Act5");
            Console.WriteLine("6. Act6");
            Console.WriteLine("7. Act7");
            Console.WriteLine("8. Act8");
            Console.WriteLine("9. Act9");
            Console.WriteLine("10. Act10");
            Console.WriteLine("11. DbReset");
        }

        public static void Act1()
        {
            List<Departamento> departamentos = DepartamentosCRUD.SelectAllHQl();
            foreach (var departamento in departamentos)
            {
                Console.WriteLine(departamento);
            }
        }
        public static void Act2()
        {
            List<Empleado> empleados = EmpleadosCRUD.SelectAllCriteria();
            foreach (var empleado in empleados)
            {
                Console.WriteLine(empleado);
            }
        }
        public static void Act3()
        {
            List<Empleado> empleados = EmpleadosCRUD.SelectSalariGreater2000Criteria();
            foreach (var empleado in empleados)
            {
                Console.WriteLine($"Cognom: {empleado.Apellido} - Salari: {empleado.Salario}");
            }
        }
        public static void Act4()
        {
            string localizacion = DepartamentosCRUD.SelectLocalizacionHQL("VENTAS");
            Console.WriteLine(localizacion);
        }
        public static void Act5()
        {
            List<Empleado> empleados = EmpleadosCRUD.SelectVendedorOrderBySalarioDescQueryOver();
            foreach (var empleado in empleados)
            {
                Console.WriteLine(empleado);
            }
        }
        public static void Act6()
        {
            List<Empleado> empleados = EmpleadosCRUD.SelectApellidoOficiStartSApellidoHQL();
            foreach (var empleado in empleados)
            {
                Console.WriteLine($"Cognom: {empleado.Apellido} - Ofici: {empleado.Oficio} - Salari: {empleado.Salario}");
            }
        }
        public static void Act7()
        {
            List<Departamento> departamentos = DepartamentosCRUD.SelectLocalizacionSevillaBarcelonaQueryOver();
            foreach (var departamento in departamentos)
            {
                Console.WriteLine(departamento);
            }
        }
        public static void Act8()
        {
            List<string> empleados = EmpleadosCRUD.SelectCognomSalariBetween2000_3500QueryOver();
            foreach (var empleado in empleados)
            {
                Console.WriteLine(empleado);
            }
        }
        public static void Act9()
        {
            List<Empleado> empleados = EmpleadosCRUD.SelectOficioEmpleadoSalariGreater1400QueryOver();
            foreach (var empleado in empleados)
            {
                Console.WriteLine($"Cognom: {empleado.Apellido} - Salari: {empleado.Salario}");
            }
        }
        public static void Act10()
        {
            Empleado empleado = EmpleadosCRUD.SelectSalariMaxQueryOver();
            Console.WriteLine($"Cognom: {empleado.Apellido} - Ofici: {empleado.Oficio} - Salari: {empleado.Salario}");
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