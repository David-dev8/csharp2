using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class APIAccountDataProvider : IAccountDataProvider
    {
        public IList<Badge> GetBadges()
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

        public IList<Mastery> GetCategoryMastery()
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

        public Rank GetRank()
        {
            return new Rank("/Assets/testDivision.png", "Master Of Quizes", "#7D1DA4", 5);
        }

        public IList<Result> GetResults()
        {
            var results = new List<Result>();
            results.Add(new Result("5/1/2008 8:30:52", 10, 2, "Quiz Royale"));
            results.Add(new Result("5/1/2008 8:30:52", 9, 2, "Quiz Royale"));
            results.Add(new Result("5/1/2008 8:30:52", 8, 2, "Quiz Royale"));
            results.Add(new Result("5/1/2008 8:30:52", 7, 2, "Quiz Royale"));
            results.Add(new Result("5/1/2008 8:30:52", 6, 2, "Quiz Royale"));
            results.Add(new Result("5/1/2008 8:30:52", 5, 2, "Quiz Royale"));
            results.Add(new Result("5/1/2008 8:30:52", 4, 2, "Quiz Royale"));
            results.Add(new Result("5/1/2008 8:30:52", 3, 2, "Quiz Royale"));
            results.Add(new Result("5/1/2008 8:30:52", 2, 2, "Quiz Royale"));
            results.Add(new Result("5/1/2008 8:30:52", 1, 2, "Quiz Royale"));
            results.Add(new Result("5/1/2008 8:30:52", 0, 2, "Quiz Royale"));
            results.Add(new Result("5/1/2008 8:30:52", 11, 2, "Quiz Royale"));
            results.Add(new Result("5/1/2008 8:30:52", 12, 2, "Quiz Royale"));
            results.Add(new Result("5/1/2008 8:30:52", 13, 2, "Quiz Royale"));
            results.Add(new Result("5/1/2008 8:30:52", 14, 2, "Quiz Royale"));
            return results;
        }
    }
}
