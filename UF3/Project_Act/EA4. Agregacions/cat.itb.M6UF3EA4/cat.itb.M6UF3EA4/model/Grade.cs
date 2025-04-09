using Newtonsoft.Json;

namespace cat.itb.M6UF3EA4.model
{
    [Serializable]
    public class Grade
    {
        public Date date { get; set; }
        public string grade { get; set; }
        public int score { get; set; }

        public override string ToString()
        {
            return $"Grade: {grade}, Score: {score}, Date: {date.date}";
        }
    }
}
