using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class CategoryMastery
    {
        public Category Category { get; set; }
        
        public double Mastery { get; set; }

        public CategoryMastery(Category category, double mastery)
        {
            Category = category;
            Mastery = mastery;
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

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return 1000 * Category.GetHashCode() + Mastery.GetHashCode();
        }
    }
}
