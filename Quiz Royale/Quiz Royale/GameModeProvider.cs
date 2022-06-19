using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Quiz_Royale
{
    /// <summary>
    /// Deze klasse levert de verschillende gamemodi in de applicatie.
    /// </summary>
    public class GameModeProvider
    {
        /// <summary>
        /// Haalt alle verschillende gamemodi op.
        /// </summary>
        /// <returns>Een lijst met alle gamemodi.</returns>
        public static IList<GameMode> GetGameModes()
        {
            return new List<GameMode>
            {
                new GameMode(Mode.QUIZ_ROYALE, "/Assets/quizRoyale.png", "Quiz Royale", "Claim your victory as last man standing", RemoveIndent(
                        @"In this thrilling mode, you are in a continouous combat with others. Eliminate your opponents, as it is your task to 
                            survive the upcoming questions and categories. Each right answer will be rewarded, either in experience or in terms of coins. Use boosters 
                            to turn the game to your advantage.
                            
                            As questions get more and more difficult and player counts start to drop, it is up to you to take your chance and grab that 
                            elusive title and be crowned winner of Quiz Royale.")), 
                new GameMode(Mode.LEAGUE_OF_QUESTIONS, "/Assets/leagueOfQuestions.png", "League of Questions", "Take on opponents with an entire new dimension", RemoveIndent(
                        @"Coming Soon. Stay tuned for updates!"), false),
                new GameMode(Mode.TRAINING, "/Assets/trainingMode.png", "Training mode", "Tired of ending in last place?", RemoveIndent(
                        @"Coming Soon. Stay tuned for updates!"), false)
            };
        }

        /// <summary>
        /// Verwijdert indentingen in de gegeven string
        /// </summary>
        /// <param name="subject">De string waarvan je indenting weg wil halen</param>
        /// <returns>De iput string zonder indenting</returns>
        private static string RemoveIndent(string subject)
        {
            subject = subject.Replace("  ", "");
            subject = Regex.Replace(subject, @"(\w)\s*(\n|\r)\s*(\w)", "$1 $3");
            return subject;
        }
    }
}
