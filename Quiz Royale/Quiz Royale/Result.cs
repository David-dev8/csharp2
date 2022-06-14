using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Quiz_Royale
{
    /// <summary>
    /// Deze klasse vertegenwoordigt het resultaat van een spel die de gebruiker heeft gespeeld.
    /// </summary>
    public class Result
    {
        private DateTime _time;
        
        public int Position { get; set; }
        
        /// <summary>
        /// Deze property geeft toegang tot de datum en tijd waarop de game is gespeeld.
        /// </summary>
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

        public Mode Mode { get; set; }

        /// <summary>
        /// Deze property geeft toegang tot de naam van de modus van dit resultaat.
        /// </summary>
        public string ModeString
        {
            get
            {
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Mode.ToString().ToLower().Replace('_', ' '));
            }
        }

        /// <summary>
        /// Creëert het resultaat van een gespeelde game door de gebruiker.
        /// </summary>
        /// <param name="time">De datum en tijd waarop de game is gespeeld</param>
        /// <param name="position">De behaalde positie van de gebruiker</param>
        /// <param name="mode">De gespeelde modus</param>
        public Result(string time, int position, Mode mode)
        {
            Time = time;
            Position = position;
            Mode = mode;
        }
    }
}
