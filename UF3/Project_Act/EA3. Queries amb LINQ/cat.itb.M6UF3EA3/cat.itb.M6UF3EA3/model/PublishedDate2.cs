using Newtonsoft.Json;

namespace cat.itb.M6UF3EA3.model
{
    public class PublishedDate2
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
    
