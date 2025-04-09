using cat.itb.M6UF3EA4.connections;

namespace cat.itb.M6UF3EA4.cruds
{
    public class GeneralCRUD
    {
        public void DropCollection(string namedatabase, string collection)
        {
            var database = MongoLocalConnection.GetDatabase(namedatabase);
            database.DropCollection(collection);
        }
    }
}
