using System;
using System.Text.Json;
using Newtonsoft.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace cat.itb.M6UF1Ex
{
    public class BooksCRUD
    {
        public void Act1()
        {
            List<Book> books = new List<Book>();
            string path = @"..\..\..\JSON\books.json";
            using (StreamReader jsonStreamRead = new StreamReader(path))
            {
                string json = jsonStreamRead.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(books, options);

            Console.WriteLine(jsonString);
        }

        public void Act2()
        {
            List<Book> books = new List<Book>();
            string path = @"..\..\..\JSON\books.json";
            using (StreamReader jsonStreamRead = new StreamReader(path))
            {
                string json = jsonStreamRead.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }
            Console.WriteLine("Abans de l'inserció tenim " + books.Count + " llibres");
            Book book = new Book
            {
                _id = 321,
                title = "SNOOPY Y CARLITOS 1969-1970 Nº 10/25 (NUEVA EDICIÓN)",
                isbn = "9788491465522",
                pageCount = 352,
                thumbnailUrl = "https://www.casadellibro.com/libro-snoopy-y-carlitos-1969af1970-nba-102f25-nueva-edicion/9788491465522/9476893",
                shortDescription = "Tiras publicadas entre 1969 y 1970 de Carlitos, la obra maestra de Charles M. Schulz. El mundo de Carlitos es un microcosmos, una pequeña comedia humana válida tanto para el lector inocente como para el sofisticado.Y la mejor manera de apreciar lo expuesto es esta edición en la que permite apreciar viñeta a viñeta la evolución tanto del artista como de los personajes.",
                status = "MEAP",
                authors = [
                    "Charles M. Schulz"
                ],
                categories = [
                    "Cómic Adulto"
                ]
            };
            books.Add(book);
            Console.WriteLine("Despres de l'insercio tenim " + books.Count + " llibres");

            var options = new JsonSerializerOptions { WriteIndented = true };
            using (StreamWriter jsonStreamWriter = File.CreateText(path))
            {
                jsonStreamWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(books, options));
            }
        }

        public void Act3()
        {
            List<Book> books = new List<Book>();
            string path = @"..\..\..\JSON\books.json";
            using (StreamReader jsonStreamRead = new StreamReader(path))
            {
                string json = jsonStreamRead.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }

            foreach (Book book in books)
            {
                Console.Write($"Titol: {book.title}, ");
                Console.WriteLine($"Numero Autors: {book.authors.Count}");
            }
        }

        public void Act4(string categoria)
        {
            List<Book> books = new List<Book>();
            string path = @"..\..\..\JSON\books.json";
            using (StreamReader jsonStreamRead = new StreamReader(path))
            {
                string json = jsonStreamRead.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }

            foreach (Book book in books)
            {
                if (book.categories.Contains(categoria))
                {
                    Console.WriteLine($"Titol: {book.title},");
                    Console.WriteLine($"Autors:");
                    foreach (string author in book.authors)
                    {
                        if (author != "") 
                        { 
                            Console.WriteLine(author); 
                        }
                    }
                    Console.WriteLine();
                }
            }
        }

        public void Act5(string title, string categoria)
        {
            List<Book> books = new List<Book>();
            string path = @"..\..\..\JSON\books.json";
            using (StreamReader jsonStreamRead = new StreamReader(path))
            {
                string json = jsonStreamRead.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }

            foreach (Book book in books)
            {
                if (book.title == title)
                {
                    Console.WriteLine("Categorias abans dels canvis");
                    foreach (string category in book.categories)
                    {
                        Console.WriteLine(category);
                    }
                    book.categories.Add(categoria);
                    Console.WriteLine("Categorias despres dels canvis");
                    foreach (string category in book.categories)
                    {
                        Console.WriteLine(category);
                    }
                }
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            using (StreamWriter jsonStreamWriter = File.CreateText(path))
            {
                jsonStreamWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(books, options));
            }
        }

        public void Act6(string title, string anticAutor, string nouAutor)
        {
            List<Book> books = new List<Book>();
            string path = @"..\..\..\JSON\books.json";
            using (StreamReader jsonStreamRead = new StreamReader(path))
            {
                string json = jsonStreamRead.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }

            foreach (Book book in books)
            {
                if (book.title == title)
                {
                    Console.WriteLine("Autors abans del canvi");
                    foreach (string author in book.authors)
                    {
                        Console.WriteLine(author);
                    }
                    book.authors.Remove(anticAutor);
                    book.authors.Add(nouAutor);
                    Console.WriteLine("Autors despres del canvi");
                    foreach (string author in book.authors)
                    {
                        Console.WriteLine(author);
                    }
                }
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            using (StreamWriter jsonStreamWriter = File.CreateText(path))
            {
                jsonStreamWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(books, options));
            }
        }

        public void Act7(string ISBN, int posicio, string nouAutor)
        {
            List<Book> books = new List<Book>();
            string path = @"..\..\..\JSON\books.json";
            using (StreamReader jsonStreamRead = new StreamReader(path))
            {
                string json = jsonStreamRead.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }

            foreach (Book book in books)
            {
                if (book.isbn == ISBN)
                {
                    Console.WriteLine("Autors abans del canvi");
                    foreach (string author in book.authors)
                    {
                        Console.WriteLine(author);
                    }
                    book.authors[posicio] = nouAutor;
                    Console.WriteLine("Autors despres del canvi");
                    foreach (string author in book.authors)
                    {
                        Console.WriteLine(author);
                    }
                }   
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            using (StreamWriter jsonStreamWriter = File.CreateText(path))
            {
                jsonStreamWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(books, options));
            }
        }

        public void Act8(string title, string nouAutor)
        {
            List<Book> books = new List<Book>();
            string path = @"..\..\..\JSON\books.json";
            using (StreamReader jsonStreamRead = new StreamReader(path))
            {
                string json = jsonStreamRead.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }

            foreach (Book book in books)
            {
                if (book.title == title)
                {
                    Console.WriteLine("Autors abans del canvi");
                    foreach (string author in book.authors)
                    {
                        Console.WriteLine(author);
                    }
                    book.authors.Add(nouAutor);
                    Console.WriteLine("Autors despres del canvi");
                    foreach (string author in book.authors)
                    {
                        Console.WriteLine(author);
                    }
                }
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            using (StreamWriter jsonStreamWriter = File.CreateText(path))
            {
                jsonStreamWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(books, options));
            }
        }

        public void Act9()
        {
            List<Book> books = new List<Book>();
            List<Book> bigbooks = new List<Book>();
            string path = @"..\..\..\JSON\books.json";
            string path2 = @"..\..\..\JSON\bigBooks.json";
            using (StreamReader jsonStreamRead = new StreamReader(path))
            {
                string json = jsonStreamRead.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }

            foreach (Book book in books)
            {
                if (book.pageCount > 500)
                {
                    bigbooks.Add(book);
                }
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            using (StreamWriter jsonStreamWriter = File.CreateText(path2))
            {
                jsonStreamWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(bigbooks, options));
            }
        }

        public void Act10()
        {
            List<Book> bigbooks = new List<Book>();
            string path = @"..\..\..\JSON\bigBooks.json";
            using (StreamReader jsonStreamRead = new StreamReader(path))
            {
                string json = jsonStreamRead.ReadToEnd();
                bigbooks = JsonConvert.DeserializeObject<List<Book>>(json);
            }

            foreach (Book book in bigbooks)
            {
                Console.WriteLine($"Title: {book.title}");
                Console.WriteLine("Categories: ");
                foreach (string category in book.categories)
                {
                    Console.WriteLine(category);
                }
                Console.WriteLine();
            }
        }

        public void Act11()
        {
            List<Book> books = new List<Book>();
            List<Book> notpublishbooks = new List<Book>();
            List<Book> publishbooks = new List<Book>();

            string path = @"..\..\..\JSON\books.json";
            string path2 = @"..\..\..\JSON\notPublishedBooks.json";
            using (StreamReader jsonStreamRead = new StreamReader(path))
            {
                string json = jsonStreamRead.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }

            foreach (Book book in books)
            {
                if (book.status != "PUBLISH")
                { 
                    notpublishbooks.Add(book);
                } 
                else
                {
                    publishbooks.Add(book); 
                }
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            using (StreamWriter jsonStreamWriter = File.CreateText(path))
            {
                jsonStreamWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(publishbooks, options));
            }

            using (StreamWriter jsonStreamWriter = File.CreateText(path2))
            {
                jsonStreamWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(notpublishbooks, options));
            }
        }

        public void Act12()
        {
            List<Book> notpublishbooks = new List<Book>();

            string path = @"..\..\..\JSON\notPublishedBooks.json";
            using (StreamReader jsonStreamRead = new StreamReader(path))
            {
                string json = jsonStreamRead.ReadToEnd();
                notpublishbooks = JsonConvert.DeserializeObject<List<Book>>(json);
            }

            foreach (Book book in notpublishbooks)
            {
                Console.WriteLine($"Title {book.title}, Status: {book.status}, ISBN: {book.isbn}");
            }
        }

        public void Act13()
        {
            List<NotPublishedBook> notpublishbooks = new List<NotPublishedBook>();

            string path = @"..\..\..\JSON\notPublishedBooks.json";
            using (StreamReader jsonStreamRead = new StreamReader(path))
            {
                string json = jsonStreamRead.ReadToEnd();
                notpublishbooks = JsonConvert.DeserializeObject<List<NotPublishedBook>>(json);
            }

            foreach (NotPublishedBook book in notpublishbooks)
            {
                book.Assessment = 3000;
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            using (StreamWriter jsonStreamWriter = File.CreateText(path))
            {
                jsonStreamWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(notpublishbooks, options));
            }
        }

        public void Act14()
        {
            List<NotPublishedBook2> notPublishedBooks2 = new List<NotPublishedBook2>();

            string path = @"..\..\..\JSON\notPublishedBooks.json";
            using (StreamReader jsonStreamRead = new StreamReader(path))
            {
                string json = jsonStreamRead.ReadToEnd();
                notPublishedBooks2 = JsonConvert.DeserializeObject<List<NotPublishedBook2>>(json);
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(notPublishedBooks2, options);

            Console.WriteLine(jsonString);

            using (StreamWriter jsonStreamWriter = File.CreateText(path))
            {
                jsonStreamWriter.WriteLine(System.Text.Json.JsonSerializer.Serialize(notPublishedBooks2, options));
            }
        }

        public void Act15()
        {
            // Es posible que o posi en null ja que el date es guarda amb string y no com a date
            List<Book> books = new List<Book>();
            string path = @"..\..\..\JSON\books.json";
            using (StreamReader jsonStreamRead = new StreamReader(path))
            {
                string json = jsonStreamRead.ReadToEnd();
                books = JsonConvert.DeserializeObject<List<Book>>(json);
            }

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(books, options);

            Console.WriteLine(jsonString);
        }
    }
}
