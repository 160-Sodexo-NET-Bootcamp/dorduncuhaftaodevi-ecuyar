using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMaker_Data.Randoms
{
    public class RandomWord
    {
        private readonly string[] words = new string[10] { "known", "small", "parallel", "expand", "place", "zoo", "rifle", "placid", "remarkable", "orange" };

        public string GetRandomWord()
        {
            //select a random word from predefined array
            Random r = new();
            int rr = r.Next(words.Length);

            return words[rr];
        }
    }
}
