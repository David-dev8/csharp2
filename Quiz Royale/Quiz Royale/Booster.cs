using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class Booster : Item
    {
        public string Description { get; set; }
        public int Indentifier { get; set; }

        public Booster(string name, string picture, int requiredAmount, Payment payment, string description, int indentifier)
        {
            Name = name;
            Picture = picture;
            RequiredAmount = requiredAmount;
            Payment = payment;
            Description = description;
            Indentifier = indentifier;
        }
    }
}
