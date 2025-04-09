using Newtonsoft.Json;
using System;

namespace cat.itb.M6UF3Ex.model
{
    [Serializable]
    public class PublishedDate
    {
        [JsonProperty("$date")]
        public string date { get; set; }
    
        public override string ToString()
        {
            return 
                "PublishedDate{" + 
                "date = '" + date + '\'' + 
                "}";
        }
    }
}