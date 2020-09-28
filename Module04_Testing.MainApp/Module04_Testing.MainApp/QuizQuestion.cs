using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module04_Testing.MainApp
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool AnsweredCorrectly { get; set; }
        public bool CaseInsensitive { get; set; }

        public void Grade(string userAnswer)
        {
            StringComparison comparer = CaseInsensitive ?
                     StringComparison.InvariantCultureIgnoreCase :
                     StringComparison.InvariantCulture;



            if(string.Equals(userAnswer, Answer, comparer))
            {
                AnsweredCorrectly = true;
            }
            else
            {
                AnsweredCorrectly = false;
            }
        }
    }
}
