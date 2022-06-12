using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class GameMode
    {
        public string Picture { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Description { get; set; }

        public Mode Mode { get; set; }

        // TODO gamemode toevoegen

        public GameMode(Mode mode, string picture, string title, string subtitle, string description)
        {
            Picture = picture;
            Title = title;
            Subtitle = subtitle;
            Description = description;
            Mode = mode;
        }
    }

    public enum Mode
    {
        QUIZ_ROYALE,
        LEAGUE_OF_QUESTIONS,
        TRAINING
    }
}
