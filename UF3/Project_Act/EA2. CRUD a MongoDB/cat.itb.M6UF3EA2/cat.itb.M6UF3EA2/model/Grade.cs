using cat.itb.M6UF3EA2.model;
using Newtonsoft.Json;

namespace cat.itb.M6UF3EA2.model
{
    [Serializable]
    public class Grade
    {
        public Date date { get; set; }
        public string grade { get; set; }
        public string score { get; set; }
    }
}
