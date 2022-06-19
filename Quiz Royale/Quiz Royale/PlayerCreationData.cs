using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class PlayerCreationData
    {
        public string Username { get; set; }

        public PlayerCreationData(string username)
        {
            Username = username;
        }
    }
}
