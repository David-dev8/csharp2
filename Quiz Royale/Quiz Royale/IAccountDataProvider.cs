using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    interface IAccountDataProvider
    {
        Rank GetRank();
        IList<Result> GetResults();
        IDictionary<Category, float> getCategoryMastery();
        IList<Badge> GetBadges();
    }
}