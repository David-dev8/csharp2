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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Category otherCategory = (Category)obj;

            return Name.Equals(otherCategory.Name) && Picture.Equals(otherCategory.Picture) && Color.Equals(otherCategory.Color);
        }

        public override int GetHashCode()
        {
            return 1000 * Name.GetHashCode() + 100 * Picture.GetHashCode() + Color.GetHashCode();
        }
    }
}
