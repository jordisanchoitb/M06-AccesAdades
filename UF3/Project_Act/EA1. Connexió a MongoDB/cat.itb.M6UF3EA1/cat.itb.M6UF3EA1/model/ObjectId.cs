using Newtonsoft.Json;

namespace cat.itb.M6UF3EA1.model
{
    public class ObjectId
    {
        [JsonProperty("$oid")]
        public string oid { get; set; }
    }
}
