using cat.itb.M6UF3EA3.connections;
using cat.itb.M6UF3EA3.model;
using MongoDB.Bson;
using Newtonsoft.Json;
using MongoDB.Driver;

namespace cat.itb.M6UF3EA3.cruds
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

        public void LoadProducts2Collection()
        {
            GeneralCRUD generalCRUD = new GeneralCRUD();
            generalCRUD.DropCollection("itb", "products");

            List<Product> products = new List<Product>();

            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("products");

            string path = @"..\..\..\files\products2.json";
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

        public void Query7()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<Product>("products");

            var product = (from prod in collection.AsQueryable<Product>()
                          orderby prod.price ascending
                          select new { prod.name, prod.price }).FirstOrDefault();

            Console.WriteLine(product.name + " - " + product.price);
        }

        public void Query8()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<Product>("products");

            var sum = collection.AsQueryable<Product>().Sum(p => p.stock);

            Console.WriteLine("La suma de tots els stock es: " + sum);

        }
        
    }
}
