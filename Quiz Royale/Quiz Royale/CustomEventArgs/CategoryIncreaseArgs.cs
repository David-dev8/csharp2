using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class CategoryIncreaseArgs : EventArgs
    {
        public string CatId { get; }

        public CategoryIncreaseArgs(string catId)
        {
            CatId = catId;
        }
    }
}
