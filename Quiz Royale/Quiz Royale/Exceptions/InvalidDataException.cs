﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale.Exceptions
{
    /// <summary>
    /// Deze exceptie wordt opgegooid wanneer er een bad request is op server.
    /// </summary>
    public class InvalidDataException: Exception
    {
        public InvalidDataException(): base("There is something wrong with the data")
        {
        }
    }
}
