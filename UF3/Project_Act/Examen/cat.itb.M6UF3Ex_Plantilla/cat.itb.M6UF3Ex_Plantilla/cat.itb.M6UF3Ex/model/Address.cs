using System;

namespace cat.itb.M6UF3Ex.model
{
    
    [Serializable]
    public class Address
    {
        //ATTRIBUTES
        public String building { get; set; }
        public double[] coord { get; set; }
        public string street { get; set; }
        public string zipcode { get; set; }


        private string GetCoord()
        {
            string coord = "";
            foreach (double c in this.coord)
            {
                coord += c + " ";
            }
            return coord;
        }

//ToSTRING
        public override string ToString()
        {
            return "Building: " + building + "  Coord: " + GetCoord() + "  Street: " + street + "   Zipcode: " + zipcode;
        }

    }
}