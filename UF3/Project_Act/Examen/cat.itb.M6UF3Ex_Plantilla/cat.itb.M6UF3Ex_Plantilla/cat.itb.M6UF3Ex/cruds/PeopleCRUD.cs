using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cat.itb.M6UF3Ex.model;
using cat.itb.M6UF3Ex.connections;
using Newtonsoft.Json;
using MongoDB.Driver;
using Microsoft.SqlServer.Server;
using MongoDB.Bson;


namespace cat.itb.M6UF3Ex.cruds
{
    public class PeopleCRUD
    {

       public void LoadCollection()
        {             
            FileInfo file = new FileInfo("../../files/people.json");
            StreamReader sr = file.OpenText();
            string fileString = sr.ReadToEnd();
            sr.Close();
            List<Person> people = JsonConvert.DeserializeObject<List<Person>>(fileString);

            var database = MongoConnection.GetDatabase("itb");
            database.DropCollection("people");
            var collection = database.GetCollection<Person>("people");      
           

            try
            {
                if (people != null)
                    collection.InsertMany(people);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nCollection people loaded");
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Collection people couldn't be inserted");
            }
            Console.ResetColor();
        }        

        public void Act5a()
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Person>("people");

            var result = collection.Aggregate()
                .Unwind("friends")
                .Group(new BsonDocument { { "_id", "$friends.name" } })
                .ToList();

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in result)
            {
                Console.WriteLine(item["_id"]);
            }
            Console.ResetColor();

        }

        public void Act5b()
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Person>("people");

            var result = collection.Aggregate()
                .Unwind("tags")
                .Group(new BsonDocument { { "_id", "$tags" }, { "count", new BsonDocument("$sum", 1) } })
                .ToList();

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in result)
            {
                Console.WriteLine(item["_id"] + " - " + item["count"]);
            }
            Console.ResetColor();
        }

        public void Act5c()
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Person>("people");

            var result = collection.Aggregate()
                .Group(new BsonDocument { { "_id", "$gender" }, { "averageAge", new BsonDocument("$avg", "$age") } })
                .ToList();

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in result)
            {
                Console.WriteLine(item["_id"] + " - " + item["averageAge"]);
            }
            Console.ResetColor();
        }

    }
}
