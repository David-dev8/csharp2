namespace Quiz_Royale.Models.Games
{
    /// <summary>
    /// Deze klasse vertegenwoordigd een speler tijdens een game.
    /// </summary>
    public class Player
    {
        public string Username { get; set; }
        
        public string Title { get; set; }

        public string ProfilePicture { get; set; }

        public string Border { get; set; }

        public double AnswerTime { get; set; }

        /// <summary>
        /// Creëert een speler die een gebruiker vertegenwoordigt tijdens een game.
        /// </summary>
        /// <param name="username">De gebruikersnaam van de speler.</param>
        /// <param name="title">De actieve spelerstitel van de gebruiker.</param>
        /// <param name="profilePicture">De actieve profielpagina van de gebruiker.</param>
        /// <param name="border">De actieve border van de gebruiker.</param>
        public Player(string username, string title, string profilePicture, string border)
        {
            Username = username;
            Title = title;
            ProfilePicture = profilePicture;
            Border = border;
        }
    }
}
