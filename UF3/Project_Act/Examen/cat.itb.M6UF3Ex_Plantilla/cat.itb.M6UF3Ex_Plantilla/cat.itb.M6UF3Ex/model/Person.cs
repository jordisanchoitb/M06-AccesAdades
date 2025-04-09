﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace cat.itb.M6UF3Ex.model

{
    [Serializable]
    public class Person
    {
        public bool isActive { get; set; }
        public string balance { get; set; }
        public string picture { get; set; }
        public int age { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string about { get; set; }
        public string registered { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string[] tags { get; set; }
        public List<Friend> friends { get; set; }
        public string gender { get; set; }
        public string randomArrayItem { get; set; }
    }
}
