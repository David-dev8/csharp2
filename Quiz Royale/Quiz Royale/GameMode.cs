using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    /// <summary>
    /// Deze klasse vertegenwoordigt een gamemodus in het spel.
    /// </summary>
    public class GameMode
    {
        public string Picture { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Description { get; set; }

        public Mode Mode { get; set; }

        public bool Released { get; set; }
        
        // TODO comment 
        public GameMode(Mode mode, string picture, string title, string subtitle, string description, bool released = true)
        {
            Picture = picture;
            Title = title;
            Subtitle = subtitle;
            Description = description;
            Mode = mode;
            Released = released;
        }
    }

    /// <summary>
    /// Deze enum vertegenwoordigd de verschillende gamemodi van de applicatie.
    /// </summary>
    public enum Mode // TODO moet dit in een apart bestand?
    {
        QUIZ_ROYALE,
        LEAGUE_OF_QUESTIONS,
        TRAINING
    }
}
