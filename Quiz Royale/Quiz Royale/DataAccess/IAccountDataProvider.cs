using Quiz_Royale.Models;
using Quiz_Royale.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz_Royale.DataAccess
{
    /// <summary>
    /// Deze interface geeft de verplichte methodes aan om de juiste implementatie van een klasse te maken die de 
    /// gegevens van een account levert.
    /// </summary>
    public interface IAccountDataProvider
    {
        /// <summary>
        /// Haalt de rang op van de huidige gebruiker.
        /// </summary>
        /// <returns>De huidige rang van de gebruiker</returns>
        Task<Rank> GetRank();

        /// <summary>
        /// Haalt de resultaten op van de gebruiker.
        /// </summary>
        /// <returns>Een lijst met resultaten.</returns>
        Task<IList<Result>> GetResults();

        /// <summary>
        ///  Haalt de categorie mastery op van de gebruiker.
        /// </summary>
        /// <returns>De categorie mastery van de gebruiker.</returns>
        Task<IList<CategoryIntensity>> GetCategoryMastery();

        /// <summary>
        /// Haalt alle badges op die de gebruiker heeft behaald tijdens het spelen van de game.
        /// </summary>
        /// <returns>Een lijst van alle badges.</returns>
        Task<IList<Badge>> GetBadges();
    }
}