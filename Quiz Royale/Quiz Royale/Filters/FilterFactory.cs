using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale.Filters
{
    /// <summary>
    /// Deze klasse zorgt ervoor dat er verschillende type filters kunnen worden gemaakt.
    /// </summary>
    public class FilterFactory
    {
        /// <summary>
        /// Maakt een filter van het gegeven type.
        /// </summary>
        /// <param name="filter">Het type filter waarop gefilterd moet worden.</param>
        /// <returns>Het filter van het gegeven type.</returns>
        public IItemFilter GetFilter(string filter) // TODO met enum???
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

        // todo return null of except?
    }
}
