using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Quiz_Royale
{
    public class Rank
    {
        public string Picture { get; set; }
        [JsonPropertyName("rank")]
        public string Name { get; set; }
        public string Color { get; set; }
        [JsonPropertyName("number")]
        public int Division { get; set; }
        public double UpperBound { get; set; }

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
