using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public interface IAccountDataProvider
    {
        Task<Rank> GetRank();
        Task<IList<Result>> GetResults();
        Task<IList<CategoryMastery>> GetCategoryMastery();
        Task<IList<Badge>> GetBadges();
    }
}