using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Quiz_Royale
{
    /// <summary>
    /// Deze klasse vertegenwoordigt de rang en de divisie waarin een gebruiker zit.
    /// </summary>
    public class Rank
    {
        public string Picture { get; set; }

        [JsonPropertyName("rank")]
        public string Name { get; set; }

        public string Color { get; set; }

        [JsonPropertyName("number")]
        public int Division { get; set; }

        public double UpperBound { get; set; }

        /// <summary>
        /// Creëert een rang waarin gebruikers zitten.
        /// </summary>
        /// <param name="picture">De afbeelding van de rang.</param>
        /// <param name="name">De naam van de rang.</param>
        /// <param name="colour">De kleur van de rang als hex-code</param>
        /// <param name="division">De nummer van de divisie waarin de gebruiker zit.</param>
        /// <param name="upperBound">Een percentage van 0 tot 100 procent dat aangeeft tot hoeveel van de totale spelers een speler 
        /// moet horen om bij deze rang te horen.</param>
        public Rank(string picture, string name, string color, int division, double upperBound)
        {
            Picture = picture;
            Name = name;
            Color = color;
            Division = division;
            UpperBound = upperBound;
        }
     }
}
