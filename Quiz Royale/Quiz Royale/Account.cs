using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    class Account
    {
        public string Username { get; set; }
        public int AmountOfCoins { get; set; }
        public int CurrentXP { get; set; }
        public int TotalWins { get; set; }
        public Inventory Inventory { get; set; }

        public int Level 
        {
            get 
            { 
                return 0; 
            } 
        }

        public void getXPToNextlever()
        {

        }

        public Account(string username, int amountOfCoins, int currentXP, int totalWins /*Inventory inventory*/)
        {
            Username = username;
            AmountOfCoins = amountOfCoins;
            CurrentXP = currentXP;
            TotalWins = totalWins;
            //Inventory = inventory;
        }
    }
}
