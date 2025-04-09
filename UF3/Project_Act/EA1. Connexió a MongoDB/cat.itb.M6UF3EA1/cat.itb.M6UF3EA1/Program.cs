using cat.itb.M6UF3EA1.connections;
using cat.itb.M6UF3EA1.model;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace cat.itb.M6UF3EA1
{
    public class Program
    {
        public static void Main()
        {
            //GetAllDBs();
            //GetCollections("sample_training");
            //Act1();
            //Act2();
            //Act3();
            //Act4();
            //Act5();
            //Act6();
            //LoadPeopleCollection();
            //LoadBooksCollection();
            //LoadRestaurantsCollection();
            //LoadProductsCollection();
            //LoadStudentsCollection();
        }

        private static void GetAllDBs()
        {
            var dbClient = MongoLocalConnection.GetMongoClient();

            var dbList = dbClient.ListDatabases().ToList();
            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }
        }
        private static void GetCollections(string collection)
        {
            var database = MongoLocalConnection.GetDatabase(collection);

            var colList = database.ListCollections().ToList();
            Console.WriteLine("The list of collection on this database is: ");
            foreach (var col in colList)
            {
                Console.WriteLine(col);
            }
        }
        private static void Act1()
        {
            var document = new BsonDocument()
            {
                { "student_id", 111333444 }, 
                { "name", "Jordi" }, 
                { "surname", "Sancho Garcia" }, 
                { "class_id", "DAM" }, 
                { "group", "DAMv" }, 
                { "scores", new BsonArray() 
                    { 
                        new BsonDocument() { 
                                { "type", "exam" }, 
                                { "score", 100 } }, 
                        new BsonDocument() { 
                                { "type", "teamWork" }, 
                                { "score", 50 } 
                        } 
                    } 
                } 
            };
            var document2 = new BsonDocument()
            {
                { "student_id", 111222333 },
                { "name", "Un altre nom" },
                { "surname", "Inventat" },
                { "class_id", "Undefined" },
                { "group", "DAMv" },
                { "interests", new BsonArray()
                    {
                        "music", 
                        "gym", 
                        "code", 
                        "electronics" 
                    } 
                } 
            };
            
            var database = MongoLocalConnection.GetDatabase("sample_training");
            var collection = database.GetCollection<BsonDocument>("grades");
            collection.InsertOne(document);
            collection.InsertOne(document2);
        }
        private static void Act2()
        {
            var database = MongoLocalConnection.GetDatabase("sample_training");
            var collection = database.GetCollection<BsonDocument>("grades");
            var filter = Builders<BsonDocument>.Filter.Eq("group", "DAMv");
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                Console.WriteLine(doc);
            }
        }
        private static void Act3()
        {
            var database = MongoLocalConnection.GetDatabase("sample_training");
            var collection = database.GetCollection<BsonDocument>("grades");
            var filter = Builders<BsonDocument>.Filter.Eq("scores.type", "exam") & Builders<BsonDocument>.Filter.Eq("scores.score", 100);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                Console.WriteLine(doc);
            }
        }
        private static void Act4()
        {
            var database = MongoLocalConnection.GetDatabase("sample_training");
            var collection = database.GetCollection<BsonDocument>("grades");
            var filter = Builders<BsonDocument>.Filter.Lt("scores.score", 50);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                Console.WriteLine(doc);
            }
        }
        private static void Act5()
        {
            var database = MongoLocalConnection.GetDatabase("sample_training");
            var collection = database.GetCollection<BsonDocument>("grades");
            var filter = Builders<BsonDocument>.Filter.Eq("student_id", 111222333);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                Console.WriteLine(doc.GetElement("interests"));
            }
        }
        private static void Act6()
        {
            LoadPeopleCollection();
            LoadBooksCollection();
            LoadRestaurantsCollection();
            LoadProductsCollection();
            LoadStudentsCollection();
        }

        private static void LoadPeopleCollection()
        {
            FileInfo file = new FileInfo(@"..\..\..\files\people.json");
            StreamReader sr = file.OpenText();
            string fileString = sr.ReadToEnd();
            sr.Close();
            List<Person> people = JsonConvert.DeserializeObject<List<Person>>(fileString);

            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("people");

            if (people != null)
                foreach (var person in people)
                {
                    Console.WriteLine(person.name);
                    string json = JsonConvert.SerializeObject(person);
                    var document = new BsonDocument();
                    document.Add(BsonDocument.Parse(json));
                    collection.InsertOne(document);
                }
        }

        private static void LoadBooksCollection()
        {
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

        private static void LoadRestaurantsCollection()
        {
            List<Restaurant> restaurants = new List<Restaurant>();

            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("restaurants");

            string path = @"..\..\..\files\restaurants.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                string line;
                while ((line = jsonStream.ReadLine()) != null)
                {
                    Restaurant restaurant = JsonConvert.DeserializeObject<Restaurant>(line);
                    restaurants.Add(restaurant);
                }
            }

            if (restaurants != null)
                foreach (var restaurant in restaurants)
                {
                    Console.WriteLine(restaurant.name);
                    string json = JsonConvert.SerializeObject(restaurant);
                    var document = restaurant.ToBsonDocument();
                    collection.InsertOne(document);
                }

        }

        private static void LoadProductsCollection()
        {
            List<Product> products = new List<Product>();

            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("products");

            string path = @"..\..\..\files\products.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                string line;
                while ((line = jsonStream.ReadLine()) != null)
                {
                    Product product = JsonConvert.DeserializeObject<Product>(line);
                    products.Add(product);
                }
            }

            if (products != null)
                foreach (var product in products)
                {
                    Console.WriteLine(product.name);
                    string json = JsonConvert.SerializeObject(product);
                    var document = new BsonDocument();
                    document.Add(BsonDocument.Parse(json));
                    collection.InsertOne(document);
                }

        }

        private static void LoadStudentsCollection()
        {
            List<Student> students = new List<Student>();

            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("students");

            string path = @"..\..\..\files\students.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                string line;
                while ((line = jsonStream.ReadLine()) != null)
                {
                    Student student = JsonConvert.DeserializeObject<Student>(line);
                    students.Add(student);
                }
            }

            if (students != null)
                foreach (var student in students)
                {
                    Console.WriteLine(student.firstname);
                    string json = JsonConvert.SerializeObject(student);
                    var document = new BsonDocument();
                    document.Add(BsonDocument.Parse(json));
                    collection.InsertOne(document);
                }
        }
    }
}