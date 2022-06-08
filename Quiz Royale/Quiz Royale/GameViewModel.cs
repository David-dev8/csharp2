using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class GameViewModel : BaseViewModel
    {
        public Game Game { get; set; }

        public GameViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            var gameFactory = new GameFactory();
            Game = gameFactory.CreateGame("QuizRoyale");
        }
    }
}
