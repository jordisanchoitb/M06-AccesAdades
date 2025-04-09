using cat.itb.M6UF3EA3.cruds;
using System;

namespace cat.itb.M6UF3EA3
{
    public class Program
    {
        public static void Main()
        {
            BooksCRUD booksCRUD = new BooksCRUD();
            ProductsCRUD productsCRUD = new ProductsCRUD();
            GeneralCRUD generalCRUD = new GeneralCRUD();

            bool exit = false;
            bool optionExit;
            do
            {
                Console.Clear();
                PrintMenu();
                string opcio = Console.ReadLine();
                switch (opcio)
                {
                    case "1":
                        optionExit = false;
                        do
                        {
                            Console.Clear();
                            PrintMenuAct1();
                            string opcioAct1 = Console.ReadLine();
                            switch (opcioAct1)
                            {
                                case "1":
                                    Console.Clear();
                                    booksCRUD.LoadBooksCollection();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    Console.Clear();
                                    booksCRUD.LoadBooks2Collection();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "3":
                                    Console.Clear();
                                    productsCRUD.LoadProductsCollection();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "4":
                                    Console.Clear();
                                    productsCRUD.LoadProducts2Collection();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "0":
                                    optionExit = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opció no vàlida");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (!optionExit);
                        break;
                    case "2":
                        optionExit = false;
                        do
                        {
                            Console.Clear();
                            PrintMenuAct2();
                            string opcioAct2 = Console.ReadLine();
                            switch (opcioAct2)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Introdueix el nom de la base de dades");
                                    string db = Console.ReadLine();
                                    Console.WriteLine("Introdueix el nom de la col·leccio");
                                    string collection = Console.ReadLine();
                                    generalCRUD.DropCollection(db, collection);
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "0":
                                    optionExit = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opció no vàlida");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (!optionExit);
                        break;
                    case "3":
                        optionExit = false;
                        do
                        {
                            Console.Clear();
                            PrintMenuAct3();
                            string opcioAct3 = Console.ReadLine();
                            switch (opcioAct3)
                            {
                                case "1":
                                    Console.Clear();
                                    booksCRUD.Query1();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    Console.Clear();
                                    booksCRUD.Query2();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "3":
                                    Console.Clear();
                                    booksCRUD.Query3("Danno Ferrin");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "4":
                                    Console.Clear();
                                    booksCRUD.Query4(300, 350, "Java");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "5":
                                    Console.Clear();
                                    booksCRUD.Query5(new string[] { "Charlie Collins", "Robi Sen" });
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "6":
                                    Console.Clear();
                                    booksCRUD.Query6("Java", "Vikram Goyal");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "7":
                                    Console.Clear();
                                    productsCRUD.Query7();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "8":
                                    Console.Clear();
                                    productsCRUD.Query8();
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                                case "0":
                                    optionExit = true;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Opció no vàlida");
                                    Console.WriteLine("Prem una tecla per continuar...");
                                    Console.ReadKey();
                                    break;
                            }
                        } while (!optionExit);
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Adeu!!");
                        Console.WriteLine("Prem una tecla per continuar...");
                        Console.ReadKey();
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
            Console.WriteLine("1. Importació de col·leccions");
            Console.WriteLine("2. Eliminar una collection");
            Console.WriteLine("3. Queries amb LINQ");
            Console.WriteLine("0. Sortir");
        }

        public static void PrintMenuAct1()
        {
            Console.WriteLine("1. Importa les col·leccions books");
            Console.WriteLine("2. Importa les col·leccions books2");
            Console.WriteLine("3. Importa les col·leccions products");
            Console.WriteLine("4. Importa les col·leccions products2");
            Console.WriteLine("0. Tornar al menu principal");
        }

        public static void PrintMenuAct2()
        {
            Console.WriteLine("1. Eliminar col·lecció");
            Console.WriteLine("0. Tornar al menu principal");
        }

        public static void PrintMenuAct3()
        {
            Console.WriteLine("1. Mostra únicament el camp ISBN de tots els llibres.");
            Console.WriteLine("2. Mostra el títol de tots els llibres i les categories a que pertanyen i els ordenes de forma descendent per número de pàgines.");
            Console.WriteLine("3. Mostra el title i authors dels llibres de \"Danno Ferrin\".");
            Console.WriteLine("4. Mostra el title, authors i pageCount dels llibres que tinguin entre 300 i 350 pàgines (ambdues incloses) i siguin de categoria \"Java\".");
            Console.WriteLine("5. Mostra el title, authors dels llibres on han participat almenys els autors: \"Charlie Collins\" i \"Robi Sen\".");
            Console.WriteLine("6. Mostra els llibres que tinguin dins el camp categories la categoria \"Java\" però descartem els que surti \"Vikram Goyal\" com author.");
            Console.WriteLine("7. Mostra el nom i el preu del producte amb el preu més baix.");
            Console.WriteLine("8. Mostra la suma de tots els stocks de la col·lecció de productes.");
            Console.WriteLine("0. Tornar al menu principal");
        }

    }
}
