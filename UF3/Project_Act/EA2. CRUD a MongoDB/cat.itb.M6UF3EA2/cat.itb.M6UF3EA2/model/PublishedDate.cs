﻿using Newtonsoft.Json;

namespace cat.itb.M6UF3EA2.model
{
    public class PublishedDate
    {
        [JsonProperty("$date")]
        public String date { get; set; }

        public override string ToString()
        {
            return
                "PublishedDate{" +
                "$date = '" + date + '\'' +
                "}";
        }
    }
}
    
