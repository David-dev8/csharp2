using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    class Result
    {
        public DateTime Time { get; set; }
        public int AnswersRight { get; set; }
        public int Postion { get; set; }
        public string Mode { get; set; }

        public Result(DateTime time, int answersRight, int postion, string mode)
        {
            Time = time;
            AnswersRight = answersRight;
            Postion = postion;
            Mode = mode;
        }
    }
}
