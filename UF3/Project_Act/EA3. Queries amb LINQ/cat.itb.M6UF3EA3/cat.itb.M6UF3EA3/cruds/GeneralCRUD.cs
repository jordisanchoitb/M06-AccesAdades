using cat.itb.M6UF3EA3.connections;

namespace cat.itb.M6UF3EA3.cruds
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
