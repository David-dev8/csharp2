﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class ResultArgs : EventArgs
    {
        public bool Result { get; }

        public ResultArgs(bool result)
        { 
            Result = result;
        }
    }
}
