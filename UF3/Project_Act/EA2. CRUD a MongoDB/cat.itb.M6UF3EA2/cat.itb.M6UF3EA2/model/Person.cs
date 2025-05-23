﻿using System;
using System.Collections.Generic;

namespace cat.itb.M6UF3EA2.model

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
        public List<string> tags { get; set; }
        public List<Friend> friends { get; set; }
        public string gender { get; set; }
        public string randomArrayItem { get; set; }
    }
}
