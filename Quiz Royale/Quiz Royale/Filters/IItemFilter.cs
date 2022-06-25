using Quiz_Royale.Models.Items;

namespace Quiz_Royale.Filters
{
    /// <summary>
    /// Deze Interface geeft de verplichte methodes aan voor het implementeren van een bepaald filter.
    /// </summary>
    public interface IItemFilter
    {
        /// <summary>
        /// Controleert of een item van een bepaald itemtype is.
        /// </summary>
        /// <param name="item">Het item dat gecontroleerd moet worden.</param>
        /// <returns>True wanneer het item van het juiste type is, anders false.</returns>
        bool Filter(Item item);
    }
}
