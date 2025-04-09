using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6UF3EA4.model
{
    [Serializable]
    public class Restaurant
    {
        public Address address { get; set; }
        public string borough { get; set; }
        public string cuisine { get; set; }
        public List<Grade> grades { get; set; }
        public string name { get; set; }
        public string restaurant_id { get; set; }

        public override string ToString()
        {
            return $"Restaurant: {name}, Cuisine: {cuisine}, Borough: {borough}, Name: {name}, Restaurant_id: {restaurant_id},\n" +
                $"Grade: {grades.ToString}";
        }
    }
}
