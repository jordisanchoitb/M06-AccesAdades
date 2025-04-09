using System;
using System.IO;
using System.Linq;
using cat.itb.M6UF3Ex.connections;
using cat.itb.M6UF3Ex.model;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace cat.itb.M6UF3Ex.cruds
{
    public class ProductsCRUD
    {
        public void LoadCollection()
        { 
            FileInfo file = new FileInfo("../../files/products.json");
            var database = MongoConnection.GetDatabase("itb");
            database.DropCollection("products");
            var collection = database.GetCollection<Product>("products");

            using (StreamReader sr = file.OpenText())
            {
                string productString;
                while ((productString = sr.ReadLine()) != null)
                {
                    Product product = JsonConvert.DeserializeObject<Product>(productString);
                    collection.InsertOne(product);
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nCollection products loaded");
            Console.ResetColor();
        }
        
        public void Act2d()
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Product>("products");

            var query = from p in collection.AsQueryable()
                where p.stock > 25 && p.categories.Contains("ipad")
                select new
                {
                    p.name,
                    p.price,
                };
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in query)
            {
                Console.WriteLine(item.name + " - " + item.price);
            }
            Console.ResetColor();
        }

        public void Act2e()
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Product>("products");

            var query = collection.AsQueryable().Average(p => p.price);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Mitja de tots els productes es: " + query);
            Console.ResetColor();
            
        }

        public void Act4d()
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("products");

            var filter = Builders<BsonDocument>.Filter.Eq("categories", "ipad");
            var result = collection.DeleteMany(filter);


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Deleted documents: " + result.DeletedCount);
            Console.ResetColor();

        }
    }
}