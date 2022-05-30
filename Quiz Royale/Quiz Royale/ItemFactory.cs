using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class ItemFactory
    {
        public Item MakeItem(string type, string name, string picture, string requiredAmount, string description = "", int indentifier = 0)
        {
            switch (type)
            {
                case "Booster":
                    return new Booster(name,picture,requiredAmount,description,indentifier);
                    break;
                case "PlayerTitle":
                    return new PlayerTitle();
                    break;
                case "ProfilePicture":
                    return new ProfilePicture();
                    break;
                case "Border":
                    return new Border();
                    break;
                default:
                    return null;
                    break;
            }
        }
    }
}
