namespace Quiz_Royale.Models.Games
{
    /// <summary>
    /// Deze klasse vertegenwoordigt het antwoord op een vraag.
    /// </summary>
    public class Answer
    {
        public char Code { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Creëert een antwoord voor een bepaalde vraag.
        /// </summary>
        /// <param name="code">De letter van het antwoord.</param>
        /// <param name="description">Het antwoord op de vraag.</param>
        public Answer(char code, string description)
        {
            Code = code;
            Description = description;
        }

        public override bool Equals(object obj)
        {
            if(obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Answer otherAnswer = (Answer)obj;

            return Code.Equals(otherAnswer.Code);
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
    }
}
