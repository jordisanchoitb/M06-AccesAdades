using System;
using MongoDB.Driver;

namespace cat.itb.M6UF3EA3.connections
{
    public class MongoClusterConnection
    {
        private static String URL = "mongodb+srv://jordisancho:PTfB8j1OasqHUA7p@m02proves.spwdnpk.mongodb.net/retryWrites=true&w=majority";
        public static IMongoDatabase GetDatabase(String database)
        {
            MongoClient dbClient = new MongoClient(URL);
            return dbClient.GetDatabase(database);
        }

        public static MongoClient GetMongoClient()
        {
            return new MongoClient(URL);
        }
    }
}