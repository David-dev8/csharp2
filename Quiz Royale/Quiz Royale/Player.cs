using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;

namespace Quiz_Royale
{
    public class Player
    {
        public string Username { get; set; }
        
        public string Title { get; set; }

        public string ProfilePicture { get; set; }

        public string Border { get; set; }

        public double AnswerTime { get; set; }

        public Player(string username, string title, string profilePicture, string border)
        {
            Username = username;
            Title = title;
            ProfilePicture = profilePicture;
            Border = border;
        }
    }
}
