using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using cat.itb.M6UF3Ex.connections;
using cat.itb.M6UF3Ex.model;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace cat.itb.M6UF3Ex.cruds
{
    public class BooksCRUD
    {
        public void LoadCollection()
        {
            FileInfo file = new FileInfo("../../files/books.json");
            string fileString = file.OpenText().ReadToEnd();
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(fileString);

            var database = MongoConnection.GetDatabase("itb");
            database.DropCollection("books");
            var collection = database.GetCollection<Book>("books");

            try
            {
                if (books != null)
                    collection.InsertMany(books);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nCollection books loaded");
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Collection couldn't be inserted");
            }
            Console.ResetColor();
        }

        public void Act3a()
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("books");
            
            var filter = Builders<BsonDocument>.Filter.Eq("title", "NHibernate in Action");
            var update = Builders<BsonDocument>.Update.AddToSet("categories", "C Sharp");

            var result = collection.UpdateOne(filter, update);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Modified documents: " + result.ModifiedCount);
            Console.ResetColor();
        }

        public void Act3b()
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("books");

            var filter = Builders<BsonDocument>.Filter.Gt("pageCount", 500);
            var update = Builders<BsonDocument>.Update.Set("tag", "big");
            var result = collection.UpdateMany(filter, update);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Modified documents: " + result.ModifiedCount);
            Console.ResetColor();
        }

        public void Act3d(string title, string anticAutor, string nouAutor)
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("books");

            var filter = Builders<BsonDocument>.Filter.Eq("title", title) & Builders<BsonDocument>.Filter.Eq("authors", anticAutor);
            var update = Builders<BsonDocument>.Update.Set("authors.$", nouAutor);
            var result = collection.UpdateOne(filter, update);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Modified documents: " + result.ModifiedCount);
            Console.ResetColor();
        }

        public void Act4a()
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("books");

            var filter = Builders<BsonDocument>.Filter.Eq("pageCount", 0);
            var result = collection.DeleteMany(filter);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Deleted documents: " + result.DeletedCount);
            Console.ResetColor();
        }
       
        public void Act4b()
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("books");

            var filter = Builders<BsonDocument>.Filter.Eq("isbn", "1932394281");
            var update = Builders<BsonDocument>.Update.PopFirst("authors");
            var result = collection.UpdateOne(filter, update);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Modified documents: " + result.ModifiedCount);
            Console.ResetColor();

        }
    }
}