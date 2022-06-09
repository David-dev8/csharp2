using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class Rank
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Colour { get; set; }
        public int Division { get; set; }

        public Rank(string picture, string name, string colour, int division)
        {
            Picture = picture;
            Name = name;
            Colour = colour;
            Division = division;
        }
     }
}
