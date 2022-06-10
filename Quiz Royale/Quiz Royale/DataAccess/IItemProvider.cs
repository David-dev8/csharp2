using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale.DataAccess
{
    public interface IItemProvider
    {
        public Task<IList<Item>> GetItems();
    }
}
