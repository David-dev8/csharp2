using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class Question
    {
        public string Content { get; set; }
        public IList<Answer> Possibilities { get; set; }
        public Category Category { get; set; }

        public Question(string question, IList<Answer> possibilities, Category category)
        {
            Content = question;
            Possibilities = possibilities;
            Category = category;
        }
    }
}
