namespace Quiz_Royale.Models.Games
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

        /// <summary>
        /// Dit is de constructor voor het GameMode object
        /// </summary>
        /// <param name="mode">De naam van de mode als enum</param>
        /// <param name="picture">een link naar het logo van de mode als string</param>
        /// <param name="title">De naam van de mode als string</param>
        /// <param name="subtitle">Het bijschrift van de mode als string</param>
        /// <param name="description">De discriptie van de mode als string</param>
        /// <param name="released">De toegangkelijkheid van de mode, bij false is de modus niet toegankelijk, en bij true wel</param>
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
}
