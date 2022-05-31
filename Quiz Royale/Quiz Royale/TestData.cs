using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    class TestData : IAccountDataProvider
    {
        public IList<Badge> GetBadges()
        {
            return new List<Badge>
            {
                new Badge("badge name","badge description", "badge picture")
            };
        }

        public Rank GetRank()
        {
            throw new NotImplementedException();
        }

        public IList<Mastery> GetCategoryMastery()
        {
            return new List<Mastery>
            {
                new Mastery(new Category("Movie icon","Movies","Red"),2)
            };
        }

        public IList<Result> GetResults()
        {
            return new List<Result>
            {
                new Result(10,10,"testMode")
            };
        }
    }
}
