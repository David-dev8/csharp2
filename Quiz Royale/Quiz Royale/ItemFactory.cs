﻿using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class ItemFactory
    {
        public Item MakeItem(int id, string type, string name, string picture, int requiredAmount, Payment payment, 
            string description = "", int indentifier = 0)
        {
            return type switch
            {
                "Booster" => new Booster(id, name, picture, requiredAmount, payment, description, indentifier),
                "PlayerTitle" => new PlayerTitle(id, name, picture, requiredAmount, payment),
                "ProfilePicture" => new ProfilePicture(id, name, picture, requiredAmount, payment),
                "Border" => new Border(id, name, picture, requiredAmount, payment),
                _ => null,
            };
        }
    }
}
