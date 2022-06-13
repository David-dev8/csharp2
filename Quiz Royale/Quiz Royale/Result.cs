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
                _time = DateTime.Parse(value);
            }
        }
        public int Position { get; set; }

        public Mode Mode { get; set; }

        public string ModeString
        {
            get
            {
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Mode.ToString().ToLower().Replace('_', ' '));
            }
        }

        public Result(string time, int position, Mode mode)
        {
            Time = time;
            Position = position;
            Mode = mode;
        }
    }
}
