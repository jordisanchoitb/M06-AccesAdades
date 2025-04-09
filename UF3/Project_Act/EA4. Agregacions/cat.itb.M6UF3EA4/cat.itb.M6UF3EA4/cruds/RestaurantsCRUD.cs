using cat.itb.M6UF3EA4.connections;
using MongoDB.Bson;
using Newtonsoft.Json;
using MongoDB.Driver;
using cat.itb.M6UF3EA4.model;

namespace cat.itb.M6UF3EA4.cruds
{
    public class RestaurantsCRUD
    {
        public void LoadRestaurantsCollection()
        {
            GeneralCRUD generalCRUD = new GeneralCRUD();
            generalCRUD.DropCollection("itb", "restaurants");

            List<Restaurant> restaurants = new List<Restaurant>();

            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<Restaurant>("restaurants");

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
                    collection.InsertOne(restaurant);
                }

        }

        public void Aggregation1()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<Restaurant>("restaurants");

            var result = collection.Aggregate()
                .Group(new BsonDocument { { "_id", "$cuisine" }, { "count", new BsonDocument("$sum", 1) } })
                .Sort(new BsonDocument { { "count", 1 } })
                .ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }

        public void Aggregation2()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<Restaurant>("restaurants");

            var result = collection.Aggregate()
                .Unwind("grades")
                .Group(new BsonDocument { { "_id", "$name" }, { "count", new BsonDocument("$sum", 1) } })
                .ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public void Aggregation3()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<Restaurant>("restaurants");
            var result = collection.Aggregate()
                .Unwind("grades")
                .Group(new BsonDocument { { "_id", "$name" }, { "max", new BsonDocument("$max", "$grades.score") } })
                .ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public void Aggregation4()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<Restaurant>("restaurants");

            var result = collection.Aggregate()
                .Group(new BsonDocument { { "_id", "$borough" }, { "cuisine", new BsonDocument("$addToSet", "$cuisine") } })
                .Sort(new BsonDocument { { "_id", 1 } })
                .ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item.GetElement("_id").Value);
                Console.WriteLine(item.GetElement("cuisine").Value);
                Console.WriteLine("----------------------------------------------------");

            }

        }
    }
}
