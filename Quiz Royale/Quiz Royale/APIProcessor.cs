using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public abstract class APIProcessor
    {
        protected APIHandler _apiHandler;

        public APIProcessor()
        {
            _apiHandler = new APIHandler();
        }
    }
}
