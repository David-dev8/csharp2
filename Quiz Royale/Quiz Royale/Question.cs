﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class Question
    {
        public string Content { get; set; }
        public IList<Answer> Possibilities { get; set; }
        public Category Category { get; set; }

        public Question(string content, IList<Answer> possibilities, Category category)
        {
            Content = content;
            Possibilities = possibilities;
            Category = category;
        }
    }
}
