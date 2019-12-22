using System.Collections.Generic;

namespace Web.Viewmodels.Quiz
{
    public class QuestionVM
    {
        public string Text {get; set;}
        public List<Answer> Answers {get; set;}
        public class Answer {
            public int Id {get; set;}
            public string Text {get; set;}
        }
        public bool isMultiple {get; set;}

        public string currentQuestion {get; set;}
    }
}