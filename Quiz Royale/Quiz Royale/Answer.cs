using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class Answer
    {
        public char Code { get; set; }
        public string Description { get; set; }

        public Answer(char code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}
