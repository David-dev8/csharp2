using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    class Answer
    {
        public char Id { get; set; }
        public string Description { get; set; }

        public Answer(char id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
