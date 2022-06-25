using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Quiz_Royale.Models
{
    /// <summary>
    /// Deze klasse vertegenwoordigt een categorie.
    /// </summary>
    public class Category
    {
        public string Picture { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        /// <summary>
        /// Creëert een categorie met de gegeven eigenschappen.
        /// </summary>
        /// <param name="name">De naam van de categorie.</param>
        /// <param name="picture">De afbeelding van de categorie.</param>
        /// <param name="color">De kleur van de categorie.</param>
        public Category(string name, string picture, string color)
        {
            Name = name;
            Picture = picture;
            Color = color;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Category otherCategory = (Category)obj;

            return Name.Equals(otherCategory.Name) && Picture.Equals(otherCategory.Picture) && Color.Equals(otherCategory.Color);
        }

        public override int GetHashCode()
        {
            return 1000 * Name.GetHashCode() + 100 * Picture.GetHashCode() + Color.GetHashCode();
        }
    }
}
