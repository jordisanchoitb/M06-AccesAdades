using cat.itb.M6UF3EA3.connections;
using cat.itb.M6UF3EA3.model;
using MongoDB.Bson;
using Newtonsoft.Json;
using MongoDB.Driver;

namespace cat.itb.M6UF3EA3.cruds
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

        public void LoadBooks2Collection()
        {
            GeneralCRUD generalCRUD = new GeneralCRUD();
            generalCRUD.DropCollection("itb", "books");

            FileInfo file = new FileInfo(@"..\..\..\files\books2.json");
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

        public void Query1()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<Book>("books");

            var booklist = collection.AsQueryable().ToList().Select(x => x.isbn);

            foreach (var book in booklist)
            {
                Console.WriteLine(book);
            }
        }

        public void Query2()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<Book>("books");

            var booklist = from book in collection.AsQueryable()
                           orderby book.pageCount descending
                           select new { book.title, book.categories };

            foreach (var book in booklist)
            {
                Console.WriteLine(book.title);
                foreach (var category in book.categories)
                {
                    Console.WriteLine("\t" + category);
                }
            }
        }

        public void Query3(string author)
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<Book>("books");

            var booklist = from book in collection.AsQueryable()
                           where book.authors.Contains(author)
                           select new { book.title, book.authors };

            foreach (var book in booklist)
            {
                Console.WriteLine(book.title);
                foreach (var autho in book.authors)
                {
                    Console.WriteLine("\t" + autho);
                }
            }
        }

        public void Query4(int min, int max, string categoria)
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<Book>("books");

            var booklist = from book in collection.AsQueryable()
                           where book.pageCount >= min && book.pageCount <= max && book.categories.Contains(categoria)
                           select new { book.title, book.pageCount, book.authors };

            foreach (var book in booklist)
            {
                Console.WriteLine(book.title + " " + book.pageCount);
                foreach (var author in book.authors)
                {
                    Console.WriteLine("\t" + author);
                }
            }
        }

        public void Query5(string[] autors)
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<Book>("books");

            var booklist = from book in collection.AsQueryable()
                           where book.authors.Intersect(autors).Count() == autors.Length
                           select new { book.title, book.authors };

            foreach (var book in booklist)
            {
                Console.WriteLine(book.title);
                foreach (var author in book.authors)
                {
                    Console.WriteLine("\t" + author);
                }
            }
        }

        public void Query6(string categoria, string autordescartat)
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<Book>("books");

            var booklist = from book in collection.AsQueryable()
                           where book.categories.Contains(categoria) && !book.authors.Contains(autordescartat)
                           orderby book.title ascending
                           select new { book.title, book.authors };

            foreach (var book in booklist)
            {
                Console.WriteLine(book.title);
                foreach (var author in book.authors)
                {
                    Console.WriteLine("\t" + author);
                }
            }

        }
    }
}
