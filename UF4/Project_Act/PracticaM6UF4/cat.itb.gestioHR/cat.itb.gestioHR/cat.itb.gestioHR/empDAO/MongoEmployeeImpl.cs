﻿using System;
using System.Collections.Generic;
using cat.itb.gestioHR.connections;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace cat.itb.gestioHR.empDAO
{
   public class MongoEmployeeImpl : EmployeeDAO
   {
       
       public void DeleteAll()
       {
           var database = MongoConnection.GetDatabase("itb");
           database.DropCollection("employee");
       }
       
        public void InsertAll(List<Employee> deps)
        {
       
            DeleteAll();
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Employee>("employee");

            try
            {
               collection.InsertMany(deps);
               Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nCollection Employees inserted");
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Collection couldn't be inserted");
            }
            Console.ResetColor();
        }

        public List<Employee> SelectAll()
        {
            var database = MongoConnection.GetDatabase("itb");
            var booksCollection = database.GetCollection<Employee>("employee");

            var deps = booksCollection.AsQueryable<Employee>().ToList();

            return deps;
        }


        public Employee Select(int depId)
        {
            var database = MongoConnection.GetDatabase("itb");
                var collection = database.GetCollection<Employee>("employee");

                var dep =  collection.AsQueryable<Employee>()
                        .Where(d => d._id == depId)
                        .Single();
            return dep;
        }

        public Boolean Insert(Employee dep)
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Employee>("employee");

            Boolean bol;
            try
            {
                collection.InsertOne(dep);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Employees inserted");
                bol = true;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Collection couldn't be inserted");
                bol = false;
            }
            Console.ResetColor();
            
            return bol;
        }
        
      
        public Boolean Delete(int depId)
        {
            Boolean bol;
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Employee>("employee");

            var deleteFilter = Builders<Employee>.Filter.Eq("_id", depId);
            
            var depDeleted = collection.DeleteOne(deleteFilter);
            Console.WriteLine("Employee deleted: " + depId);
            var num = depDeleted.DeletedCount;
            if (depDeleted.DeletedCount != 0)
            {
                bol = true;
            }
            else
            {
                bol = false;
            }

            return bol;
        }

        public Boolean Update(Employee dep)
        {
            var database = MongoConnection.GetDatabase("itb");
            var collection = database.GetCollection<Employee>("employee");

            Delete(dep._id);
            Console.WriteLine("Employee updated: " + dep._id);
            return Insert(dep);
        }

   }
}