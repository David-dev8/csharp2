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

        private double _mastery;

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
