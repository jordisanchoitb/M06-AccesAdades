using Newtonsoft.Json;

namespace cat.itb.M6UF3EA2.model
{
    public class ObjectId
    {
        [JsonProperty("$oid")]
        public string oid { get; set; }
    }
}
