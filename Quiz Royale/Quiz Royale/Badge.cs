using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class Badge
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool IsEarned { get; set; }

        public Badge(string name, string description, string picture, bool isEarned)
        {
            Name = name;
            Description = description;
            Picture = picture;
            IsEarned = isEarned;
        }
    }
}
