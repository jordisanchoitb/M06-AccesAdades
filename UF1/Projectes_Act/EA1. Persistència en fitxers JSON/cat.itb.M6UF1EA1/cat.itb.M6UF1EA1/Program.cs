using System;
using Newtonsoft.Json;

namespace cat.itb.M6UF1EA1
{
    public class Program
    {
        public static void Main()
        {
            //Ex3();
            //Ex2();
            Ex6();
            Ex5();
        }

        public static void Ex2()
        {
            string path = @"..\..\..\json\products1.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                Console.WriteLine(json);
            }
        }

        public static void Ex3()
        {
            Product product1 = new Product
            {
                Name = "Product 1",
                Price = 100,
                Stock = 10,
                Picture = "product1.jpg",
                Categories = new string[] { "Category 1", "Category 2" }
            };

            Product product2 = new Product
            {
                Name = "Product 2",
                Price = 200,
                Stock = 20,
                Picture = "product2.jpg",
                Categories = new string[] { "Category 2", "Category 3" }
            };

            Product product3 = new Product
            {
                Name = "Product 3",
                Price = 300,
                Stock = 30,
                Picture = "product3.jpg",
                Categories = new string[] { "Category 3", "Category 4" }
            };

            Product product4 = new Product
            {
                Name = "Product 4",
                Price = 400,
                Stock = 40,
                Picture = "product4.jpg",
                Categories = new string[] { "Category 4", "Category 5" }
            };

            Product product5 = new Product
            {
                Name = "Product 5",
                Price = 500,
                Stock = 50,
                Picture = "product5.jpg",
                Categories = new string[] { "Category 5", "Category 6" }
            };

            string path = @"..\..\..\json\products1.json";
            string json1 = JsonConvert.SerializeObject(product1);
            string json2 = JsonConvert.SerializeObject(product2);
            string json3 = JsonConvert.SerializeObject(product3);
            string json4 = JsonConvert.SerializeObject(product4);
            string json5 = JsonConvert.SerializeObject(product5);

            using (StreamWriter jsonStream = new StreamWriter(path, true))
            {
                jsonStream.WriteLine(json1);
                jsonStream.WriteLine(json2);
                jsonStream.WriteLine(json3);
                jsonStream.WriteLine(json4);
                jsonStream.WriteLine(json5);
            }
        }

        public static void Ex5()
        {
            string path = @"..\..\..\json\products2.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                string json = jsonStream.ReadToEnd();
                Console.WriteLine(json);
            }
        }
        public static void Ex6()
        {
            Product2 product1 = new Product2
            {
                Name = "Product 1",
                Price = 100,
                Stock = 10,
                Picture = "product1.jpg",
                Categories = [new Category { Id = 1, Name = " Category1"},new Category { Id = 2, Name= "Category2" }]
            };

            Product2 product2 = new Product2
            {
                Name = "Product 2",
                Price = 200,
                Stock = 20,
                Picture = "product2.jpg",
                Categories = [new Category { Id = 2, Name = " Category2"},new Category { Id = 3, Name= "Category3" }]
            };

            Product2 product3 = new Product2
            {
                Name = "Product 3",
                Price = 300,
                Stock = 30,
                Picture = "product3.jpg",
                Categories = [new Category { Id = 3, Name = " Category3"},new Category { Id = 4, Name= "Category4" }]
            };

            Product2 product4 = new Product2
            {
                Name = "Product 4",
                Price = 400,
                Stock = 40,
                Picture = "product4.jpg",
                Categories = [new Category { Id = 4, Name = " Category4"},new Category { Id = 5, Name= "Category5" }]
            };

            Product2 product5 = new Product2
            {
                Name = "Product 5",
                Price = 500,
                Stock = 50,
                Picture = "product5.jpg",
                Categories = [new Category { Id = 5, Name = " Category5"},new Category { Id = 6, Name= "Category6" }]
            };

            string path = @"..\..\..\json\products2.json";
            string json1 = JsonConvert.SerializeObject(product1);
            string json2 = JsonConvert.SerializeObject(product2);
            string json3 = JsonConvert.SerializeObject(product3);
            string json4 = JsonConvert.SerializeObject(product4);
            string json5 = JsonConvert.SerializeObject(product5);

            using (StreamWriter jsonStream = new StreamWriter(path, true))
            {
                jsonStream.WriteLine();
                jsonStream.WriteLine(json1);
                jsonStream.WriteLine(json2);
                jsonStream.WriteLine(json3);
                jsonStream.WriteLine(json4);
                jsonStream.WriteLine(json5);
            }

        }
    }
}