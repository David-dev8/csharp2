using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public interface IInventoryMutator
    {
        public Task EquipItem(Item item);

        public Task ObtainItem(Item item);
    }
}
