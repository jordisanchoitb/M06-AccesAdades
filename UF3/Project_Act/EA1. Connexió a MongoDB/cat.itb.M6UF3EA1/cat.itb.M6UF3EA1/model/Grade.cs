using Newtonsoft.Json;

namespace cat.itb.M6UF3EA1.model
{
    [Serializable]
    public class Grade
    {
        [JsonProperty("$date")]
        public ulong date { get; set; }
        public string grade { get; set; }
        public string score { get; set; }
    }
}
