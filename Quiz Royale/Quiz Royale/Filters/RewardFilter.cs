using Quiz_Royale.Models.Items;

namespace Quiz_Royale.Filters
{
    /// <summary>
    /// Deze filter controleert of een bepaald item verkrijgbaar is met XP.
    /// </summary>
    public class RewardFilter : IItemFilter
    {
        public bool Filter(Item item)
        {
            return item.Payment == Payment.XP;
        }
    }
}
