using System;
using cat.itb.M6UF3EA4.cruds;

namespace cat.itb.M6UF3EA4
{
    public class Program
    {
        public static void Main()
        {
            RestaurantsCRUD restaurantsCRUD = new RestaurantsCRUD();

            bool exit = false, optionexit;
            do
            {
                Console.Clear();
                optionexit = false;
                PrintMenu();
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        do
                        {
                            Console.Clear();
                            PrintImportMenu();
                            int importOption = Convert.ToInt32(Console.ReadLine());
                            switch (importOption)
                            {
                                case 1:
                                    Console.Clear();
                                    restaurantsCRUD.LoadRestaurantsCollection();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case 0:
                                    optionexit = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opció no vàlida");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (!optionexit);
                        break;
                    case 2:
                        do
                        {
                            Console.Clear();
                            PrintAggregationsMenu();
                            int aggregationOption = Convert.ToInt32(Console.ReadLine());
                            switch (aggregationOption)
                            {
                                case 1:
                                    Console.Clear();
                                    restaurantsCRUD.Aggregation1();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Clear();
                                    restaurantsCRUD.Aggregation2();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Clear();
                                    restaurantsCRUD.Aggregation3();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.Clear();
                                    restaurantsCRUD.Aggregation4();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case 0:
                                    optionexit = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opció no vàlida");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (!optionexit);
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Sortint...");
                        exit = true;
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
            Console.WriteLine("1. Importació de la col·lecció Restaurants");
            Console.WriteLine("2. Agregacions");
            Console.WriteLine("0. Sortir");
        }

        public static void PrintAggregationsMenu()
        {
            Console.WriteLine("1. Crea un mètode que mostri el número de restaurants per tipus de cuina i ordena'ls de forma descendent de la cuina amb menys restaurants a la cuina amb més restaurants.");
            Console.WriteLine("2. Crea un mètode que mostri el número de valoracions 'grades' de tots els restaurants. Mostra només el nom del restaurant i el número de valoracions.");
            Console.WriteLine("3. Crea un mètode que mostri la valoració 'score' més alta per cada restaurant. Mostra el nom del restaurant i el 'score' més alt obtingut.");
            Console.WriteLine("4. Crea un mètode que mostri els noms de tipus de cuina per cada barri 'borough'.");
            Console.WriteLine("0. Sortir al menu principal");
        }

        public static void PrintImportMenu()
        {
            Console.WriteLine("1. Importació de la col·lecció Restaurants");
            Console.WriteLine("0. Sortir al menu principal");
        }
    }
}