using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class ProfilePicture : Item 
    {

        public ProfilePicture(string name, string picture, int requiredAmount, Payment payment)
        {
            Name = name;
            Picture = picture;
            RequiredAmount = requiredAmount;
            Payment = payment;
        }
    }
}
