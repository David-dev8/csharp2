using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    /// <summary>
    /// Deze klasse vertegenwoordigt een mastery van een bepaalde categorie.
    /// </summary>
    public class CategoryMastery
    {
        private double _mastery;

        public Category Category { get; set; }

        /// <summary>
        /// Deze property geeft toegang tot de mastery van een bepaalde categorie.
        /// </summary>
        public double Mastery
        {
            get 
            {
                return Math.Round(_mastery, 3);
            }
            set 
            { 
                _mastery = value; 
            }
        }


        /// <summary>
        /// Creëert een mastery van een gegeven categorie.
        /// </summary>
        /// <param name="category">De categorie waarvan vragen zijn beantwoord.</param>
        /// <param name="mastery">Het percentage van goede antwoorden ten opzichte van alle vragen.</param>
        public CategoryMastery(Category category, double mastery)
        {
            Category = category;
            _mastery = mastery;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            CategoryMastery otherMastery = (CategoryMastery) obj;

            return Category.Name.Equals(otherMastery.Category.Name);
        }

        public override int GetHashCode()
        {
            return 1000 * Category.GetHashCode() + Mastery.GetHashCode();
        }
    }
}
