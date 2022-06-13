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
            return _apiHandler.FetchAll<Badge>("/PlayerData/Badges");
        }

        public Task<IList<CategoryMastery>> GetCategoryMastery()
        {
            return _apiHandler.FetchAll<CategoryMastery>("/PlayerData/Mastery");
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
