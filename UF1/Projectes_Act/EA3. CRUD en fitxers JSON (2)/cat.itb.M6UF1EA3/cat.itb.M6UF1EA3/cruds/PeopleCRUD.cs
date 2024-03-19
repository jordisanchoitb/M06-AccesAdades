using System;
using System.Text.Json;
using Newtonsoft.Json;


namespace cat.itb.M6UF1EA3
{
    public class PeopleCRUD
    {
        public void Act1()
        {
            List<People> peoples = new List<People>();
            string path = @"..\..\..\FitxersJSON\people.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                string json = jsonStream.ReadToEnd();
                peoples = JsonConvert.DeserializeObject<List<People>>(json);
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(peoples, options);

            Console.WriteLine(jsonString);
        }

        public void Act2()
        {
            List<People> peoples = new List<People>();
            string path = @"..\..\..\FitxersJSON\people.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                string json = jsonStream.ReadToEnd();
                peoples = JsonConvert.DeserializeObject<List<People>>(json);
            }

            foreach (People people in peoples)
            {
                if (people.Name == "Julia Young")
                {
                    people.Friends.Add(new Friend { Id = 4, Name = "Trimity Ford" });
                }
            }

            var options = new JsonSerializerOptions { WriteIndented = true };

            using (StreamWriter jsonStreamWriter = File.CreateText(path))
            {
                jsonStreamWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(peoples, options));
            }
        }

        public void Act3()
        {
            List<People> peoples = new List<People>();
            List<People> peoplesGreater25 = new List<People>();
            string path = @"..\..\..\FitxersJSON\people.json";
            string path2 = @"..\..\..\FitxersJSON\adultPeopleArray.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                string json = jsonStream.ReadToEnd();
                peoples = JsonConvert.DeserializeObject<List<People>>(json);
            }

            foreach (People people in peoples)
            {
                if (people.Age > 25)
                {
                    peoplesGreater25.Add(people);
                }
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            
            using (StreamWriter jsonStreamWriter = File.CreateText(path2))
            {
                jsonStreamWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(peoplesGreater25, options));
            }

        }

        public void Act4()
        {
            List<People> peoples = new List<People>();
            List<People> peoplesTeacher = new List<People>();
            string path = @"..\..\..\FitxersJSON\people.json";
            string path2 = @"..\..\..\FitxersJSON\teacher.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                string json = jsonStream.ReadToEnd();
                peoples = JsonConvert.DeserializeObject<List<People>>(json);
            }

            foreach (People people in peoples)
            {
                if (people.RandomArrayItem == "teacher")
                {
                    peoplesTeacher.Add(people);
                }
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            using (StreamWriter jsonStreamWriter = File.CreateText(path2))
            {
                jsonStreamWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(peoplesTeacher, options));
            }

        }

        public void Act5()
        {
            List<People> peoplesTeacher = new List<People>();
            string path = @"..\..\..\FitxersJSON\teacher.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                string json = jsonStream.ReadToEnd();
                peoplesTeacher = JsonConvert.DeserializeObject<List<People>>(json);
            }

            foreach (People people in peoplesTeacher)
            {
                Console.WriteLine($"Nom: {people.Name}, Edad: {people.Age}, Génere: {people.Gender}");
            }
        }

        public void Act6()
        {
            List<People> peoplesTeacher = new List<People>();
            List<People> peoplesTeacherMale = new List<People>();
            string path = @"..\..\..\FitxersJSON\teacher.json";
            string path2 = @"..\..\..\FitxersJSON\professors.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                string json = jsonStream.ReadToEnd();
                peoplesTeacher = JsonConvert.DeserializeObject<List<People>>(json);
            }

            foreach (People people in peoplesTeacher)
            {
                if (people.Gender == "male")
                {
                    peoplesTeacherMale.Add(people);
                }
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            using (StreamWriter jsonStreamWriter = File.CreateText(path2))
            {
                jsonStreamWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(peoplesTeacherMale, options));
            }
        }

        public void Act7()
        {
            List<People> peoplesProfessors = new List<People>();
            string path = @"..\..\..\FitxersJSON\professors.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                string json = jsonStream.ReadToEnd();
                peoplesProfessors = JsonConvert.DeserializeObject<List<People>>(json);
            }

            Console.WriteLine($"Hi han {peoplesProfessors.Count()} profesors.");

            foreach (People people in peoplesProfessors)
            {
                Console.WriteLine($"Profesor: {people.Name}");
                foreach (Friend friend in people.Friends)
                {
                    Console.WriteLine($"Amic: {friend.Name}");
                }
            }
        }

        public void Act8()
        {
            List<People> peoplesProfessors = new List<People>();
            string path = @"..\..\..\FitxersJSON\professors.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                string json = jsonStream.ReadToEnd();
                peoplesProfessors = JsonConvert.DeserializeObject<List<People>>(json);
            }

            foreach (People people in peoplesProfessors)
            {
                if (people.Name == "Allison Oldman")
                {
                    people.Tags.Add("sisto");
                    people.Age = 29;
                }
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            using (StreamWriter jsonStreamWriter = File.CreateText(path))
            {
                jsonStreamWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(peoplesProfessors, options));
            }
        }
    }
}
