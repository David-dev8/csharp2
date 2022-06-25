using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Quiz_Royale.Models.Games
{
    /// <summary>
    /// Deze klasse vertegenwoordigt een vraag die wordt gebruikt voor de game.
    /// </summary>
    public class Question
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public IList<Answer> Possibilities { get; set; }

        public Category Category { get; set; }

        /// <summary>
        /// Creëert een vraag met de mogelijke antwoorden van een bepaalde categorie.
        /// </summary>
        /// <param name="id">De id van de vraag.</param>
        /// <param name="content">De vraag die wordt gesteld aan de gebruiker.</param>
        /// <param name="possibilities">De mogelijke antwoorden op de vraag.</param>
        /// <param name="category">De categorie van de vraag.</param>
        public Question(int id, string content, IList<Answer> possibilities, Category category)
        {
            Id = id;
            Content = content;
            Possibilities = new ObservableCollection<Answer>(possibilities);
            Category = category;
        }
    }
}
