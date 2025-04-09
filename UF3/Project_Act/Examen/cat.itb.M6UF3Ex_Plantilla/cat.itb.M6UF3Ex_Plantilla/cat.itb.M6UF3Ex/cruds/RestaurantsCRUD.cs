using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using cat.itb.M6UF3Ex.connections;
using cat.itb.M6UF3Ex.model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;


namespace cat.itb.M6UF3Ex.cruds
{
    public class RestaurantsCRUD
    {
        public void LoadCollection()
        {
            FileInfo file = new FileInfo("../../files/restaurants.json");
            var database = MongoConnection.GetDatabase("itb");
            database.DropCollection("restaurants");
            var collection = database.GetCollection<Restaurant>("restaurants");

            using (StreamReader sr = file.OpenText())
            {
                string productString;
                while ((productString = sr.ReadLine()) != null)
                {
                    Restaurant rest = JsonConvert.DeserializeObject<Restaurant>(productString);
                    collection.InsertOne(rest);
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nCollection restaurants loaded");
            Console.ResetColor();
        }

        public void Act1()
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Restaurant>("restaurants");

            Restaurant rest1 = new Restaurant
            {
                address = new Address { building = "3850", street = "Richmond Avenue", zipcode = "10312" },
                borough = "Staten Island",
                cuisine = "Pizza",
                name = "David Vaquer - El pizzero espagnol",
                restaurant_id = "9999999559"
            };

            Restaurant rest2 = new Restaurant
            {
                address = new Address { building = "24", street = "East 39 Street", coord = new double[] { -73.9812198, 40.7509706 }, zipcode = "10016" },
                borough = "Manhattan",
                cuisine = "American",
                name = "Joan_Gomez's Hamburgers",
                restaurant_id = "99999996691"
            };

            collection.InsertOne(rest1);
            collection.InsertOne(rest2);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nRestaurants added");
        }

        public void Act2a()
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("restaurants");

            var filter = Builders<BsonDocument>.Filter.Eq("address.zipcode", "11209") & Builders<BsonDocument>.Filter.Eq("cuisine", "Delicatessen");
            var result = collection.Find(filter).ToList();

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var doc in result)
            {
                Console.WriteLine(doc);
            }
            Console.ResetColor();
        }

        public void Act2b(string borough)
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Restaurant>("restaurants");

            var query = from r in collection.AsQueryable()
                        where r.borough == borough
                        select new {
                            r.name,
                            r.cuisine,
                            r.address
                        };

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var rest in query)
            {
                Console.WriteLine(rest.name + " - " + rest.cuisine);
                Console.WriteLine("\t" + rest.address);
            }
            Console.ResetColor();
        }
        public void Act2c()
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("restaurants");

            var filter = Builders<BsonDocument>.Filter.Eq("borough", "Queens") & Builders<BsonDocument>.Filter.Ne("cuisine", "American ");
            var result = collection.Find(filter).ToList();

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var doc in result)
            {
                Console.WriteLine("Nom: " + doc.GetElement("name").Value + " Cuina: " + doc.GetElement("cuisine").Value);
            }
            Console.ResetColor();
        } 

        public void Act2f() 
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Restaurant>("restaurants");

            var query = collection.AsQueryable().Where(r => r.restaurant_id == "40361521").Select(r => new
            {
                grades = r.grades.Count,
                score = r.grades.Sum(g => g.score)
            });

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var rest in query)
            {
                Console.WriteLine("Grades: " + rest.grades + " Score: " + rest.score);
            }
            Console.ResetColor();
        } 

        public void Act3c()
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("restaurants");

            var filter = Builders<BsonDocument>.Filter.Eq("restaurant_id", "40368271");
            var update = Builders<BsonDocument>.Update.Set("address.coord", new double[] { -61.886970, 38.72532 });

            var result = collection.UpdateOne(filter, update);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Modified documents: " + result.ModifiedCount);
            var changed = collection.Find(filter).ToList();
            foreach (var doc in changed)
            {
                Console.WriteLine(doc.GetElement("address"));
            }
            Console.ResetColor();
        }

        public void Act4c()
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("restaurants");

            var filter = Builders<BsonDocument>.Filter.Eq("borough", "Bronx");
            var update = Builders<BsonDocument>.Update.Unset("cuisine");

            var result = collection.UpdateMany(filter, update);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Modified documents: " + result.ModifiedCount);
            Console.ResetColor();
        }

        public void Act5d()
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Restaurant>("restaurants");
            
            var result = collection.Aggregate()
                .Group(new BsonDocument { { "_id", "$address.zipcode" }, { "street", new BsonDocument("$addToSet", "$address.street") } })
                .ToList();

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in result)
            {
                Console.Write("Codi postal: ");
                Console.WriteLine(item["_id"]);

                Console.WriteLine("Carrers:");
                foreach (var street in item["street"].AsBsonArray)
                {
                    Console.WriteLine("\t" + street);
                }
            }
            Console.ResetColor();

        }
    }
}