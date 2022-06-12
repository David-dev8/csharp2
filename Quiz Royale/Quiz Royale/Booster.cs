using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class Booster : Item
    {
        public string Description { get; set; }

        public Booster(int id, string name, string picture, int requiredAmount, Payment payment, string description)
            : base(id, name, picture, requiredAmount, payment)
        {
            Description = description;
        }
    }
}
