using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    /// <summary>
    /// Deze klasse vertegenwoordigt een intensiteit van een bepaalde categorie.
    /// Er wordt een waarde tussen de 0 en 100 gekoppeld aan een categorie, waardoor dit een percentuele indicatie van de intensiteit geeft.
    /// </summary>
    public class CategoryIntensity
    {
        private double _intensity;

        public Category Category { get; set; }

        /// <summary>
        /// Deze property geeft toegang tot de intensiteit van een bepaalde categorie. Er wordt afgerond op tweee decimalen.
        /// </summary>
        public double Intensity
        {
            get 
            {
                return Math.Round(_intensity, 2);
            }
            set 
            {
                _intensity = value; 
            }
        }


        /// <summary>
        /// Creëert een intensiteit van een gegeven categorie.
        /// </summary>
        /// <param name="category">De categorie waarvan vragen zijn beantwoord.</param>
        /// <param name="intensity">Het percentage tussen 0 en 100 dat hoort bij de categorie.</param>
        public CategoryIntensity(Category category, double intensity)
        {
            Category = category;
            Intensity = intensity;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            CategoryIntensity otherIntensity = (CategoryIntensity) obj;

            return Category.Name.Equals(otherIntensity.Category.Name);
        }

        public override int GetHashCode()
        {
            return 1000 * Category.GetHashCode() + Intensity.GetHashCode();
        }
    }
}
