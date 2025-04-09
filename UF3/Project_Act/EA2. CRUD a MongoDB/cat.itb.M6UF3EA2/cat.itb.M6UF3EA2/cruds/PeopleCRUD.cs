using cat.itb.M6UF3EA2.connections;
using cat.itb.M6UF3EA2.model;
using MongoDB.Bson;
using Newtonsoft.Json;
using MongoDB.Driver;

namespace cat.itb.M6UF3EA2.cruds
{
    public class PeopleCRUD
    {
        public void LoadPeopleCollection()
        {
            GeneralCRUD generalCRUD = new GeneralCRUD();
            generalCRUD.DropCollection("itb","people");

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

        public void GetFriendsOfAriannaCramer()
        {
            var database = MongoLocalConnection.GetDatabase("itb");
            var collection = database.GetCollection<BsonDocument>("people");

            var filter = Builders<BsonDocument>.Filter.Eq("name", "Arianna Cramer");
            var result = collection.Find(filter).ToList();

            if (result.Count > 0)
            {
                var friends = result[0].GetValue("friends").AsBsonArray;
                foreach (var friend in friends)
                {
                    Console.WriteLine(friend.ToString());
                }
            }

        }
    }
}
