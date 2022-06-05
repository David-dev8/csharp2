using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class PlayersViewModel: BaseViewModel
    {
        public IList<Player> Players
        {
            get
            {
                return new List<Player> { 
                    new Player("t", "t", "t", "t"),
                    new Player("Harold", "Harold", "Harold", "Harold"),
                    new Player("t", "t", "t", "t"),
                    new Player("t", "t", "t", "t"),
                    new Player("Harold", "Harold", "Harold", "Harold"),
                    new Player("t", "t", "t", "t"),
                    new Player("Harold", "Harold", "Harold", "Harold"),
                    new Player("t", "t", "t", "t"),
                    new Player("t", "t", "t", "t"),
                    new Player("Harold", "Harold", "Harold", "Harold"),
                    new Player("t", "t", "t", "t"),
                    new Player("Harold", "Harold", "Harold", "Harold"),
                    new Player("t", "t", "t", "t"),
                    new Player("t", "t", "t", "t"),
                    new Player("Harold", "Harold", "Harold", "Harold"),
                    new Player("Harold", "Harold", "Harold", "Harold"),
                    new Player("t", "t", "t", "t"),
                    new Player("Harold", "Harold", "Harold", "Harold"),
                    new Player("t", "t", "t", "t"),
                    new Player("t", "t", "t", "t"),
                    new Player("Harold", "Harold", "Harold", "Harold"),
                    new Player("t", "t", "t", "t"),
                    new Player("Harold", "Harold", "Harold", "Harold"),
                    new Player("t", "t", "t", "t"),
                    new Player("t", "t", "t", "t"),
                    new Player("Harold", "Harold", "Harold", "Harold"),
                    new Player("Harold", "Harold", "Harold", "Harold"),
                    new Player("t", "t", "t", "t"),
                    new Player("Harold", "Harold", "Harold", "Harold"),
                    new Player("t", "t", "t", "t"),
                    new Player("t", "t", "t", "t"),
                    new Player("Harold", "Harold", "Harold", "Harold"),
                    new Player("t", "t", "t", "t"),
                    new Player("Harold", "Harold", "Harold", "Harold"),
                    new Player("t", "t", "t", "t"),
                    new Player("t", "t", "t", "t"),
                    new Player("Harold", "Harold", "Harold", "Harold")
                };
            }
        }

        public PlayersViewModel(NavigationStore navigationStore): base(navigationStore)
        {
        }
    }
}
