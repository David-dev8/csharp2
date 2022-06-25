namespace Quiz_Royale.Models.User
{
    /// <summary>
    /// Deze klasse vertegenwoordigt een badge die de gebruiker kan verdienen tijdens het spelen.
    /// </summary>
    public class Badge
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public bool IsEarned { get; set; }

        /// <summary>
        /// Creëert een badge die een gebruiker kan verdienen.
        /// </summary>
        /// <param name="name">De naam van de badge.</param>
        /// <param name="description">De beschrijving van de badge om deze te behalen.</param>
        /// <param name="picture">De afbeelding van de badge.</param>
        /// <param name="isEarned">Geeft aan of de badge al verdiend is.</param>
        public Badge(string name, string description, string picture, bool isEarned)
        {
            Name = name;
            Description = description;
            Picture = picture;
            IsEarned = isEarned;
        }
    }
}
