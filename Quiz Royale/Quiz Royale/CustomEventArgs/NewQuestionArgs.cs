using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class NewQuestionArgs : EventArgs
    {
        public Question Question { get; }

        public NewQuestionArgs(Question question)
        { 
            Question = question;
        }
    }
}
