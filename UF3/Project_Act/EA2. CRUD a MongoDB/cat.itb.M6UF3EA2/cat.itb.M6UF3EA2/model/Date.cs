using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cat.itb.M6UF3EA2.model
{
    [Serializable]
    public class Date
    {
        [JsonProperty("$date")]
        public long date { get; set; }
    }
}
