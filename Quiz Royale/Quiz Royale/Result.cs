using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Quiz_Royale
{
    public class Result
    {
        private DateTime _time;
        public string Time
        {
            get
            {
                return _time.ToString("dd-MM-yyyy hh:mm");
            }
            set
            {
                DateTime.Parse(value);
            }
        }
        public int AnswersRight { get; set; }
        public int Position { get; set; }
        public string Mode { get; set; }

        public Result(string time, int answersRight, int position, string mode)
        {
            Time = time;
            AnswersRight = answersRight;
            Position = position;
            Mode = mode;
        }
    }
}
