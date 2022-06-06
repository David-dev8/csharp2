using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Quiz_Royale
{
    public class Category
    {
        public string Picture { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public Category(string name, string picture, string color)
        {
            Name = name;
            Picture = picture;
            Color = color;
        }
    }
}
