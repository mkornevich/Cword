using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwordCommon
{
    public class Element
    {
        public string word;

        public string question;

        // должен быть уникальным
        public int number;

        public Element(string word, string question, int number)
        {
            this.word = word;
            this.question = question;
            this.number = number;
        }

    }
}
