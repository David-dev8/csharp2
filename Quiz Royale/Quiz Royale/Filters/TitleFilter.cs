using Quiz_Royale.Models.Items;

namespace Quiz_Royale.Filters
{
    /// <summary>
    /// Deze filter controleert of een bepaald item van het type spelerstitel is.
    /// </summary>
    public class TitleFilter : IItemFilter
    {
        public bool Filter(Item item)
        {
            return item is PlayerTitle;
        }
    }
}
