using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    class Booster : Item
    {
        public string Description { get; set; }
        public int Indentifier { get; set; }

        public Booster(string name, string picture, string requiredAmount, string description, int indentifier)
        {
            Name = name;
            Picture = picture;
            RequiredAmount = requiredAmount;
            Description = description;
            Indentifier = indentifier;
        }

    }
}
