using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale.Filters
{
    public class FilterFactory
    {
        public IItemFilter GetFilter(string filter)
        {
            return filter switch
            {
                "Booster" => new BoosterFilter(),
                "Border" => new BorderFilter(),
                "Buy" => new BuyFilter(),
                "ProfilePicture" => new ProfilePictureFilter(),
                "Reward" => new RewardFilter(),
                "Title" => new TitleFilter(),
                _ => null,
            };
        }
    }
}
