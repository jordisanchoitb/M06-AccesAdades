using System;
using Newtonsoft.Json;

namespace cat.itb.M6UF1EA2
{
    public static class Program
    {
        public static void Main()
        {
            //Ex1();
            //Ex2();
            //Ex3();
            //Ex4();
            //Ex5();
            //Ex6();
            //Ex7();
            //Ex8();
            //Ex9();
            //Ex10();
        }

        public static void Ex1()
        {
            List<Products1> listProducts1 = new List<Products1>();

            string path = @"../../../FitxersJSON/products1.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                string line;
                while ((line = jsonStream.ReadLine()) != null)
                {
                    Products1 product1 = JsonConvert.DeserializeObject<Products1>(line);
                    listProducts1.Add(product1);
                }
            }
            foreach (Products1 product in listProducts1)
            {
                if (product.Price > 600)
                {
                    string json = JsonConvert.SerializeObject(product);
                    Console.WriteLine(json);
                }
            }
        }

        public static void Ex2()
        {
            List<Products1> listProducts1 = new List<Products1>();
            List<string> category = new List<string>();

            string path = @"../../../FitxersJSON/products1.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                string line;
                while ((line = jsonStream.ReadLine()) != null)
                {
                    Products1 product1 = JsonConvert.DeserializeObject<Products1>(line);
                    listProducts1.Add(product1);
                }
            }
            foreach (Products1 product in listProducts1)
            {
                if (product.Name == "iPhone 8")
                {
                    for (int i = 0; i < product.Categories.Length; i++)
                    {
                        if (product.Categories[i] != null)
                        {
                            category.Add(product.Categories[i]);
                        }
                    }
                    category.Add("supersmartphone");
                    product.Categories = category.ToArray();
                    Console.WriteLine(JsonConvert.SerializeObject(product));
                }
            }
            using (StreamWriter jsonStream = File.CreateText(path))
            {
                foreach (Products1 product in listProducts1)
                {
                    jsonStream.WriteLine(JsonConvert.SerializeObject(product));
                }
            }
        }

        public static void Ex3()
        {
            List<Products1> listProducts1 = new List<Products1>();
            string path = @"../../../FitxersJSON/products1.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                string line;
                while ((line = jsonStream.ReadLine()) != null)
                {
                    Products1 product1 = JsonConvert.DeserializeObject<Products1>(line);
                    listProducts1.Add(product1);
                }
            }

            foreach (Products1 product in listProducts1)
            {
                if (product.Name == "MacBook")
                {
                    product.Stock = 5;
                }
            }

            using (StreamWriter jsonStream = File.CreateText(path))
            {
                foreach (Products1 product in listProducts1)
                {
                    jsonStream.WriteLine(JsonConvert.SerializeObject(product));
                }
            }
        }

        public static void Ex4()
        {
            List<Products1> listProducts1 = new List<Products1>();
            string path = @"../../../FitxersJSON/products1.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                string line;
                while ((line = jsonStream.ReadLine()) != null)
                {
                    Products1 product1 = JsonConvert.DeserializeObject<Products1>(line);
                    if (product1.Stock <= 100)
                    {
                        listProducts1.Add(product1);
                    }
                }

            }

            using (StreamWriter jsonStream = File.CreateText(path))
            {
                foreach (Products1 product in listProducts1)
                {
                    jsonStream.WriteLine(JsonConvert.SerializeObject(product));
                }
            }
        }

        public static void Ex5()
        {
            List<Products2> listProducts2 = new List<Products2>();
            List<Category> listCategories = new List<Category>();
            string path = @"../../../FitxersJSON/products2.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                string line;
                while ((line = jsonStream.ReadLine()) != null)
                {
                    Products2 product2 = JsonConvert.DeserializeObject<Products2>(line);
                    listProducts2.Add(product2);
                }
            }

            foreach (Products2 product in listProducts2)
            {
                if (product.Name == "iPhone 8")
                {
                    for (int i = 0; i < product.Categories.Length; i++)
                    {
                        if (product.Categories[i] != null)
                        {
                            listCategories.Add(product.Categories[i]);
                        }
                    }
                    listCategories.Add(new Category { Id = 10, Name = "supersmartphone" });
                    product.Categories = listCategories.ToArray();
                    Console.WriteLine(JsonConvert.SerializeObject(product));
                }
            }

            using (StreamWriter jsonStream = File.CreateText(path))
            {
                foreach (Products2 product in listProducts2)
                {
                    jsonStream.WriteLine(JsonConvert.SerializeObject(product));
                }
            }
        }

        public static void Ex6()
        {
            List<Products2> listProducts2 = new List<Products2>();
            string path = @"../../../FitxersJSON/products2.json";
            string pathselect = @"../../../FitxersJSON/products2Select.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                string line;
                while ((line = jsonStream.ReadLine()) != null)
                {
                    Products2 product2 = JsonConvert.DeserializeObject<Products2>(line);
                    if (product2.Price > 1000)
                    {
                        listProducts2.Add(product2);
                    }
                }
            }

            using (StreamWriter jsonStream = File.CreateText(pathselect))
            {
                foreach (Products2 product in listProducts2)
                {
                    jsonStream.WriteLine(JsonConvert.SerializeObject(product));
                }
            }
        }

        public static void Ex7()
        {
            List<Products2> listProducts2 = new List<Products2>();
            string path = @"../../../FitxersJSON/products2.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                string line;
                while ((line = jsonStream.ReadLine()) != null)
                {
                    Products2 product2 = JsonConvert.DeserializeObject<Products2>(line);
                    if (product2.Name == "iPad")
                    {
                        product2.Price = 535;
                    }
                    listProducts2.Add(product2);
                }
            }

            using (StreamWriter jsonStream = File.CreateText(path))
            {
                foreach (Products2 product in listProducts2)
                {
                    jsonStream.WriteLine(JsonConvert.SerializeObject(product));
                }
            }
        }

        public static void Ex8()
        {
            List<Products2> listProducts2 = new List<Products2>();
            string path = @"../../../FitxersJSON/products2.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                string line;
                while ((line = jsonStream.ReadLine()) != null)
                {
                    Products2 product2 = JsonConvert.DeserializeObject<Products2>(line);
                    if (product2.Categories.Length == 1)
                    {
                        product2.Stock += 5;
                    }
                    listProducts2.Add(product2);
                }
            }

            using (StreamWriter jsonStream = File.CreateText(path))
            {
                foreach (Products2 product in listProducts2)
                {
                    jsonStream.WriteLine(JsonConvert.SerializeObject(product));
                }
            }
        }

        public static void Ex9()
        {
            List<Products2> listProducts2 = new List<Products2>();
            string path = @"../../../FitxersJSON/products2.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                string line;
                while ((line = jsonStream.ReadLine()) != null)
                {
                    Products2 product2 = JsonConvert.DeserializeObject<Products2>(line);
                    if (product2.Name != "iPhone SE")
                    {
                        listProducts2.Add(product2);
                    }
                }
            }

            using (StreamWriter jsonStream = File.CreateText(path))
            {
                foreach (Products2 product in listProducts2)
                {
                    jsonStream.WriteLine(JsonConvert.SerializeObject(product));
                }
            }
        }

        public static void Ex10()
        {
            List<Restaurant> listRestaurants = new List<Restaurant>();
            string path = @"../../../FitxersJSON/restaurants.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                string line;
                while ((line = jsonStream.ReadLine()) != null)
                {
                    Restaurant restaurant = JsonConvert.DeserializeObject<Restaurant>(line);
                    listRestaurants.Add(restaurant);
                }
            } 

            foreach (Restaurant restaurant in listRestaurants)
            {
                if (restaurant.Restaurant_Id == "30191841")
                {
                    Console.WriteLine($"El restaurant amb la id \"30191841\" a tingut {restaurant.Grades.Length} valoracions");
                    int suma = 0;
                    for (int i = 0; i < restaurant.Grades.Length; i++)
                    {
                        suma += restaurant.Grades[i].Score;
                    }
                    Console.WriteLine($"La suma de tots els scores del restaurant es: {suma}");
                }
            }     
        }
    }
}