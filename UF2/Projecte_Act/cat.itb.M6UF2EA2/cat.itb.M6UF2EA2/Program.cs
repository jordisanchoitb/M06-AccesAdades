using System;   

namespace cat.itb.M6UF2EA2
{
    public static class Program
    {
        public static void Main()
        {
            Menu();
        }
        public static void Menu()
        {
            int userOption;
            bool executeAct3To4 = false, executeAct2To9 = false, executeAct1To10 = false;
            do
            {
                PrintMenu();
                Console.WriteLine("Escull una opció:");
                userOption = Convert.ToInt32(Console.ReadLine());
                switch (userOption)
                {
                    case 0:
                        Console.Clear();
                        ResetBBDD();
                        executeAct3To4 = false;
                        executeAct2To9 = false;
                        executeAct1To10 = false;
                        Console.WriteLine("Fes clic en una tecla per continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 1:
                        Console.Clear();
                        Act1();
                        executeAct1To10 = true;
                        break;
                    case 2:
                        Console.Clear();
                        Act2();
                        executeAct2To9 = true;
                        break;
                    case 3:
                        Console.Clear();
                        Act3();
                        executeAct3To4 = true;
                        break;
                    case 4:
                        Console.Clear();
                        if (executeAct3To4)
                        {
                            Act4();
                        }
                        else
                        {
                            Console.WriteLine("Has d'executar l'act 3 primer");
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Act5();
                        break;
                    case 6:
                        Console.Clear();
                        Act6();
                        break;
                    case 7:
                        Console.Clear();
                        Act7();
                        break;
                    case 8:
                        Console.Clear();
                        Act8();
                        break;
                    case 9:
                        Console.Clear();
                        if (executeAct2To9)
                        {
                            Act9();
                        }
                        else
                        {
                            Console.WriteLine("Has d'executar l'act 2 primer");
                        }
                        break;
                    case 10:
                        Console.Clear();
                        if (executeAct1To10)
                        {
                            Act10();
                        }
                        else
                        {
                            Console.WriteLine("Has d'executar l'act 1 primer");
                        }
                        break;
                    case 11:
                        Console.Clear();
                        Console.WriteLine("Sortint...");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opció no vàlida");
                        Console.WriteLine("Fes clic en una tecla per continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (userOption != 11);
        }
        public static void PrintMenu()
        {
            Console.WriteLine("0. Reiniciar la BBDD");
            Console.WriteLine("1. Act 1");
            Console.WriteLine("2. Act 2");
            Console.WriteLine("3. Act 3");
            Console.WriteLine("4. Act 4");
            Console.WriteLine("5. Act 5");
            Console.WriteLine("6. Act 6");
            Console.WriteLine("7. Act 7");
            Console.WriteLine("8. Act 8");
            Console.WriteLine("9. Act 9");
            Console.WriteLine("10. Act 10");
            Console.WriteLine("11. Sortir");
        }
        public static void ResetBBDD()
        {
            GeneralCRUD generalCRUD = new GeneralCRUD();
            generalCRUD.RunScriptEmpresa();
        }
        public static void Act1()
        {
            ProducteCRUD producteCRUD = new ProducteCRUD();
            Producte producte = new Producte(300388, "RH GUIDE TO PADDLE");
            Producte producte2 = new Producte(400552, "RH GUIDE TO BOX");
            Producte producte3 = new Producte(400333, "ACE TENNIS BALLS-10 PACK");
            List<Producte> productes = new List<Producte>() { producte, producte2, producte3 };
            producteCRUD.Insert(productes);
            Console.WriteLine("Fes clic en una tecla per continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Act2()
        {
            EmpleatCRUD empleatCRUD = new EmpleatCRUD();
            Empleat empleat = new Empleat(4885, "BORREL", "EMPLEAT", 7902, new DateTime(1981, 12, 25), 104000, 0, 30);
            Empleat empleat2 = new Empleat(8772, "PUIG", "VENEDOR", 7698, new DateTime(1990, 01, 23), 108000, 0, 30);
            Empleat empleat3 = new Empleat(9945, "FERRER", "ANALISTA", 7698, new DateTime(1988, 05, 17), 169000, 39000, 20);
            List<Empleat> empleats = new List<Empleat>() { empleat, empleat2, empleat3 };
            empleatCRUD.Insert(empleats);
            Console.WriteLine("Fes clic en una tecla per continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Act3()
        {
            ClientCRUD clientCRUD = new ClientCRUD();
            int client_cod1 = 104;
            int newLimitCredit1 = 20000;
            int client_cod2 = 106;
            int newLimitCredit2 = 12000;
            int client_cod3 = 107;
            int newLimitCredit3 = 20000;
            clientCRUD.UpdateLimitCredit(client_cod1, newLimitCredit1);
            clientCRUD.UpdateLimitCredit(client_cod2, newLimitCredit2);
            clientCRUD.UpdateLimitCredit(client_cod3, newLimitCredit3);
            Console.WriteLine("Fes clic en una tecla per continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Act4()
        {
            ClientCRUD clientCRUD = new ClientCRUD();
            int client_cod = 106;
            Client client = clientCRUD.SelectOneId(client_cod);
            Console.WriteLine(client);
            Console.WriteLine("Fes clic en una tecla per continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Act5()
        {
            EmpleatCRUD empleatCRUD = new EmpleatCRUD();
            int emp_no = 7788;
            Empleat empleat = empleatCRUD.SelectOneId(emp_no);
            Console.WriteLine(empleat);
            Console.WriteLine("Fes clic en una tecla per continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Act6()
        {
            ProducteCRUD producteCRUD = new ProducteCRUD();
            int prod_num = 101860;
            Producte producte = producteCRUD.SelectOneId(prod_num);
            Console.WriteLine(producte);
            Console.WriteLine("Fes clic en una tecla per continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Act7()
        {
            EmpleatCRUD empleatCRUD = new EmpleatCRUD();
            List<Empleat> empleats = empleatCRUD.SelectAll();
            foreach (Empleat empleat in empleats)
            {
                Console.WriteLine($"Cognoms: {empleat.Cognom}, Salari: {empleat.Salari}");
            }
            Console.WriteLine("Fes clic en una tecla per continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Act8()
        {
            ClientCRUD clientCRUD = new ClientCRUD();
            int client_cod = 109;
            clientCRUD.Delete(client_cod);
            Console.WriteLine("Fes clic en una tecla per continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Act9()
        {
            EmpleatCRUD empleatCRUD = new EmpleatCRUD();
            int emp_no = 4885;
            empleatCRUD.Delete(emp_no);
            Console.WriteLine("Fes clic en una tecla per continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Act10()
        {
            ProducteCRUD producteCRUD = new ProducteCRUD();
            int prod_num = 400552;
            producteCRUD.Delete(prod_num);
            Console.WriteLine("Fes clic en una tecla per continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}