using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class Mastery
    {
        public Category Category { get; set; }

        public float SuccesRate { get; set; }

        public Mastery(Category category, float succesRate)
        {
            Category = category;
            SuccesRate = succesRate;
        }
    }
}
