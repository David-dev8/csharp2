using Quiz_Royale.Models.Games;
using System;
using System.Collections.Generic;

namespace Quiz_Royale.CustomEventArgs
{
    /// <summary>
    /// Deze klasse bevat informatie voor wanneer het aantal antwoordmogelijkheden verkleind wordt.
    /// </summary>
    public class ReduceAnswersArgs: EventArgs
    {
        public IList<Answer> WrongAnswers { get; }

        /// <summary>
        /// Creëert ReduceAnswersArgs met de gegeven antwoorden.
        /// </summary>
        /// <param name="wrongAnswers">Antwoorden die in ieder geval niet goed zijn.</param>
        public ReduceAnswersArgs(IList<Answer> wrongAnswers)
        {
            WrongAnswers = wrongAnswers;
        }
    }
}
