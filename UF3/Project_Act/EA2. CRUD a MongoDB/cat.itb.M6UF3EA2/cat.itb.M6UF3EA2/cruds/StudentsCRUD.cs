using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cat.itb.M6UF3EA2.connections;
using cat.itb.M6UF3EA2.model;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace cat.itb.M6UF3EA2.cruds
{
    public class StudentsCRUD
    {
        public void LoadStudentsCollection()
        {
            GeneralCRUD generalCRUD = new GeneralCRUD();
            generalCRUD.DropCollection("itb", "students");

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
