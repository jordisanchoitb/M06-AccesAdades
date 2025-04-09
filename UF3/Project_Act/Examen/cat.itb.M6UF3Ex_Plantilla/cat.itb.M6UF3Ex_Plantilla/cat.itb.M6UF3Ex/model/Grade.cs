using System;

namespace cat.itb.M6UF3Ex.model
{
    [Serializable]
    public class Grade
    {
        //ATTRIBUTES
        public Date date { get; set; }
        public string grade { get; set; }
        public int score { get; set; }
    
        //ToSTRING
        public override string ToString()
        {
            return "Date: " + date + "  Grade: " + grade + "   Score: " + score;
        }
    
    }
}