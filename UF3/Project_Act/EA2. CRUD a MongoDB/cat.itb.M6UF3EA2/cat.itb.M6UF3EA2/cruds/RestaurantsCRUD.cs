using cat.itb.M6UF3EA2.connections;
using cat.itb.M6UF3EA2.model;
using MongoDB.Bson;
using Newtonsoft.Json;
using MongoDB.Driver;

namespace cat.itb.M6UF3EA2.cruds
{
    public class RestaurantsCRUD
    {
        public void LoadRestaurantsCollection()
        {
            GeneralCRUD generalCRUD = new GeneralCRUD();
            generalCRUD.DropCollection("itb", "restaurants");

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

        public void GetManhattanSeafoodRestaurants()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("restaurants");

            var filter = Builders<BsonDocument>.Filter.Eq("borough", "Manhattan") & Builders<BsonDocument>.Filter.Eq("cuisine", "Seafood");
            var result = collection.Find(filter).ToList();

            if (result.Count > 0)
            {
                foreach (var restaurant in result)
                {
                    Console.WriteLine(restaurant.GetValue("name").ToString());
                }
            }
        }

        public void GetRestaurantsByZipcode()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("restaurants");

            var filter = Builders<BsonDocument>.Filter.Eq("address.zipcode", "10075");
            var result = collection.Find(filter).ToList();

            if (result.Count > 0)
            {
                foreach (var restaurant in result)
                {
                    Console.WriteLine(restaurant.GetValue("name").ToString());
                }
            }
        }

        public void UpdateZipcode()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("restaurants");

            var filter = Builders<BsonDocument>.Filter.Eq("address.street", "Charles Street");
            var update = Builders<BsonDocument>.Update.Set("address.zipcode", "30033");
            var result = collection.UpdateMany(filter, update);

            Console.WriteLine(result.ModifiedCount + " documents modificats");

        }

        public void AddStarsField()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("restaurants");

            var filter = Builders<BsonDocument>.Filter.Eq("cuisine", "Caribbean");
            var update = Builders<BsonDocument>.Update.AddToSet("stars", "*****");
            var result = collection.UpdateMany(filter, update);

            Console.WriteLine(result.ModifiedCount + " documents modificats");

        }

        public void DeleteDelicatessenRestaurants()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("restaurants");

            var filter = Builders<BsonDocument>.Filter.Eq("cuisine", "Delicatessen");
            var result = collection.DeleteMany(filter);

            Console.WriteLine(result.DeletedCount + " documents eliminats");
        }

    }
}
