using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class ProfilePicture : Item 
    {
        public ProfilePicture(int id, string name, string picture, int requiredAmount, Payment payment)
            : base(id, name, picture, requiredAmount, payment)
        {
        }
    }
}
