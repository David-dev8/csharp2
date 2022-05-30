using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public interface IAccountDataProvider
    {
        Rank GetRank();
        IList<Result> GetResults();
        IDictionary<Category, float> GetCategoryMastery();
        IList<Badge> GetBadges();
    }
}