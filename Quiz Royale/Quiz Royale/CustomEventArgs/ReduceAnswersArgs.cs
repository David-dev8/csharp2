using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class ReduceAnswersArgs: EventArgs
    {
        public IList<Answer> WrongAnswers { get; }

        public ReduceAnswersArgs(IList<Answer> wrongAnswers)
        {
            WrongAnswers = wrongAnswers;
        }
    }
}
