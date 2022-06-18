using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Quiz_Royale
{
    /// <summary>
    /// Deze klasse vertegenwoordigt een vraag die wordt gebruikt voor de game.
    /// </summary>
    public class Question
    {
        public string Content { get; set; }

        public ObservableCollection<Answer> Possibilities { get; set; }

        public Category Category { get; set; }

        /// <summary>
        /// Creëert een vraag met de mogelijke antwoorden van een bepaalde categorie.
        /// </summary>
        /// <param name="content">De vraag die wordt gesteld aan de gebruiker.</param>
        /// <param name="possibilities">De mogelijke antwoorden op de vraag.</param>
        /// <param name="category">De categorie van de vraag.</param>
        public Question(string content, IList<Answer> possibilities, Category category)
        {
            Content = content;
            Possibilities = new ObservableCollection<Answer>(possibilities);
            Category = category;
        }
    }
}
