using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    class Question
    {
        public string Answer { get; set; }
        public IList<Answer> Posibilities { get; set; }
        public int Time { get; set; }
        public int category { get; set; }
    }
}
