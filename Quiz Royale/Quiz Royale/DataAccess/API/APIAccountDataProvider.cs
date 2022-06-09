using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class APIAccountDataProvider : IAccountDataProvider
    {
        public IList<Badge> GetBadges()
        {
            throw new NotImplementedException();
        }

        public IDictionary<Category, float> GetCategoryMastery()
        {
            throw new NotImplementedException();
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
