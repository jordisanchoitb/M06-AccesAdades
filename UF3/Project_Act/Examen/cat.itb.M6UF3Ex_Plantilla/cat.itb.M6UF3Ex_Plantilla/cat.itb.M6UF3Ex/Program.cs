using System;
using cat.itb.M6UF3Ex.connections;
using cat.itb.M6UF3Ex.cruds;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cat.itb.M6UF3Ex
{
    internal class Program
    {
        public static void Main()
        {
            RestaurantsCRUD rCRUD = new RestaurantsCRUD();
            ProductsCRUD pCRUD = new ProductsCRUD();
            BooksCRUD bCRUD = new BooksCRUD();
            PeopleCRUD peCRUD = new PeopleCRUD();
            bool exit = false, exitoption;
            
            do
            {
                exitoption = false;
                Console.Clear();
                PrintMenu();
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        do
                        {
                            Console.Clear();
                            PrintAct1Menu();
                            string act1option = Console.ReadLine();
                            switch (act1option)
                            {
                                case "1":
                                    Console.Clear();
                                    rCRUD.Act1();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "0":
                                    Console.Clear();
                                    exitoption = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opció no vàlida");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (!exitoption);
                        break;
                    case "2":
                        do
                        {
                            Console.Clear();
                            PrintAct2Menu();
                            string act2option = Console.ReadLine();
                            switch (act2option)
                            {
                                case "1":
                                    Console.Clear();
                                    rCRUD.Act2a();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    Console.Clear();
                                    rCRUD.Act2b("Bronx");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "3":
                                    Console.Clear();
                                    rCRUD.Act2c();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "4":
                                    Console.Clear();
                                    pCRUD.Act2d();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "5":
                                    Console.Clear();
                                    pCRUD.Act2e();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "6":
                                    Console.Clear();
                                    rCRUD.Act2f();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "0":
                                    Console.Clear();
                                    exitoption = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opció no vàlida");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (!exitoption);
                        break;
                    case "3":
                        do
                        {
                            Console.Clear();
                            PrintAct3Menu();
                            string act3option = Console.ReadLine();
                            switch (act3option)
                            {
                                case "1":
                                    Console.Clear();
                                    bCRUD.Act3a();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    Console.Clear();
                                    bCRUD.Act3b();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "3":
                                    Console.Clear();
                                    rCRUD.Act3c();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "4":
                                    Console.Clear();
                                    bCRUD.Act3d("Mule in Action", "David Dossot", "Rob Pen");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "0":
                                    Console.Clear();
                                    exitoption = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opció no vàlida");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (!exitoption);
                        break;
                    case "4":
                        do
                        {
                            Console.Clear();
                            PrintAct4Menu();
                            string act4option = Console.ReadLine();
                            switch (act4option)
                            {
                                case "1":
                                    Console.Clear();
                                    bCRUD.Act4a();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    Console.Clear();
                                    bCRUD.Act4b();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "3":
                                    Console.Clear();
                                    rCRUD.Act4c();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "4":
                                    Console.Clear();
                                    pCRUD.Act4d();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "0":
                                    Console.Clear();
                                    exitoption = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opció no vàlida");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (!exitoption);
                        break;
                    case "5":
                        do
                        {
                            Console.Clear();
                            PrintAct5Menu();
                            string act5option = Console.ReadLine();
                            switch (act5option)
                            {
                                case "1":
                                    Console.Clear();
                                    peCRUD.Act5a();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    Console.Clear();
                                    peCRUD.Act5b();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "3":
                                    Console.Clear();
                                    peCRUD.Act5c();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "4":
                                    Console.Clear();
                                    rCRUD.Act5d();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "0":
                                    Console.Clear();
                                    exitoption = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opció no vàlida");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (!exitoption);
                        break;
                    case "6":
                        do
                        {
                            Console.Clear();
                            PrintAct6Menu();
                            string act6option = Console.ReadLine();
                            switch (act6option)
                            {
                                case "1":
                                    Console.Clear();
                                    rCRUD.LoadCollection();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    Console.Clear();
                                    pCRUD.LoadCollection();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "3":
                                    Console.Clear();
                                    bCRUD.LoadCollection();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "4":
                                    Console.Clear();
                                    peCRUD.LoadCollection();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "0":
                                    Console.Clear();
                                    exitoption = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opció no vàlida");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (!exitoption);
                        break;
                    case "0":
                        Console.Clear();
                        exit = true;
                        Console.WriteLine("Adeu!!");
                        Console.WriteLine("Prem un boto per tancar la finestra...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opció no vàlida");
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
                        break;
                }
            } while (!exit);
         }

        public static void PrintMenu()
        {
            Console.WriteLine("1. Exercici 1. Inserció de documents");
            Console.WriteLine("2. Exercici 2. Consultes");
            Console.WriteLine("3. Exercici 3. Actualitzar documents");
            Console.WriteLine("4. Exercici 4. Eliminar documents");
            Console.WriteLine("5. Exercici 5. Agregacions");
            Console.WriteLine("6. Importar collections");
            Console.WriteLine("0. Sortir");
        }

        public static void PrintAct1Menu()
        {
            Console.WriteLine("1. Insercio dels documents");
            Console.WriteLine("0. Sortir al menu principal");
        }

        public static void PrintAct2Menu()
        {
            Console.WriteLine("1. Act A)");
            Console.WriteLine("2. Act B)");
            Console.WriteLine("3. Act C)");
            Console.WriteLine("4. Act D)");
            Console.WriteLine("5. Act E)");
            Console.WriteLine("6. Act F)");
            Console.WriteLine("0. Sortir al menu principal");
        }

        public static void PrintAct3Menu()
        {
            Console.WriteLine("1. Act A)");
            Console.WriteLine("2. Act B)");
            Console.WriteLine("3. Act C)");
            Console.WriteLine("4. Act D)");
            Console.WriteLine("0. Sortir al menu principal");
        }

        public static void PrintAct4Menu()
        {
            Console.WriteLine("1. Act A)");
            Console.WriteLine("2. Act B)");
            Console.WriteLine("3. Act C)");
            Console.WriteLine("4. Act D)");
            Console.WriteLine("0. Sortir al menu principal");
        }

        public static void PrintAct5Menu()
        {
            Console.WriteLine("1. Act A)");
            Console.WriteLine("2. Act B)");
            Console.WriteLine("3. Act C)");
            Console.WriteLine("4. Act D)");
            Console.WriteLine("0. Sortir al menu principal");
        }

        public static void PrintAct6Menu()
        {
            Console.WriteLine("1. Importar restaurants");
            Console.WriteLine("2. Importar products");
            Console.WriteLine("3. Importar books");
            Console.WriteLine("4. Importar people");
            Console.WriteLine("0. Sortir al menu principal");
        }
    }
}