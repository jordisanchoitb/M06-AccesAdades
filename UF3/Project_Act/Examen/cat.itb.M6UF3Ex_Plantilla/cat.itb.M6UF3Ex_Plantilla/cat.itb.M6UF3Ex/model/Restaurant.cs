using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace cat.itb.M6UF3Ex.model
{
    [Serializable]
    public class Restaurant
    {
        //ATTRIBUTES
        public Address address { get; set; }
        public string borough { get; set; }
        public string cuisine { get; set; }
        public List<Grade> grades { get; set; }
        public string name { get; set; }
        public string restaurant_id { get; set; }


        //ToSTRING
        public override string ToString()
        {
            return "  Address: " + address + "  Borough: " + borough + "   Cuisine: " + cuisine + "   Name: " + name +
                   "   Grades: " + grades;
        }

    }
}