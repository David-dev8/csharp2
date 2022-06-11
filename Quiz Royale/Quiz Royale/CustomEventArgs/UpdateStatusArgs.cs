using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class UpdateStatusArgs : EventArgs
    {
        public string Message { get; }

        public UpdateStatusArgs(string message)
        {
            Message = message;
        }
    }
}
