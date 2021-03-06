using Quiz_Royale.Models.Items;

namespace Quiz_Royale.Filters
{
    /// <summary>
    /// Deze filter controleert of een bepaald item van het type profielfoto is.
    /// </summary>
    public class ProfilePictureFilter : IItemFilter
    {
        public bool Filter(Item item)
        {
            return item is ProfilePicture;
        }
    }
}
