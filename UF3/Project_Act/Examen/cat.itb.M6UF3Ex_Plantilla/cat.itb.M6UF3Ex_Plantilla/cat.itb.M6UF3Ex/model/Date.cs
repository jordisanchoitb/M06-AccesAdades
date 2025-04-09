using System;
using Newtonsoft.Json;

namespace cat.itb.M6UF3Ex.model
{
    [Serializable]
    public class Date
    {
        [JsonProperty("$date")]
        public long date { get; set; }
    }
}