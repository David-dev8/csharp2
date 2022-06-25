using System;

namespace Quiz_Royale.Exceptions
{
    /// <summary>
    /// Deze exceptie wordt opgegooid wanneer er iets is misgegaan op de server.
    /// </summary>
    public class InternalErrorException: Exception
    {
        public InternalErrorException(): base("Something went wrong in the processing of the action")
        {
        }
    }
}
