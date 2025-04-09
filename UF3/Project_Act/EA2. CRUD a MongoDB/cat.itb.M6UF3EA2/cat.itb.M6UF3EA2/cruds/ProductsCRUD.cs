using cat.itb.M6UF3EA2.connections;
using cat.itb.M6UF3EA2.model;
using MongoDB.Bson;
using Newtonsoft.Json;
using MongoDB.Driver;

namespace cat.itb.M6UF3EA2.cruds
{
    public class ProductsCRUD
    {
        public void LoadProductsCollection()
        {
            GeneralCRUD generalCRUD = new GeneralCRUD();
            generalCRUD.DropCollection("itb", "products");

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

        public void UpdateProductsByPrice()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("products");
            
            var filter = Builders<BsonDocument>.Filter.Gt("price", 600) & Builders<BsonDocument>.Filter.Lt("price", 1000);
            var update = Builders<BsonDocument>.Update.Set("stock", 150);
            var result = collection.UpdateMany(filter, update);

            Console.WriteLine(result.ModifiedCount + " documents modificats");
        }

        public void AddDiscountField()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("products");

            var filter = Builders<BsonDocument>.Filter.Gt("stock", 100);
            var update = Builders<BsonDocument>.Update.AddToSet("discount", 0.20);
            var result = collection.UpdateMany(filter, update);

            Console.WriteLine(result.ModifiedCount + " documents modificats");

        }

        public void AddSmartTVCategory()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("products");

            var filter = Builders<BsonDocument>.Filter.Eq("name", "Apple TV");
            var update = Builders<BsonDocument>.Update.Set("category", "smartTV");
            var result = collection.UpdateMany(filter, update);

            Console.WriteLine(result.ModifiedCount + " documents modificats");

        }

        public void DeleteProductsByPrice()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("products");

            var filter = Builders<BsonDocument>.Filter.Gt("price", 400) & Builders<BsonDocument>.Filter.Lt("price", 600);
            var result = collection.DeleteMany(filter);

            Console.WriteLine(result.DeletedCount + " documents eliminats");

        }

        public void DeleteMacMini()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("products");

            var filter = Builders<BsonDocument>.Filter.Eq("name", "Mac mini");
            var result = collection.DeleteOne(filter);

            Console.WriteLine(result.DeletedCount + " documents eliminats");
        }

        public void DeleteFirstCategoryOfMacBookAir()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("products");

            var filter = Builders<BsonDocument>.Filter.Eq("name", "MacBook Air");
            var update = Builders<BsonDocument>.Update.PopFirst("categories");
            var result = collection.UpdateOne(filter, update);

            Console.WriteLine(result.ModifiedCount + " documents modificats");
        }
    }
}
