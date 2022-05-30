using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class Category
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Colour { get; set; }

        public Category(string picture, string name, string colour)
        {
            Picture = picture;
            Name = name;
            Colour = colour;
        }
    }
}
