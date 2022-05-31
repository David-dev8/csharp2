using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    interface IAccountDataProvider
    {
        Rank GetRank();
        IList<Result> GetResults();
        IList<Mastery> GetCategoryMastery();
        IList<Badge> GetBadges();
    }
}