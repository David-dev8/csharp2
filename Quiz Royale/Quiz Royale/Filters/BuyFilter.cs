using Quiz_Royale.Models.Items;

namespace Quiz_Royale.Filters
{
    /// <summary>
    /// Deze filter controleert of een bepaald item koopbaar is met coins.
    /// </summary>
    public class BuyFilter : IItemFilter
    {
        public bool Filter(Item item)
        {
            return item.Payment == Payment.COINS;
        }
    }
}
