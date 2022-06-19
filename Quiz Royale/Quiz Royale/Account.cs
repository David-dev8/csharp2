using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Quiz_Royale
{
    /// <summary>
    /// Deze klasse vertegenwoordigt een account van een gebruiker op de applicatie.
    /// </summary>
    public class Account: Observable
    {
        private const int NEEDED_XP_TO_REACH_NEXT_LEVEL = 1000;

        private int _amountOfCoins;
        private int _currentXP;

        public string Username { get; set; }

        /// <summary>
        /// Deze property geeft toegang tot de hoeveelheid coins die de gebruiker heeft.
        /// </summary>
		[JsonPropertyName("coins")]
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

        /// <summary>
        /// Deze property geeft toegang tot de hoeveelheid XP die de gebruiker heeft.
        /// </summary>
		[JsonPropertyName("xp")]
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

        [JsonPropertyName("AmountOfWins")]
        public int TotalWins { get; set; }

        public Inventory Inventory { get; set; }

        /// <summary>
        /// Deze property geeft toegang tot het huidige level van de gebruiker.
        /// </summary>
        public int Level
        {
            get
            {
                return CurrentXP / NEEDED_XP_TO_REACH_NEXT_LEVEL;
            }
        }

        /// <summary>
        /// Deze property geeft toegang tot het aantal xp dat nog nodig is om het volgende level te bereiken.
        /// </summary>
        public int XPToNextLevel
        {
            get
            {
                return NEEDED_XP_TO_REACH_NEXT_LEVEL - CurrentXP % NEEDED_XP_TO_REACH_NEXT_LEVEL;
            }
        }

        /// <summary>
        /// Deze property geeft toegang tot de progressie van het level die door de gebruiker is geboekt.
        /// </summary>
        public int PercentOfLevelProgress
        {
            get
            {
                return 100 - (int) (XPToNextLevel / (double) NEEDED_XP_TO_REACH_NEXT_LEVEL * 100);
            }
        }

        /// <summary>
        /// Creëert een account van een gebruiker op de applicatie.
        /// </summary>
        /// <param name="username">De gebruikersnaam van het account.</param>
        /// <param name="amountOfCoins">De hoeveelheid coins die een gebruiker heeft.</param>
        /// <param name="currentXP">De hoeveelheid XP die een gebruiker heeft.</param>
        /// <param name="totalWins">Het aantal overwinningen dat de gebruiker heeft behaald.</param>
        public Account(string username, int amountOfCoins, int currentXP, int totalWins)
        {
            Username = username;
            AmountOfCoins = amountOfCoins;
            CurrentXP = currentXP;
            TotalWins = totalWins;
            Inventory = new Inventory();
        }
    }
}
