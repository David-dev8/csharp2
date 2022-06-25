using System;

namespace Quiz_Royale.Exceptions
{
    /// <summary>
    /// Deze exceptie kan worden opgegooid wanneer een resource niet kan worden gevonden.
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("The requested resource is not found")
        {
        }
    }
}
