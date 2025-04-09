using cat.itb.M6UF3EA2.connections;
using cat.itb.M6UF3EA2.model;
using MongoDB.Bson;
using Newtonsoft.Json;
using MongoDB.Driver;

namespace cat.itb.M6UF3EA2.cruds
{
    public class BooksCRUD
    {
        public void LoadBooksCollection()
        {
            GeneralCRUD generalCRUD = new GeneralCRUD();
            generalCRUD.DropCollection("itb","books");

            FileInfo file = new FileInfo(@"..\..\..\files\books.json");
            StreamReader sr = file.OpenText();
            string fileString = sr.ReadToEnd();
            sr.Close();
            List<Book> books = JsonConvert.DeserializeObject<List<Book>>(fileString);

            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("books");

            if (books != null)
                foreach (var book in books)
                {
                    Console.WriteLine(book.title);
                    string json = JsonConvert.SerializeObject(book);
                    var document = new BsonDocument();
                    document.Add(BsonDocument.Parse(json));
                    collection.InsertOne(document);
                }
        }

        public void GetBooksByPages()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("books");

            var filter = Builders<BsonDocument>.Filter.Empty;
            var sort = Builders<BsonDocument>.Sort.Ascending("pages");
            var result = collection.Find(filter).Sort(sort).ToList();

            if (result.Count > 0)
            {
                foreach (var book in result)
                {
                    Console.WriteLine(book.GetValue("title").ToString());
                    Console.WriteLine(book.GetValue("authors").ToString());
                }
            }

        }

        public void GetBooksByPagesGreaterThan250()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("books");

            var filter = Builders<BsonDocument>.Filter.Gt("pageCount", 250);
            var result = collection.Find(filter).ToList();

            if (result.Count > 0)
            {
                foreach (var book in result)
                {
                    Console.WriteLine(book.GetValue("title").ToString() +" - "+ book.GetValue("isbn").ToString() + " - " + book.GetValue("pageCount").ToString());
                }
            }
        }
    }
}
