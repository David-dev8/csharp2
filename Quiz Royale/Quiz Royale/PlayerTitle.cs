﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class PlayerTitle : Item
    {
        public PlayerTitle(int id, string name, string picture, int requiredAmount, Payment payment)
            : base(id, name, picture, requiredAmount, payment)
        {
        }
    }
}
