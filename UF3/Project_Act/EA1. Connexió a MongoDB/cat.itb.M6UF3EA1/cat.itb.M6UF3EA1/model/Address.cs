using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6UF3EA1.model
{
    [Serializable]
    public class Address
    {
        public string building { get; set; }
        public string street { get; set; }
        public string zipcode { get; set; }
        public List<double> coord { get; set; }
    }
}
