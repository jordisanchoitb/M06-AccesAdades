using System;
using cat.itb.M6UF3EA2.cruds;

namespace cat.itb.M6UF3EA2
{
    public class Program
    {
        public static void Main()
        {
            BooksCRUD booksCRUD = new BooksCRUD();
            PeopleCRUD peopleCRUD = new PeopleCRUD();
            ProductsCRUD productsCRUD = new ProductsCRUD();
            RestaurantsCRUD restaurantsCRUD = new RestaurantsCRUD();
            StudentsCRUD studentsCRUD = new StudentsCRUD();
            GeneralCRUD generalCRUD = new GeneralCRUD();
            bool exit = false;
            bool exitmenu;

            do
            {
                exitmenu = false;
                Console.Clear();
                PrintMenu();
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        do
                        {
                            Console.Clear();
                            PrintMenuAct1();
                            string option1 = Console.ReadLine();
                            switch (option1)
                            {
                                case "1":
                                    Console.Clear();
                                    booksCRUD.LoadBooksCollection();
                                    Console.WriteLine("Col·leccio books restaurada");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    Console.Clear();
                                    peopleCRUD.LoadPeopleCollection();
                                    Console.WriteLine("Col·leccio people restaurada");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "3":
                                        Console.Clear();
                                        productsCRUD.LoadProductsCollection();
                                        Console.WriteLine("Col·leccio products restaurada");
                                        Console.WriteLine("Prem una tecla per continuar...");
                                        Console.ReadKey();
                                        break;
                                case "4":
                                        Console.Clear();
                                        restaurantsCRUD.LoadRestaurantsCollection();
                                        Console.WriteLine("Col·leccio restaurants restaurada");
                                        Console.WriteLine("Prem una tecla per continuar...");
                                        Console.ReadKey();
                                        break;
                                case "5":
                                        Console.Clear();
                                        studentsCRUD.LoadStudentsCollection();
                                        Console.WriteLine("Col·leccio students restaurada");
                                        Console.WriteLine("Prem una tecla per continuar...");
                                        Console.ReadKey();
                                        break;
                                case "0":
                                    exitmenu = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opció no vàlida");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (!exitmenu);
                        break;
                    case "2":
                        do
                        {
                            Console.Clear();
                            PrintMenuAct2();
                            string option2 = Console.ReadLine();
                            switch (option2)
                            {
                                case "1":
                                    Console.Clear();
                                    peopleCRUD.GetFriendsOfAriannaCramer();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    Console.Clear();
                                    restaurantsCRUD.GetManhattanSeafoodRestaurants();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "3":
                                    Console.Clear();
                                    restaurantsCRUD.GetRestaurantsByZipcode();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "4":
                                    Console.Clear();
                                    booksCRUD.GetBooksByPages();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "5":
                                    Console.Clear();
                                    booksCRUD.GetBooksByPagesGreaterThan250();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "0":
                                    exitmenu = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opció no vàlida");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (!exitmenu);
                        break;
                    case "3":
                        do
                        {
                            Console.Clear();
                            PrintMenuAct3();
                            string option3 = Console.ReadLine();
                            switch (option3)
                            {
                                case "1":
                                    Console.Clear();
                                    productsCRUD.UpdateProductsByPrice();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    Console.Clear();
                                    productsCRUD.AddDiscountField();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "3":
                                    Console.Clear();
                                    productsCRUD.AddSmartTVCategory();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "4":
                                    Console.Clear();
                                    restaurantsCRUD.UpdateZipcode();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "5":
                                    Console.Clear();
                                    restaurantsCRUD.AddStarsField();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "0":
                                    exitmenu = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opció no vàlida");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (!exitmenu);
                        break;
                    case "4":
                        do
                        {
                            Console.Clear();
                            PrintMenuAct4();
                            string option4 = Console.ReadLine();
                            switch (option4)
                            {
                                case "1":
                                    Console.Clear();
                                    productsCRUD.DeleteProductsByPrice();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    Console.Clear();
                                    productsCRUD.DeleteMacMini();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "3":
                                    Console.Clear();
                                    restaurantsCRUD.DeleteDelicatessenRestaurants();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "4":
                                    Console.Clear();
                                    productsCRUD.DeleteFirstCategoryOfMacBookAir();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "0":
                                    exitmenu = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opció no vàlida");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (!exitmenu);
                        break;
                    case "5":
                        do
                        {
                            Console.Clear();
                            PrintMenuAct5();
                            string option5 = Console.ReadLine();
                            switch (option5)
                            {
                                case "1":
                                    Console.Clear();

                                    Console.WriteLine("Introdueix el nom de la base de dades a eliminar");
                                    string database = Console.ReadLine() ?? "";
                                    Console.WriteLine("Introdueix el nom de la col·lecció a eliminar");
                                    string collection = Console.ReadLine() ?? "";
                                    try
                                    {
                                        generalCRUD.DropCollection(database, collection);
                                        Console.WriteLine("Col·lecció eliminada");
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Error al eliminar la col·lecció, mira que el nom de la base de dades o de la col·lecció estiguin correctament escrits");
                                    }
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "0":
                                    exitmenu = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opció no vàlida");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (!exitmenu);
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Adeu!!");
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
            Console.WriteLine("1. Importació de de col·leccions");
            Console.WriteLine("2. Consultes");
            Console.WriteLine("3. Actualitzar documents");
            Console.WriteLine("4. Eliminar documents");
            Console.WriteLine("5. Eliminar una collection");
            Console.WriteLine("0. Sortir");
        }

        public static void PrintMenuAct1()
        {
            Console.WriteLine("1. Importació de fitxer books");
            Console.WriteLine("2. Importació de fitxer people");
            Console.WriteLine("3. Importació de fitxer products");
            Console.WriteLine("4. Importació de fitxer restaurants");
            Console.WriteLine("5. Importació de fitxer students");
            Console.WriteLine("0. Tornar al menu principal");
        }

        public static void PrintMenuAct2()
        {
            Console.WriteLine("1. Amics de Arianna Cramer");
            Console.WriteLine("2. Restaurants de Manhattan i Seafood");
            Console.WriteLine("3. Restaurants per zipcode");
            Console.WriteLine("4. Llibres ordenats per pàgines");
            Console.WriteLine("5. Llibres per pàgines > 250");
            Console.WriteLine("0. Tornar al menu principal");
        }

        public static void PrintMenuAct3()
        {
            Console.WriteLine("1. Actualitzar productes per preu");
            Console.WriteLine("2. Afegir camp discount");
            Console.WriteLine("3. Afegir categoria smartTV");
            Console.WriteLine("4. Actualitzar zipcode");
            Console.WriteLine("5. Afegir camp stars");
            Console.WriteLine("0. Tornar al menu principal");
        }

        public static void PrintMenuAct4()
        {
            Console.WriteLine("1. Eliminar productes per preu");
            Console.WriteLine("2. Eliminar Mac mini");
            Console.WriteLine("3. Eliminar restaurants Delicatessen");
            Console.WriteLine("4. Eliminar primera categoria de MacBook Air");
            Console.WriteLine("0. Tornar al menu principal");
        }

        public static void PrintMenuAct5()
        {
            Console.WriteLine("1. Eliminar col·lecció");
            Console.WriteLine("0. Tornar al menu principal");
        }
    }
}