using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public int RequiredAmount { get; set; }
        public Payment Payment { get; set; }

        public Item(int id, string name, string picture, int requiredAmount, Payment payment)
        {
            Id = id;
            Name = name;
            Picture = picture;
            RequiredAmount = requiredAmount;
            Payment = payment;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Item otherItem = (Item) obj;

            return Id == otherItem.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
