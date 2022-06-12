using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class Account: Observable
    {
        private const int NEEDED_XP_TO_REACH_NEXT_LEVEL = 1000;

        public string Username { get; set; }

        private int _amountOfCoins;

        public int AmountOfCoins
        {
            get
            {
                return _amountOfCoins;
            }
            set
            {
                _amountOfCoins = value;
                OnPropertyChanged();
            }
        }


        private int _currentXP;

        public int CurrentXP
        {
            get
            {
                return _currentXP;
            }
            set
            {
                _currentXP = value;
                OnPropertyChanged();
            }
        }

        public int TotalWins { get; set; }
        public Inventory Inventory { get; set; }

        public int Level
        {
            get
            {
                return CurrentXP / NEEDED_XP_TO_REACH_NEXT_LEVEL;
            }
        }

        public int XPToNextLevel
        {
            get
            {
                return NEEDED_XP_TO_REACH_NEXT_LEVEL - CurrentXP % NEEDED_XP_TO_REACH_NEXT_LEVEL;
            }
        }

        public int PercentOfLevelProgress
        {
            get
            {
                return 100 - (int) (XPToNextLevel / (double) NEEDED_XP_TO_REACH_NEXT_LEVEL * 100);
            }
        }

        public Account(string username, int amountOfCoins, int currentXP, int totalWins, Inventory inventory)
        {
            Username = username;
            AmountOfCoins = amountOfCoins;
            CurrentXP = currentXP;
            TotalWins = totalWins;
            Inventory = inventory;
        }

        public int GetLevel()
        {
            return 0;
        }

        public void GetXPToNextlevel()
        {

        }
    }
}
