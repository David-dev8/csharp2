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

        public CategoryMastery CurrentCategory
        {
            get
            {
                return Chances.Skip(1).First();
            }
        }

        public IList<CategoryMastery> Chances
        {
            get
            {
                return new List<CategoryMastery>
                {
                    new CategoryMastery(new Category("Nature", "/Assets/coins.png", "#F72909"), 30),
                    new CategoryMastery(new Category("Nature", "/Assets/coins.png", "#FFB436"), 15),
                    new CategoryMastery(new Category("Nature", "/Assets/coins.png", "#E6E61B"), 10),
                    new CategoryMastery(new Category("Nature", "/Assets/coins.png", "#4DAD03"), 10),
                    new CategoryMastery(new Category("Coins", "/Assets/coins.png", "#5294DF"), 20),
                    new CategoryMastery(new Category("Cat", "/Assets/coins.png", "#BD1897"), 5),
                    new CategoryMastery(new Category("h", "/Assets/coins.png", "#E867C8"), 10)
                };
            }
        }

        public PlayersViewModel(NavigationStore navigationStore): base(navigationStore)
        {
        }
    }
}
