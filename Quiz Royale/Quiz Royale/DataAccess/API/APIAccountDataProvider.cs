using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class APIAccountDataProvider : APIProcessor, IAccountDataProvider
    {
        public Task<IList<Badge>> GetBadges()
        {
            return new List<Badge>
            {
                new Badge("Winner","Win 50 times in quiz royale","/Assets/testBadge.png"),
                new Badge("On Fire!","Description","/Assets/testBadge.png"),
                new Badge("Badge3","Description","/Assets/testBadge.png"),
                new Badge("Badge4","Description","/Assets/testBadge.png"),
                new Badge("Badge4","Description","/Assets/testBadge.png"),
                new Badge("Badge4","Description","/Assets/testBadge.png"),
                new Badge("Badge4","Description","/Assets/testBadge.png"),
                new Badge("Badge4","Description","/Assets/testBadge.png"),
                new Badge("Badge4","Description","/Assets/testBadge.png"),
                new Badge("Badge4","Description","/Assets/testBadge.png"),
                new Badge("Badge4","Description","/Assets/testBadge.png"),
            };
        }

        public Task<IList<CategoryMastery>> GetCategoryMastery()
        {
            return new List<Mastery>
            {
                new Mastery(new Category("Wetenschap", "/Assets/testCategory.png", "#FFFFFF"), 100),
                new Mastery(new Category("Wetenschap", "/Assets/testCategory.png", "#b80c0c"), 100),
                new Mastery(new Category("Wetenschap", "/Assets/testCategory.png", "#FFFFFF"), 100),
                new Mastery(new Category("Wetenschap", "/Assets/testCategory.png", "#FFFFFF"), 100),
                new Mastery(new Category("Wetenschap", "/Assets/testCategory.png", "#4fb80c"), 100),
                new Mastery(new Category("Wetenschap", "/Assets/testCategory.png", "#FFFFFF"), 100),
                new Mastery(new Category("Wetenschap", "/Assets/testCategory.png", "#FFFFFF"), 100)
            };
        }

        public Task<Rank> GetRank()
        {
            return _apiHandler.Fetch<Rank>("/PlayerData/Rank");
        }

        public Task<IList<Result>> GetResults()
        {
            return _apiHandler.FetchAll<Result>("/PlayerData/Result");
        }
    }
}
