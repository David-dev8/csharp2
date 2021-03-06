using Quiz_Royale.Models.Games;
using System;

namespace Quiz_Royale.CustomEventArgs
{
    /// <summary>
    /// Deze klasse bevat informatie voor wanneer er een nieuwe vraag in een spel is gekozen.
    /// </summary>
    public class NewQuestionArgs : EventArgs
    {
        public Question Question { get; }

        /// <summary>
        /// Creëert NewQuestionArgs op basis van de gegeven vraag.
        /// </summary>
        /// <param name="question">De nieuwe vraag.</param>
        public NewQuestionArgs(Question question)
        {
            Question = question;
        }
    }
}
