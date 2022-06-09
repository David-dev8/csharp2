﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Quiz_Royale
{
    public class GameModeProvider
    {
        // todo wrm geen interface?
        public static IList<GameMode> GetGameModes()
        {
            return new List<GameMode>
            {
                new GameMode("/Assets/quizRoyale.png", "Quiz Royale", "Claim your victory as last man standing", RemoveIndent(
                        @"In this thrilling mode, you are in a continouous combat with others. Eliminate your opponents, as it is your task to 
                            survive the upcoming questions and categories. Each right answer will be rewarded, either in experience or in terms of coins. Use boosters 
                            to turn the game to your advantage.
                            
                            As questions get more and more difficult and player counts start to drop, it is up to you to take your chance and grab that 
                            elusive title and be crowned winner of Quiz Royale.")), 
                new GameMode("/Assets/leagueOfQuestions.png", "League of Questions", "Take on opponents with an entire new dimension", RemoveIndent(
                        @"Coming Soon. Stay tuned for updates!")),
                new GameMode("/Assets/trainingMode.png", "Training mode", "Tired of ending in last place?", RemoveIndent(
                        @"Coming Soon. Stay tuned for updates!"))
            };
        }

        private static string RemoveIndent(string subject)
        {
            subject = subject.Replace("  ", "");
            subject = Regex.Replace(subject, @"(\w)\s*(\n|\r)\s*(\w)", "$1 $3");
            return subject;
        }
    }
}
