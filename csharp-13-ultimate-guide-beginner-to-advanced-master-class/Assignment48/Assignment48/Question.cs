using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment48
{
    internal class Question : IQuestion
    {
        public string QuestionText { get; set; }
        public List<IOption> Options { get; set; }
        public char CorrectAnswerLetter { get; set; }
        public char OptionSelectedByStudent { get; set; }
        public int MarksSecured { get; set; }
    }
}
